using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace Vision_Core
{
    class VisionConsole
    {
        public MainWindow mainWindow;

        public void Log(string output)
        {

            mainWindow.listBox_console.Items.Add(output);
            mainWindow.listBox_console.TopIndex = mainWindow.listBox_console.Items.Count - 1;

            
        }


        public void VarDump(Object obj)
        {
            string output = JsonConvert.SerializeObject(obj, Formatting.Indented);


            using (var reader = new StringReader(output))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    mainWindow.listBox_console.Items.Add(line);
                }
            }

            Console.WriteLine( JsonConvert.SerializeObject(obj, Formatting.Indented));
            mainWindow.listBox_console.TopIndex = mainWindow.listBox_console.Items.Count - 1;
        }






        public delegate void VarDumpCallback(Object obj);

        public void ThreadVarDump(Object obj)
        {

            if (mainWindow.InvokeRequired)
            {
                mainWindow.BeginInvoke(new VarDumpCallback(VarDump), obj);
            }
            else
            {
                VarDump(obj);
            }
        }






        public delegate void LogCallback(string output);

        public void ThreadLog(string output)
        {

            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[1];

                paras[0] = output;


                mainWindow.BeginInvoke(new LogCallback(Log), paras);
            }
            else
            {
                Log(output);
            }
        }




    }




}
