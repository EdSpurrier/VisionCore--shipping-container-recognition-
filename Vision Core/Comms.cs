using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Vision_Core
{
    public class Comms
    {

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class Comm_Data
        {
            public int comms_unique_id = -1;
            public string comms_datetime = "";
            public string target_id = "";
            public string comm = "";
            public string comm_data = "";
            public string status = "";
        }

        static MainWindow mainWindow;

        static Vision_Core.VisionConsole console;
        static int cycle_time = 5;
        string destination_id = "None";
        List<Comm_Data> comms_found = new List<Comm_Data>();

        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;
            
            console = mainWindow.vConsole;
            mainWindow = thisMainWindow;
            mainWindow.vConsole.Log("Comms() - Module Initiated.");
            

           StartBackgroundWatcher();
        }

        public void ReadComms()
        {
            if (mainWindow.textBox_system_watchgod_id.Text == "WatchGod Id" || mainWindow.textBox_system_watchgod_id.Text == "Error")
            {
                console.ThreadLog("CANNOT READ COMMS FROM GUI.... Not Started by Watchgod!");
                return;
            };

            console.ThreadLog("Reading Comms From GUI.");
            this.destination_id = mainWindow.textBox_system_watchgod_id.Text;
            comms_found = mainWindow.DB.ReadComms(this.destination_id, comms_found, Vision_Core.Properties.Settings.Default.system_internal_name);
            console.ThreadLog("Found Comms:" + comms_found.Count.ToString());

            foreach (Comm_Data comm_found in comms_found)
            {
                if (comm_found.status == "Created")
                {
                    ThreadActionComm(comm_found);
                };
            };
        }


        public delegate void ActionCommCallback(Comm_Data comm_data);

        public void ThreadActionComm(Comm_Data comm_data)
        {
            if (mainWindow.InvokeRequired)
            {


                mainWindow.BeginInvoke(new ActionCommCallback(ActionComm), comm_data);
            }
            else
            {
                ActionComm(comm_data);
            }
        }

        public void ActionComm(Comm_Data comm_data)
        {

            console.ThreadLog("Actioning Comms:" + comm_data.comm);


            if (comm_data.comm == "cd_process_datetime")
            {

                DateTime datetime;

                if (DateTime.TryParseExact(comm_data.comm_data, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    mainWindow.vConsole.Log("COMMS: DateTime Valid  : " + datetime);

                    mainWindow.cfg.UpdateSystemSetting("cd_process_date", (true).ToString());
                    mainWindow.cfg.UpdateSystemSetting(comm_data.comm, datetime.ToString());
                }
                else
                {
                    mainWindow.vConsole.Log("COMMS: DateTime Invalid");
                    comm_data.status = "Error";
                };

                comm_data.status = "Completed";

            } else if (comm_data.comm == "cpa_push") {

                DateTime datetime;

                if (DateTime.TryParseExact(comm_data.comm_data, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    mainWindow.vConsole.Log("COMMS: DateTime Valid  : " + datetime);

                    mainWindow.cfg.UpdateSystemSetting("cpa_process_date", (true).ToString());
                    mainWindow.cfg.UpdateSystemSetting("cpa_process_datetime", datetime.ToString());
                    mainWindow.CPA.PushToGUI(null, null);
                }
                else
                {
                    mainWindow.vConsole.Log("COMMS: DateTime Invalid");
                    comm_data.status = "Error";
                };

                comm_data.status = "Completed";

            } else if (comm_data.comm == "cpa_pull") {

                DateTime datetime;

                if (DateTime.TryParseExact(comm_data.comm_data, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    mainWindow.vConsole.Log("COMMS: DateTime Valid  : " + datetime);

                    mainWindow.cfg.UpdateSystemSetting("cpa_process_date", (true).ToString());
                    mainWindow.cfg.UpdateSystemSetting("cpa_process_datetime", datetime.ToString());
                    mainWindow.CPA.PullFromGUI(null, null);
                }
                else
                {
                    mainWindow.vConsole.Log("COMMS: DateTime Invalid");
                    comm_data.status = "Error";
                };

comm_data.status = "Completed";
            };
        }

        //////////////////////////////////////
        //  BACKGROUND WATCHER
        //////////////////////////////////////

        private BackgroundWorker backgroundWorker1;

        private void StartBackgroundWatcher()
        {

            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void StopBackgroundWatcher()
        {
            if (backgroundWorker1 != null)
            {
                backgroundWorker1.CancelAsync();
            };
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {

                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    ReadComms();
                    sw.Stop();
                    int msec = (1000 * (int)cycle_time) - (int)sw.ElapsedMilliseconds;
                    if (msec < 1) msec = 1;
                    System.Threading.Thread.Sleep(msec);
                }
            }
        }
    }
}
