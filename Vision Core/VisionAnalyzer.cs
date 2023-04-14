using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Google.Cloud.Vision.V1;

using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.IO;

using Iso.Validators;

namespace Vision_Core
{
    class VisionAnalyzer
    {
        public MainWindow mainWindow;

        public System.Windows.Forms.ListView visionQueue_list;
        public System.Windows.Forms.ListView text_detected_output;
        public System.Windows.Forms.ListView label_detected_output;
        public System.Windows.Forms.ListView filelist;
        public ConsoleManager console;

        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_va_console, mainWindow.checkBox_va_auto_scroll, mainWindow.button_va_clear_console);
            console.maximumRows = 1000;
           

            visionQueue_list = mainWindow.listView_va_vision_queue;

            console.ThreadLog("Vision() - Module Initiated.");

            text_detected_output = mainWindow.listView_va_text_dectected;
            label_detected_output = mainWindow.listView_va_labels_dectected;

            filelist = mainWindow.listView_va_filelist;
            visionQueue_list.SelectedIndexChanged += new System.EventHandler(this.SelectQueueListItem);
            filelist.SelectedIndexChanged += new System.EventHandler(this.SelectFilelistItem);

            ContainerValidator.console = console;
        }


        ////////////////////////////
        //  DISPLAY SELECTION DATA
        ////////////////////////////

        public int selected_queue_item_number = -1;
        public int selected_filelist_item_number = -1;

        public void SelectQueueListItem(object sender, EventArgs e)
        {
            if (visionQueue_list.SelectedItems.Count > 0)
            {
                if (selected_queue_item_number == visionQueue_list.SelectedItems[0].Index)
                {
                    return;
                };

                selected_queue_item_number = visionQueue_list.SelectedItems[0].Index;

                //console.Log("Selected Queue Item >> " + selected_queue_item_number.ToString());

                SelectQueueShowFilelistUI();
            }
            else
            {
                selected_queue_item_number = -1;

                //console.Log("ClearSelection()");
                ClearSelection();
            };
        }

        public void ClearSelection()
        {
            filelist.Items.Clear();
            text_detected_output.Items.Clear();
        }


        public void SelectQueueShowFilelistUI()
        {

            filelist.Items.Clear();

            if (selected_queue_item_number < 0)
            {
                return;
            };


            foreach (Parts.KeyFrameImage keyFrame in visionQueue[selected_queue_item_number].keyFrames.ToList())
            {
                filelist.Items.Add(new ListViewItem(new string[] {
                    keyFrame.file_name,
                    visionQueue[selected_queue_item_number].video_unique_id.ToString(),
                    visionQueue[selected_queue_item_number].status,
                    keyFrame.text_found.Count.ToString(),
                    keyFrame.valid_text_found.Count.ToString(),
                    keyFrame.label_found.Count.ToString(),
                    keyFrame.analyzed.ToString(),
                    keyFrame.type_code_confidence.ToString()
                }));
            };


        }









        public delegate void UpdateChildrenUI_CallBack();

        void UpdateChildrenUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateChildrenUI_CallBack(UpdateChildrenUI));
            }
            else
            {
                UpdateChildrenUI();
            }
        }



        public void UpdateChildrenUI()
        {
            UpdateFilelistUI();
            UpdateTextDetectedUI();
            UpdateLabelDetectedUI();
        }









        public void UpdateFilelistUI()
        {

            if (selected_queue_item_number < 0)
            {
                filelist.Items.Clear();
                return;
            };


            int listItemNumber = 0;
            foreach (Parts.KeyFrameImage keyFrame in visionQueue[selected_queue_item_number].keyFrames.ToList())
            {
                filelist.Items[listItemNumber].SubItems[2].Text = visionQueue[selected_queue_item_number].status;
                filelist.Items[listItemNumber].SubItems[3].Text = keyFrame.text_found.Count.ToString();
                filelist.Items[listItemNumber].SubItems[4].Text = keyFrame.valid_text_found.Count.ToString();
                filelist.Items[listItemNumber].SubItems[5].Text = keyFrame.label_found.Count.ToString();
                filelist.Items[listItemNumber].SubItems[6].Text = keyFrame.analyzed.ToString();
                filelist.Items[listItemNumber].SubItems[7].Text = keyFrame.type_code_confidence.ToString();
                listItemNumber++;
            };

        }



        public void SelectFilelistItem(object sender, EventArgs e)
        {
            if (selected_queue_item_number < 0)
            {
                return;
            };



            if (filelist.SelectedItems.Count > 0)
            {
                selected_filelist_item_number = filelist.SelectedItems[0].Index;

                //console.Log("Selected File List Item >> " + selected_filelist_item_number.ToString());

                UpdateTextDetectedUI();
                UpdateLabelDetectedUI();
            }
            else
            {
                selected_filelist_item_number = -1;
                selected_queue_item_number = -1;
                //console.Log("ClearFilelistSelection()");
                ClearFilelistSelection();
            };



        }


        public void ClearFilelistSelection()
        {
            text_detected_output.Items.Clear();
        }



        public void UpdateTextDetectedUI()
        {
            text_detected_output.Items.Clear();

            if (selected_filelist_item_number < 0 || selected_queue_item_number < 0)
            {
                return;
            };



            foreach (Parts.TextFound text_found in visionQueue[selected_queue_item_number].keyFrames[selected_filelist_item_number].text_found.ToList())
            {
                text_detected_output.Items.Add(new ListViewItem(new string[] {
                    text_found.text,
                    text_found.text.Length.ToString(),
                    text_found.valid.ToString(),
                    text_found.confidence.ToString()
                }));

            };

        }


        public void UpdateLabelDetectedUI()
        {
            label_detected_output.Items.Clear();

            if (selected_filelist_item_number < 0 || selected_queue_item_number < 0)
            {
                return;
            };



            foreach (Parts.LabelFound label_found in visionQueue[selected_queue_item_number].keyFrames[selected_filelist_item_number].label_found.ToList())
            {
                label_detected_output.Items.Add(new ListViewItem(new string[] {
                    label_found.label,
                    label_found.confidence.ToString()
                }));

            };

        }

        ////////////////////////////
        //  UI
        ////////////////////////////


        public void UpdateVisionQueueUI()
        {
            visionQueue_list.Items.Clear();
            foreach (Parts.VideoFile visionFile in visionQueue)
            {
                visionQueue_list.Items.Add(new ListViewItem(new string[] {
                    visionFile.file_name,
                    visionFile.status,
                    visionFile.relation_data.type,
                    visionFile.relation_data.unique_id.ToString(),
                    GetImageCountAnalyzed(visionFile).ToString() + "/" + visionFile.keyFrames.Count.ToString()
                }));
            };


            //if (visionQueue.Count > 0 && ReturnFirstUnprocessedItem() >= 0)
            //{
            //    UpdateFilelistUI();
            //};

        }


        public delegate void UpdateVisionQueueUI_CallBack();

        void UpdateVisionQueueUI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateVisionQueueUI_CallBack(UpdateVisionQueueUI));
            }
            else
            {
                UpdateVisionQueueUI();
            }
        }





        public void UpdateVisionQueue_Update_UI()
        {

            int listItemNumber = 0;
            foreach (Parts.VideoFile visionFile in visionQueue.ToList())
            {
                try
                {
                    visionQueue_list.Items[listItemNumber].SubItems[1].Text = visionFile.status;
                    visionQueue_list.Items[listItemNumber].SubItems[4].Text = GetImageCountAnalyzed(visionFile).ToString() + "/" + visionFile.keyFrames.Count.ToString();
                }
                catch {
                };
                
                listItemNumber++;
            };

            UpdateFilelistUI();
            UpdateLabelDetectedUI();

        }


        public delegate void UpdateVisionQueue_Update_UI_CallBack();

        void UpdateVisionQueue_Update_UI_Thread()
        {
            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new UpdateVisionQueue_Update_UI_CallBack(UpdateVisionQueue_Update_UI));
            }
            else
            {
                UpdateVisionQueue_Update_UI();
            }
        }

        ////////////////////////////
        //  VISION ANALYZER
        ////////////////////////////

        List<Parts.VideoFile> visionQueue = new List<Parts.VideoFile>();
        bool analyzing = false;
        public List<string> text_detected = new List<string>();
        public int azure_debounce = 1000;
        public int maximum_list_items = 20;
        public int current_item = 0;
        public int totalAnalyzed = 1;

        public void AddToVisionQueue(Parts.VideoFile videoFile)
        {

            visionQueue.Add(videoFile);

            if (analyzing)
            {
                console.ThreadLog("Currently Analyzing. Adding To Queue");
                UpdateVisionQueueUI();
                return;
            }
            else
            {
                StartProcessVisionQueueThread();
            };

        }

        public int ReturnFirstUnprocessedItem()
        {
            int value = 0;
            foreach(Parts.VideoFile videoFile in visionQueue)
            {
                if (videoFile.status != "Analyzed")
                {
                    return value;
                };
                value++;
            };
            return value;    
        }

        public void StartProcessVisionQueueThread()
        {
            console.ThreadLog("Starting Processor Queue Thread");
            Thread convertThread = new Thread(delegate () { ProcessVisionQueue(); });
            convertThread.IsBackground = true;
            convertThread.Start();
        }



        public void ProcessVisionQueue()
        {
            UpdateVisionQueueUI_Thread();
            UpdateChildrenUI_Thread();

            if (visionQueue.Count > 0 && ReturnFirstUnprocessedItem() >= 0 )
            {
                console.ThreadLog("Processing Vision Queue");

                if (analyzing)
                {
                    console.ThreadLog("Currently Analyzing.");
                    return;
                }
                else
                {
                    
                    current_item = ReturnFirstUnprocessedItem();
                    if (current_item < 0)
                    {
                        console.ThreadLog("Completed Extractor Queue");
                    }
                    else {

                        console.ThreadLog("Processing = "  + current_item.ToString() );

                        if (visionQueue.Count > current_item)
                        {
                            Analyze(visionQueue[current_item]);
                        };

                    };

                    
                };
            }
            else
            {
                console.ThreadLog("Completed Extractor Queue");
            };

        }




        public void ResetVisionAnalyzer(bool error)
        {
            console.ThreadLog("Reseting Vision Analyzer");
            if (error)
            {
                visionQueue[current_item].status = "Vision Error";
                console.ThreadLog("Analyzer Error = Restarting Vision Queue");
                visionQueue[current_item].relation_data.callback_update(visionQueue[current_item], "Analyzer Error");
            }
            else
            {
                analyzing = false;

                visionQueue[current_item].status = "Analyzed";
                visionQueue[current_item].relation_data.callback_vision(visionQueue[current_item], "Analyzed");

                if (visionQueue.Count > maximum_list_items)
                {
                    visionQueue.Remove(visionQueue[current_item]);
                };

                

                ProcessVisionQueue();


            };

            UpdateVisionQueueUI_Thread();
            UpdateChildrenUI_Thread();
        }






        public void Analyze(Parts.VideoFile videoFile)
        {
            int keyframeNo = 1;
            analyzing = true;

            console.ThreadLog("Analyzing next in stack Number=" + totalAnalyzed.ToString());
            totalAnalyzed++;

            UpdateVisionQueue_Update_UI_Thread();

            videoFile.status = "Analyzing...";
            

            if (ContainerValidator.CheckForValidContainerCode(videoFile))
            {
                console.ThreadLog("Found Valid Container Number");
                ResetVisionAnalyzer(false);
                return;
            };


            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                if (!keyFrame.analyzed)
                {
                    AnalyzeKeyFrame(keyFrame, videoFile);
                    console.ThreadLog("Analyzing New Keyframe = " + keyframeNo.ToString() + "/" + videoFile.keyFrames.Count.ToString());
                    return;
                };
                keyframeNo++;
            };
            console.ThreadLog("All Keyframes Analyzed.");


            ResetVisionAnalyzer(false);

        }




        ////////////////////////////
        //  DATA
        ////////////////////////////
        public int GetImageCountAnalyzed(Parts.VideoFile videoFile)
        {
            int count = 0;
            foreach (Parts.KeyFrameImage keyFrame in videoFile.keyFrames)
            {
                if (keyFrame.analyzed)
                {
                    count++;
                };
            }

            return count;
        }




        ////////////////////////////
        //  COMPUTER VISION = AZURE
        ////////////////////////////


        // subscriptionKey = "0123456789abcdef0123456789ABCDEF"
        private const string subscriptionKey = "7977aa3c830d49328f462b38fc28312a";

        // localImagePath = @"C:\Documents\LocalImage.jpg"
        //private const string localImagePath = @"<LocalImage>";

        private const string remoteImageUrl =
            "https://upload.wikimedia.org/wikipedia/commons/3/3c/Shaki_waterfall.jpg";

        // Specify the features to return
        private readonly List<VisualFeatureTypes> features =
            new List<VisualFeatureTypes>()
        {
            VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags
        };



        // For printed text, change to TextRecognitionMode.Printed
        private const TextRecognitionMode textRecognitionMode =
            TextRecognitionMode.Handwritten;

        private const int numberOfCharsInOperationId = 36;

        void AnalyzeKeyFrame(Parts.KeyFrameImage keyFrame, Parts.VideoFile videoFile)
        {
            ComputerVisionClient computerVision = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials(subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });

            // You must use the same region as you used to get your subscription
            // keys. For example, if you got your subscription keys from westus,
            // replace "westcentralus" with "westus".
            //
            // Free trial subscription keys are generated in the "westus"
            // region. If you use a free trial subscription key, you shouldn't
            // need to change the region.

            // Specify the Azure region
            computerVision.Endpoint = "https://australiaeast.api.cognitive.microsoft.com/";

            console.ThreadLog("Images being analyzed...");
            //var t1 = AnalyzeRemoteAsync(computerVision, remoteImageUrl);
            //var t2 = AnalyzeLocalAsync(computerVision, keyFrame.file_name);


            if (mainWindow.checkBox_va_object_detection_active.Checked)
            {
                var t1 = ExtractLabelsFromKeyframeAsync(computerVision, keyFrame, videoFile);
                Task.WhenAll(t1).Wait(1000);
            };
            

            var t2 = ExtractTextFromKeyframe_Async(computerVision, keyFrame, videoFile);

            //console.ThreadLog("Press ENTER to exit");
            //Console.ReadLine();

            
        }


        public void AnalyzeSingleImage(string file_name)
        {
            ComputerVisionClient computerVision = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials(subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });

            // You must use the same region as you used to get your subscription
            // keys. For example, if you got your subscription keys from westus,
            // replace "westcentralus" with "westus".
            //
            // Free trial subscription keys are generated in the "westus"
            // region. If you use a free trial subscription key, you shouldn't
            // need to change the region.

            // Specify the Azure region
            computerVision.Endpoint = "https://australiaeast.api.cognitive.microsoft.com/";

            console.ThreadLog("[SINGLE IMAGE] >> Images being analyzed...");
            //var t1 = AnalyzeRemoteAsync(computerVision, remoteImageUrl);
            //var t2 = AnalyzeLocalAsync(computerVision, keyFrame.file_name);




            var t2 = ExtractTextFromSingleImage_Async(computerVision, file_name);

            //console.ThreadLog("Press ENTER to exit");
            //Console.ReadLine();


        }


        ////////////////////////////
        //  LABEL DETECTION
        ////////////////////////////


        // Analyze a local image
        private async Task ExtractLabelsFromKeyframeAsync(
             ComputerVisionClient computerVision, Parts.KeyFrameImage keyFrame, Parts.VideoFile videoFile)
        {
            if (!File.Exists(keyFrame.file_name))
            {
                console.ThreadLog(
                    "Unable to open or read localImagePath: {0} " + keyFrame.file_name);
                return;
            }

            using (Stream imageStream = File.OpenRead(keyFrame.file_name))
            {
                ImageAnalysis analysis = await computerVision.AnalyzeImageInStreamAsync(
                    imageStream, features);



                //console.ThreadLog(">>================<<");
                //console.ThreadLog(">>================<<");
                //console.ThreadLog(">>================<<");
                //console.ThreadVarDump(analysis);
                //console.ThreadLog(">>================<<");
                //console.ThreadLog(">>================<<");
                //console.ThreadLog(">>================<<");

                await ExtractMetaData(analysis, keyFrame, videoFile);
            }
        }



        // Display the most relevant caption for the image
        private async Task ExtractMetaData(ImageAnalysis analysis, Parts.KeyFrameImage keyFrame, Parts.VideoFile videoFile)
        {

            foreach(var label in analysis.Tags)
            {
                Parts.LabelFound label_found = new Parts.LabelFound();
                label_found.label = label.Name;
                label_found.confidence = (float)label.Confidence;
                keyFrame.label_found.Add(label_found);
            }


            if (analysis.Description.Captions.Count != 0)
            {
                console.ThreadLog(analysis.Description.Captions[0].Text + "\n");
            }
            else
            {
                console.ThreadLog("No description generated.");
            }
        }



        ////////////////////////////
        //  TEXT DETECTION
        ////////////////////////////


        // Recognize text from a local image
        private async Task ExtractTextFromSingleImage_Async(
            ComputerVisionClient computerVision, string file_name)
        {


            if (!File.Exists(file_name))
            {
                console.ThreadLog(
                    "\nUnable to open or read localImagePath:\n{0} \n" + file_name);
                return;
            };

            using (Stream imageStream = File.OpenRead(file_name))
            {
                // Start the async process to recognize the text
                BatchReadFileInStreamHeaders textHeaders =
                    await computerVision.BatchReadFileInStreamAsync(
                        imageStream, textRecognitionMode);

                await TextDetect_Async_SingleImage(computerVision, textHeaders.OperationLocation);
            };


            console.ThreadLog("Completed Text Extraction Process");

        }

        // Retrieve the recognized text
        private async Task TextDetect_Async_SingleImage(
            ComputerVisionClient computerVision, string operationLocation)
        {
            // Retrieve the URI where the recognized text will be
            // stored from the Operation-Location header
            string operationId = operationLocation.Substring(
                operationLocation.Length - numberOfCharsInOperationId);

            console.ThreadLog("\nCalling GetHandwritingRecognitionOperationResultAsync()");
            ReadOperationResult result =
                await computerVision.GetReadOperationResultAsync(operationId);

            // Wait for the operation to complete
            int i = 0;
            int maxRetries = 10;
            while ((result.Status == TextOperationStatusCodes.Running ||
                    result.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries)
            {
                console.ThreadLog(
                    "Server status: {0}, waiting {1} seconds..." + result.Status + i);
                await Task.Delay(1000);

                result = await computerVision.GetReadOperationResultAsync(operationId);
            }

            // Display the results

            text_detected.Clear();

            var recResults = result.RecognitionResults;


            console.ThreadLog(">>================<<");
            foreach (TextRecognitionResult recResult in recResults)
            {
                foreach (Line line in recResult.Lines)
                {
                    console.ThreadLog("Found Line: " + line.Text);
                };
            };
            console.ThreadLog(">>================<<");
            console.ThreadLog("Completed Image Analysis Process");

        }






        // Recognize text from a local image
        private async Task ExtractTextFromKeyframe_Async(
            ComputerVisionClient computerVision, Parts.KeyFrameImage keyFrame, Parts.VideoFile videoFile)
        {


            if (!File.Exists(keyFrame.file_name))
            {
                console.ThreadLog(
                    "\nUnable to open or read localImagePath:\n{0} \n" + keyFrame.file_name);
                return;
            };

            using (Stream imageStream = File.OpenRead(keyFrame.file_name))
            {
                // Start the async process to recognize the text
                BatchReadFileInStreamHeaders textHeaders =
                    await computerVision.BatchReadFileInStreamAsync(
                        imageStream, textRecognitionMode);

                await TextDetect_Async(computerVision, textHeaders.OperationLocation, keyFrame, videoFile);
            };


            console.ThreadLog("Completed Text Extraction Process");
        }






        // Retrieve the recognized text
        private async Task TextDetect_Async(
            ComputerVisionClient computerVision, string operationLocation, Parts.KeyFrameImage keyFrame, Parts.VideoFile videoFile)
        {
            // Retrieve the URI where the recognized text will be
            // stored from the Operation-Location header
            string operationId = operationLocation.Substring(
                operationLocation.Length - numberOfCharsInOperationId);

            console.ThreadLog("\nCalling GetHandwritingRecognitionOperationResultAsync()");
            ReadOperationResult result =
                await computerVision.GetReadOperationResultAsync(operationId);

            // Wait for the operation to complete
            int i = 0;
            int maxRetries = 10;
            while ((result.Status == TextOperationStatusCodes.Running ||
                    result.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries)
            {
                console.ThreadLog(
                    "Server status: {0}, waiting {1} seconds..." + result.Status + i);
                await Task.Delay(1000);

                result = await computerVision.GetReadOperationResultAsync(operationId);
            }

            // Display the results

            text_detected.Clear();

            var recResults = result.RecognitionResults;

            console.ThreadLog(">>================<<");
            foreach (TextRecognitionResult recResult in recResults)
            {
                foreach (Line line in recResult.Lines)
                {
                    Parts.TextFound text_found = new Parts.TextFound();
                    string thisString = CleanTextFromAzure(line.Text);

                    text_found.text = thisString;

                    keyFrame.text_found.Add(text_found);
                };
            };
            console.ThreadLog(">>================<<");
            console.ThreadLog("Completed Image Analysis Process");

            keyFrame.analyzed = true;


            videoFile.relation_data.callback_update(videoFile, "Vision Analyzing");

            azure_debounce = (int)(mainWindow.numericUpDown_va_azure_debounce.Value * 1000);
            console.ThreadLog("Waiting For Azure Server Debounce... " + azure_debounce.ToString() + "s");         
            Thread.Sleep(azure_debounce);

            Analyze(videoFile);
 
        }






        ////////////////////////////
        //  TEXT CLEANER
        ////////////////////////////

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled).Trim('.');
        }




        public string CleanTextFromAzure(string line)
        {

            string cleaned_text = Regex.Replace(line, @"s", "");
            string cleaned_text_2 = Regex.Replace(cleaned_text, " ", "");
            string cleaned_text_3 = Tools.TrimPunctuation(cleaned_text_2);
            cleaned_text = RemoveSpecialCharacters(cleaned_text_3);
            return cleaned_text;

        }


    }
}
