using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision_Core
{
    class EventManager
    {

        public MainWindow mainWindow;

        public ConsoleManager console;

        public Parts.EventSystem event_cd;
        public System.Windows.Forms.ListView event_alarm_list;

        public int max_alarm_queue = 20;


        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_em_console, mainWindow.checkBox_em_console_autoscroll, mainWindow.button_em_clear_console);
            console.maximumRows = 1000;
            console.Log("EventManager() - Module Initiated.");

            event_alarm_list = mainWindow.listView_event_alarm;

            SetupEventTypes();

            mainWindow.button_em_arm_cd.Click += new System.EventHandler(Arm_ContainerDetector);
            
        }

        public void SetupEventTypes()
        {
            event_cd = new Parts.EventSystem();
            event_cd.name = "Container Detector";
            event_cd.channel = (int)mainWindow.numericUpDown_em_channel_cd.Value;
            event_cd.type = mainWindow.comboBox_em_type_cd.Text;
            event_cd.debounce_time = (int)mainWindow.numericUpDown_em_trigger_buffer_cd.Value * 1000;
        }

        public void Arm_ContainerDetector(object sender, EventArgs e)
        {


            console.Log("Arming Container Detector");
            console.Log("Channel = " + event_cd.channel.ToString() );
            console.Log("Type = " + event_cd.type.ToString());
            mainWindow.button_em_arm_cd.Enabled = false;
            mainWindow.numericUpDown_em_channel_cd.Enabled = false;
            mainWindow.comboBox_em_type_cd.Enabled = false;
            mainWindow.numericUpDown_em_trigger_buffer_cd.Enabled = false;

            Arm();
        }



        ////////////////////////////
        //  UI
        ////////////////////////////

        public delegate void UpdateEventUI_Update_CallBack();

        void UpdateEventUI_Update_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateEventUI_Update_CallBack(UpdateEventUI_Update));
            }
            else
            {
                UpdateEventUI_Update();
            }
        }


        public void UpdateEventUI_Update()
        {
            mainWindow.textBox_em_debounce_countdown_cd.Text = (event_cd.current_countdown_cycle / 1000).ToString() + "s (debounce)";
            //UpdateEventAlarmListUI();
        }



        public delegate void UpdateEventAlarmListUI_CallBack();

        void UpdateEventAlarmListUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateEventAlarmListUI_CallBack(UpdateEventAlarmListUI));
            }
            else
            {
                UpdateEventAlarmListUI();
            }
        }

        public void UpdateEventAlarmListUI()
        {
            event_alarm_list.Items.Clear();
            foreach (Parts.EventAlarm event_alarm in eventAlarms.ToList())
            {
                event_alarm_list.Items.Add(new ListViewItem(new string[] {
                    event_alarm.alarm_unique_id.ToString(),
                    event_alarm.event_name,
                    event_alarm.event_type,
                    event_alarm.status,
                    event_alarm.related_unique_id.ToString(),
                    event_alarm.event_datetime.ToString(),
                    event_alarm.debounce_time.ToString(),
                }));
            };
        }




        ////////////////////////////
        //  DEBOUNCE TIMER
        ////////////////////////////
        public bool DebounceEvent(Parts.EventSystem event_system)
        {
            if (event_system.triggered)
            {
                //console.ThreadLog("Debouncing Event");
                return true;
            } else {
                StartDebounceTimer(event_system);
                event_system.triggered = true;
                //console.ThreadLog("Triggering Event");
                return false;
            }
             
        }

        public void StartDebounceTimer(Parts.EventSystem event_system)
        {
            event_system.debounceTimer = new System.Timers.Timer();
            event_system.debounceTimer.Interval = 1000;

            event_system.current_countdown_cycle = event_system.debounce_time;

            //console.ThreadLog("Starting Count Down Timer");

            event_system.debounceTimer.Elapsed += (s, e) =>
            {
                DebounceCountdown_Tick(s, e, event_system);
            };
            event_system.debounceTimer.Start();
        }

        public void DebounceCountdown_Tick(object sender, EventArgs e, Parts.EventSystem event_system)
        {
            event_system.current_countdown_cycle -= 1000;
            UpdateEventUI_Update_Thread();

            //console.ThreadLog("Timer Count Down");

            if (event_system.current_countdown_cycle <= 0)
            {

                event_system.current_countdown_cycle = 0;
                event_system.debounceTimer.Stop();
                event_system.triggered = false;

            };

            //console.ThreadLog("Timer Count Down = " + event_system.current_countdown_cycle.ToString() + "s");
        }



        public delegate void  TriggerEvent_CallBack();

        void TriggerEvent_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new TriggerEvent_CallBack(TriggerEvent));
            }
            else
            {
                TriggerEvent();
            }
        }


        public void TriggerEvent()
        {
            mainWindow.CD.TriggerContainerDetector();
        }


        ////////////////////////////
        //  HIKVISION ARM
        ////////////////////////////

        //  ARMING
        private CHCNetSDK.MSGCallBack_V31 m_falarmData_V31 = null;
        //private CHCNetSDK.MSGCallBack m_falarmData = null;
        private Int32[] m_lAlarmHandle = new Int32[200];


        CHCNetSDK.NET_VCA_TRAVERSE_PLANE m_struTraversePlane = new CHCNetSDK.NET_VCA_TRAVERSE_PLANE();
        CHCNetSDK.NET_VCA_AREA m_struVcaArea = new CHCNetSDK.NET_VCA_AREA();
        CHCNetSDK.NET_VCA_INTRUSION m_struIntrusion = new CHCNetSDK.NET_VCA_INTRUSION();
        //CHCNetSDK.UNION_STATFRAME m_struStatFrame = new CHCNetSDK.UNION_STATFRAME();
        //CHCNetSDK.UNION_STATTIME m_struStatTime = new CHCNetSDK.UNION_STATTIME();


        public void Arm()
        {
            console.Log("Arming Server");
            if (mainWindow.HVS.userID < 0)
            {
                console.Log("ERROR >> Failed To Arm -- Not Connected");
                ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "Failed to Arm");
                return;
            }

            //设置报警回调函数
            if (m_falarmData_V31 == null)
            {
                m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
            }
            CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);


            CHCNetSDK.NET_DVR_SETUPALARM_PARAM struAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();
            struAlarmParam.dwSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(struAlarmParam);
            struAlarmParam.byLevel = 1; //0- 一级布防,1- 二级布防
            struAlarmParam.byAlarmInfoType = 1;//智能交通设备有效，新报警信息类型
            //struAlarmParam.byFaceAlarmDetection = 1;//1-人脸侦测

            m_lAlarmHandle[mainWindow.HVS.userID] = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(mainWindow.HVS.userID, ref struAlarmParam);
            if (m_lAlarmHandle[mainWindow.HVS.userID] < 0)
            {
                mainWindow.core.systemStatus = "ERROR >> Failed To Arm";
                mainWindow.core.systemError = true;
                ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "Failed to Arm");
            }
            else
            {
                console.Log("Server Armed Successfully");
                mainWindow.core.systemStatus = "System Armed";
                mainWindow.core.deviceServerIP = mainWindow.textBox_server_ip.Text;
                mainWindow.core.systemError = false;
                armed = true;
            }
        }



        public bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //WriteToConsole("Hello i am alarmed!");
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容

            AlarmMessageHandle(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);

            return true; //回调函数需要有返回，表示正常接收到数据
        }





        public void AlarmMessageHandle(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容


            if (DebounceEvent(event_cd))
            {
                return;
            };


            CHCNetSDK.NET_DVR_ALARMINFO struAlarmInfo = new CHCNetSDK.NET_DVR_ALARMINFO();

            struAlarmInfo = (CHCNetSDK.NET_DVR_ALARMINFO)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO));

            CHCNetSDK.NET_VCA_RULE_ALARM struRuleAlarmInfo = new CHCNetSDK.NET_VCA_RULE_ALARM();
            struRuleAlarmInfo = (CHCNetSDK.NET_VCA_RULE_ALARM)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_VCA_RULE_ALARM));
            uint dwSize = (uint)Marshal.SizeOf(struRuleAlarmInfo.struRuleInfo.uEventParam);

            string strTimeYear = ((struRuleAlarmInfo.dwAbsTime >> 26) + 2000).ToString();
            string strTimeMonth = ((struRuleAlarmInfo.dwAbsTime >> 22) & 15).ToString("d2");
            string strTimeDay = ((struRuleAlarmInfo.dwAbsTime >> 17) & 31).ToString("d2");
            string strTimeHour = ((struRuleAlarmInfo.dwAbsTime >> 12) & 31).ToString("d2");
            string strTimeMinute = ((struRuleAlarmInfo.dwAbsTime >> 6) & 63).ToString("d2");
            string strTimeSecond = ((struRuleAlarmInfo.dwAbsTime >> 0) & 63).ToString("d2");
            string strTime = strTimeYear + "-" + strTimeMonth + "-" + strTimeDay + " " + strTimeHour + ":" + strTimeMinute + ":" + strTimeSecond;


            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            console.ThreadLog("Event Triggered! >>>> " + strTime);

            //console.ThreadVarDump(struAlarmInfo);


            TriggerEventAlarm(DateTime.Now);

            //TriggerEvent_Thread();

        }


        ////////////////////////////
        //  DATA
        ////////////////////////////

        public bool armed = false;

        public void LimitMaxAlarms()
        {
            while (eventAlarms.Count > max_alarm_queue)
            {
                eventAlarms.Remove(eventAlarms[0]);
            }
        }


        ////////////////////////////
        //  EVENT ALARMS
        ////////////////////////////
        List<Parts.EventAlarm> eventAlarms = new List<Parts.EventAlarm>();

        public void TriggerEventAlarm(DateTime datetime, bool force_test = false)
        {
            if (!armed && !force_test)
            {
                console.ThreadLog("System Not Armed");
                return;
            }
            console.ThreadLog("Event Alarm Triggered >> " + datetime.ToString());

            LimitMaxAlarms();

            Parts.EventAlarm thisEventAlarm = CreateNewEventAlarm(datetime, event_cd);
            eventAlarms.Add(thisEventAlarm);

            UpdateEventAlarmListUI_Thread();

            Thread convertThread = new Thread(delegate () { InsertEventAlarm_VisionCore(thisEventAlarm); });
            convertThread.IsBackground = true;
            convertThread.Start();

        }

        public Parts.EventAlarm CreateNewEventAlarm(DateTime datetime, Parts.EventSystem event_system)
        {
            Parts.EventAlarm newEventAlarm = new Parts.EventAlarm();
            newEventAlarm.alarm_unique_id = -1;
            newEventAlarm.process_status = "Unprocessed";
            newEventAlarm.event_type = event_system.type;
            newEventAlarm.status = "Created";
            newEventAlarm.related_unique_id = -1;
            newEventAlarm.event_datetime = datetime;
            newEventAlarm.debounce_time = event_system.debounce_time;
            newEventAlarm.event_name = event_system.name;
            return newEventAlarm;
        }




        ///////////////////////////////////
        //  DATABASE THREAD CONNECTION
        ///////////////////////////////////


        public void InsertEventAlarm_VisionCore(Parts.EventAlarm event_alarm)
        {

            
            event_alarm.alarm_unique_id = mainWindow.DB.InsertNewEventAlarm_VisionCore(event_alarm);

            if (event_alarm.alarm_unique_id != -1) {
                event_alarm.status = "Added To Database";
            } else {
                event_alarm.status = "Database Error";
            };

            UpdateEventAlarmListUI_Thread();
        }
    }
}
