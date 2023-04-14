using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using VidCon = NReco.VideoConverter;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Threading;

namespace Vision_Core
{
    class ImageExtractor
    {


        public MainWindow mainWindow;

        public System.Windows.Forms.ListView extractorQueue_list;
        public ConsoleManager console;

        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            extractorQueue_list = mainWindow.listView_ie_extractor_queue;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_ie_console, mainWindow.checkBox_ie_console_autoscroll, mainWindow.button_ie_clear_console);
            console.Log("ImageExtractor() - Module Initiated.");

        }




        ////////////////////////////
        //  UI
        ////////////////////////////

        public void UpdateExtractorQueueUI()
        {
            extractorQueue_list.Items.Clear();

 
            foreach (Parts.VideoFile extractorFile in extractorQueue.ToList())
            {
                extractorQueue_list.Items.Add(new ListViewItem(new string[] {
                    extractorFile.file_name,
                    extractorFile.status,
                    extractorFile.relation_data.type,
                    extractorFile.relation_data.unique_id.ToString(),
                    extractorFile.keyFrames.Count.ToString()
                }));
            };


            if (extractorQueue.Count > 0)
            {
                extractorQueue[0].relation_data.callback_update(extractorQueue[0], "Extracting Keyframes");

            };
            
        }


        public delegate void UpdateExtractorQueueUI_CallBack();

        void UpdateExtractorQueueUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateExtractorQueueUI_CallBack(UpdateExtractorQueueUI));
            }
            else
            {
                UpdateExtractorQueueUI();
            }
        }




        ////////////////////////////
        //  EXTRACTOR
        ////////////////////////////

        List<Parts.VideoFile> extractorQueue = new List<Parts.VideoFile>();
        bool extracting = false;

        public void AddToExtractorQueue(Parts.VideoFile videoFile)
        {
            extractorQueue.Add(videoFile);

            if (extracting)
            {
                console.ThreadLog("Currently Extracting. Adding To Queue");
                UpdateExtractorQueueUI();
                return;
            }
            else
            {
                StartProcessExtractorQueueThread();
            };

        }

        public void StartProcessExtractorQueueThread()
        {
            Thread convertThread = new Thread(delegate () { ProcessExtractorQueue(); });
            convertThread.IsBackground = true;
            convertThread.Start();
        }

        public void ProcessExtractorQueue()
        {
            UpdateExtractorQueueUI_Thread();

            if (extractorQueue.Count > 0)
            {
                console.ThreadLog("Processing Extractor Queue");

                if (extracting)
                {
                    console.ThreadLog("Currently Extracting.");
                    return;
                }
                else
                {
                    ExtractFrames(extractorQueue[0]);
                };
            }
            else
            {
                console.ThreadLog("Completed Extractor Queue");
            };

        }


        public void ResetExtractor(bool error)
        {
            if (error)
            {
                extractorQueue[0].status = "Extractor Error";
                console.ThreadLog("Extractor Error = Restarting Download Queue");
                extractorQueue[0].keyFrames = new List<Parts.KeyFrameImage>();
                extractorQueue[0].relation_data.callback_update(extractorQueue[0], "Extractor Error");
            }
            else
            {
                extracting = false;
                extractorQueue[0].status = "Keyframes Extracted";
                extractorQueue[0].relation_data.callback_extracted(extractorQueue[0], "Keyframes Extracted");
                extractorQueue.Remove(extractorQueue[0]);
                ProcessExtractorQueue();
            };
        }







        public void ExtractFrames(Parts.VideoFile videoFile)
        {
            extracting = true;
            string directoryPath = System.IO.Path.GetDirectoryName(videoFile.file_name) + "/" + Path.GetFileNameWithoutExtension(videoFile.file_name) + "/";

            Tools.CheckFolderExists(directoryPath);

            videoFile.keyframe_path = directoryPath;

            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = videoFile.file_name };

                engine.GetMetadata(mp4);
                console.ThreadLog(videoFile.file_name);
                console.ThreadVarDump(mp4.Metadata);

                if (mp4.Metadata == null)
                {
                    extractorQueue.Remove(videoFile);
                    UpdateExtractorQueueUI_Thread();
                    return;
                };
                var i = 0;
                //console.ThreadLog("Duration In Seconds: " + mp4.Metadata.Duration.Seconds.ToString());
                //console.ThreadLog("Duration In Total Seconds: " + mp4.Metadata.Duration.TotalSeconds.ToString());
                while (i < mp4.Metadata.Duration.TotalSeconds)
                {

                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(i) };
                    var outputFile = new MediaFile { Filename = string.Format("{0}\\image-{1}.jpeg", directoryPath, i) };

                    try
                    {
                        engine.GetThumbnail(mp4, outputFile, options);

                        if (File.Exists(outputFile.Filename))
                        {
                            ImageCropper.CropImage(outputFile.Filename, (int)mainWindow.numericUpDown_ie_crop_x.Value, (int)mainWindow.numericUpDown_ie_crop_y.Value, (int)mainWindow.numericUpDown_ie_crop_width.Value, (int)mainWindow.numericUpDown_ie_crop_height.Value);
                        };

                    }
                    catch
                    {
                        console.ThreadLog(
                            "Unable to GetThumbnail @ " + TimeSpan.FromSeconds(i).ToString());
                    };


                    i += (int)mainWindow.numericUpDown_ie_extract_rate.Value;

                    //  CHECK IF FILE EXISTS - INCASE THE FILE IS AT ITS END
                    if (!File.Exists(outputFile.Filename))
                    {
                        console.ThreadLog(
                            "Unable to open or read localImagePath: {0} " + outputFile.Filename);
                    }
                    else {
                        Parts.KeyFrameImage newKeyFrame = new Parts.KeyFrameImage();
                        newKeyFrame.file_name = outputFile.Filename;
                        newKeyFrame.text_found = new List<Parts.TextFound>();
                        newKeyFrame.analyzed = false;
                        newKeyFrame.valid_text_found = new List<Parts.TextFound>();
                        newKeyFrame.label_found = new List<Parts.LabelFound>();
                        videoFile.keyFrames.Add(newKeyFrame);
                    };

                    

                    UpdateExtractorQueueUI_Thread();
                };


            };

            ResetExtractor(false);
        }







    }
}
