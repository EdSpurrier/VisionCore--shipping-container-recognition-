using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;

namespace Vision_Core
{
    public static class Testing
    {
        public static MainWindow mainWindow = new MainWindow();
        public static void SetupControl(MainWindow mW)
        {
            mainWindow = mW;
            mainWindow.vConsole.Log("Testing() - Module Initiated.");

            SetupTesting();
        }

        public static void SetupTesting()
        {
            mainWindow.button_cd_test_image_extractor.Click += new System.EventHandler(ImageExtractor);
            mainWindow.button_cd_test_image_extractor_again.Click += new System.EventHandler(ImageExtractorAgain);


            mainWindow.button_cd_set_datetime.Click += new System.EventHandler(SetContainerDetectorTriggerTime);
            mainWindow.button_cd_trigger_settime.Click += new System.EventHandler(TriggerContainerDetectorSetTime);

            mainWindow.button_em_set_datetime_cd.Click += new System.EventHandler(SetEventAlarmTime_ContainerDetector);
            mainWindow.button_em_test_cd.Click += new System.EventHandler(TriggerEventAlarm_ContainerDetector);

            mainWindow.button_hvs_test.Click += new System.EventHandler(HSV_Test);

            mainWindow.button_cc_test_stitcher.Click += new System.EventHandler(CC_Test_Stitch);

            //mainWindow.button_cd_start.Click += new System.EventHandler(DatabaseCycle_ContainerDetector);

            mainWindow.button_test_vision_analyzer_single_image.Click += new System.EventHandler(SingleImage_VisualAnalyzer);
        }



        public static void SingleImage_VisualAnalyzer(object sender, EventArgs e)
        {
            mainWindow.vConsole.Log("Analyzing Single Image...");

            string file_name = OpenFile();
            mainWindow.vConsole.Log("Opened File = " + file_name);
            if (file_name == "None")
            {
                return;
            };

            mainWindow.VA.AnalyzeSingleImage(file_name);

        }


        public static void HSV_Test(object sender, EventArgs e)
        {
            mainWindow.vConsole.VarDump(mainWindow.HVS.iChannelNum);
        }




        public static string file_name_stored = "";
        public static void ImageExtractorAgain(object sender, EventArgs e)
        {
            ExtractImages(true);
        }

        public static void ImageExtractor(object sender, EventArgs e)
        {
            mainWindow.vConsole.Log("Creating Image Extractor Test");

            ExtractImages(false);

        }


