using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;

namespace Vision_Core
{
    class FTPUploader
    {
        

        public MainWindow mainWindow;
        public ConsoleManager console;
        public System.Windows.Forms.ListView uploadQueue_list;

        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            uploadQueue_list = mainWindow.listView_ftp_queue;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_ftp_console, mainWindow.checkBox_ftp_auto_scroll, mainWindow.button_ftp_clear_console);
            console.Log("FTPUploader() - Module Initiated.");

            Start_UploadCycle();

        }

        public void AddToUploaderQueue(Parts.VideoFile videoFile)
        {
            uploadQueue.Add(videoFile);
            console.Log("Added Video File To FTP Uploader = " + videoFile.file_name);

            UpdateUploadQueueUI();
        }



        List<Parts.VideoFile> uploadQueue = new List<Parts.VideoFile>();


        ////////////////////////////
        //  UI
        ////////////////////////////
        public void UpdateUploadQueueUI()
        {
            uploadQueue_list.Items.Clear();
            foreach (Parts.VideoFile videoFile in uploadQueue)
            {
                uploadQueue_list.Items.Add(new ListViewItem(new string[] {
                    videoFile.file_name,
                    videoFile.status,
                    videoFile.relation_data.type,
                    videoFile.relation_data.unique_id.ToString(),
                    videoFile.uploaded.ToString() + "/100",
                }));
            }
        }



        public void UpdateUploadQueueUI_Update()
        {

            int listItemNumber = 0;
            foreach (Parts.VideoFile videoFile in uploadQueue)
            {

                uploadQueue_list.Items[listItemNumber].SubItems[4].Text = videoFile.uploaded.ToString() + "/100";

                listItemNumber++;

            }

        }




        ////////////////////////////
        //  CYCLE PROCESSOR
        ////////////////////////////

        System.Windows.Forms.Timer cycleTimer;
        public int cycleInterval = 1000;
        public bool threadProcessorEnabled = true;


        private void Start_UploadCycle()
        {
            console.Log("Init Upload Thread");
            cycleTimer = new System.Windows.Forms.Timer();
            cycleTimer.Interval = cycleInterval;
            cycleTimer.Tick += new System.EventHandler(Cycle);
            cycleTimer.Start();
        }


        private void Cycle(object sender, EventArgs e)
        {
            //console.Log("Uploader Cycle Completed.");
            cycleTimer.Stop();

            if (uploadQueue.Count > 0)
            {
                Thread convertThread = new Thread(delegate () { Upload(uploadQueue[0]); });
                convertThread.IsBackground = true;
                convertThread.Start();
            }
            else
            {
                //console.Log("Uploader Cycle Restarting.");
                cycleTimer.Start();
            };


        }



        void RestartCycleProcess()
        {
            mainWindow.progressBar_ftp_upload_status.Value = 0;
            console.Log("Restarting Cycle");
            cycleTimer.Start();
            UpdateUploadQueueUI();
        }

        public delegate void RestartCycleCallback();

        void RestartCycle()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new RestartCycleCallback(RestartCycleProcess));
            }
            else
            {
                RestartCycleProcess();
            }
        }




        public void Upload(Parts.VideoFile videoFile)
        {
            console.ThreadLog("Uploading File = " + videoFile.file_name);


            string url = Vision_Core.Properties.Settings.Default.ftp_ip;
            string username = Vision_Core.Properties.Settings.Default.ftp_login;
            string password = Vision_Core.Properties.Settings.Default.ftp_password; 

            string fileURL = url + "/vision_core/" + videoFile.ftp_sub_directory + "/" + videoFile.saved_file_name;

            var request = (FtpWebRequest)WebRequest.Create(fileURL);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Stream fileStream;
            //using (fileStream = File.OpenRead(videoFile.file_path + "/" + videoFile.saved_file_name))
            //{
            //    using (Stream requestStream = request.GetRequestStream())
            //    {
            //        fileStream.CopyTo(requestStream);
            //        requestStream.Close();
            //    }
            //}

            //var response = (FtpWebResponse)request.GetResponse();

            console.ThreadLog("Loading File: " + videoFile.file_name);



            using (Stream fileStream = File.OpenRead(videoFile.file_name))
            using (Stream ftpStream = request.GetRequestStream())
            {
                mainWindow.progressBar_ftp_upload_status.Invoke(
                (MethodInvoker)delegate { mainWindow.progressBar_ftp_upload_status.Maximum = (int)fileStream.Length; });

                byte[] buffer = new byte[10240];
                int read;
                while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, read);
                    mainWindow.progressBar_ftp_upload_status.Invoke(
                        (MethodInvoker)delegate {
                            mainWindow.progressBar_ftp_upload_status.Value = (int)fileStream.Position;
                            videoFile.uploaded = (int)(((int)fileStream.Position / (int)fileStream.Length) * 100);
                        });
                    
                };

                
                ftpStream.Close();
            };



            //  UPDATING ACTUAL URL NOT FTP URL FOR HTTP ACCESS - HIDDEN IN DIR - "do_not_delete"
            fileURL = url + "/do_not_delete/vision_core/" + videoFile.ftp_sub_directory + "/" + videoFile.saved_file_name;
            fileURL = fileURL.Replace("ftp", "http");


            videoFile.ftp_url = fileURL;
            videoFile.status = "Uploaded";

            console.ThreadLog("Upload Completed >> " + videoFile.file_name);

            videoFile.relation_data.callback_uploaded(videoFile);

            uploadQueue.Remove(videoFile);


            RestartCycle();
        }



        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://example.com");
        //    ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
        //    using (var inputStream = File.OpenRead(fileName))
        //    using (var outputStream = ftpWebRequest.GetRequestStream())
        //    {
        //        var buffer = new byte[1024 * 1024];
        //        int totalReadBytesCount = 0;
        //        int readBytesCount;
        //        while ((readBytesCount = inputStream.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            outputStream.Write(buffer, 0, readBytesCount);
        //            totalReadBytesCount += readBytesCount;
        //            var progress = totalReadBytesCount * 100.0 / inputStream.Length;
        //            backgroundWorker1.ReportProgress((int)progress);
        //        }
        //    }
        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressBar.Value = e.ProgressPercentage;
        //}
    }
}
