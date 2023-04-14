using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Web;
using Newtonsoft.Json;



namespace Vision_Core
{
    public class Config
    {

        public MainWindow mainWindow;

        public List<Parts.Setting> systemSettings = new List<Parts.Setting>();


        public void SettingsCheckIn_WebGUI()
        {

            //  GET UNIQUE SYSTEM ID   
            int system_uniuqe_id = mainWindow.DB.SelectSystem_WebVisionCore();
            mainWindow.vConsole.ThreadLog("Connected To System_U_Id: " + system_uniuqe_id.ToString());

            //  SET INTERNAL SYSTEM SETTINGS (INCASE THERE ARE NEW ONES OR THEY DONT MATCH)
            if (systemSettings.Count == 0)
            {
                //CreateInternalSystemSettings();

            };

            CreateInternalSystemSettings();


            //  IF THERE IS A SYSTEM ALREADY EXISTS GET ITS DATA
            if (system_uniuqe_id != -1)
            {
                //  SEND THE CURRENT INTERNAL SYSTEM SETTINGS TO THE GUI DB
                mainWindow.DB.UpdateSystemSettings_WebVisionCore(system_uniuqe_id);
            };

        }



        public void CreateInternalSystemSettings()
        {
            systemSettings.Clear();

            mainWindow.vConsole.ThreadLog("Creating System Settings");

            systemSettings.Add(new Parts.Setting(
                nameof(Vision_Core.Properties.Settings.Default.cd_process_datetime),
                //Vision_Core.Properties.Settings.Default.cd_process_datetime.ToString(),
                mainWindow.dateTimePicker_cd_process_datetime.Value.ToString(),
                mainWindow,
                mainWindow.dateTimePicker_cd_process_datetime
                ));

            systemSettings.Add(new Parts.Setting(
                nameof(Vision_Core.Properties.Settings.Default.cd_process_date),
                mainWindow.checkBox_cd_process_date.Checked.ToString(),
                mainWindow,
                mainWindow.checkBox_cd_process_date
                ));

            systemSettings.Add(new Parts.Setting(
                nameof(Vision_Core.Properties.Settings.Default.cpa_process_datetime),
                //Vision_Core.Properties.Settings.Default.cpa_process_datetime.ToString(),
                mainWindow.dateTimePicker_cpa_process_datetime.Value.ToString(),
                mainWindow,
                mainWindow.dateTimePicker_cpa_process_datetime
                ));

            systemSettings.Add(new Parts.Setting(
                nameof(Vision_Core.Properties.Settings.Default.cpa_process_date),
                mainWindow.checkBox_cpa_process_date.Checked.ToString(),
                mainWindow,
                mainWindow.checkBox_cpa_process_date
                ));


        }

        public void UpdateSystemSetting(string name, string data)
        {
            bool change_complete = false;
            foreach (Parts.Setting systemSetting in systemSettings)
            {
                if (!change_complete)
                {
                    change_complete = systemSetting.Update(name, data);
                };
            };

            if (!change_complete)
            {
                mainWindow.vConsole.Log("ERROR >> System Setting Could Not Be Found [" + name + ":" + data + "]");
            };

            SaveConfig_AppData();
        }

        public void LoadSettingsFile(string fileName)
        {
            mainWindow.vConsole.Log("Loading Settings File = " + fileName);
            MySettings settings = MySettings.Load(fileName);
            LoadConfig_SettingsFile(settings);
        }

        public void SaveSettingsFile(string folderName)
        {
            MySettings settings = new MySettings();
            mainWindow.vConsole.Log("Saving Settings File = " + folderName + "/settings.json");
            settings = SaveConfig_SettingsFile(settings);
            settings.Save(folderName);
        }



