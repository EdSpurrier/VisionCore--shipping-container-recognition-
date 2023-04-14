using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Vision_Core
{
    public static class Tools
    {
        public static MainWindow mainWindow = new MainWindow();
        public static void SetupControl(MainWindow mW)
        {
            mainWindow = mW;
        }


        

        public static uint UnixTimeStampUTC()
        {
            uint unixTimeStamp;
            DateTime currentTime = DateTime.Now;
            DateTime zuluTime = currentTime.ToUniversalTime();
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            unixTimeStamp = (uint)(zuluTime.Subtract(unixEpoch)).TotalSeconds;

            return unixTimeStamp;
        }


        public static void CheckFolderExists (string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (IOException ioex)
            {
                ErrorHandler.LogError(90, ioex.Message);

            }
        }

        public static string GetIP()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
        }

        public static string GetExternalIP()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            return a3[0];
        }


        public static void OpenFolderInExplorer(string path)
        {
            string cmd = "explorer.exe";
            string arg = "/select, " + path;
            System.Diagnostics.Process.Start(cmd, arg);
        }


        public static bool IsCurrentDateBetween(DateTime curent, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.CompareTo(toDate) >= 1)
            {
                
            }
            int cd_fd = curent.CompareTo(fromDate);
            int cd_td = curent.CompareTo(toDate);

            if (cd_fd == 0 || cd_td == 0)
            {
                return true;
            }

            if (cd_fd >= 1 && cd_td <= -1)
            {
                return true;
            }
            return false;
        }



        public static void OutputVideoFileData(Parts.VideoFile videoFile)
        {
            mainWindow.vConsole.Log("Parts.VideoFile DATA:");
            mainWindow.vConsole.Log("file_name: " + videoFile.file_name);
            mainWindow.vConsole.Log("file_path: " + videoFile.file_path);
            mainWindow.vConsole.Log("start_datetime: " + videoFile.start_datetime.ToString());
            mainWindow.vConsole.Log("end_datetime: " + videoFile.end_datetime.ToString());
            mainWindow.vConsole.Log("ftp_sub_directory: " + videoFile.ftp_sub_directory);
            mainWindow.vConsole.Log("ftp_url: " + videoFile.ftp_url);
            mainWindow.vConsole.Log("saved_file_name: " + videoFile.saved_file_name);
            mainWindow.vConsole.Log("downloaded: " + videoFile.downloaded.ToString());
            mainWindow.vConsole.Log("downloadType: " + videoFile.downloadType.ToString());
            mainWindow.vConsole.Log("channel_number: " + videoFile.channel_number.ToString());

            mainWindow.vConsole.Log("keyFrames COUNT: " + videoFile.keyFrames.Count.ToString());
            int keyframe_no = 0;
            foreach(Parts.KeyFrameImage keyframe in videoFile.keyFrames)
            {
                mainWindow.vConsole.Log("keyFrame No. >> " + keyframe_no.ToString() + "/" + videoFile.keyFrames.Count.ToString() );
                mainWindow.vConsole.Log("             >> file_name: " + keyframe.file_name);
                mainWindow.vConsole.Log("             >> analyzed: " + keyframe.analyzed);
                mainWindow.vConsole.Log("             >> text_found COUNT: " + keyframe.text_found.Count.ToString());
                mainWindow.vConsole.Log("             >> valid_text_found: " + keyframe.valid_text_found);
                keyframe_no++;
            };

        }



        public static string TrimPunctuation(string value)
        {
            // Count start punctuation.
            int removeFromStart = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsPunctuation(value[i]))
                {
                    removeFromStart++;
                }
                else
                {
                    break;
                }
            }

            // Count end punctuation.
            int removeFromEnd = 0;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (char.IsPunctuation(value[i]))
                {
                    removeFromEnd++;
                }
                else
                {
                    break;
                }
            }
            // No characters were punctuation.
            if (removeFromStart == 0 &&
                removeFromEnd == 0)
            {
                return value;
            }
            // All characters were punctuation.
            if (removeFromStart == value.Length &&
                removeFromEnd == value.Length)
            {
                return "";
            }
            // Substring.
            return value.Substring(removeFromStart,
                value.Length - removeFromEnd - removeFromStart);
        }





        public static int DifferenceInSeconds(DateTime date1, DateTime date2)
        {
            return (int)System.Math.Abs((date1 - date2).TotalSeconds);
        }

        public static int TimeSpanInMinutes(DateTime startTime, DateTime endTime)
        {
            string start = startTime.ToString("hh:mm");
            string end = endTime.ToString("hh:mm");

            TimeSpan span = TimeSpan.Parse(end).Subtract(TimeSpan.Parse(start));
            return (int)span.TotalMinutes;
        }


        public static void CleanUpVideoFile(Parts.VideoFile videoFile)
        {
            
            //  CHECK IF FILE EXISTS - INCASE THE FILE IS AT ITS END
            if (File.Exists(videoFile.file_name))
            {
                File.Delete(videoFile.file_name);
                if (videoFile.keyframe_path != null || videoFile.keyframe_path != "")
                {
                    Directory.Delete(videoFile.keyframe_path, true);
                };
            };
            
        }
    }
}
