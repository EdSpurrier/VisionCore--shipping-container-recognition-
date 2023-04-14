using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;


namespace Vision_Core
{
    public class ConsoleManager
    {
        public MainWindow mainWindow;
        public System.Windows.Forms.ListBox console;
        public System.Windows.Forms.CheckBox autoscroll;
        public int maximumRows = 50;

        

        public void Init(MainWindow thisMainWindow, System.Windows.Forms.ListBox thisConsole, System.Windows.Forms.CheckBox thisAutoscroll, System.Windows.Forms.Button clearButton)
        {

            mainWindow = thisMainWindow;
            console = thisConsole;
            autoscroll = thisAutoscroll;
            clearButton.Click += new System.EventHandler(ClearConsole);

            Log("ConsoleManager() - Module Initiated.");

        }

        /////////////////////////////////
        /// LOG > [START]
        /////////////////////////////////

        public void ClearConsole(object sender, EventArgs e)
        {
            console.Items.Clear();
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

        public void Log(string output)
        {
            if (console.Items.Count > maximumRows)
            {
                console.Items.RemoveAt(0);
            };
            console.Items.Add(output);
            if (autoscroll.Checked)
            {
                console.TopIndex = console.Items.Count - 1;
            };
        }



        public delegate void VarDumpback(object output);

        public void ThreadVarDump(object output)
        {
            if (mainWindow.InvokeRequired)
            {
                object[] paras = new object[1];

                paras[0] = output;

                mainWindow.BeginInvoke(new VarDumpback(VarDump), paras);
            }
            else
            {
                VarDump(output);
            }
        }


        public void VarDump(Object obj)
        {
            string output = JsonConvert.SerializeObject(obj, Formatting.Indented);


            using (var reader = new StringReader(output))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    if (console.Items.Count > maximumRows)
                    {
                        console.Items.RemoveAt(0);
                    };
                    console.Items.Add(line);
                }
            }

            if (autoscroll.Checked)
            {
                console.TopIndex = console.Items.Count - 1;
            };
        }


    }
}