        public void SaveConfig_AppData ()
        {
            mainWindow.vConsole.Log("Saving AppData Config...");


            Vision_Core.Properties.Settings.Default.server_ip = mainWindow.textBox_server_ip.Text;
            Vision_Core.Properties.Settings.Default.server_port = mainWindow.textBox_server_port.Text;

            Vision_Core.Properties.Settings.Default.login = mainWindow.textBox_login.Text;
            Vision_Core.Properties.Settings.Default.password = mainWindow.textBox_password.Text;
            Vision_Core.Properties.Settings.Default.save_folder = mainWindow.textBox_save_folder.Text;


            Vision_Core.Properties.Settings.Default.conversion_quality = mainWindow.comboBox_settings_conversion_quality.Text;

            Vision_Core.Properties.Settings.Default.ftp_login = mainWindow.textBox_FTP_user_name.Text;
            Vision_Core.Properties.Settings.Default.ftp_password = mainWindow.textBox_FTP_password.Text;
            Vision_Core.Properties.Settings.Default.ftp_ip = mainWindow.textBox_FTP_IP.Text;

            Vision_Core.Properties.Settings.Default.vision_sql_login = mainWindow.textBox_vision_sql_login.Text;
            Vision_Core.Properties.Settings.Default.vision_sql_password = mainWindow.textBox_vision_sql_password.Text;
            Vision_Core.Properties.Settings.Default.vision_sql_ip = mainWindow.textBox_vision_sql_ip.Text;
            Vision_Core.Properties.Settings.Default.vision_sql_database = mainWindow.textBox_vision_sql_database.Text;


            Vision_Core.Properties.Settings.Default.core_sql_login = mainWindow.textBox_core_sql_login.Text;
            Vision_Core.Properties.Settings.Default.core_sql_password = mainWindow.textBox_core_sql_password.Text;
            Vision_Core.Properties.Settings.Default.core_sql_ip = mainWindow.textBox_core_sql_ip.Text;
            Vision_Core.Properties.Settings.Default.core_sql_database = mainWindow.textBox_core_sql_database.Text;
            Vision_Core.Properties.Settings.Default.core_sql_database = mainWindow.textBox_core_sql_database.Text;

            Vision_Core.Properties.Settings.Default.visioncore_gui_sql_database = mainWindow.textBox_vision_core_gui_sql_database.Text;



            Vision_Core.Properties.Settings.Default.cc_record_channel_1 = mainWindow.checkBox_cc_record_channel_1.Checked;
            Vision_Core.Properties.Settings.Default.cc_record_channel_2 = mainWindow.checkBox_cc_record_channel_2.Checked;
            Vision_Core.Properties.Settings.Default.cc_record_channel_3 = mainWindow.checkBox_cc_record_channel_3.Checked;
            Vision_Core.Properties.Settings.Default.cc_record_channel_4 = mainWindow.checkBox_cc_record_channel_4.Checked;
            

            Vision_Core.Properties.Settings.Default.cc_preroll = (int)mainWindow.numericUpDown_cc_preroll.Value;
            Vision_Core.Properties.Settings.Default.cc_min_length = (int)mainWindow.numericUpDown_cc_min_length.Value;

            Vision_Core.Properties.Settings.Default.cc_ftp_sub_dir = mainWindow.textBox_cc_ftp_sub_dir.Text;

            Vision_Core.Properties.Settings.Default.cd_clean_up = mainWindow.checkBox_cd_clean_up.Checked;
            Vision_Core.Properties.Settings.Default.cc_clean_up = mainWindow.checkBox_cc_clean_up.Checked;
            Vision_Core.Properties.Settings.Default.cpa_reprocess = mainWindow.checkBox_cpa_reprocess.Checked;


            Vision_Core.Properties.Settings.Default.va_min_confidence = (int)mainWindow.numericUpDown_va_min_confidence.Value;
            Vision_Core.Properties.Settings.Default.system_internal_name = mainWindow.textBox_system_internal_name.Text;


            Vision_Core.Properties.Settings.Default.ie_crop_x = (int)mainWindow.numericUpDown_ie_crop_x.Value;
            Vision_Core.Properties.Settings.Default.ie_crop_y = (int)mainWindow.numericUpDown_ie_crop_y.Value;
            Vision_Core.Properties.Settings.Default.ie_crop_width = (int)mainWindow.numericUpDown_ie_crop_width.Value;
            Vision_Core.Properties.Settings.Default.ie_crop_height = (int)mainWindow.numericUpDown_ie_crop_height.Value;

            Vision_Core.Properties.Settings.Default.cd_process_date = mainWindow.checkBox_cd_process_date.Checked;
            Vision_Core.Properties.Settings.Default.cd_process_datetime = mainWindow.dateTimePicker_cd_process_datetime.Value;

            Vision_Core.Properties.Settings.Default.cpa_process_date = mainWindow.checkBox_cpa_process_date.Checked;
            Vision_Core.Properties.Settings.Default.cpa_process_datetime = mainWindow.dateTimePicker_cpa_process_datetime.Value;

            Vision_Core.Properties.Settings.Default.cd_recording_channel = (int)mainWindow.numericUpDown_cd_recording_channel.Value;

            Vision_Core.Properties.Settings.Default.cpa_owner = mainWindow.textBox_cpa_owner.Text;



            


            Vision_Core.Properties.Settings.Default.Save();


            mainWindow.vConsole.Log("Saved AppData Config.");
        }



