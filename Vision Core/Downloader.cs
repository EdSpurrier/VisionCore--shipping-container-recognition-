using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace Vision_Core
{
    class Downloader
    {


        public MainWindow mainWindow;

        public System.Windows.Forms.ListView downloadQueue_list;
        public ConsoleManager console;


        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            downloadQueue_list = mainWindow.listView_download_queue;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_downloader_console, mainWindow.checkBox_downloader_console_autoscroll, mainWindow.button_downloader_clear_console);
            console.Log("Downloader() - Module Initiated.");
        }


        ////////////////////////////
        //  CYCLE TIMER
        ////////////////////////////

        private static System.Timers.Timer retryTimer;
        public int countdown_cycle = 5000;
        public int current_countdown_cycle = 0;

        public void StartRetryCountdown()
        {
            retryTimer = new System.Timers.Timer();
            retryTimer.Interval = 1000;
            current_countdown_cycle = countdown_cycle;

            console.Log("Starting Count Down Timer");

            retryTimer.Elapsed += (s, e) =>
            {
                RetryCountdown_Tick(s, e);
            };
            retryTimer.Start();
        }

        public void RetryCountdown_Tick(object sender, EventArgs e)
        {
            current_countdown_cycle -= 1000;
            UpdateDownloadQueueUI_Update_Thread();
            if (current_countdown_cycle <= 0)
            {
                current_countdown_cycle = 0;
                retryTimer.Stop();

                if (downloadQueue.Count > 0)
                {
                    DownloadVideo_Thread(downloadQueue[0]);
                };
                
            };
        }



        ////////////////////////////
        //  UI
        ////////////////////////////

        public delegate void UpdateDownloadQueueUI_CallBack();

        void UpdateDownloadQueueUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateDownloadQueueUI_CallBack(UpdateDownloadQueueUI));
            }
            else
            {
                UpdateDownloadQueueUI();
            }
        }

        public void UpdateDownloadQueueUI()
        {
            downloadQueue_list.Items.Clear();
            foreach (Parts.VideoFile downloadFile in downloadQueue)
            {
                downloadQueue_list.Items.Add(new ListViewItem(new string[] {
                    downloadFile.file_name,
                    downloadFile.status,
                    downloadFile.channel_number.ToString(),
                    downloadFile.start_datetime.ToString(),
                    downloadFile.end_datetime.ToString(),
                    downloadFile.relation_data.type,
                    downloadFile.relation_data.unique_id.ToString(),
                    downloadFile.downloadType.ToString(),
                    downloadFile.downloaded.ToString() + "/100"
                }));
            }
        }



        public delegate void UpdateDownloadQueueUI_Update_CallBack();

        void UpdateDownloadQueueUI_Update_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateDownloadQueueUI_Update_CallBack(UpdateDownloadQueueUI_Update));
            }
            else
            {
                UpdateDownloadQueueUI_Update();
            }
        }


        public void UpdateDownloadQueueUI_Update()
        {

            int listItemNumber = 0;
            foreach (Parts.VideoFile downloadFile in downloadQueue)
            {

                downloadQueue_list.Items[listItemNumber].SubItems[8].Text = downloadFile.downloaded.ToString() + "/100";

                listItemNumber++;

            };
            mainWindow.textBox_downloader_countdown_timer.Text = (current_countdown_cycle / 1000).ToString() + "s (retry)";
        }





        ////////////////////////////
        //  DOWNLOADER
        ////////////////////////////

        private Int32 downloadController = -1;
        List<Parts.VideoFile> downloadQueue = new List<Parts.VideoFile>();
        bool downloading = false;

        public void AddToDownloadQueue(Parts.VideoFile videoFile)
        {
            downloadQueue.Add(videoFile);
            ProcessDownloadQueue();
        }


        public void ProcessDownloadQueue()
        {

            UpdateDownloadQueueUI_Thread();

            if (downloadQueue.Count > 0)
            {
                console.ThreadLog("Processing Download Queue");

                if (downloading)
                {
                    console.ThreadLog("Currently Downloading.");
                    return;
                }
                else {
                    DownloadVideo_Thread(downloadQueue[0]);
                };

                
            }
            else {
                console.ThreadLog("Completed Download Queue");
            };

        }


        public void ResetDownloader(bool error)
        {

            downloadController = -1;
            mainWindow.timer_download.Stop();
            mainWindow.timer_download.Enabled = false;
            string file_name = downloadQueue[0].archive_save_folder + "/" + downloadQueue[0].saved_file_name;

            if (File.Exists(file_name))
            {
                FileInfo download_file_info = new FileInfo(file_name);

                if (download_file_info.Length <= 0)
                {
                    console.ThreadLog("Download Error = File Empty");
                    error = true;
                };

                console.ThreadLog("File Size = " + download_file_info.Length.ToString() + "b");

            }
            else {

                console.ThreadLog("Download Error = File Does Not Exist");
                error = true;
            };


            if (error)
            {
                downloadQueue[0].status = "error";
                console.ThreadLog("Download Error = Restarting Download Queue");
                downloadQueue[0].downloaded = 0;
                downloadQueue[0].relation_data.callback_update(downloadQueue[0], "Waiting To Download");
                StartRetryCountdown();
            }
            else
            {
                downloadQueue[0].split_file_parts = CountSplitFileParts(downloadQueue[0]);

                console.ThreadLog( "!IMPORTANT! == File Count >>> " + downloadQueue[0].split_file_parts.ToString() );

                downloading = false;
                downloadQueue[0].status = "Downloaded";
                downloadQueue[0].file_name = file_name;
                downloadQueue[0].relation_data.callback_downloaded(downloadQueue[0]);
                downloadQueue.Remove(downloadQueue[0]);
                ProcessDownloadQueue();
            };
        }

        

        public int CountSplitFileParts(Parts.VideoFile videoFile)
        {
            string striped_file_name = System.IO.Path.GetFileNameWithoutExtension(videoFile.saved_file_name);
            string[] filePaths = Directory.GetFiles(videoFile.archive_save_folder, striped_file_name + "*.*");
            console.ThreadLog( "Searching For File Splits[" + videoFile.relation_data.unique_id + "]: " + filePaths.Length.ToString() );
            return filePaths.Length;
        }


        public delegate void DownloadVideo_CallBack(Parts.VideoFile videoFile);

        void DownloadVideo_Thread(Parts.VideoFile videoFile)
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new DownloadVideo_CallBack(DownloadVideo), videoFile);
            }
            else
            {
                DownloadVideo(videoFile);
            }
        }



        public void DownloadVideo(Parts.VideoFile videoFile)
        {


            if (downloadController >= 0)
            {
                //ErrorHandler.LogError(1111110, "Currently Downloading - Can't Download = " + videoFile.file_name);
                console.ThreadLog("Currently Downloading Adding New Video File To Download Queue.");
                return;
            }

            downloading = true;

            string saveFileName = videoFile.relation_data.type + "__" + videoFile.relation_data.unique_id.ToString() + "__" + videoFile.channel_number + "__" + videoFile.start_datetime.ToString("dd-MM-yyyy-HH-mm-ss") + "__" + videoFile.end_datetime.ToString("dd-MM-yyyy-HH-mm-ss") + ".mp4";

            string archive_save_folder = mainWindow.textBox_save_folder.Text + "/" + videoFile.start_datetime.ToString("dd-MM-yyyy") + "/" + videoFile.folder_name;

            Tools.CheckFolderExists(archive_save_folder);


            if (videoFile.downloadType == Parts.VideoFileDownloadType.DeviceFile)
            {
                downloadController = CHCNetSDK.NET_DVR_GetFileByName(mainWindow.HVS.userID, videoFile.file_name, archive_save_folder + "/" + saveFileName);
            }
            else if (videoFile.downloadType == Parts.VideoFileDownloadType.Timeframe)
            {

                DateTime dateTimeStart = videoFile.start_datetime;
                DateTime dateTimeEnd = videoFile.end_datetime;

                CHCNetSDK.NET_DVR_TIME startTime = new CHCNetSDK.NET_DVR_TIME();
                startTime.dwYear = (uint)dateTimeStart.Year;
                startTime.dwMonth = (uint)dateTimeStart.Month;
                startTime.dwDay = (uint)dateTimeStart.Day;
                startTime.dwHour = (uint)dateTimeStart.Hour;
                startTime.dwMinute = (uint)dateTimeStart.Minute;
                startTime.dwSecond = (uint)dateTimeStart.Second;


                CHCNetSDK.NET_DVR_TIME endTime = new CHCNetSDK.NET_DVR_TIME();
                endTime.dwYear = (uint)dateTimeEnd.Year;
                endTime.dwMonth = (uint)dateTimeEnd.Month;
                endTime.dwDay = (uint)dateTimeEnd.Day;
                endTime.dwHour = (uint)dateTimeEnd.Hour;
                endTime.dwMinute = (uint)dateTimeEnd.Minute;
                endTime.dwSecond = (uint)dateTimeEnd.Second;



                downloadController = CHCNetSDK.NET_DVR_GetFileByTime(mainWindow.HVS.userID, mainWindow.HVS.iChannelNum[(videoFile.channel_number-1)], ref startTime, ref endTime, archive_save_folder + "/" + saveFileName);

                

            }



            if (downloadController < 0)
            {
                ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "NET_DVR_GetFileByName failed");
                ResetDownloader(true);
                return;
            }


            uint iOutValue = 0;


            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(downloadController, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "NET_DVR_PLAYSTART failed");
                ResetDownloader(true);
                return;
            };


            videoFile.status = "Downloading";

            videoFile.saved_file_name = saveFileName;
            videoFile.archive_save_folder = archive_save_folder;
            videoFile.file_path = archive_save_folder;

            mainWindow.timer_download.Interval = 1000;
            mainWindow.timer_download.Enabled = true;
            console.ThreadLog("Download Started => " + videoFile.file_name);

            console.ThreadLog(archive_save_folder + "/" + saveFileName);

        }



        public void DownloadProgressTick(object sender, EventArgs e)
        {

            mainWindow.progressBar_download.Maximum = 100;
            mainWindow.progressBar_download.Minimum = 0;

            int iPos = 0;


            //Get downloading process
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(downloadController);

            downloadQueue[0].downloaded = iPos;
            UpdateDownloadQueueUI_Update_Thread();

            downloadQueue[0].relation_data.callback_update(downloadQueue[0], "Downloading");

            if ((iPos > mainWindow.progressBar_download.Minimum) && (iPos < mainWindow.progressBar_download.Maximum))
            {
                mainWindow.progressBar_download.Value = iPos;
            };

            if (iPos == 100)  //Finish downloading
            {
                mainWindow.progressBar_download.Value = iPos;
                if (!CHCNetSDK.NET_DVR_StopGetFile(downloadController))
                {
                    ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "NET_DVR_StopGetFile failed");
                    return;
                }

                console.ThreadLog("Download Completed.");
                mainWindow.progressBar_download.Value = 0;
                

                ResetDownloader(false);

            };

            if (iPos == 200) //Network abnormal,download failed
            {
                ErrorHandler.LogError(1111110, "The downloading is abnormal for the abnormal network!");

                ResetDownloader(true);
            };

        }

        



    }
}
