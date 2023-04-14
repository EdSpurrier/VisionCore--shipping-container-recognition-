using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace Vision_Core
{
    


    public class ContainerChain
    {


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class ChainRecording
        {
            public int unique_id;
            public int container_unique_id;
            public string container_id;
            public DateTime start_datetime;
            public DateTime stop_datetime;
            public List<Parts.VideoFile> videoFiles;
            public string status;
            public int totalDownloaded;
            public string converted;
            public List<Parts.EventAlarm> event_alarms = new List<Parts.EventAlarm>();
        }





        public List<ChainRecording> chainRecordings = new List<ChainRecording>();


        /////////////////////////////////
        /// SYSTEM > [START]
        /////////////////////////////////

        public MainWindow mainWindow;
        public System.Windows.Forms.ListView file_list; 
        public System.Windows.Forms.ListView container_events;
        public ConsoleManager console;



        public void Init(MainWindow thisMainWindow)
        {


            mainWindow = thisMainWindow;

            SetupUI();

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_container_chain_console, mainWindow.checkBox_container_chain_autoscroll, mainWindow.button_cc_clear_console );

            console.Log("ContainerChain() - Module Initiated.");

        }

        



        /////////////////////////////////
        /// UI > [START]
        /////////////////////////////////

        public void SetupUI()
        {
            file_list = mainWindow.listView_container_chain_files_found;
            container_events = mainWindow.listView_container_chain_container_chain_events;

            container_events.SelectedIndexChanged += new System.EventHandler(this.SelectListItem);
        }

        public void SelectListItem(object sender, EventArgs e)
        {
            if (container_events.SelectedItems.Count > 0)
            {
                var item = container_events.SelectedItems[0].Index;

                AddFileToList(chainRecordings[item]);
            }
            else {
                AddFileToList(null);
            };
        }

        public int GetSelectedContainerChainItem()
        {
            var item = -1;

            if (container_events.SelectedItems.Count > 0)
            {
                item = container_events.SelectedItems[0].Index;
            }

            return item;
        }


        public void UpdateContainerEventsUI()
        {
            int selectedContainerChainItem = GetSelectedContainerChainItem();

            container_events.Items.Clear();
            foreach (ChainRecording chainRecording in chainRecordings)
            {
                container_events.Items.Add(new ListViewItem(new string[] {
                    chainRecording.unique_id.ToString(),
                    chainRecording.status,
                    chainRecording.container_unique_id.ToString(),
                    chainRecording.container_id,
                    chainRecording.start_datetime.ToString(),
                    chainRecording.stop_datetime.ToString(),
                    chainRecording.videoFiles.Count.ToString(),
                    chainRecording.totalDownloaded.ToString() + "/100",
                    GetConvertedStatus(chainRecording),
                    GetUploadedStatus(chainRecording).ToString() + "/100",

                }));
            };


            if (selectedContainerChainItem >= 0)
            {
                container_events.Items[selectedContainerChainItem].Selected = true;
                container_events.Select();
            };
            //SelectListItem(null, null, selectedContainerChainItem);
        }

        public void UpdateContainerEventsUI_Update()
        {
            int selectedContainerChainItem = GetSelectedContainerChainItem();

            int listItemNumber = 0;
            foreach (ChainRecording chainRecording in chainRecordings)
            {

                container_events.Items[listItemNumber].SubItems[1].Text = chainRecording.status;

                container_events.Items[listItemNumber].SubItems[6].Text = chainRecording.videoFiles.Count.ToString();
                container_events.Items[listItemNumber].SubItems[7].Text = chainRecording.totalDownloaded.ToString() + "/100";
                
                container_events.Items[listItemNumber].SubItems[8].Text = GetConvertedStatus(chainRecording);

                container_events.Items[listItemNumber].SubItems[9].Text = GetUploadedStatus(chainRecording).ToString() + "/100";

                listItemNumber++;
            };

            if (selectedContainerChainItem >= 0)
            {
                UpdateFileList_Update(chainRecordings[selectedContainerChainItem]);
            };
        }


        public void AddFileToList(ChainRecording chainRecording)
        {
            file_list.Items.Clear();
            if (chainRecording == null)
            {
                return;
            };
            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                file_list.Items.Add(new ListViewItem(new string[] {
                    fileFound.video_unique_id.ToString(),
                    fileFound.file_name,
                    fileFound.status,
                    fileFound.start_datetime.ToString(),
                    fileFound.end_datetime.ToString(),
                    fileFound.downloaded.ToString() + "/100",
                    fileFound.converted.ToString(),
                    fileFound.uploaded.ToString() + "/100",
                }));
            }
        }


        public void UpdateFileList_Update(ChainRecording chainRecording)
        {
            int listItemNumber = 0;
            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                file_list.Items[listItemNumber].SubItems[1].Text = fileFound.file_name;
                file_list.Items[listItemNumber].SubItems[2].Text = fileFound.status;
                file_list.Items[listItemNumber].SubItems[5].Text = fileFound.downloaded.ToString() + "/100";
                file_list.Items[listItemNumber].SubItems[6].Text = fileFound.converted.ToString();
                file_list.Items[listItemNumber].SubItems[7].Text = fileFound.uploaded.ToString() + "/100";

                listItemNumber++;
            };
        }

        /////////////////////////////////
        /// ACTIONS PRE-PROCESS > [START]
        /////////////////////////////////

        public void SetContainerNumber(string containerNumber)
        {
            mainWindow.textBox_container_number.Text = containerNumber;
        }

        public void SetStartTime(DateTime startTime)
        {
            mainWindow.textBox_container_chain_start_time.Text = startTime.ToString();
        }

        public void SetStopTime(DateTime stopTime)
        {
            mainWindow.textBox_container_chain_stop_time.Text = stopTime.ToString();
        }

        public void SetContainerUniqueId(int container_unique_id)
        {
            mainWindow.textBox_container_unique_id.Text = container_unique_id.ToString();
        }




        public ChainRecording StartContainerChain(List<Parts.EventAlarm> event_alarms)
        {
            ChainRecording newChainRecording = new ChainRecording();

            var diffInSeconds = (Convert.ToDateTime(mainWindow.textBox_container_chain_stop_time.Text) - Convert.ToDateTime(mainWindow.textBox_container_chain_start_time.Text)).TotalSeconds;

            if (diffInSeconds < (int)mainWindow.numericUpDown_cc_min_length.Value)
            {
                console.Log("Event Not Long Enough (Minimum " + mainWindow.numericUpDown_cc_min_length.Value.ToString() + "seconds)");
                return newChainRecording;
            }

            newChainRecording.start_datetime = Convert.ToDateTime(mainWindow.textBox_container_chain_start_time.Text).AddSeconds((int)-mainWindow.numericUpDown_cc_preroll.Value);
            newChainRecording.stop_datetime = Convert.ToDateTime(mainWindow.textBox_container_chain_stop_time.Text);
            newChainRecording.container_id = mainWindow.textBox_container_number.Text;
            newChainRecording.container_unique_id = Convert.ToInt32(mainWindow.textBox_container_unique_id.Text);
            newChainRecording.status = "Created";
            newChainRecording.videoFiles = new List<Parts.VideoFile>();
            newChainRecording.event_alarms = event_alarms;


            ExtractRecording(newChainRecording);


            return newChainRecording;
        }






        

        public void Start()
        {
            //Log("Starting Container Chain Recording");
            mainWindow.textBox_container_chain_start_time.Text = DateTime.Now.ToString();
        }


        public void Download_Timeframe()
        {
            List<Parts.EventAlarm> event_alarms = new List<Parts.EventAlarm>();
            StartContainerChain(event_alarms);
        }


        public void Stop()
        {


            mainWindow.textBox_container_chain_stop_time.Text = DateTime.Now.AddSeconds((int)-mainWindow.numericUpDown_settings_record_lag.Value).ToString();


            var diffInSeconds = (Convert.ToDateTime(mainWindow.textBox_container_chain_stop_time.Text) - Convert.ToDateTime(mainWindow.textBox_container_chain_start_time.Text)).TotalSeconds;

            if ( diffInSeconds < (int)mainWindow.numericUpDown_cc_min_length.Value)
            {
                console.Log("Event Not Long Enough (Minimum " + mainWindow.numericUpDown_cc_min_length.Value.ToString() + "seconds)");
                return;
            }

            ChainRecording newChainRecording = new ChainRecording();
            newChainRecording.start_datetime = Convert.ToDateTime(mainWindow.textBox_container_chain_start_time.Text).AddSeconds((int)-mainWindow.numericUpDown_cc_preroll.Value);
            newChainRecording.stop_datetime = Convert.ToDateTime(mainWindow.textBox_container_chain_stop_time.Text);
            newChainRecording.container_id = mainWindow.textBox_container_number.Text;
            
            newChainRecording.status = "Created";
            newChainRecording.videoFiles = new List<Parts.VideoFile>();

            
            

            ExtractRecording(newChainRecording);

            
        }





        public void ExtractRecording(ChainRecording chainRecording)
        {

            if (mainWindow.HVS.userID < 0) {
                console.Log("Not Connected To Server");
                return;
            };


            console.Log("Extracting = Chain Recording -- " + chainRecording.start_datetime.ToString()  + " >> " + chainRecording.stop_datetime.ToString() );

            if (mainWindow.checkBox_cc_download_device_videos.Checked)
            {
                chainRecording.videoFiles = SearchForVideos(chainRecording);
            };

            
            foreach (Parts.VideoFile videoFile in SetTimeframeDownloads(chainRecording) )
            {
                chainRecording.videoFiles.Add(videoFile);
                
            };

            

            chainRecordings.Add(chainRecording);


            //VideoFileDatabase_Action(chainRecording, "insert");


            UpdateContainerEventsUI();
            DownloadFileList(chainRecording);

        }

        public void DownloadFileList(ChainRecording chainRecording)
        {

            foreach (Parts.VideoFile videoFile in chainRecording.videoFiles)
            {

                mainWindow.DL.AddToDownloadQueue(videoFile);

            }
        }


        


        public void CleanUpAllVideoFiles(ChainRecording chainRecording)
        {
            if (mainWindow.checkBox_cc_clean_up.Checked)
            {
                foreach (Parts.VideoFile videoFile in chainRecording.videoFiles)
                {
                    Tools.CleanUpVideoFile(videoFile);
                };
            };
            
        }
        

        /////////////////////////////////
        /// DATABASE
        /////////////////////////////////


        public void VideoFileDatabase_Action(ChainRecording chainRecording)
        {
            Thread dbThread = null;


            dbThread = new Thread(delegate () { InsertAllIntoDatabases(chainRecording); });


            dbThread.IsBackground = true;
            dbThread.Start();

        }

        public void InsertAllIntoDatabases(ChainRecording chainRecording)
        {

            bool all_uploaded = true;

            foreach (Parts.VideoFile videoFile in chainRecording.videoFiles)
            {
                if (videoFile.status != "Uploaded")
                {
                    all_uploaded = false;
                };
            };

            chainRecording.container_unique_id = mainWindow.DB.UpdateContainerWithContainerChainEvent_WebGUI(chainRecording);
            chainRecording.status = "Processed";
            chainRecording.unique_id = mainWindow.DB.InsertNewContainerChainEvent_VisionCore(chainRecording);

            if (all_uploaded)
            {
                mainWindow.DB.UpdateEventAlarms_VisionCore(chainRecording.event_alarms, "Processed");
                CleanUpAllVideoFiles(chainRecording);

                foreach (Parts.VideoFile videoFile in chainRecording.videoFiles)
                {
                    videoFile.relation_data.unique_id = chainRecording.unique_id;

                    console.ThreadLog(videoFile.relation_data.unique_id.ToString() + " == " + chainRecording.unique_id.ToString());

                    videoFile.video_unique_id = mainWindow.DB.InsertNewVideoFile_VisionCore(videoFile);
                };
            };
            
        }





        /////////////////////////////////
        /// ACTIONS PROCESS > [START]
        /////////////////////////////////

        public void DownloadProcessCompleted(ChainRecording chainRecording)
        {
            console.Log("Completed Download Process");
            //VideoFileDatabase_Action(chainRecording, "update");
        }

        public void ConvertProcessCompleted(ChainRecording chainRecording)
        {
            console.Log("Completed Convert Process");
            //VideoFileDatabase_Action(chainRecording, "update");
        }

        public void UploadProcessCompleted(ChainRecording chainRecording)
        {
            console.Log("Completed Upload Process");
            VideoFileDatabase_Action(chainRecording);
        }
        /////////////////////////////////
        /// ACTIONS POST-PROCESS > [START]
        /////////////////////////////////





        /////////////////////////////////
        /// DATA > [START]
        /////////////////////////////////

        public string GetConvertedStatus (ChainRecording chainRecording)
        {
            int convertedCount = 0;
            foreach (Parts.VideoFile videoFile in chainRecording.videoFiles)
            {
                if (videoFile.converted)
                {
                    convertedCount++;
                }
            }
            return convertedCount.ToString() + "/" + chainRecording.videoFiles.Count;
        }

        public int GetUploadedStatus(ChainRecording chainRecording)
        {
            int total = 0;

            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                total += fileFound.uploaded;
            }

            return total / chainRecording.videoFiles.Count;
        }


        public int GetContainerChainIndex(int unique_id)
        {
            int index = -1;
            int thisIndex = 0;
            foreach (ChainRecording chainRecording in chainRecordings)
            {
                if (chainRecording.unique_id == unique_id)
                {
                    index = thisIndex;
                    break;
                };
                thisIndex++;
            }

            return index;
        }



        public bool CheckIfAllFilesUploaded(ChainRecording chainRecording)
        {
            bool allUploaded = true;
            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                if (fileFound.uploaded < 100)
                {
                    allUploaded = false;
                    break;
                };
            }

            return allUploaded;
        }

        public bool CheckIfAllFilesConverted(ChainRecording chainRecording)
        {
            bool allConverted = true;
            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                if (!fileFound.converted)
                {
                    allConverted = false;
                    break;
                };
            }

            return allConverted;
        }



        public bool CheckIfAllFilesDownloaded(ChainRecording chainRecording)
        {
            bool allDownloaded = true;
            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                if (fileFound.downloaded < 100)
                {
                    allDownloaded = false;
                    break;
                };
            }

            return allDownloaded;
        }

        public int GetTotalDownloaded(ChainRecording chainRecording)
        {
            int totalDownloaded = 0;

            foreach (Parts.VideoFile fileFound in chainRecording.videoFiles)
            {
                totalDownloaded += fileFound.downloaded;
            }

            return totalDownloaded / chainRecording.videoFiles.Count;
        }




        public List<Parts.VideoFile> SetTimeframeDownloads(ChainRecording chainRecording)
        {
            List<Parts.VideoFile> allTimeframeVideoFiles = new List<Parts.VideoFile>();

            Parts.RelationData relation_data = new Parts.RelationData();
            relation_data.unique_id = chainRecording.unique_id;
            relation_data.type = "Container_Chain";
            relation_data.callback_complete = new VideoFileCallBack(mainWindow.CC.CallBack_Complete);
            relation_data.callback_downloaded = new VideoFileCallBack(mainWindow.CC.CallBack_Downloaded);
            relation_data.callback_converted = new VideoFileCallBack(mainWindow.CC.CallBack_Converted);
            relation_data.callback_uploaded = new VideoFileCallBack(mainWindow.CC.CallBack_Uploaded);
            relation_data.callback_update = new VideoFileAndStatusCallBack(mainWindow.CC.CallBack_Update);
            

            if (mainWindow.checkBox_cc_record_channel_1.Checked)
            {
                Parts.VideoFile fileFound = new Parts.VideoFile();

                fileFound.file_name = "Null";
                fileFound.start_datetime = chainRecording.start_datetime;
                fileFound.end_datetime = chainRecording.stop_datetime;
                fileFound.channel_number = 1;

                fileFound.relation_data = relation_data;
                fileFound.folder_name = chainRecording.unique_id.ToString() + "/";

                fileFound.status = "file found";
                fileFound.downloaded = 0;
                fileFound.converted = false;
                fileFound.uploaded = 0;
                fileFound.ftp_sub_directory = mainWindow.textBox_cc_ftp_sub_dir.Text;

                allTimeframeVideoFiles.Add(fileFound);
               
            };


            if (mainWindow.checkBox_cc_record_channel_2.Checked)
            {
                Parts.VideoFile fileFound = new Parts.VideoFile();

                fileFound.file_name = "Null";
                fileFound.start_datetime = chainRecording.start_datetime;
                fileFound.end_datetime = chainRecording.stop_datetime;
                fileFound.channel_number = 2;

                fileFound.relation_data = relation_data;
                fileFound.folder_name = chainRecording.unique_id.ToString() + "/";

                fileFound.status = "file found";
                fileFound.downloaded = 0;
                fileFound.converted = false;
                fileFound.uploaded = 0;
                fileFound.ftp_sub_directory = mainWindow.textBox_cc_ftp_sub_dir.Text;

                allTimeframeVideoFiles.Add(fileFound);

            };


            if (mainWindow.checkBox_cc_record_channel_3.Checked)
            {
                Parts.VideoFile fileFound = new Parts.VideoFile();

                fileFound.file_name = "Null";
                fileFound.start_datetime = chainRecording.start_datetime;
                fileFound.end_datetime = chainRecording.stop_datetime;
                fileFound.channel_number = 3;

                fileFound.relation_data = relation_data;
                fileFound.folder_name = chainRecording.unique_id.ToString() + "/";

                fileFound.status = "file found";
                fileFound.downloaded = 0;
                fileFound.converted = false;
                fileFound.uploaded = 0;
                fileFound.ftp_sub_directory = mainWindow.textBox_cc_ftp_sub_dir.Text;

                allTimeframeVideoFiles.Add(fileFound);

            };

            if (mainWindow.checkBox_cc_record_channel_4.Checked)
            {
                Parts.VideoFile fileFound = new Parts.VideoFile();

                fileFound.file_name = "Null";
                fileFound.start_datetime = chainRecording.start_datetime;
                fileFound.end_datetime = chainRecording.stop_datetime;
                fileFound.channel_number = 4;

                fileFound.relation_data = relation_data;
                fileFound.folder_name = chainRecording.unique_id.ToString() + "/";

                fileFound.status = "file found";
                fileFound.downloaded = 0;
                fileFound.converted = false;
                fileFound.uploaded = 0;
                fileFound.ftp_sub_directory = mainWindow.textBox_cc_ftp_sub_dir.Text;

                allTimeframeVideoFiles.Add(fileFound);

            };

           
            return allTimeframeVideoFiles;
        }






        public List<Parts.VideoFile> SearchForVideos(ChainRecording chainRecording)
        {

            Parts.RelationData relation_data = new Parts.RelationData();
            relation_data.unique_id = chainRecording.unique_id;
            relation_data.type = "Container_Chain";
            relation_data.callback_complete = new VideoFileCallBack(mainWindow.CC.CallBack_Complete);
            relation_data.callback_downloaded = new VideoFileCallBack(mainWindow.CC.CallBack_Downloaded);
            relation_data.callback_update = new VideoFileAndStatusCallBack(mainWindow.CC.CallBack_Update);



            DateTime dateTimeStart = chainRecording.start_datetime;
            DateTime dateTimeEnd = chainRecording.stop_datetime;


            CHCNetSDK.NET_DVR_FILECOND_V40 struFileCond_V40 = new CHCNetSDK.NET_DVR_FILECOND_V40();

            
            struFileCond_V40.dwFileType = 0xff; //0xff-All，0-Timing record，1-Motion detection，2-Alarm trigger，...
            struFileCond_V40.dwIsLocked = 0xff; //0-unfixed file，1-fixed file，0xff means all files（including fixed and unfixed files）

            console.Log("Searching For New Recordings [Channel=" + struFileCond_V40.lChannel + "][From Time=" + chainRecording.start_datetime.ToString() + "][To Time=" + chainRecording.stop_datetime.ToString() + "]");


            //Set the starting time to search video files
            struFileCond_V40.struStartTime.dwYear = (uint)dateTimeStart.Year;
            struFileCond_V40.struStartTime.dwMonth = (uint)dateTimeStart.Month;
            struFileCond_V40.struStartTime.dwDay = (uint)dateTimeStart.Day;
            struFileCond_V40.struStartTime.dwHour = (uint)dateTimeStart.Hour;
            struFileCond_V40.struStartTime.dwMinute = (uint)dateTimeStart.Minute;
            struFileCond_V40.struStartTime.dwSecond = (uint)dateTimeStart.Second;

            //Set the stopping time to search video files
            struFileCond_V40.struStopTime.dwYear = (uint)dateTimeEnd.Year;
            struFileCond_V40.struStopTime.dwMonth = (uint)dateTimeEnd.Month;
            struFileCond_V40.struStopTime.dwDay = (uint)dateTimeEnd.Day;
            struFileCond_V40.struStopTime.dwHour = (uint)dateTimeEnd.Hour;
            struFileCond_V40.struStopTime.dwMinute = (uint)dateTimeEnd.Minute;
            struFileCond_V40.struStopTime.dwSecond = (uint)dateTimeEnd.Second;



            List<Parts.VideoFile> allVideoFilesFound = new List<Parts.VideoFile>();


            if (mainWindow.checkBox_cc_record_channel_1.Checked)
            {
                struFileCond_V40.lChannel = 1; //Channel number
                foreach (Parts.VideoFile videoFile in mainWindow.HVS.SearchForVideos(struFileCond_V40, relation_data))
                {
                    allVideoFilesFound.Add(videoFile);
                };
            };

            if (mainWindow.checkBox_cc_record_channel_2.Checked)
            {
                struFileCond_V40.lChannel = 2; //Channel number
                foreach (Parts.VideoFile videoFile in mainWindow.HVS.SearchForVideos(struFileCond_V40, relation_data))
                {
                    allVideoFilesFound.Add(videoFile);
                };
            };

            if (mainWindow.checkBox_cc_record_channel_3.Checked)
            {
                struFileCond_V40.lChannel = 3; //Channel number
                foreach (Parts.VideoFile videoFile in mainWindow.HVS.SearchForVideos(struFileCond_V40, relation_data))
                {
                    allVideoFilesFound.Add(videoFile);
                };
            };

            if (mainWindow.checkBox_cc_record_channel_4.Checked)
            {
                struFileCond_V40.lChannel = 4; //Channel number
                foreach (Parts.VideoFile videoFile in mainWindow.HVS.SearchForVideos(struFileCond_V40, relation_data))
                {
                    allVideoFilesFound.Add(videoFile);
                };
            };

            foreach (Parts.VideoFile videoFile in allVideoFilesFound)
            {
                videoFile.downloadType = Parts.VideoFileDownloadType.DeviceFile;
            };

            return allVideoFilesFound;
        }






        /////////////////////////////////
        /// CALLBACKS > [START]
        /////////////////////////////////

        public void CallBack_Complete(Parts.VideoFile videoFile)
        {
            console.Log("Process Completed");
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
    
            int containerChainIndex = GetContainerChainIndex(videoFile.relation_data.unique_id);

            bool allConverted = CheckIfAllFilesConverted(chainRecordings[containerChainIndex]);

            if (allConverted)
            {
                chainRecordings[containerChainIndex].status = "All Converted";
                ConvertProcessCompleted(chainRecordings[containerChainIndex]);

            }
            else
            {
                chainRecordings[containerChainIndex].status = "Converting";
            };

            UpdateContainerEventsUI_Update();

            mainWindow.FTP.AddToUploaderQueue(videoFile);
        }





        public delegate void CallBack_Uploaded_CallBack(Parts.VideoFile videoFile);



        public void CallBack_Uploaded(Parts.VideoFile videoFile)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[1];

                paras[0] = videoFile;

                mainWindow.BeginInvoke(new CallBack_Converted_CallBack(Thread_CallBack_Uploaded), paras);
            }
            else
            {
                Thread_CallBack_Uploaded(videoFile);
            };
        }

        public void Thread_CallBack_Uploaded(Parts.VideoFile videoFile)
        {

            int containerChainIndex = GetContainerChainIndex(videoFile.relation_data.unique_id);

            bool allUploaded = CheckIfAllFilesUploaded(chainRecordings[containerChainIndex]);

            if (allUploaded)
            {
                chainRecordings[containerChainIndex].status = "All Uploaded";
                UploadProcessCompleted(chainRecordings[containerChainIndex]);

            }
            else
            {
                chainRecordings[containerChainIndex].status = "Uploading";
            };

            UpdateContainerEventsUI_Update();

        }







        public void CallBack_Downloaded(Parts.VideoFile videoFile)
        {
            int containerChainIndex = GetContainerChainIndex(videoFile.relation_data.unique_id);
            
            bool allDownloaded = CheckIfAllFilesDownloaded(chainRecordings[containerChainIndex]);

            if (allDownloaded)
            {
                chainRecordings[containerChainIndex].status = "All Downloaded";
                DownloadProcessCompleted(chainRecordings[containerChainIndex]);
            }
            else
            {
                chainRecordings[containerChainIndex].status = "Downloading";
            };

            UpdateContainerEventsUI_Update();

            mainWindow.VC.AddToConverterQueue(videoFile);
        }

        public void CallBack_Update(Parts.VideoFile videoFile, string status)
        {
            
            int containerChainIndex = GetContainerChainIndex(videoFile.relation_data.unique_id);
            chainRecordings[containerChainIndex].totalDownloaded = GetTotalDownloaded(chainRecordings[containerChainIndex]);
            bool allDownloaded = CheckIfAllFilesDownloaded(chainRecordings[containerChainIndex]);


            if (allDownloaded)
            {
                chainRecordings[containerChainIndex].status = "All Downloaded";
            }
            else
            {
                chainRecordings[containerChainIndex].status = "Downloading";
            };

            UpdateContainerEventsUI_Update();
        }
    }
}