        public static void SetContainerDetectorTriggerTime(object sender, EventArgs e)
        {
            mainWindow.textBox_cd_trigger_datetime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void TriggerContainerDetectorSetTime(object sender, EventArgs e)
        {
            if (mainWindow.textBox_cd_trigger_datetime.Text != string.Empty)
            {
                mainWindow.vConsole.Log("Testing Container Detector @ Time: " + mainWindow.textBox_cd_trigger_datetime.Text);
                DateTime datetime;

                if (DateTime.TryParseExact(mainWindow.textBox_cd_trigger_datetime.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    mainWindow.vConsole.Log("DateTime Valid  : " + datetime);
                    mainWindow.CD.TriggerEvent(datetime);
                }
                else
                {
                    mainWindow.vConsole.Log("DateTime Invalid");
                };

            }
            else
            {
                mainWindow.vConsole.Log("Testing Container Detector @ Time: NOT SET");
            }

        }




        public static void ExtractImages(bool same_again)
        {
            string file_name = "none";
            if (!same_again)
            {
                file_name = OpenFile();
                mainWindow.vConsole.Log("Opened File = " + file_name);
                file_name_stored = file_name;
            }
            else
            {
                file_name = file_name_stored;
            };


            Parts.VideoFile videoFile = CreateVideoFileBase(file_name);

            SetVideoFileDownloaded(videoFile);

            SetupVideoFileForImageExtraction(videoFile);

            SetVideoContainerDetector(videoFile);

            Tools.OutputVideoFileData(videoFile);

            ContainerDetector.Detection detection = CreateContainerDetector(videoFile, "Downloaded");

            mainWindow.CD.detections.Add(detection);
            mainWindow.CD.UpdateContainerEventsUI();

            videoFile.relation_data.callback_downloaded(videoFile);
        }


        public static string OpenFile()
        {
            var openFileDialog1 = new OpenFileDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                return "None";
            };

        }

        static int unique_id = 1;


        /////////////////////////////////
        /// VIDEO FILE
        /////////////////////////////////

        public static Parts.VideoFile CreateVideoFileBase(string file_name)
        {
            unique_id++;

            Parts.VideoFile videoFile = new Parts.VideoFile();

            videoFile.video_unique_id = unique_id;
            videoFile.file_name = file_name;
            videoFile.start_datetime = DateTime.Now;
            videoFile.end_datetime = DateTime.Now;

            videoFile.ftp_sub_directory = "Not Set";
            videoFile.ftp_url = "Not Set";
            videoFile.keyFrames = new List<Parts.KeyFrameImage>();

            return videoFile;
        }


        public static void SetVideoFileDownloaded(Parts.VideoFile videoFile)
        {
            videoFile.file_path = Path.GetDirectoryName(videoFile.file_name);
            videoFile.saved_file_name = Path.GetFileName(videoFile.file_name);
            videoFile.downloaded = 100;
        }

        public static void SetupVideoFileForImageExtraction(Parts.VideoFile videoFile)
        {
            videoFile.downloadType = Parts.VideoFileDownloadType.Timeframe;
            videoFile.channel_number = (int)mainWindow.CD.recording_channel.Value;

        }

        public static void SetVideoContainerDetector(Parts.VideoFile videoFile)
        {
            Parts.RelationData relation_data = new Parts.RelationData();
            relation_data.unique_id = unique_id;
            relation_data.type = "Container_Detector";
            relation_data.callback_complete = new VideoFileCallBack(mainWindow.CD.CallBack_Complete);
            relation_data.callback_downloaded = new VideoFileCallBack(mainWindow.CD.CallBack_Downloaded);
            relation_data.callback_converted = new VideoFileCallBack(mainWindow.CD.CallBack_Converted);
            relation_data.callback_uploaded = new VideoFileCallBack(mainWindow.CD.CallBack_Uploaded);
            relation_data.callback_update = new VideoFileAndStatusCallBack(mainWindow.CD.CallBack_Update);
            relation_data.callback_extracted = new VideoFileAndStatusCallBack(mainWindow.CD.CallBack_Extracted);
            relation_data.callback_vision = new VideoFileAndStatusCallBack(mainWindow.CD.CallBack_Vision);
            videoFile.relation_data = relation_data;
        }







        /////////////////////////////////
        /// CONTAINER DETECTOR
        /////////////////////////////////


        public static ContainerDetector.Detection CreateContainerDetector(Parts.VideoFile videoFile, string status)
        {
            mainWindow.vConsole.Log("Creating New Container Detection");
            ContainerDetector.Detection newDetection = new ContainerDetector.Detection();
            newDetection.event_datetime = DateTime.Now;

            newDetection.start_datetime = newDetection.event_datetime.AddSeconds((int)-mainWindow.numericUpDown_cd_preroll.Value);
            newDetection.stop_datetime = newDetection.event_datetime.AddSeconds((int)mainWindow.numericUpDown_cd_recording_time.Value);
            newDetection.recording_time = (int)mainWindow.numericUpDown_cd_recording_time.Value;


            newDetection.container_id = "None";
            newDetection.status = status;
            newDetection.unique_id = unique_id;

            newDetection.videoFile = videoFile;

            newDetection.parent_unique_id = -1;

            return newDetection;
        }




        /////////////////////////////////
        /// EVENT SYSTEM
        /////////////////////////////////

        public static void SetEventAlarmTime_ContainerDetector(object sender, EventArgs e)
        {
            mainWindow.textBox_em_set_datetime_cd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void TriggerEventAlarm_ContainerDetector(object sender, EventArgs e)
        {

            if (mainWindow.textBox_em_set_datetime_cd.Text != string.Empty)
            {
                mainWindow.vConsole.Log("Testing Event Alarm >> Container Detector @ Time: " + mainWindow.textBox_em_set_datetime_cd.Text);
                DateTime datetime;

                if (DateTime.TryParseExact(mainWindow.textBox_em_set_datetime_cd.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    mainWindow.vConsole.Log("DateTime Valid  : " + datetime);

                    mainWindow.EM.TriggerEventAlarm(datetime, true);

                }
                else
                {
                    mainWindow.vConsole.Log("DateTime Invalid");
                };

            }
            else
            {
                mainWindow.vConsole.Log("Testing Event Alarm >> Container Detector @ Time: NOT SET");
            }
        }



        /////////////////////////////////
        /// CONTAINER CHAIN
        /////////////////////////////////

        public static void CC_Test_Stitch(object sender, EventArgs e)
        {
            mainWindow.vConsole.Log("TEST: Init Video Stitch Test..");


            mainWindow.vConsole.Log("TEST: Select a video file with multiple video files in its dir");


            string file_name = OpenFile();
            mainWindow.vConsole.Log("TEST: Creating Video File = " + file_name);
            Parts.VideoFile videoFile = CreateVideoFileBase(file_name);
            
            mainWindow.vConsole.Log("DONE: Created Video File");


            mainWindow.vConsole.Log("TEST: Creating Container Chain.");
            ContainerChain.ChainRecording containerChain = CreateContainerChain(videoFile);
            SetVideoContainerChain(videoFile);

            mainWindow.vConsole.Log("TEST: Setting Video File & Container Chain For Testing = ALL DOWNLOADED");
            SetContainerChainAllDownloaded(containerChain);
            mainWindow.vConsole.Log("DONE: ALL DOWNLOADED");


            mainWindow.vConsole.Log("TEST: Inserting Container Chain to Module.");
            mainWindow.CC.chainRecordings.Add(containerChain);
            mainWindow.CC.UpdateContainerEventsUI();

            mainWindow.vConsole.Log("TEST: Count File Splits.");
            containerChain.videoFiles[0].split_file_parts = mainWindow.DL.CountSplitFileParts(containerChain.videoFiles[0]);

            mainWindow.vConsole.Log("TEST: Calling Back - Download Completed.");

            mainWindow.vConsole.Log("TEST: READING UI = " + containerChain.videoFiles[0].relation_data.unique_id.ToString() );

            containerChain.videoFiles[0].relation_data.callback_downloaded(containerChain.videoFiles[0]);
        }

        public static void SetContainerChainAllDownloaded(ContainerChain.ChainRecording containerChain)
        {
            foreach(Parts.VideoFile videoFile in containerChain.videoFiles)
            {
                SetVideoFileDownloaded(videoFile);

                videoFile.start_datetime = containerChain.start_datetime;
                videoFile.end_datetime = containerChain.stop_datetime;
                videoFile.channel_number = 1;
                videoFile.archive_save_folder = videoFile.file_path;
                videoFile.folder_name = containerChain.unique_id.ToString() + "/";
                videoFile.status = "Downloaded";
                videoFile.downloaded = 100;
                videoFile.converted = false;
                videoFile.uploaded = 0;
                videoFile.ftp_sub_directory = mainWindow.textBox_cc_ftp_sub_dir.Text;
                videoFile.relation_data.unique_id = containerChain.unique_id;
            };
        }



        public static void SetVideoContainerChain(Parts.VideoFile videoFile)
        {
            Parts.RelationData relation_data = new Parts.RelationData();
            
            relation_data.type = "Container_Detector";
            relation_data.callback_complete = new VideoFileCallBack(mainWindow.CC.CallBack_Complete);
            relation_data.callback_downloaded = new VideoFileCallBack(mainWindow.CC.CallBack_Downloaded);
            relation_data.callback_converted = new VideoFileCallBack(mainWindow.CC.CallBack_Converted);
            relation_data.callback_uploaded = new VideoFileCallBack(mainWindow.CC.CallBack_Uploaded);
            relation_data.callback_update = new VideoFileAndStatusCallBack(mainWindow.CC.CallBack_Update);
            videoFile.relation_data = relation_data;
        }

        public static ContainerChain.ChainRecording CreateContainerChain(Parts.VideoFile videoFile)
        {
            
            ContainerChain.ChainRecording newContainerChain = new ContainerChain.ChainRecording();

            newContainerChain.start_datetime = DateTime.Now.AddSeconds((int)-mainWindow.numericUpDown_cc_preroll.Value);
            newContainerChain.stop_datetime = DateTime.Now;
            newContainerChain.container_id = mainWindow.textBox_container_number.Text;
            newContainerChain.container_unique_id = Convert.ToInt32(mainWindow.textBox_container_unique_id.Text);
            newContainerChain.status = "Created";
            newContainerChain.videoFiles = new List<Parts.VideoFile>();

            newContainerChain.videoFiles.Add(videoFile);

            newContainerChain.event_alarms = new List<Parts.EventAlarm>();

            newContainerChain.unique_id = 666111;

            mainWindow.vConsole.Log("DONE: Created New Container Chain");

            return newContainerChain;
        }

    }
}
