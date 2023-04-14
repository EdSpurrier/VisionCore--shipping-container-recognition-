using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VidCon = NReco.VideoConverter;

namespace Vision_Core
{
    public static class VideoStitcher
    {
        public static MainWindow mainWindow;

        public static void StitchVideo(Parts.VideoFile videoFile, ConsoleManager console)
        {

            //var ffMpeg = new VidCon.FFMpegConverter();

            console.ThreadLog("Stitching Video");
            string striped_file_name = System.IO.Path.GetFileNameWithoutExtension(videoFile.saved_file_name);
            string[] filePaths = Directory.GetFiles(videoFile.archive_save_folder, striped_file_name + "*.*");

            console.ThreadLog("Number Of Files To Stitch = " + filePaths.Length.ToString());


            //VidCon.FFMpegInput[] inputs = new VidCon.FFMpegInput[filePaths.Length];
            //int i = 0;
            //foreach (string filePath in filePaths)
            //{
            //    inputs[i] = new VidCon.FFMpegInput(filePath);
            //    console.ThreadLog("Adding = " + i.ToString() + "/" + filePaths.Length.ToString() + " >>> " + filePath);
            //    i++;
            //};



            //ffMpeg.ConvertMedia(inputs, outputVideoFile, "mp4", GetConversionSettings());

            //ffMpeg.ConcatMedia(filePaths, outputVideoFile, "mp4", GetConversionSettings());


            Tools.CheckFolderExists(mainWindow.textBox_save_folder.Text + "/temp/");
            string outputVideoFile = mainWindow.textBox_save_folder.Text + "/temp/" + Path.GetFileNameWithoutExtension(filePaths[0]) + "_stitched.mp4";

            

            
            


            string[] filePaths_temp = new string[filePaths.Length];

            int count = 0;

            foreach (var file in filePaths)
            {
                string outputVideoFile_temp = mainWindow.textBox_save_folder.Text + "/temp/" + Path.GetFileNameWithoutExtension(file) + "_convert_pre_stitch.mp4";
                //  CONVERT THEN DELETED OLD FILE
                VidCon.FFMpegInput[] input_temp = new VidCon.FFMpegInput[1];
                input_temp[0] = new VidCon.FFMpegInput(file);



                console.ThreadLog("File Compress Temp Part = " + file + " >> " + outputVideoFile_temp);
                var ffMpeg_temp = new VidCon.FFMpegConverter();

                ffMpeg_temp.ConvertMedia(input_temp, outputVideoFile_temp, "mp4", GetConversionSettings());

                filePaths_temp[count] = outputVideoFile_temp;

                count++;

            };

            console.ThreadLog("Completed Convert Pre-Stitch");



            return;
            console.ThreadLog("Stitching Pre-converted Files");
            concatMedia(filePaths, outputVideoFile, console);

            

            //   DELETING OLD SEPARATE FILES

            //foreach (string filePath in filePaths)
           // {
            //    console.ThreadLog("Removing Temporary File: " + filePath);
            //    File.Delete(filePath);
           // };

            

            console.ThreadLog("Converting New Concat Video File To HD res.");
            //  CONVERT THEN DELETED OLD FILE
            VidCon.FFMpegInput[] inputs = new VidCon.FFMpegInput[1];
            inputs[0] = new VidCon.FFMpegInput(outputVideoFile);

            var ffMpeg = new VidCon.FFMpegConverter();

            ffMpeg.ConvertMedia(inputs, filePaths[0], "mp4", GetConversionSettings());

            console.ThreadLog("Removing Temporary File: " + outputVideoFile);

            return;
            File.Delete(outputVideoFile);

            //  ADDING NEW FILE
            //System.IO.File.Move(outputVideoFile, filePaths[0]);

        }

        public static VidCon.ConvertSettings GetConversionSettings()
        {
            var convertSettings = new VidCon.ConvertSettings();

            convertSettings.VideoFrameSize = VidCon.FrameSize.hd720;

            return convertSettings;
        }




        private static string makeTempFile(string fileName, ConsoleManager console)
        {
            VidCon.FFMpegConverter c = new VidCon.FFMpegConverter();
            FileInfo fileInfo = new System.IO.FileInfo(fileName);
            console.ThreadLog(fileInfo.DirectoryName + " // " + fileInfo.FullName);
            string tempFile = Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(fileName) + ".ts");
            c.Invoke(string.Format("-i {0} -c copy -bsf:v h264_mp4toannexb -f mpegts -y {1}", fileName, tempFile));
            return tempFile;
        }

        private static void concatMedia(string[] files, string output, ConsoleManager console)
        {
            VidCon.FFMpegConverter c = new VidCon.FFMpegConverter();
            List<string> tempFiles = new List<string>();
            foreach (var item in files)
            {
                //tempFiles.Add(makeTempFile(item, console));
                console.ThreadLog("File Check = " + item);
            };
            console.ThreadLog(string.Format("-i \"concat:{0}\" -c copy -bsf:a aac_adtstoasc -y {1}", string.Join("|", files), output));

            console.ThreadVarDump(files);
            console.ThreadVarDump(output);
            
            


            c.Invoke(string.Format("-i \"concat:{0}\" -c copy -bsf:a aac_adtstoasc -y {1}", string.Join("|", files), output));



            foreach (var item in tempFiles)
            {
                console.ThreadLog("Deleting File: " + item);

                System.IO.File.Delete(item);
            };
            console.ThreadLog("Completed Contact...");
        }
    }
}