        public void LoadConfig_AppData()
        {
            mainWindow.vConsole.ThreadLog("Loading AppData Config...");


            mainWindow.textBox_server_ip.Text = Vision_Core.Properties.Settings.Default.server_ip;
            mainWindow.textBox_server_port.Text = Vision_Core.Properties.Settings.Default.server_port;

            mainWindow.textBox_login.Text = Properties.Settings.Default.login;
            mainWindow.textBox_password.Text = Properties.Settings.Default.password;
            mainWindow.textBox_save_folder.Text = Vision_Core.Properties.Settings.Default.save_folder;


            mainWindow.comboBox_settings_conversion_quality.Text = Vision_Core.Properties.Settings.Default.conversion_quality;


            mainWindow.textBox_FTP_user_name.Text = Vision_Core.Properties.Settings.Default.ftp_login;
            mainWindow.textBox_FTP_password.Text = Vision_Core.Properties.Settings.Default.ftp_password;
            mainWindow.textBox_FTP_IP.Text = Vision_Core.Properties.Settings.Default.ftp_ip;

            mainWindow.textBox_vision_sql_login.Text = Vision_Core.Properties.Settings.Default.vision_sql_login;
            mainWindow.textBox_vision_sql_password.Text = Vision_Core.Properties.Settings.Default.vision_sql_password;
            mainWindow.textBox_vision_sql_ip.Text = Vision_Core.Properties.Settings.Default.vision_sql_ip;
            mainWindow.textBox_vision_sql_database.Text = Vision_Core.Properties.Settings.Default.vision_sql_database;

            mainWindow.textBox_core_sql_login.Text = Vision_Core.Properties.Settings.Default.core_sql_login;
            mainWindow.textBox_core_sql_password.Text = Vision_Core.Properties.Settings.Default.core_sql_password;
            mainWindow.textBox_core_sql_ip.Text = Vision_Core.Properties.Settings.Default.core_sql_ip;
            mainWindow.textBox_core_sql_database.Text = Vision_Core.Properties.Settings.Default.core_sql_database;
            mainWindow.textBox_vision_core_gui_sql_database.Text = Vision_Core.Properties.Settings.Default.visioncore_gui_sql_database;

            mainWindow.textBox_system_internal_name.Text = Vision_Core.Properties.Settings.Default.system_internal_name;



            mainWindow.checkBox_cc_record_channel_1.Checked = Vision_Core.Properties.Settings.Default.cc_record_channel_1;
            mainWindow.checkBox_cc_record_channel_2.Checked = Vision_Core.Properties.Settings.Default.cc_record_channel_2;
            mainWindow.checkBox_cc_record_channel_3.Checked = Vision_Core.Properties.Settings.Default.cc_record_channel_3;
            mainWindow.checkBox_cc_record_channel_4.Checked = Vision_Core.Properties.Settings.Default.cc_record_channel_4;


            mainWindow.numericUpDown_cc_preroll.Value = Vision_Core.Properties.Settings.Default.cc_preroll;
            mainWindow.numericUpDown_cc_min_length.Value = Vision_Core.Properties.Settings.Default.cc_min_length;

            mainWindow.textBox_cc_ftp_sub_dir.Text = Vision_Core.Properties.Settings.Default.cc_ftp_sub_dir;



            mainWindow.checkBox_cd_clean_up.Checked = Vision_Core.Properties.Settings.Default.cd_clean_up;
            mainWindow.checkBox_cc_clean_up.Checked = Vision_Core.Properties.Settings.Default.cc_clean_up;
            mainWindow.checkBox_cpa_reprocess.Checked = Vision_Core.Properties.Settings.Default.cpa_reprocess;

            mainWindow.numericUpDown_va_min_confidence.Value = Vision_Core.Properties.Settings.Default.va_min_confidence;



            mainWindow.numericUpDown_ie_crop_x.Value = Vision_Core.Properties.Settings.Default.ie_crop_x;
            mainWindow.numericUpDown_ie_crop_y.Value = Vision_Core.Properties.Settings.Default.ie_crop_y;
            mainWindow.numericUpDown_ie_crop_width.Value = Vision_Core.Properties.Settings.Default.ie_crop_width;
            mainWindow.numericUpDown_ie_crop_height.Value = Vision_Core.Properties.Settings.Default.ie_crop_height;

            mainWindow.checkBox_cd_process_date.Checked = Vision_Core.Properties.Settings.Default.cd_process_date;
            mainWindow.dateTimePicker_cd_process_datetime.Value = Vision_Core.Properties.Settings.Default.cd_process_datetime;

            mainWindow.checkBox_cpa_process_date.Checked = Vision_Core.Properties.Settings.Default.cpa_process_date;
            mainWindow.dateTimePicker_cpa_process_datetime.Value = Vision_Core.Properties.Settings.Default.cpa_process_datetime;


            mainWindow.textBox_cpa_owner.Text = Vision_Core.Properties.Settings.Default.cpa_owner;

            mainWindow.numericUpDown_cd_recording_channel.Value = Vision_Core.Properties.Settings.Default.cd_recording_channel;

            mainWindow.vConsole.ThreadLog("Loaded AppData Config.");

        }


