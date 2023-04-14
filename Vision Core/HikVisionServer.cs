using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace Vision_Core
{
    class HikVisionServer
    {
        public MainWindow mainWindow;
        public ConsoleManager console;



        public Int32 userID = -1;

        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;

        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        public int[] iChannelNum = new int[96];

        public void Init(MainWindow thisMainWindow)
        {
            
            mainWindow = thisMainWindow;

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_hvs_console, mainWindow.checkBox_hvs_console_autoscroll, mainWindow.button_hvs_clear_console);
            console.Log("HikVisionServer() - Module Initiated.");

        }


        public void ConnectToServer(string start_type = "none")
        {
            console.Log("Connecting To Server");
            mainWindow.ConnectingUI();

            if (mainWindow.textBox_login.Text == "" || mainWindow.textBox_password.Text == "" || mainWindow.textBox_server_ip.Text == "" || mainWindow.textBox_server_port.Text == "")
            {
                MessageBox.Show("Check Server Connection Settings", Vision_Core.Properties.Settings.Default.system_internal_name + " ERROR");
                return;
            };


            if (userID < 0)
            {
                string DVRIPAddress = mainWindow.textBox_server_ip.Text; //IP or domain of device
                Int16 DVRPortNumber = Int16.Parse(mainWindow.textBox_server_port.Text);//Service port of device
                string DVRUserName = mainWindow.textBox_login.Text;//Login name of deivce
                string DVRPassword = mainWindow.textBox_password.Text;//Login password of device

                mainWindow.button_connect.Enabled = false;


                //Login the device
                userID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (userID < 0)
                {
                    
                    ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "NET_DVR_Login_V30 failed");
                    mainWindow.button_connect.Enabled = true;

                    mainWindow.core.systemStatus = "ERROR >> Failed To Connect To HikVision Device";
                    mainWindow.core.systemError = true;

                    MessageBox.Show("Error Connecting To Server [Check Error Console]", Vision_Core.Properties.Settings.Default.system_internal_name + " ERROR");
                    mainWindow.DisconnectedUI();

                    return;
                }
                else
                {
                    mainWindow.ActivateUI();

                    //mainWindow.vConsole.VarDump(DeviceInfo);

                    dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                    dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;


                    if (dwDChanTotalNum > 0)
                    {
                        InfoIPChannel();
                    }
                    else
                    {
                        for (int i = 0; i < dwAChanTotalNum; i++)
                        {
                            ListAnalogChannel(i + 1, 1);
                            iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                        }
                        console.Log("This device has no IP channel!");
                    }

                    mainWindow.core.systemStatus = "System Connected To HikVision Device";
                    console.Log("System Connected To HikVision Device");
                    
                    mainWindow.core.deviceServerIP = mainWindow.textBox_server_ip.Text;

                    if (start_type == "all")
                    {
                        mainWindow.StartAll();
                    }
                    else if (start_type == "em")
                    {
                        mainWindow.StartEventManagerSystem();
                    }
                    else if (start_type == "em_cd")
                    {
                        mainWindow.StartEventManagerSystem();
                        mainWindow.StartCDSystem();
                    }
                    else if (start_type == "cpa_cc")
                    {
                        mainWindow.StartCPA_CCSystem();
                    }
                    else if (start_type == "cd")
                    {
                        mainWindow.StartCDSystem();
                    };

                    
                }

            }
        }


        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0; //The demo just acquire 64 channels of first group.If ip channels of device is more than 64,you should call NET_DVR_GET_IPPARACFG_V40 times to acquire more according to group 0~i
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(userID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "NET_DVR_GET_IPPARACFG_V40 failed");
            }
            else
            {
                // succ
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                for (int i = 0; i < dwAChanTotalNum; i++)
                {
                    ListAnalogChannel(i + 1, m_struIpParaCfgV40.byAnalogChanEnable[i]);
                    iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                }

                byte byStreamType;
                uint iDChanNum = 64;

                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //If the ip channels of device is less than 64,will get the real channel of device
                }

                for (int i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;

                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;
                    m_unionGetStream = m_struIpParaCfgV40.struStreamMode[i].uGetStream;

                    switch (byStreamType)
                    {
                        //At present NVR just support case 0-one way to get stream from device
                        case 0:
                            dwSize = (uint)Marshal.SizeOf(m_unionGetStream);
                            IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_unionGetStream, ptrChanInfo, false);
                            m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                            //List ip channels
                            ListIPChannel(i + 1, m_struChanInfo.byEnable, m_struChanInfo.byIPID);
                            Marshal.FreeHGlobal(ptrChanInfo);
                            break;

                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);
        }

        public void ListIPChannel(Int32 iChanNo, byte byOnline, byte byIPID)
        {

            string status = "Empty";
            string CameraName = String.Format("IPCamera {0}", iChanNo);

            if (byIPID != 0)
            {
                if (byOnline == 0)
                {
                    status = "offline"; //The channel is offline
                }
                else
                    status = "online"; //The channel is online
            }

            mainWindow.listView_connected_devices.Items.Add(new ListViewItem(new string[] { CameraName, status }));//Add channels to list
        }

        public void ListAnalogChannel(Int32 iChanNo, byte byEnable)
        {
            string status = "Enabled";

            if (byEnable == 0)
            {
                status = "Disabled"; //This channel has been disabled               
            };

            mainWindow.listView_connected_devices.Items.Add(new ListViewItem(new string[] { String.Format("Camera {0}", iChanNo), status }));//Add channels to list
        }










        ////////////////////////////
        //  SEARCHER
        ////////////////////////////

    
        public List<Parts.VideoFile> SearchForVideos(CHCNetSDK.NET_DVR_FILECOND_V40 struFileCond_V40, Parts.RelationData relation_data)
        {
            Int32 m_lFindHandle = -1;

            //Start to search video files 
            m_lFindHandle = CHCNetSDK.NET_DVR_FindFile_V40(userID, ref struFileCond_V40);


            List<Parts.VideoFile> videoFilesFound = new List<Parts.VideoFile>();


            if (m_lFindHandle < 0)
            {
                ErrorHandler.LogError(CHCNetSDK.NET_DVR_GetLastError(), "NET_DVR_FindFile_V40 failed");

            }
            else
            {
                CHCNetSDK.NET_DVR_FINDDATA_V30 struFileData = new CHCNetSDK.NET_DVR_FINDDATA_V30(); ;
                while (true)
                {
                    //Get file information one by one.
                    int result = CHCNetSDK.NET_DVR_FindNextFile_V30(m_lFindHandle, ref struFileData);

                    if (result == CHCNetSDK.NET_DVR_ISFINDING)  //Searching, please wait
                    {
                        continue;
                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_SUCCESS) //Get the file information successfully
                    {

                        string fileName = struFileData.sFileName;




                        string startTime = struFileData.struStartTime.dwYear.ToString("D4") + "-" +
                            struFileData.struStartTime.dwMonth.ToString("D2") + "-" +
                            struFileData.struStartTime.dwDay.ToString("D2") + "_" +
                            struFileData.struStartTime.dwHour.ToString("D2") + ":" +
                            struFileData.struStartTime.dwMinute.ToString("D2") + ":" +
                            struFileData.struStartTime.dwSecond.ToString("D2");


                        DateTime start_datetime = DateTime.ParseExact(startTime, "yyyy-MM-dd_HH:mm:ss", null);





                        string endTime = struFileData.struStopTime.dwYear.ToString("D4") + "-" +
                            struFileData.struStopTime.dwMonth.ToString("D2") + "-" +
                            struFileData.struStopTime.dwDay.ToString("D2") + "_" +
                            struFileData.struStopTime.dwHour.ToString("D2") + ":" +
                            struFileData.struStopTime.dwMinute.ToString("D2") + ":" +
                            struFileData.struStopTime.dwSecond.ToString("D2");

                        DateTime end_datetime = DateTime.ParseExact(endTime, "yyyy-MM-dd_HH:mm:ss", null);



                        Parts.VideoFile fileFound = new Parts.VideoFile();

                        fileFound.file_name = fileName;
                        fileFound.start_datetime = start_datetime;
                        fileFound.end_datetime = end_datetime;
                        fileFound.channel_number = struFileCond_V40.lChannel;

                        fileFound.relation_data = relation_data;

                        fileFound.status = "file found";
                        fileFound.downloaded = 0;

                        videoFilesFound.Add(fileFound);
                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_NOFIND || result == CHCNetSDK.NET_DVR_NOMOREFILE)
                    {
                        break; //No file found or no more file found, searching is finished 
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return videoFilesFound;
        }
        
        ////////////////////////////
        ////////////////////////////
        ////////////////////////////









    }
}