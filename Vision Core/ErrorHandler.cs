using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision_Core
{
    public static class ErrorHandler
    {
        public static MainWindow mainWindow = new MainWindow();
        public static void SetupControl(MainWindow mW)
        {
            mainWindow = mW;
        }


        public static string ReturnError(UInt32 errorCode)
        {
            switch(errorCode)
            {
                case 01012222:
                    return "!(" + errorCode.ToString() + ")! >> No Channel In Search Error.";
                case 01013333:
                    return "!(" + errorCode.ToString() + ")! >> No Channel In Search Error.";
                case 0:
                    return "!(" + errorCode.ToString() + ")! >> SDK says: NO Error??";
                case 1111110:
                    return "!(" + errorCode.ToString() + ")! >> Internal Error.";
                case 4:
                    return "!(" + errorCode.ToString() + ")! >> Channel number error. There is no corresponding channel number on the device.";
                case 34:
                    return "!(" + errorCode.ToString() + ")! >> Failed to create a file, during local recording, saving picture, getting configuration file or downloading record file.";
                case 90:
                    return "!(" + errorCode.ToString() + ")! >> Error Creating Folder.";
                default:
                    return "!(" + errorCode.ToString() + ")! >> Check SDK";
            }
            
        }

        public static void LogError(UInt32 errorCode, string note)
        {
            string output = "!ERR! >> [" + note + "]" + ReturnError(errorCode);
            mainWindow.listBox_error.Items.Add(output);
            //mainWindow.vConsole.Log(output);
            mainWindow.listBox_error.TopIndex = mainWindow.listBox_error.Items.Count - 1;
        }

    }
}
