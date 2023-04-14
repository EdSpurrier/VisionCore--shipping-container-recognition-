using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using VidCon = NReco.VideoConverter;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Vision_Core
{
    class VideoConverter
    {

        public MainWindow mainWindow;
        public ConsoleManager console;
        public System.Windows.Forms.ListView convertQueue_list;

        System.Windows.Forms.Timer cycleTimer;
        public int cycleInterval = 1000;
        public bool threadProcessorEnabled = true;


        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;
            convertQueue_list = mainWindow.listView_vc_queue;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_vc_console, mainWindow.checkBox_vc_auto_scroll, mainWindow.button_vc_clear_console);
            console.Log("VideoConverter() - Module Initiated.");


            Start_ConvertCycle();
        }



        ////////////////////////////
        //  UI
        ////////////////////////////
        public void UpdateConvertQueueUI()
        {
            convertQueue_list.Items.Clear();
            foreach (Parts.VideoFile convertFile in converterQueue)
            {
                convertQueue_list.Items.Add(new ListViewItem(new string[] {
                    convertFile.file_name,
                    convertFile.status,
                    convertFile.relation_data.type,
                    convertFile.relation_data.unique_id.ToString(),
                    convertFile.converted.ToString(),
                }));
            }
        }


        ////////////////////////////
        //  CYCLE PROCESSOR
        ////////////////////////////
        private void Start_ConvertCycle()
        {
            console.Log("Init Converter Thread");
            cycleTimer = new System.Windows.Forms.Timer();
            cycleTimer.Interval = cycleInterval;
            cycleTimer.Tick += new System.EventHandler(Cycle);
            cycleTimer.Start();
        }

   
        private void Cycle(object sender, EventArgs e)
        {
            //console.Log("Converter Cycle Completed.");
            cycleTimer.Stop();

            if (converterQueue.Count > 0)
            {
                Thread convertThread = new Thread(delegate () { ConvertVideo(converterQueue[0]); });
                convertThread.IsBackground = true;
                convertThread.Start();
            }
            else
            {
                //console.Log("Converter Cycle Restarting.");
                cycleTimer.Start();
            };


        }




        void RestartCycleProcess()
        {
            console.Log("Restarting Cycle");
            cycleTimer.Start();
            UpdateConvertQueueUI();
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




        public void AddToConverterQueue(Parts.VideoFile videoFile)
        {
            //mainWindow.vConsole.Log("Conversion Thread Status == " + convertThread.IsAlive.ToString() );

            if (!threadProcessorEnabled)
            {
                mainWindow.vConsole.Log(">>> THREAD PROCESSOR DISABLED");
                return;
            }

            converterQueue.Add(videoFile);
            console.Log("Added New Video File To Convert");

            UpdateConvertQueueUI();

        }




        ////////////////////////////
        //  ACTIONS
        ////////////////////////////

        List<Parts.VideoFile> converterQueue = new List<Parts.VideoFile>();

        public void ConvertVideo(Parts.VideoFile videoFile)
        {
            videoFile.status = "Converting";

            if (videoFile.split_file_parts > 1)
            {
                Stopwatch watch_stitch = new Stopwatch();
                watch_stitch.Start();
                console.ThreadLog("Starting Stitch = " + watch_stitch.Elapsed.TotalSeconds.ToString());
                VideoStitcher.StitchVideo(videoFile, console);
                watch_stitch.Stop();
                console.ThreadLog("Finished Stitch = " + watch_stitch.Elapsed.TotalSeconds.ToString());

                
            }
            else {
                console.ThreadLog("No Files To Stitch...");
            }
            


            Stopwatch watch = new Stopwatch();
            watch.Start();
            console.ThreadLog("Starting Conversion = " + watch.Elapsed.TotalSeconds.ToString() );


            string inputVideoFile = videoFile.archive_save_folder + "/" + videoFile.saved_file_name;
            string outputFolder = videoFile.archive_save_folder + "/" + Path.GetFileNameWithoutExtension(videoFile.file_name) + "/";
            string outputVideoFile = outputFolder + "/" + videoFile.saved_file_name;


            Tools.CheckFolderExists(outputFolder);


            VidCon.FFMpegInput[] inputs = new VidCon.FFMpegInput[1];
            inputs[0] = new VidCon.FFMpegInput(inputVideoFile);

            var ffMpeg = new VidCon.FFMpegConverter();

            ffMpeg.ConvertMedia(inputs, outputVideoFile, "mp4", GetConversionSettings() );

            watch.Stop();
            console.ThreadLog("Finished Conversion = " + watch.Elapsed.TotalSeconds.ToString());
            videoFile.converted = true;

            videoFile.relation_data.callback_converted(videoFile);

            videoFile.status = "Converted";
            videoFile.file_name = outputVideoFile;
            videoFile.file_path = outputFolder;

            converterQueue.Remove(videoFile);

            RestartCycle();
        }



        public VidCon.ConvertSettings GetConversionSettings()
        {
            var convertSettings = new VidCon.ConvertSettings();

            if (Vision_Core.Properties.Settings.Default.conversion_quality == "1080x1920")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.hd1080;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "1280x720")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.hd720;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "1366x768")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.wxga1366x768;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "852x480")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.hd480;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "640x480")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.svga800x600;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "320x200")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.qvga320x200;
            };

            return convertSettings;
        }




        public void SplitVideo(string inputVideoFile, string outputVideoFile, int StartTime, int EndTime)
        {
            console.Log("Splitting Video File");

            VidCon.FFMpegInput[] inputs = new VidCon.FFMpegInput[1];
            inputs[0] = new VidCon.FFMpegInput(inputVideoFile);


            var ffMpeg = new VidCon.FFMpegConverter();

            var convertSettings = new VidCon.ConvertSettings();

            if (Vision_Core.Properties.Settings.Default.conversion_quality == "1080x1920")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.hd1080;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "1280x720")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.hd720;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "1366x768")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.wxga1366x768;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "852x480")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.hd480;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "640x480")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.svga800x600;
            }
            else if (Vision_Core.Properties.Settings.Default.conversion_quality == "320x200")
            {
                convertSettings.VideoFrameSize = VidCon.FrameSize.qvga320x200;
            };


            convertSettings.Seek = StartTime;

            convertSettings.MaxDuration = (EndTime - StartTime);


            ffMpeg.ConvertMedia(inputVideoFile, null, outputVideoFile, null, convertSettings);
        }
    }
}