        public class MySettings : AppSettings<MySettings>
        {

            public string server_ip = Vision_Core.Properties.Settings.Default.server_ip;

            public string server_port = Vision_Core.Properties.Settings.Default.server_port;

            public string login = Properties.Settings.Default.login;
            public string password = Properties.Settings.Default.password;
            public string save_folder = Vision_Core.Properties.Settings.Default.save_folder;


            public string conversion_quality = Vision_Core.Properties.Settings.Default.conversion_quality;

            public string ftp_login = Vision_Core.Properties.Settings.Default.ftp_login;
            public string ftp_password = Vision_Core.Properties.Settings.Default.ftp_password;
            public string ftp_ip = Vision_Core.Properties.Settings.Default.ftp_ip;

            public string vision_sql_login = Vision_Core.Properties.Settings.Default.vision_sql_login;
            public string vision_sql_password = Vision_Core.Properties.Settings.Default.vision_sql_password;
            public string vision_sql_ip = Vision_Core.Properties.Settings.Default.vision_sql_ip;
            public string vision_sql_database = Vision_Core.Properties.Settings.Default.vision_sql_database;

            public string core_sql_login = Vision_Core.Properties.Settings.Default.core_sql_login;
            public string core_sql_password = Vision_Core.Properties.Settings.Default.core_sql_password;
            public string core_sql_ip = Vision_Core.Properties.Settings.Default.core_sql_ip;
            public string core_sql_database = Vision_Core.Properties.Settings.Default.core_sql_database;
            public string visioncore_gui_sql_database = Vision_Core.Properties.Settings.Default.visioncore_gui_sql_database;




            public string system_internal_name = Vision_Core.Properties.Settings.Default.system_internal_name;

            public bool cc_record_channel_1 = Vision_Core.Properties.Settings.Default.cc_record_channel_1;
            public bool cc_record_channel_2 = Vision_Core.Properties.Settings.Default.cc_record_channel_2;
            public bool cc_record_channel_3 = Vision_Core.Properties.Settings.Default.cc_record_channel_3;
            public bool cc_record_channel_4 = Vision_Core.Properties.Settings.Default.cc_record_channel_4;


            public int cc_preroll = Vision_Core.Properties.Settings.Default.cc_preroll;
            public int cc_min_length = Vision_Core.Properties.Settings.Default.cc_min_length;

            public string cc_ftp_sub_dir = Vision_Core.Properties.Settings.Default.cc_ftp_sub_dir;

            public bool cc_clean_up = Vision_Core.Properties.Settings.Default.cc_clean_up;
            public bool cd_clean_up = Vision_Core.Properties.Settings.Default.cd_clean_up;
            public bool cpa_reprocess = Vision_Core.Properties.Settings.Default.cpa_reprocess;


            public int va_min_confidence = Vision_Core.Properties.Settings.Default.va_min_confidence;



            public int ie_crop_x = Vision_Core.Properties.Settings.Default.ie_crop_x;
            public int ie_crop_y = Vision_Core.Properties.Settings.Default.ie_crop_y;
            public int ie_crop_width = Vision_Core.Properties.Settings.Default.ie_crop_width;
            public int ie_crop_height = Vision_Core.Properties.Settings.Default.ie_crop_height;


            public int cd_recording_channel = Vision_Core.Properties.Settings.Default.cd_recording_channel;

            public bool cd_process_date = Vision_Core.Properties.Settings.Default.cd_process_date;
            public DateTime cd_process_datetime = Vision_Core.Properties.Settings.Default.cd_process_datetime;

