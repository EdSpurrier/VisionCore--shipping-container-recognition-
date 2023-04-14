using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


public delegate void VideoFileCallBack(Vision_Core.Parts.VideoFile videoFile);
public delegate void VideoFileAndStatusCallBack(Vision_Core.Parts.VideoFile videoFile, string status);

namespace Vision_Core
{
    public class Parts
    {

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class Setting
        {
            MainWindow mainWindow;
            public string setting_name = "";
            public string setting_data = "";
            public dynamic ui_object = null;

            public Setting(string name, string data, MainWindow mainWindow, dynamic ui_object = null)
            {
                this.mainWindow = mainWindow;
                this.ui_object = ui_object;
                this.setting_name = name;
                this.setting_data = data;
            }



            public delegate void Set_Thread_CallBack();

            void Set()
            {
                if (mainWindow.InvokeRequired)
                {
                    mainWindow.BeginInvoke(new Set_Thread_CallBack(Set_Thread));
                }
                else
                {
                    Set_Thread();
                }
            }


            public void Set_Thread()
            {

                Type var_type = Vision_Core.Properties.Settings.Default[this.setting_name].GetType();
                if (var_type.Equals(typeof(int)))
                {
                    Vision_Core.Properties.Settings.Default[this.setting_name] = Int32.Parse(this.setting_data);
                    if (ui_object != null)
                    {
                        ui_object.Value = Int32.Parse(this.setting_data);
                    };
                }
                else if (var_type.Equals(typeof(string)))
                {
                    Vision_Core.Properties.Settings.Default[this.setting_name] = this.setting_data;
                    if (ui_object != null)
                    {
                        ui_object.Text = this.setting_data;
                    };

                }
                else if (var_type.Equals(typeof(bool)))
                {
                    Vision_Core.Properties.Settings.Default[this.setting_name] = Convert.ToBoolean(this.setting_data);
                    mainWindow.vConsole.ThreadLog("Found Bool");
                    if (ui_object != null)
                    {
                        ui_object.Checked = Convert.ToBoolean(this.setting_data);
                    };
                    
                }
                else if (var_type.Equals(typeof(System.DateTime)))
                {
                    mainWindow.vConsole.ThreadLog("Found Datetime");
                    Vision_Core.Properties.Settings.Default[this.setting_name] = Convert.ToDateTime(this.setting_data);
                    if (ui_object != null)
                    {
                        ui_object.Value = Convert.ToDateTime(this.setting_data);
                    };
                };
   
            }

            public string CheckChanges()
            {
                if (ui_object == null)
                {
                    mainWindow.vConsole.ThreadLog("Error!!");
                    return this.setting_data;
                };

                Type var_type = Vision_Core.Properties.Settings.Default[this.setting_name].GetType();
                if (var_type.Equals(typeof(int)))
                {
                    this.setting_data = ui_object.Value.ToString();
                }
                else if (var_type.Equals(typeof(string)))
                {
                    this.setting_data = ui_object.Text;
                }
                else if (var_type.Equals(typeof(bool)))
                {
                    this.setting_data = ui_object.Checked.ToString();
                }
                else if (var_type.Equals(typeof(System.DateTime)))
                {
                    this.setting_data = ui_object.Value.ToString();
                };

                return this.setting_data;
            }

            public void Get()
            {
                this.setting_data = Vision_Core.Properties.Settings.Default[this.setting_name].ToString();
            }

            public bool Update(string name, string data)
            {
                bool updated = false;
                if (name == this.setting_name)
                {
                    this.setting_data = data;
                    Set();
                    updated = true;
                };

                return updated;
            }
        }


        

        public enum VideoFileDownloadType
        {
            Timeframe,
            DeviceFile
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class RelationData
        {
            public int unique_id;
            public string type;
            public VideoFileCallBack callback_complete;
            public VideoFileCallBack callback_downloaded;
            public VideoFileCallBack callback_converted;
            public VideoFileCallBack callback_uploaded;
            public VideoFileAndStatusCallBack callback_update;
            public VideoFileAndStatusCallBack callback_extracted;
            public VideoFileAndStatusCallBack callback_vision;
        }



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class TextFound
        {
            public string text = "";
            public bool valid = false;
            public int confidence = 0;
            public bool processed = false;
        }



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class LabelFound
        {
            public string label = "";
            public float confidence = 0f;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class KeyFrameImage
        {
            public string file_name;
            public List<LabelFound> label_found;
            public List<TextFound> text_found;
            public List<TextFound> valid_text_found;
            public bool analyzed;
            public int type_code_confidence = 0;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class VideoFile
        {
            public int video_unique_id;

            public int split_file_parts = 0;

            public string file_name;
            public string file_path;
            public string ftp_sub_directory;
            public string ftp_url;
            public string keyframe_path;

            public int channel_number;

            public string folder_name;

            public string saved_file_name;
            public string archive_save_folder;

            public DateTime start_datetime;
            public DateTime end_datetime;

            public VideoFileDownloadType downloadType;

            public int downloaded;
            public bool converted;
            public int uploaded;

            public string status = "NULL";

            public RelationData relation_data;

            public List<KeyFrameImage> keyFrames = new List<KeyFrameImage>();

        }










        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class EventSystem
        {
            public string name;
            public int channel;
            public string type;
            public int debounce_time;
            public bool triggered = false;
            public System.Timers.Timer debounceTimer;
            public int current_countdown_cycle = 0;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class EventAlarm
        {
            public int alarm_unique_id;
            public string process_status;
            public string event_name;
            public string event_type;
            public string status;
            public int related_unique_id;
            public string related_data = "null";
            public DateTime event_datetime;
            public int debounce_time;
            public int confidence = 0;
            public string owner = "";
        }



    }
}
