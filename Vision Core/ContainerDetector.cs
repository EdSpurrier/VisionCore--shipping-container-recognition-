using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace Vision_Core
{
    public class ContainerDetector
    {

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class Detection
        {
            public int unique_id;
            public int parent_unique_id;
            public int container_unique_id = -1;
            public string container_id;
            public int confidence = 0;
            public string process_status = "unprocessed";
            public DateTime event_datetime;
            public DateTime start_datetime;
            public DateTime stop_datetime;
            public int recording_time;
            public Parts.VideoFile videoFile;
            public string status;
        }


        /////////////////////////////////
        /// SYSTEM > [START]
        /////////////////////////////////

        public MainWindow mainWindow;
        public System.Windows.Forms.ListView event_list;
        public System.Windows.Forms.TextBox recording_timer;
        public System.Windows.Forms.NumericUpDown recording_channel;
        public ConsoleManager console;

        public List<Detection> detections = new List<Detection>();

        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            event_list = mainWindow.listView_cd_queue;
            recording_timer = mainWindow.textBox_cd_recording_timer;
            recording_channel = mainWindow.numericUpDown_cd_recording_channel;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_cd_console, mainWindow.checkBox_cd_console_autoscroll, mainWindow.button_cd_clear_console);
            console.Log("ContainerDetector() - Module Initiated.");

            mainWindow.button_cd_event_trigger.Click += new System.EventHandler(TriggerEvent_Button);
            mainWindow.button_cd_search_events.Click += new System.EventHandler(SearchEvents);
            mainWindow.button_cd_start.Click += new System.EventHandler(StartDatabaseCycle);


        }



        /////////////////////////////////
        /// UI > [START]
        /////////////////////////////////

        public void UpdateContainerEventsUI()
        {

            event_list.Items.Clear();
            foreach (Detection detection in detections.ToList())
            {
                if (detection.videoFile.keyFrames == null)
                {
                    detection.videoFile.keyFrames = new List<Parts.KeyFrameImage>();
                };

                event_list.Items.Add(new ListViewItem(new string[] {
                    detection.unique_id.ToString(),
                    detection.parent_unique_id.ToString(),
                    detection.status,
                    detection.container_unique_id.ToString(),
                    detection.container_id,
                    detection.event_datetime.ToString(),
                    detection.start_datetime.ToString(),
                    detection.stop_datetime.ToString(),
                    detection.videoFile.file_name.ToString(),
                    detection.videoFile.downloaded.ToString() + "/100",
                    detection.videoFile.keyFrames.Count.ToString(),
                }));
            };
        }



        public void UpdateContainerEventsUI_Update()
        {

            int listItemNumber = 0;
            foreach (Detection detection in detections.ToList())
            {
                event_list.Items[listItemNumber].SubItems[2].Text = detection.status;
                event_list.Items[listItemNumber].SubItems[4].Text = detection.container_id;
                event_list.Items[listItemNumber].SubItems[8].Text = detection.videoFile.file_name.ToString();
                event_list.Items[listItemNumber].SubItems[9].Text = detection.videoFile.downloaded.ToString() + "/100";
                event_list.Items[listItemNumber].SubItems[10].Text = detection.videoFile.keyFrames.Count.ToString();

                listItemNumber++;
            };
        }



        public delegate void UpdateContainerEventsUI_CallBack();

        void UpdateContainerEventsUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateContainerEventsUI_CallBack(UpdateContainerEventsUI));
            }
            else
            {
                UpdateContainerEventsUI();
            }
        }




        public delegate void UpdateContainerEventsUI_Update_CallBack();

        void UpdateContainerEventsUI_Update_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateContainerEventsUI_Update_CallBack(UpdateContainerEventsUI_Update));
            }
            else
            {
                UpdateContainerEventsUI_Update();
            }
        }




        void UpdateRecordingUI(string recordingTime)
        {
            recording_timer.Text = recordingTime;

        }

        public delegate void UpdateRecordingUI_CallBack(string recordingTime);

        void UpdateUI_Thread(string recordingTime)
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateRecordingUI_CallBack(UpdateRecordingUI), recordingTime);
            }
            else
            {
                UpdateRecordingUI(recordingTime);
            }
        }




        /////////////////////////////////
        /// EVENTS
        /////////////////////////////////




        public void TriggerEvent_Button(object sender, EventArgs e)
        {


            TriggerContainerDetector();

        }

        public void TriggerContainerDetector()
        {
            TriggerEvent(DateTime.Now);
        }


        public void TriggerEvent(DateTime datetime, int unique_id = -1)
        {

            if (mainWindow.HVS.userID < 0)
            {
                console.Log("Not Connected To Server");
                return;
            };

            console.Log("Event Triggered!");

            Detection newDetection = new Detection();
            newDetection.event_datetime = datetime;

            newDetection.start_datetime = newDetection.event_datetime.AddSeconds((int)-mainWindow.numericUpDown_cd_preroll.Value);
            newDetection.stop_datetime = newDetection.event_datetime.AddSeconds((int)mainWindow.numericUpDown_cd_recording_time.Value);
            newDetection.recording_time = (int)mainWindow.numericUpDown_cd_recording_time.Value;


            //newDetection.start_datetime = Convert.ToDateTime(mainWindow.textBox_container_chain_start_time.Text);
            //newDetection.stop_datetime = Convert.ToDateTime(mainWindow.textBox_container_chain_stop_time.Text);
            //newDetection.recording_time = 30;


            newDetection.container_id = "None";
            newDetection.status = "Created";
            newDetection.unique_id = unique_id;

            newDetection.videoFile = new Parts.VideoFile();

            newDetection.videoFile.keyFrames = new List<Parts.KeyFrameImage>();

            newDetection.videoFile.file_name = "Not Set";
            newDetection.parent_unique_id = -1;


            foreach (Detection detection in detections)
            {

                if (Tools.IsCurrentDateBetween(newDetection.event_datetime, detection.start_datetime, detection.stop_datetime))
                {
                    console.Log("Event is within Time [parent=" + detection.unique_id.ToString() + " child=" + newDetection.unique_id.ToString() + "]");
                    //newDetection.parent_unique_id = detection.unique_id;
                    //detection.stop_datetime = newDetection.stop_datetime;
                    //newDetection.status = "Parented";
                    break;
                };
            }


            detections.Add(newDetection);

            UpdateContainerEventsUI();

            if (newDetection.status != "Parented")
            {
                ExtractRecording_Thread(GetCurrentDetection());
            }

        }

        public void SearchEvents(object sender, EventArgs e)
        {
            List<Detection> valid_detections = new List<Detection>();

            string current_container = "None";

            foreach (Detection detection in detections)
            {
                if (detection.status == "Container Found")
                {
                    if (detection.container_id != "None")
                    {
                        console.Log("Found VALID Container Id = " + detection.container_id);
                        if (current_container != "None")
                        {
                            if (current_container == detection.container_id)
                            {
                                valid_detections.Add(detection);
                            };
                        }
                        else {
                            valid_detections.Add(detection);
                        };
                        
                    }
                    else
                    {
                        console.Log("No Valid Container Id in detection");
                    };
                };
            };

            console.Log("Valid Detections Found = " + valid_detections.Count.ToString());


            if (valid_detections.Count > 1)
            {

                foreach (Detection detection in detections)
                {
                    Parts.KeyFrameImage keyframe = GetFrameWithDetectedContainer(detection.videoFile);

                    mainWindow.CC.SetContainerNumber(GetDetectedContainerNumber(detection.videoFile));

                    mainWindow.CC.SetStartTime(GetDateTimeOfDetectedContainer(detection.videoFile));

                    console.Log(
                            "FOUND A CONTAINER NUMBER == " +
                            GetDetectedContainerNumber(detection.videoFile) +
                            "\n GET START TIME == " +
                            GetDateTimeOfDetectedContainer(detection.videoFile)
                        );
                };
   
            };


        }







        /////////////////////////////////
        /// RECORDING
        /////////////////////////////////
        
        public bool recording = false;
        public int recordingTime = 0;

        private static System.Timers.Timer recordingTimer;

        public DateTime endTimeRecording;

        public void RecordingTime(Detection detection)
        {
            endTimeRecording = detection.stop_datetime;


            TimeSpan clipLength = (endTimeRecording - DateTime.Now);
            int numberOfSeconds = clipLength.Seconds;
            recordingTime = numberOfSeconds + (int)mainWindow.numericUpDown_settings_record_lag.Value;


            if (recording)
            {
                console.Log("Recording >> Cannot Record [Updated=" + recordingTime + "s]");

                return;
            };

            

            recording = true;
            StartTimer();
        }



        public void StartTimer()
        {
            recordingTimer = new System.Timers.Timer();
            recordingTimer.Interval = 1000;
            recordingTimer.Elapsed += (s, e) =>
            {
                recordingTimer_Tick(s, e);
            };
            recordingTimer.Start();
            console.Log("Recording Timer Started >> " + recordingTime + "s]");
        }



        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan clipLength = (endTimeRecording - DateTime.Now);
            int numberOfSeconds = clipLength.Seconds;
            recordingTime = numberOfSeconds + (int)mainWindow.numericUpDown_settings_record_lag.Value;


            if (recordingTime > 0)
            {
                UpdateUI_Thread(recordingTime + " seconds");
            }
            else
            {
                recordingTimer.Stop();
                UpdateUI_Thread("Finished");
                recording = false;

                ExtractRecording_Thread(GetCurrentDetection());
            }
        }









        /////////////////////////////////
        /// ACTIONS PROCESS > [START]
        /////////////////////////////////

        public void DownloadProcessCompleted(Detection detection)
        {
            console.Log("Completed Download Process");
            mainWindow.IE.AddToExtractorQueue(detection.videoFile);
        }

        public void ConvertProcessCompleted(Detection detection)
        {
            console.Log("Completed Convert Process");

        }

        public void UploadProcessCompleted(Detection detection)
        {
            console.Log("Completed Upload Process");


        }
        /////////////////////////////////
        /// ACTIONS POST-PROCESS > [START]
        /////////////////////////////////






        /////////////////////////////////
        /// ACTIONS
        /////////////////////////////////

        int max_active_detections = 30;
     

        public void CleanUpDetectionList()
        {

            foreach (Detection detection in detections)
            {
                if (detection.process_status != "Analyzed")
                {
                    return;
                };
            };

            console.ThreadLog("Cleaning Detection List = Count > " + max_active_detections.ToString() + " >> " + detections.Count.ToString());

            List<Detection> detectionsToRemove = new List<Detection>();

            int countToRemove = detections.Count - max_active_detections;


            foreach (Detection detection in detections)
            {


                if (countToRemove <= 0)
                {
                    break;
                };

                if (detection.process_status == "Analyzed")
                {
                    detectionsToRemove.Add(detection);
                };

                countToRemove++;
            };

            foreach (Detection detectionToRemove in detectionsToRemove)
            {
                detections.Remove(detectionToRemove);
            };

        }

        public Detection GetCurrentDetection()
        {
            Detection currentDetection = new Detection();

            foreach (Detection detection in detections)
            {
                if (detection.status == "Created")
                {
                    if (detection.parent_unique_id == -1)
                    {
                        currentDetection = detection;
                    };
                };
            };

            return currentDetection;
        }


        public int GetContainerDetectionIndex(int unique_id)
        {
            int index = -1;
            int thisIndex = 0;
            foreach (Detection detection in detections)
            {
                if (detection.unique_id == unique_id)
                {
                    index = thisIndex;
                    break;
                };
                thisIndex++;
            }

            return index;
        }



        public Detection GetContainerDetectionVideofile(Parts.VideoFile videoFile)
        {
            int index = -1;
            int thisIndex = 0;
            foreach (Detection detection in detections)
            {
                if (detection.unique_id == videoFile.relation_data.unique_id)
                {
                    index = thisIndex;
                    break;
                };
                thisIndex++;
            }
             
            return detections[thisIndex];
        }




        public delegate void ExtractRecording_CallBack(Detection dectection);

        void ExtractRecording_Thread(Detection dectection)
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new ExtractRecording_CallBack(ExtractRecording), dectection);
            }
            else
            {
                ExtractRecording(dectection);
            }
        }





        public void ExtractRecording(Detection dectection)
        {

            if (mainWindow.HVS.userID < 0)
            {
                console.ThreadLog("Not Connected To Server");
                return;
            };

            dectection.status = "Processing";


            console.ThreadLog("Extracting = Container Detector Recording -- " + dectection.start_datetime.ToString() + " >> " + dectection.stop_datetime.ToString());

            int channel = (int)recording_channel.Value;


            dectection.videoFile = SetTimeframeDownload(dectection);



            UpdateContainerEventsUI_Thread();

            mainWindow.DL.AddToDownloadQueue(dectection.videoFile);

        }



        public Parts.VideoFile SetTimeframeDownload(Detection dectection)
        {

            Parts.VideoFile videoFile = new Parts.VideoFile();

            Parts.RelationData relation_data = new Parts.RelationData();
            relation_data.unique_id = dectection.unique_id;
            relation_data.type = "Container_Detector";
            relation_data.callback_complete = new VideoFileCallBack(mainWindow.CD.CallBack_Complete);
            relation_data.callback_downloaded = new VideoFileCallBack(mainWindow.CD.CallBack_Downloaded);
            relation_data.callback_converted = new VideoFileCallBack(mainWindow.CD.CallBack_Converted);
            relation_data.callback_uploaded = new VideoFileCallBack(mainWindow.CD.CallBack_Uploaded);
            relation_data.callback_update = new VideoFileAndStatusCallBack(mainWindow.CD.CallBack_Update);
            relation_data.callback_extracted = new VideoFileAndStatusCallBack(mainWindow.CD.CallBack_Extracted);
            relation_data.callback_vision = new VideoFileAndStatusCallBack(mainWindow.CD.CallBack_Vision);



            videoFile.file_name = "Not Set";
            videoFile.start_datetime = dectection.start_datetime;
            videoFile.end_datetime = dectection.stop_datetime;
            videoFile.channel_number = (int)recording_channel.Value;

            videoFile.relation_data = relation_data;

            videoFile.status = "file found";
            videoFile.converted = false;
            videoFile.uploaded = 0;
            videoFile.ftp_sub_directory = mainWindow.textBox_cc_ftp_sub_dir.Text;
            videoFile.downloadType = Parts.VideoFileDownloadType.Timeframe;

            return videoFile;
        }



        public string GetDetectedContainerNumber(Parts.VideoFile videoFile)
        {
            string container_number = "Not Found";

            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {
                    if (text_found.valid)
                    {
                        container_number = text_found.text;
                    }
                }
            }

            return container_number;

        }


        public int GetDetectedContainerConfidence(Parts.VideoFile videoFile)
        {
            int confidence = 0;

            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {
                    if (text_found.valid)
                    {
                        confidence = text_found.confidence;
                    }
                }
            }

            return confidence;
        }



        public Parts.KeyFrameImage GetFrameWithDetectedContainer(Parts.VideoFile videoFile)
        {
            Parts.KeyFrameImage container_keyframe = null;

            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {
                    if (text_found.valid)
                    {
                        container_keyframe = keyFrame;
                    }
                }
            }

            return container_keyframe;

        }



        public DateTime GetDateTimeOfDetectedContainer(Parts.VideoFile videoFile)
        {
            int keyframe_number = 0;
            DateTime returnDateTime = videoFile.start_datetime;


            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                foreach (Parts.TextFound text_found in keyFrame.text_found)
                {
                    if (text_found.valid)
                    {
                        console.Log( "Break Seconds >> " + keyframe_number.ToString()  + " [DATETIME >> " + returnDateTime.ToString() + " = " + returnDateTime.AddSeconds(keyframe_number).ToString() );
                        break;
                    };
                    
                };
                keyframe_number++;
            };

            return returnDateTime.AddSeconds( keyframe_number );
    }


        /////////////////////////////////
        /// CALLBACKS > [START]
        /////////////////////////////////

        public void CallBack_Complete(Parts.VideoFile videoFile)
        {
            console.Log("Process Completed");
        }



        public delegate void CallBack_Vision_CallBack(Parts.VideoFile videoFile, string status);



        public void CallBack_Vision(Parts.VideoFile videoFile, string status)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[2];

                paras[0] = videoFile;
                paras[1] = status;


                mainWindow.BeginInvoke(new CallBack_Vision_CallBack(Thread_CallBack_Vision), paras);
            }
            else
            {
                Thread_CallBack_Vision(videoFile, status);
            };
        }

        public void Thread_CallBack_Vision(Parts.VideoFile videoFile, string status)
        {
            console.Log("Vision Callback");

            int containerDetectionIndex = GetContainerDetectionIndex(videoFile.relation_data.unique_id);
            GetContainerDetectionVideofile(videoFile).status = status;


            detections[containerDetectionIndex].container_id = GetDetectedContainerNumber(videoFile);
            detections[containerDetectionIndex].confidence = GetDetectedContainerConfidence(videoFile);
            

            if (detections[containerDetectionIndex].container_id == "Not Found")
            {
                detections[containerDetectionIndex].status = "Container Not Found";
            }
            else {
                console.Log(
                    "FOUND A CONTAINER NUMBER == " +
                    GetDetectedContainerNumber(videoFile) +
                    " >> GET START TIME == " +
                    GetDateTimeOfDetectedContainer(videoFile)
                );

                detections[containerDetectionIndex].status = "Container Found";

                detections[containerDetectionIndex].container_unique_id = mainWindow.DB.SelectContainerUniqueId_WebGUI( detections[containerDetectionIndex].container_id );
            };


            detections[containerDetectionIndex].process_status = "Analyzed";


            


            UpdateEventAlarmInDatabase( GetContainerDetectionVideofile(videoFile) );

            UpdateContainerEventsUI_Update_Thread();

            Tools.CleanUpVideoFile(videoFile);


        }




        public delegate void CallBack_Converted_CallBack(Parts.VideoFile videoFile);



        public void CallBack_Converted(Parts.VideoFile videoFile)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[1];

                paras[0] = videoFile;

                mainWindow.BeginInvoke(new CallBack_Converted_CallBack(Thread_CallBack_Converted), paras);
            }
            else
            {
                Thread_CallBack_Converted(videoFile);
            };
        }

        public void Thread_CallBack_Converted(Parts.VideoFile videoFile)
        {

            console.Log("Converted Callback = NOT CONNECTED");
        }




        public delegate void CallBack_Extracted_CallBack(Parts.VideoFile videoFile, string status);

        public void CallBack_Extracted(Parts.VideoFile videoFile, string status)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[2];

                paras[0] = videoFile;
                paras[1] = status;

                mainWindow.BeginInvoke(new CallBack_Extracted_CallBack(Thread_CallBack_Extracted), paras);
            }
            else
            {
                Thread_CallBack_Extracted(videoFile, status);
            };
        }




        public void Thread_CallBack_Extracted(Parts.VideoFile videoFile, string status)
        {
            //console.Log("Extracted Callback");

            GetContainerDetectionVideofile(videoFile).status = status;

            int containerDetectionIndex = GetContainerDetectionIndex(videoFile.relation_data.unique_id);

            detections[containerDetectionIndex].status = "Analyzing Keyframes";

            mainWindow.VA.AddToVisionQueue(videoFile);

            UpdateContainerEventsUI_Update_Thread();
        }









        public delegate void CallBack_Uploaded_CallBack(Parts.VideoFile videoFile);



        public void CallBack_Uploaded(Parts.VideoFile videoFile)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[1];

                paras[0] = videoFile;

                mainWindow.BeginInvoke(new CallBack_Uploaded_CallBack(Thread_CallBack_Uploaded), paras);
            }
            else
            {
                Thread_CallBack_Uploaded(videoFile);
            };
        }




        public void Thread_CallBack_Uploaded(Parts.VideoFile videoFile)
        {
            console.Log("Uploaded Callback = NOT CONNECTED");
        }





        public void CallBack_Downloaded(Parts.VideoFile videoFile)
        {

            //console.ThreadLog("Downloaded Callback");


            int containerDetectionIndex = GetContainerDetectionIndex(videoFile.relation_data.unique_id);
            

            if (detections[containerDetectionIndex].videoFile.downloaded == 100)
            { 
                detections[containerDetectionIndex].status = "Downloaded";
                console.Log("Download Complete");
                DownloadProcessCompleted(detections[containerDetectionIndex]);
            };

            UpdateContainerEventsUI_Update_Thread();

        }





        public delegate void CallBack_Update_CallBack(Parts.VideoFile videoFile, string status);


        public void CallBack_Update(Parts.VideoFile videoFile, string status)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[2];

                paras[0] = videoFile;
                paras[1] = status;

                mainWindow.BeginInvoke(new CallBack_Update_CallBack(Thread_CallBack_Update), paras);
            }
            else
            {
                Thread_CallBack_Update(videoFile, status);
            };
        }



        public void Thread_CallBack_Update(Parts.VideoFile videoFile, string status)
        {
            //console.ThreadLog("Update Callback");

            GetContainerDetectionVideofile(videoFile).status = status;

            UpdateContainerEventsUI_Update_Thread();
        }






        ///////////////////////////////////
        //  DATABASE UPDATE STATUS & RELATION U ID OF DETECTION / EVENT ALARM
        ///////////////////////////////////

        public void UpdateEventAlarmInDatabase(Detection detection)
        {
            console.ThreadLog("Updating Event Alarm With New Thread");
            Thread convertThread = new Thread(delegate () { UpdateEventAlarm_VisionCore(detection); });
            convertThread.IsBackground = true;
            convertThread.Start();
        }

        public void UpdateEventAlarm_VisionCore(Detection detection)
        {

            console.ThreadLog("Updated Event Alarm In Database [u_id=" + detection.unique_id.ToString() + "] = " + mainWindow.DB.UpdateAllEventAlarm_VisionCore(detection).ToString() );

            Thread_CallBack_Update(detection.videoFile, detection.status + " [Database Updated]");
        }





        ///////////////////////////////////
        //  DATABASE CYCLE THREAD
        ///////////////////////////////////


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
            mainWindow.button_cd_start.Enabled = false;

            databaseTimer = new System.Timers.Timer();
            databaseTimer.Interval = (int)(mainWindow.numericUpDown_cd_database_cycle_time.Value * 1000);

            console.Log("Starting Database Cycle");

            databaseTimer.Elapsed += (s, e) =>
            {
                CheckDatabaseForEventAlarms(s, e);
            };
            databaseTimer.Start();

        }


        public void CheckDatabaseForEventAlarms(object sender, EventArgs e)
        {
            databaseTimer.Stop();
            //console.ThreadLog("Running Database Thread");
            Thread convertThread = new Thread(delegate () { SearchForEventAlarms_VisionCore(); });
            convertThread.IsBackground = true;
            convertThread.Start();
        }





        public void SearchForEventAlarms_VisionCore()
        {
            CleanUpDetectionList();


            if (detections.Count > max_active_detections)
            {
                console.ThreadLog("Maximum Active Detections Reached - Waiting for them to process...");
                databaseTimer.Start();
                return;
            };

            List<Parts.EventAlarm> eventAlarms = mainWindow.DB.SearchForAllEventAlarms_VisionCore("Unprocessed", 10, mainWindow.dateTimePicker_cd_process_datetime.Value, mainWindow.checkBox_cd_process_date.Checked);

            //console.ThreadLog("Event Alarms Found = " + eventAlarms.Count.ToString() );

            mainWindow.BeginInvoke(new TriggerEventList_CallBack(TriggerEventList), eventAlarms);
        }

        public delegate void TriggerEventList_CallBack(List<Parts.EventAlarm> eventAlarms);
        public void TriggerEventList(List<Parts.EventAlarm> eventAlarms)
        {
            
            foreach (Parts.EventAlarm event_alarm in eventAlarms)
            {
                bool already_added = false;

                foreach (Detection detection in detections)
                {
                    if (detection.unique_id == event_alarm.alarm_unique_id)
                    {
                        already_added = true;
                    };
                };

                if (!already_added)
                {
                    TriggerEvent(event_alarm.event_datetime, event_alarm.alarm_unique_id);
                };
            };

            databaseTimer.Start();

        }
        





    }

}
