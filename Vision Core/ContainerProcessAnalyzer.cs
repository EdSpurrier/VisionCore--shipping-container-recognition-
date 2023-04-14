using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision_Core
{
    class ContainerProcessAnalyzer
    {

        public MainWindow mainWindow;

        public ConsoleManager console;
        public System.Windows.Forms.ListView container_event_list;
        public System.Windows.Forms.ListView container_event_output_data;


        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_cpa_console, mainWindow.checkBox_cpa_console_autoscroll, mainWindow.button_cpa_clear_console);
            console.maximumRows = 1000;
            console.Log("ContainerProcessAnalyzer() - Module Initiated.");

            container_event_list = mainWindow.listView_cpa_events;
            container_event_output_data = mainWindow.listView_cpa_event_output_data;

            mainWindow.button_cpa_start.Click += new System.EventHandler(StartDatabaseCycle);

            mainWindow.button_cpa_pull.Click += new System.EventHandler(PullFromGUI);
            mainWindow.button_cpa_push.Click += new System.EventHandler(PushToGUI);
        }




        ////////////////////////////
        //  UI
        ////////////////////////////


        public delegate void UpdateContainerEventListUI_CallBack();

        void UpdateContainerEventListUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateContainerEventListUI_CallBack(UpdateContainerEventListUI));
            }
            else
            {
                UpdateContainerEventListUI();
            }
        }

        public void UpdateContainerEventListUI()
        {
            container_event_list.Items.Clear();
            foreach (Parts.EventAlarm event_alarm in processedEventAlarms.ToList())
            {
                container_event_list.Items.Add(new ListViewItem(new string[] {
                    event_alarm.alarm_unique_id.ToString(),
                    event_alarm.related_data,
                    event_alarm.related_unique_id.ToString(),
                    event_alarm.process_status,
                    event_alarm.status,
                    event_alarm.event_datetime.ToString(),
                }));
            };


            container_event_output_data.Items.Clear();

            container_event_output_data.Items.Add(new ListViewItem(new string[] {
                    "Container Id: ",
                    currentContainerChain.container_id,
                }));
            container_event_output_data.Items.Add(new ListViewItem(new string[] {
                    "Relate Unique Id: ",
                    currentContainerChain.container_unique_id.ToString(),
                }));
            container_event_output_data.Items.Add(new ListViewItem(new string[] {
                    "Start Time: ",
                    currentContainerChain.start_datetime.ToString(),
                }));
            container_event_output_data.Items.Add(new ListViewItem(new string[] {
                    "End Time: ",
                    currentContainerChain.stop_datetime.ToString(),
                }));
            container_event_output_data.Items.Add(new ListViewItem(new string[] {
                    "Length (sec): ",
                    Tools.DifferenceInSeconds(currentContainerChain.stop_datetime, currentContainerChain.start_datetime).ToString(),
                }));


        }



        ///////////////////////////////////
        //  DATABASE CYCLE THREAD
        ///////////////////////////////////
        Thread convertThread;
        bool processing = false;
        private static System.Timers.Timer databaseTimer;
        public bool database_active = false;

        public void StartDatabaseCycle(object sender, EventArgs eventarg)
        {
            if (database_active)
            {
                console.Log("Database Cycle Already Active.");
                return;
            };

            database_active = true;
            mainWindow.button_cpa_start.Enabled = false;

            databaseTimer = new System.Timers.Timer();
            databaseTimer.Interval = (int)(mainWindow.numericUpDown_cd_database_cycle_time.Value * 1000);

            console.Log("Starting Database Cycle");

            databaseTimer.Elapsed += (s, e) =>
            {
                CheckDatabaseForEventAlarms(s, e);
            };

            databaseTimer.Start();
        }

        
        public void RestartCycle()
        {
            console.ThreadLog("Restarting Cycle");
            processing = false;
            databaseTimer.Start();
        }

        public void CheckDatabaseForEventAlarms(object sender, EventArgs e)
        {

            databaseTimer.Stop();
            if (!processing)
            {
                processing = true;
                console.ThreadLog("Running Database Thread");
                convertThread = new Thread(delegate () { SearchForContainerEvents_VisionCore(); });
                convertThread.IsBackground = true;
                convertThread.Start();
            }
            else {
                RestartCycle();
            };

            
        }


        ///////////////////////////////////
        //  GUI ONLINE INTERACTIONS
        ///////////////////////////////////
        public void PullFromGUI(object sender, EventArgs eventarg)
        {
            console.Log("Pulling Ready Events From Database Date = " + mainWindow.dateTimePicker_cpa_process_datetime.Value.ToString("yyyy-MM-dd") );

            List<Parts.EventAlarm> eventAlarms = mainWindow.DB.SearchForEventAlarms_WebVisionCore(mainWindow.dateTimePicker_cpa_process_datetime.Value);
            console.ThreadLog("Event Alarms Found = " + eventAlarms.Count.ToString());

            mainWindow.DB.UpdateEventAlarmsFromGUI_VisionCore(eventAlarms);

            console.ThreadLog("Updated Event Alarms Total = " + eventAlarms.Count.ToString());

            mainWindow.DB.DeleteEventAlarms_WebGUI(mainWindow.dateTimePicker_cpa_process_datetime.Value);

            console.ThreadLog("Cleaned VisionCore GUI DB date= " + mainWindow.dateTimePicker_cpa_process_datetime.Value.ToString());
        }

        public void PushToGUI(object sender, EventArgs eventarg)
        {
            console.Log("Pushing Unprocessed Events From Database Date = " + mainWindow.dateTimePicker_cpa_process_datetime.Value.ToString("yyyy-MM-dd") );

            mainWindow.DB.ResetEventAlarms_VisionCore();
            console.ThreadLog("Reset Event Alarms For Processing");

            List<Parts.EventAlarm> eventAlarms = mainWindow.DB.SearchForEventAlarms_VisionCore("Analyzed", 10000, mainWindow.dateTimePicker_cpa_process_datetime.Value, true);
            console.ThreadLog("Event Alarms Found = " + eventAlarms.Count.ToString());

            mainWindow.DB.InsertEventAlarms_WebGUI(eventAlarms);

            console.ThreadLog("Added To WebGUI DB");
        }



        ///////////////////////////////////
        //  CPA SYSTEM
        ///////////////////////////////////
        List<Parts.EventAlarm> processedEventAlarms = new List<Parts.EventAlarm>();
        
        ContainerChain.ChainRecording currentContainerChain = new ContainerChain.ChainRecording();
        public bool first_run = true;


        public void SearchForContainerEvents_VisionCore()
        {
            processedEventAlarms.Clear();
            List<Parts.EventAlarm> actualEventAlarms = new List<Parts.EventAlarm>();
            currentContainerChain = new ContainerChain.ChainRecording();

            if (mainWindow.checkBox_cpa_reprocess.Checked && first_run)
            {
                first_run = false;
                console.ThreadLog("REPROCESSING >> Searching For Processing Event Alarms");
                mainWindow.DB.ResetEventAlarms_VisionCore();
            };

            List<Parts.EventAlarm> eventAlarms = mainWindow.DB.SearchForEventAlarms_VisionCore("Analyzed", 10000, mainWindow.dateTimePicker_cpa_process_datetime.Value, mainWindow.checkBox_cpa_process_date.Checked);


            string currentContainerId = "null";
            string lastContainerId = "null";

            if (eventAlarms.Count <= 0)
            {
                UpdateContainerEventListUI_Thread();
                console.ThreadLog("No Alarm Events In Database");
                RestartCycle();
                return;
            };

            int totalCount = eventAlarms.Count;


            eventAlarms = SortAscendingAlarms(eventAlarms);


            foreach (Parts.EventAlarm eventAlarm in eventAlarms)
            {
                totalCount--;
                console.ThreadLog("Total Count = " + totalCount.ToString());
                currentContainerId = eventAlarm.related_data;

                if (currentContainerId == "Not Found")
                {
                    console.ThreadLog("Container Not Found In Event");
                    continue;
                };

                eventAlarm.related_unique_id = mainWindow.DB.SelectContainerUniqueId_WebGUI(eventAlarm.related_data);

                processedEventAlarms.Add(eventAlarm);

                if (lastContainerId == "null")
                {
                    lastContainerId = eventAlarm.related_data;

                };

                if (lastContainerId == currentContainerId)
                {
                    console.ThreadLog(lastContainerId + " == " + currentContainerId);
                    actualEventAlarms.Add(eventAlarm);

                }
                else if (lastContainerId != currentContainerId)
                {
                    console.ThreadLog("Break Search. [" + lastContainerId + " != " + currentContainerId + "]");
                    GetEarliestDate_Thread( actualEventAlarms.ToList() );
                    break;
                };

                lastContainerId = currentContainerId;


                if (totalCount <= 0) 
                {
                    console.ThreadLog("Container Chain Process Is Not Complete [There Needs To Be Another Container Id To Break The Chain]");
                    RestartCycle();

                }
            };


            UpdateContainerEventListUI_Thread();
            


        }


        public List<Parts.EventAlarm> ReorderEventAlarms(List<Parts.EventAlarm> eventAlarms)
        {
            List<Parts.EventAlarm> reordered_eventAlarms = new List<Parts.EventAlarm>();


            List<DateTime> dateTimes = new List<DateTime>();

            List<DateTime> dateTimes_ordered = new List<DateTime>();

            foreach (Parts.EventAlarm eventAlarm in eventAlarms)
            {
                dateTimes.Add(eventAlarm.event_datetime);
            };


            reordered_eventAlarms = SortDescendingAlarms(eventAlarms);
            //reordered_eventAlarms = SortAscendingAlarms(eventAlarms);

            dateTimes_ordered = SortDescending( dateTimes );

            //int row_number = 0;
            //foreach (DateTime dateTime in dateTimes_ordered)
            //{
            //    console.ThreadLog( "Row[" + row_number.ToString() + "]=" + dateTime.ToString() + " >> " + dateTimes[row_number].ToString());
            //    row_number++;
            //};


            int row_number = 0;

            foreach (Parts.EventAlarm eventAlarm in eventAlarms)
            {
                console.ThreadLog("Row[" + row_number.ToString() + "]=" + eventAlarm.event_datetime.ToString() + " >> " + reordered_eventAlarms[row_number].event_datetime.ToString());
                row_number++;
            };



            return reordered_eventAlarms;
        }


        List<DateTime> SortDescending(List<DateTime> list)
        {
            List<DateTime> thisList = list.ToList();

            thisList.Sort((a, b) => b.CompareTo(a));
            return thisList;
        }
        List<DateTime> SortAscending(List<DateTime> list)
        {
            List<DateTime> thisList = list.ToList();
            thisList.Sort((a, b) => a.CompareTo(b));
            return thisList;
        }

        
        List<Parts.EventAlarm> SortAscendingAlarms(List<Parts.EventAlarm> list)
        {
            List<Parts.EventAlarm> thisList = list.ToList();

            thisList.Sort((b, a) => b.event_datetime.CompareTo(a.event_datetime));
            return thisList;
        }

        List<Parts.EventAlarm> SortDescendingAlarms(List<Parts.EventAlarm> list)
        {
            List<Parts.EventAlarm> thisList = list.ToList();

            thisList.Sort((a, b) => b.event_datetime.CompareTo(a.event_datetime));
            return thisList;
        }



        public void GetEarliestDate(List<Parts.EventAlarm> eventAlarms)
        {
            Parts.EventAlarm earliest = eventAlarms[0];
            Parts.EventAlarm latest = eventAlarms[0];

            foreach (Parts.EventAlarm eventAlarm in eventAlarms)
            {
                int result = DateTime.Compare(earliest.event_datetime, eventAlarm.event_datetime);
                string relationship;

                if (result < 0)
                {
                    relationship = "is earlier than";
                    latest = eventAlarm;
                }
                else if (result == 0)
                {
                    relationship = "is the same time as";
                }
                else
                {
                    relationship = "is later than";
                    earliest = eventAlarm;
                };

                //string output = earliest.event_datetime + " " + relationship + " " + eventAlarm.event_datetime;
                //console.ThreadLog(output);

            }


            

            if (mainWindow.textBox_cpa_owner.Text != "")
            {
                
                console.ThreadLog("Processing Owner Match [" + earliest.owner + " >><< " + mainWindow.textBox_cpa_owner.Text + "]");
                if (earliest.owner.ToUpper() != mainWindow.textBox_cpa_owner.Text.ToUpper())
                {
                    console.ThreadLog("Owner Does Not Match [" + earliest.owner + "!=" + mainWindow.textBox_cpa_owner.Text + "]");
                    mainWindow.DB.UpdateEventAlarms_VisionCore(eventAlarms, "Processing");
                    RestartCycle();
                    return;
                };

            }
            else {
                console.ThreadLog("NOT Processing Owner Match");
            };
            

            mainWindow.CC.SetStartTime(earliest.event_datetime);

            if (mainWindow.checkBox_cpa_last_event_at_next_container.Checked)
            {
                latest.event_datetime = processedEventAlarms[(processedEventAlarms.Count - 1)].event_datetime;
            };


            console.ThreadLog("Timespan: " + Tools.TimeSpanInMinutes(earliest.event_datetime, latest.event_datetime).ToString() );
            if ( Tools.TimeSpanInMinutes(earliest.event_datetime, latest.event_datetime) > 60 || Tools.TimeSpanInMinutes(earliest.event_datetime, latest.event_datetime) < -60)
            {
                latest.event_datetime = earliest.event_datetime.AddMinutes(60);
                console.ThreadLog("Timespan [TOO LONG RECORRECTING TO 60mins]: " + Tools.TimeSpanInMinutes(earliest.event_datetime, latest.event_datetime).ToString());
            };

            console.ThreadLog("Earliest: " + earliest.event_datetime + " >> Latest: " + latest.event_datetime);

         

            mainWindow.CC.SetStopTime(latest.event_datetime);

            
            mainWindow.CC.SetContainerNumber(earliest.related_data);
            mainWindow.CC.SetContainerUniqueId(earliest.related_unique_id);

            currentContainerChain = mainWindow.CC.StartContainerChain(eventAlarms);
            UpdateContainerEventListUI_Thread();


            console.ThreadLog("IMPORTANT >>> THIS IS CHANGING IT TO PROCESSED NOW! [NEED TO WORK OUT CORRECT WAY TO CONTROL THIS]");
            mainWindow.DB.UpdateEventAlarms_VisionCore(eventAlarms, "Processing");


            RestartCycle();
        }



        public delegate void GetEarliestDate_CallBack(List<Parts.EventAlarm> eventAlarms);

        void GetEarliestDate_Thread(List<Parts.EventAlarm> eventAlarms)
        {
            console.ThreadLog("Setting & Starting Container Chain");

            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new GetEarliestDate_CallBack(GetEarliestDate), eventAlarms);
            }
            else
            {
                GetEarliestDate(eventAlarms);
            }
        }





    }
}
