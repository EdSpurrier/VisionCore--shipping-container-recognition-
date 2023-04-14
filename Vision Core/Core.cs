using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Vision_Core
{
    class Core
    {

        public MainWindow mainWindow;

        public string systemStatus = "Loaded";
        public string deviceServerIP = "Not Connected - Server";
        public string externalIp = "Not Initialized";
        public bool systemError = false;

        public bool autoStart = false;


        public void CheckAutoStart()
        {
            if (mainWindow.command_line_arg_2 == "autostart")
            {
                autoStart = true;
                mainWindow.vConsole.Log("AUTOSTART = Activated arg=[" + mainWindow.command_line_arg_3 + "]");
            }
            else {
                mainWindow.vConsole.Log("AUTOSTART = Disabled");
            };


        }

        public void Init(MainWindow thisMainWindow)
        {

            mainWindow = thisMainWindow;
            mainWindow.vConsole.Log("Core() - Module Initiated.");
            systemStatus = "Initialized";


            externalIp = Tools.GetExternalIP();

            StartSystemClock();

            CheckAutoStart();

            
            StartSystemCoreCheckInCycle();

            
        }


        public void RestartApp()
        {
            string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(myApp);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;


            startInfo.Arguments = mainWindow.command_line_arg_1 + " " + mainWindow.command_line_arg_2 + " " + mainWindow.command_line_arg_3;

            System.Diagnostics.Process.Start(startInfo);

            Environment.Exit(0);
        }


        public int systemCoreCycleInterval = 5000;
        System.Windows.Forms.Timer systemCoreCycleTimer;

        

        public void StartSystemCoreCheckInCycle()
        {
            systemCoreCycleTimer = new System.Windows.Forms.Timer();
            systemCoreCycleTimer.Interval = systemCoreCycleInterval;
            systemCoreCycleTimer.Tick += new System.EventHandler(SystemCoreSettingsAndCheckInCycle);
            mainWindow.vConsole.Log("System Core Check In Cycle Started.");
            systemCoreCycleTimer.Start();

        }


        //  SYSTEM CHECKIN
        public void SystemCoreSettingsAndCheckInCycle(object sender, EventArgs e)
        {
            Thread dbThread = new Thread(delegate () { SystemCoreSettingsAndCheckIn(); });
            dbThread.IsBackground = true;
            dbThread.Start();

        }


        public void SystemCoreSettingsAndCheckIn()
        {
            mainWindow.DB.InsertSystemCheckInStatus_WebGUI(externalIp, deviceServerIP, systemStatus, systemError, systemCoreCycleInterval);
            mainWindow.vConsole.ThreadLog("System Core Checking In... [Status=" + systemStatus + "][Ext IP=" + externalIp + "][Device Server IP=" + deviceServerIP + "][System Error Status=" + systemError.ToString() + "]");
            mainWindow.cfg.SettingsCheckIn_WebGUI();
        }



        public int systemClockCycleInterval = 1000;
        System.Windows.Forms.Timer systemClockCycleTimer;
        private void StartSystemClock()
        {
            systemClockCycleTimer = new System.Windows.Forms.Timer();
            systemClockCycleTimer.Interval = systemClockCycleInterval;
            systemClockCycleTimer.Tick += new System.EventHandler(Timer_current_time_Tick);
            mainWindow.vConsole.Log("System Clock Started.");
            systemClockCycleTimer.Start();
        }


        private void Timer_current_time_Tick(object sender, EventArgs e)
        {
            mainWindow.textBox_current_time.Text = DateTime.Now.ToLongTimeString();
        }


        public void UpdateBuildVersion ()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string displayableVersion = $"{version}";
            mainWindow.label_build_version.Text = "Build Version: " + displayableVersion;
        }
    }
}
