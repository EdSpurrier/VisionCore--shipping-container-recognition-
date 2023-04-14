using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;


namespace Vision_Core
{
    public partial class MainWindow : Form
    {
        public static MainWindow Self;

        private bool initSDK = false;

        string baseDir;

        internal Core core;

        internal VisionConsole vConsole;
        internal Config cfg;
        internal HikVisionServer HVS;
        internal FTPUploader FTP;
        internal Database DB;
        internal Downloader DL;
        internal ContainerChain CC;
        internal VideoConverter VC;
        internal VisionAnalyzer VA;
        internal ImageExtractor IE;
        internal ContainerDetector CD;
        internal EventManager EM;
        internal ContainerProcessAnalyzer CPA;
        internal Comms Comms;

        internal string command_line_arg_1 = "Error";
        internal string command_line_arg_2 = "False";
        internal string command_line_arg_3 = "None";

        string[] args;

        public object Process { get; internal set; }

        public MainWindow()
        {
            Self = this;


            args = Environment.GetCommandLineArgs();

            if (args != null)
            {
                if (args.Length > 1)
                {
                    // note that args[0] is the path of the executable
                    command_line_arg_1 = args[1];
                    

                    
                };

                if (args.Length > 2)
                {
                    // note that args[0] is the path of the executable
                    command_line_arg_2 = args[2];
                    
                };

                if (args.Length > 3)
                {
                    // note that args[0] is the path of the executable
                    command_line_arg_3 = args[3];

                };
            }


            




            InitializeComponent();

            this.Text = Vision_Core.Properties.Settings.Default.system_internal_name;


            
        }

        

        void InitializeCore()
        {
            vConsole = new VisionConsole();
            vConsole.mainWindow = this;

            core = new Core();
            core.Init(this);
        }


        void Setup()
        {
            initSDK = CHCNetSDK.NET_DVR_Init();
            baseDir = Directory.GetCurrentDirectory();
            
        }


        void InitializeModules()
        {
            
            cfg = new Config();
            cfg.mainWindow = this;

            DB = new Database();
            DB.Init(this);

            HVS = new HikVisionServer();
            HVS.Init(this);

            DL = new Downloader();
            DL.Init(this);

            FTP = new FTPUploader();
            FTP.Init(this);

            CC = new ContainerChain();
            CC.Init(this);

            VC = new VideoConverter();
            VC.Init(this);

            VA = new VisionAnalyzer();
            VA.Init(this);

            IE = new ImageExtractor();
            IE.Init(this);

            CD = new ContainerDetector();
            CD.Init(this);

            EM = new EventManager();
            EM.Init(this);

            CPA = new ContainerProcessAnalyzer();
            CPA.Init(this);

            Comms = new Comms();
            Comms.Init(this);

            VideoStitcher.mainWindow = this;
        }

        


        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitializeCore();

            Setup();

            InitializeModules();


            Tools.SetupControl(this);
            ErrorHandler.SetupControl(this);
            Testing.SetupControl(this);
            core.UpdateBuildVersion();

            if (initSDK == false)
            {
                MessageBox.Show("initSDK error!", Vision_Core.Properties.Settings.Default.system_internal_name + " ERROR");
                return;
            }
            else
            {
                //Save log of SDK
                CHCNetSDK.NET_DVR_SetLogToFile(3, baseDir + "\\sdkLog\\", true);
                vConsole.Log("SDK Log Created = " + baseDir + "\\sdkLog\\");
                
                cfg.LoadConfig_AppData();

                AutoStart();
            }

            Console.WriteLine( "Server_Ip" + Properties.Settings.Default.server_ip);

            vConsole.Log("Initiated Vision Core");


            vConsole.Log("[WatchGod Id]: " + command_line_arg_1);
            vConsole.Log("[Autostart Status]: " + command_line_arg_2);
            vConsole.Log("[Autostart Args]: " + command_line_arg_3);
            this.textBox_system_watchgod_id.Text = command_line_arg_1;