            public bool cpa_process_date = Vision_Core.Properties.Settings.Default.cpa_process_date;
            public DateTime cpa_process_datetime = Vision_Core.Properties.Settings.Default.cpa_process_datetime;

            public string cpa_owner = Vision_Core.Properties.Settings.Default.cpa_owner;

        }


        public void LoadConfig_SettingsFile(MySettings settings)
        {
            
            mainWindow.vConsole.Log("Loading Settings File Config....");

            Vision_Core.Properties.Settings.Default.server_ip = settings.server_ip;
            Vision_Core.Properties.Settings.Default.server_port = settings.server_port;

            Vision_Core.Properties.Settings.Default.login = settings.login;
            Vision_Core.Properties.Settings.Default.password = settings.password;
            Vision_Core.Properties.Settings.Default.save_folder = settings.save_folder;




            Vision_Core.Properties.Settings.Default.conversion_quality = mainWindow.comboBox_settings_conversion_quality.Text;

            Vision_Core.Properties.Settings.Default.ftp_login = settings.ftp_login;
            Vision_Core.Properties.Settings.Default.ftp_password = settings.ftp_password;
            Vision_Core.Properties.Settings.Default.ftp_ip = settings.ftp_ip;

            Vision_Core.Properties.Settings.Default.vision_sql_login = settings.vision_sql_login;
            Vision_Core.Properties.Settings.Default.vision_sql_password = settings.vision_sql_password;
            Vision_Core.Properties.Settings.Default.vision_sql_ip = settings.vision_sql_ip;
            Vision_Core.Properties.Settings.Default.vision_sql_database = settings.vision_sql_database;


            Vision_Core.Properties.Settings.Default.core_sql_login = settings.core_sql_login;
            Vision_Core.Properties.Settings.Default.core_sql_password = settings.core_sql_password;
            Vision_Core.Properties.Settings.Default.core_sql_ip = settings.core_sql_ip;
            Vision_Core.Properties.Settings.Default.core_sql_database = settings.core_sql_database;
            Vision_Core.Properties.Settings.Default.visioncore_gui_sql_database = settings.visioncore_gui_sql_database;


            Vision_Core.Properties.Settings.Default.system_internal_name = settings.system_internal_name;

            Vision_Core.Properties.Settings.Default.cc_record_channel_1 = settings.cc_record_channel_1;
            Vision_Core.Properties.Settings.Default.cc_record_channel_2 = settings.cc_record_channel_2;
            Vision_Core.Properties.Settings.Default.cc_record_channel_3 = settings.cc_record_channel_3;
            Vision_Core.Properties.Settings.Default.cc_record_channel_4 = settings.cc_record_channel_4;


            Vision_Core.Properties.Settings.Default.cc_preroll = settings.cc_preroll;
            Vision_Core.Properties.Settings.Default.cc_min_length = settings.cc_min_length;

            Vision_Core.Properties.Settings.Default.cc_ftp_sub_dir = settings.cc_ftp_sub_dir;

            Vision_Core.Properties.Settings.Default.cc_clean_up = settings.cc_clean_up;
            Vision_Core.Properties.Settings.Default.cd_clean_up = settings.cd_clean_up;
            Vision_Core.Properties.Settings.Default.cpa_reprocess = settings.cpa_reprocess;

            Vision_Core.Properties.Settings.Default.va_min_confidence = settings.va_min_confidence;


            Vision_Core.Properties.Settings.Default.ie_crop_x = settings.ie_crop_x;
            Vision_Core.Properties.Settings.Default.ie_crop_y = settings.ie_crop_y;
            Vision_Core.Properties.Settings.Default.ie_crop_width = settings.ie_crop_width;
            Vision_Core.Properties.Settings.Default.ie_crop_height = settings.ie_crop_height;

            Vision_Core.Properties.Settings.Default.cd_process_date = settings.cd_process_date;
            Vision_Core.Properties.Settings.Default.cd_process_datetime = settings.cd_process_datetime;

            Vision_Core.Properties.Settings.Default.cpa_process_date = settings.cpa_process_date;
            Vision_Core.Properties.Settings.Default.cpa_process_datetime = settings.cpa_process_datetime;


            Vision_Core.Properties.Settings.Default.cd_recording_channel = settings.cd_recording_channel;

            Vision_Core.Properties.Settings.Default.cpa_owner = settings.cpa_owner;

            mainWindow.vConsole.Log("Loaded Settings File Config.");

            LoadConfig_AppData();

        }