            cfg.CreateInternalSystemSettings();
            //cfg.SettingsCheckIn_WebGUI();


            
        }

        void AutoStart()
        {
            if (core.autoStart)
            {
                cfg.LoadConfig_AppData();
                HVS.ConnectToServer(command_line_arg_3);
            };
        }


        public void StartAll()
        {
            button_start.Enabled = false;
            vConsole.Log("Starting All Application Modules.");
            EM.Arm_ContainerDetector(null, null);
            CPA.StartDatabaseCycle(null, null);
            CD.StartDatabaseCycle(null, null);
        }

        public void StartEventManagerSystem()
        {
            button_start.Enabled = false;
            vConsole.Log("Starting Event Manager Module.");
            EM.Arm_ContainerDetector(null, null);
        }

        public void StartCPA_CCSystem()
        {
            button_start.Enabled = false;
            vConsole.Log("Starting CPA & CC Module.");
            CPA.StartDatabaseCycle(null, null);
        }


        public void StartCDSystem()
        {
            button_start.Enabled = false;
            vConsole.Log("Starting CD Module.");
            CD.StartDatabaseCycle(null, null);
        }

        private void Button_connect_Click(object sender, EventArgs e)
        {
            cfg.SaveConfig_AppData();
            HVS.ConnectToServer();
        }


        private void Button_choose_save_folder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                //Do your work here!
                textBox_save_folder.Text = folderName;
                textBox_save_folder.Text = folderName;
            }
        }

        private void Timer_download_Tick(object sender, EventArgs e)
        {
            DL.DownloadProgressTick(sender, e);
        }




        public void ActivateUI()
        {
            button_connect.Enabled = false;

            button_load_settings.Enabled = false;

            textBox_server_ip.Enabled = false;
            textBox_server_port.Enabled = false;
            textBox_login.Enabled = false;
            textBox_password.Enabled = false;

            textBox_system_internal_name.Enabled = false;
            textBox_save_folder.Enabled = false;
            button_choose_save_folder.Enabled = false;

            textBox_FTP_user_name.Enabled = false;
            textBox_FTP_password.Enabled = false;
            textBox_FTP_IP.Enabled = false;

            textBox_core_sql_ip.Enabled = false;
            textBox_core_sql_login.Enabled = false;
            textBox_core_sql_password.Enabled = false;
            textBox_core_sql_database.Enabled = false;

            textBox_vision_sql_ip.Enabled = false;
            textBox_vision_sql_login.Enabled = false;
            textBox_vision_sql_password.Enabled = false;
            textBox_vision_sql_database.Enabled = false;

            tabControl_main.Enabled = true;

        }

        public void ConnectingUI()
        {
            tabControl_main.Enabled = false;
        }

        public void DisconnectedUI()
        {
            tabControl_main.Enabled = true;
        }

        private void Button_clear_console_Click(object sender, EventArgs e)
        {
            listBox_console.Items.Clear();
        }

        private void Button_clear_error_Click(object sender, EventArgs e)
        {
            listBox_error.Items.Clear();
        }





        private void Button_save_settings_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                //Do your work here!
                cfg.SaveSettingsFile(folderName);
            };

            
        }

        private void Button_load_settings_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                //Do your work here!
                cfg.LoadSettingsFile(fileName);
            };
        }



        private void Button_restart_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want To Restart The System?", "Restart System", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                core.RestartApp();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }



        private void Button_container_chain_start_Click(object sender, EventArgs e)
        {
            CC.Start();
        }

        private void Button_container_chain_stop_Click(object sender, EventArgs e)
        {
            CC.Stop();
        }


        private void Button_cc_download_Click(object sender, EventArgs e)
        {
            CC.Download_Timeframe();
        }

        private void Button_start_Click(object sender, EventArgs e)
        {
            cfg.SaveConfig_AppData();
            HVS.ConnectToServer("all");
        }

        private void Button_start_em_sys_Click(object sender, EventArgs e)
        {
            cfg.SaveConfig_AppData();
            HVS.ConnectToServer("em sys");
        }



        

    }
}