        public MySettings SaveConfig_SettingsFile(MySettings settings)
        {
            SaveConfig_AppData();

            mainWindow.vConsole.Log("Saving Settings File Config....");

            settings.server_ip = Vision_Core.Properties.Settings.Default.server_ip;
            settings.server_port = Vision_Core.Properties.Settings.Default.server_port;

            settings.login = Vision_Core.Properties.Settings.Default.login;
            settings.password = Vision_Core.Properties.Settings.Default.password;
            settings.save_folder = Vision_Core.Properties.Settings.Default.save_folder;



            settings.conversion_quality = Vision_Core.Properties.Settings.Default.conversion_quality;


            settings.ftp_login = Vision_Core.Properties.Settings.Default.ftp_login;
            settings.ftp_password = Vision_Core.Properties.Settings.Default.ftp_password;
            settings.ftp_ip = Vision_Core.Properties.Settings.Default.ftp_ip;

            settings.vision_sql_login = Vision_Core.Properties.Settings.Default.vision_sql_login;
            settings.vision_sql_password = Vision_Core.Properties.Settings.Default.vision_sql_password;
            settings.vision_sql_ip = Vision_Core.Properties.Settings.Default.vision_sql_ip;
            settings.vision_sql_database = Vision_Core.Properties.Settings.Default.vision_sql_database;


            settings.core_sql_login = Vision_Core.Properties.Settings.Default.core_sql_login;
            settings.core_sql_password = Vision_Core.Properties.Settings.Default.core_sql_password;
            settings.core_sql_ip = Vision_Core.Properties.Settings.Default.core_sql_ip;
            settings.core_sql_database = Vision_Core.Properties.Settings.Default.core_sql_database;
            settings.visioncore_gui_sql_database = Vision_Core.Properties.Settings.Default.visioncore_gui_sql_database;
            
            settings.system_internal_name = Vision_Core.Properties.Settings.Default.system_internal_name;

            settings.cc_record_channel_1 = Vision_Core.Properties.Settings.Default.cc_record_channel_1;
            settings.cc_record_channel_2 = Vision_Core.Properties.Settings.Default.cc_record_channel_2;
            settings.cc_record_channel_3 = Vision_Core.Properties.Settings.Default.cc_record_channel_3;
            settings.cc_record_channel_4 = Vision_Core.Properties.Settings.Default.cc_record_channel_4;


            settings.cc_preroll = Vision_Core.Properties.Settings.Default.cc_preroll;
            settings.cc_min_length = Vision_Core.Properties.Settings.Default.cc_min_length;

            settings.cc_ftp_sub_dir = Vision_Core.Properties.Settings.Default.cc_ftp_sub_dir;

            settings.cc_clean_up = Vision_Core.Properties.Settings.Default.cc_clean_up;
            settings.cd_clean_up = Vision_Core.Properties.Settings.Default.cd_clean_up;

            settings.cpa_reprocess = Vision_Core.Properties.Settings.Default.cpa_reprocess;

            settings.va_min_confidence = Vision_Core.Properties.Settings.Default.va_min_confidence;

            settings.ie_crop_x = Vision_Core.Properties.Settings.Default.ie_crop_x;
            settings.ie_crop_y = Vision_Core.Properties.Settings.Default.ie_crop_y;
            settings.ie_crop_width = Vision_Core.Properties.Settings.Default.ie_crop_width;
            settings.ie_crop_height = Vision_Core.Properties.Settings.Default.ie_crop_height;


            settings.cd_process_date = Vision_Core.Properties.Settings.Default.cd_process_date;
            settings.cd_process_datetime = Vision_Core.Properties.Settings.Default.cd_process_datetime;

            settings.cpa_process_date = Vision_Core.Properties.Settings.Default.cpa_process_date;
            settings.cpa_process_datetime = Vision_Core.Properties.Settings.Default.cpa_process_datetime;

            settings.cd_recording_channel = Vision_Core.Properties.Settings.Default.cd_recording_channel;

            settings.cpa_owner = Vision_Core.Properties.Settings.Default.cpa_owner;

            mainWindow.vConsole.Log("Saved Settings File Config.");

            return settings;

        }
    }


    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public string Save(string folderName, string fileName = DEFAULT_FILENAME)
        {
            string file = folderName + "/" + fileName;
            File.WriteAllText(file, (JsonConvert.SerializeObject(this, Formatting.Indented)));
            return file;
        }


        //public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        //{
        //    File.WriteAllText(fileName, (JsonConvert.SerializeObject(pSettings, Formatting.Indented)));
        //}

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
            return t;
        }


    }
}
