using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;


namespace Vision_Core
{
    class Database
    {

        public MainWindow mainWindow;
        public ConsoleManager console;


        public void Init(MainWindow thisMainWindow)
        {
            mainWindow = thisMainWindow;
            

            console = new ConsoleManager();
            console.Init(mainWindow, mainWindow.listBox_db_console, mainWindow.checkBox_db_auto_scroll, mainWindow.button_db_clear_console);
            console.Log("Database() - Module Initiated.");
            console.maximumRows = 1000;

            mainWindow.button_db_test_connections.Click += new System.EventHandler(TestConnections_Click);
            mainWindow.button_backup_databases.Click += new System.EventHandler(BackupDatabases_Click);
            //TestConnections();
        }


        ////////////////////////////
        /// UI
        ////////////////////////////

        private void TestConnections_Click(object sender, EventArgs e)
        {
            TestConnections();
        }

        private void BackupDatabases_Click(object sender, EventArgs e)
        {
            TestConnections();
            


            //  DOWNLOAD DATABASES
            string file = "C:/Users/Administrator/Google Drive/Database Backups/web_gui.sql";
            using (MySqlConnection conn = new MySqlConnection( ConnectionString_WebGUI() ))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }

            file = "C:/Users/Administrator/Google Drive/Database Backups/web_vision_core.sql";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString_WebVisionCore()))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }


            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;
            string command = "C:/Users/Administrator/Google Drive/Database Backups/backup_wamp.bat";
            ProcessInfo = new ProcessStartInfo("C:/Users/Administrator/Google Drive/Database Backups/backup_wamp.bat");
            //ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;

            Process = Process.Start(ProcessInfo);
            Process.WaitForExit();

            ExitCode = Process.ExitCode;
            Process.Close();

            console.ThreadLog("ExitCode: " + ExitCode.ToString() + " >> ExecuteCommand");
        }



        //============================================//  
        //=========[ MYSQL DATABASE SYSTEM ]==========//
        //============================================//

        private static MySqlConnection connection = null;

        public void TestConnections()
        {
            console.Log("Vision Core SQL Database Status = " + TestDatabase(ConnectionString_VisionCore()));
            console.Log("Web GUI SQL Database Status = " + TestDatabase(ConnectionString_WebGUI()));
        }


        public void Close()
        {
            connection.Close();
        }



        public bool TestDatabase(string conn_string)
        {

            connection = null;

            connection = new MySqlConnection(conn_string);

            try
            {
                connection.Open();
                Close();
                return true;
            }
            catch (Exception ex)
            {
                console.Log(ex.Message);
                Close();
                return false;
            };

        }


        public void BasicQuery(string connection_string, string query, bool debug = false)
        {
            MySqlConnection connection = new MySqlConnection(connection_string);

            try
            {
                connection.Open();

                if (debug)
                {
                    console.ThreadLog("DB Query = " + query);
                };



                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();


                connection.Close();

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
            }
        }




        //============================================//  
        //==================[ COMMS ]=================//
        //============================================//


        public List<Comms.Comm_Data> ReadComms(string destination_id, List<Comms.Comm_Data> comms_found, string destination = "None" )
        {
            List<Comms.Comm_Data> comm_datas = new List<Comms.Comm_Data>();

            foreach (Comms.Comm_Data comm_found in comms_found)
            {
                string query = "UPDATE `comms` SET " +
                    "`status`='" + comm_found.status + "' " +
                    "WHERE `comms_unique_id` = '" + comm_found.comms_unique_id.ToString() + "';";

                BasicQuery(ConnectionString_WebVisionCore(), query, true);
            };



            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                connection.Open();

                if (destination == "None")
                {
                    destination = GetType().Namespace;
                }

                string query_read = "SELECT * from `comms` WHERE `status` = 'Created' AND `destination` = '" + destination + "' AND `destination_id` = '" + destination_id + "';";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadLog("DB Query Read = " + query_read);





                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {

                        DateTime datetime;

                        if (DateTime.TryParseExact(dataReader.GetValue(dataReader.GetOrdinal("comms_datetime")).ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                        {

                            int seconds_difference = Tools.DifferenceInSeconds(datetime, DateTime.Now);

                            //console.ThreadLog("Diff Sec: " + seconds_difference.ToString());

                            Comms.Comm_Data comm_data = new Comms.Comm_Data();

                            comm_data.comms_unique_id = (int)dataReader.GetValue(dataReader.GetOrdinal("comms_unique_id"));
                            comm_data.comms_datetime = dataReader.GetValue(dataReader.GetOrdinal("comms_datetime")).ToString();
                            comm_data.target_id = dataReader.GetValue(dataReader.GetOrdinal("target_id")).ToString();
                            comm_data.comm = dataReader.GetValue(dataReader.GetOrdinal("comm")).ToString();
                            comm_data.comm_data = dataReader.GetValue(dataReader.GetOrdinal("comm_data")).ToString();

                            if (seconds_difference < 90 && seconds_difference > -90)
                            {
                                comm_data.status = dataReader.GetValue(dataReader.GetOrdinal("status")).ToString();
                            }
                            else
                            {
                                comm_data.status = "Error";
                            };




                            comm_datas.Add(comm_data);
                        };

                    };

                    dataReader.NextResult();
                };

                connection.Close();

                return comm_datas;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return comm_datas;
            }

        }


        //============================================//  
        //=============[ VISION CORE DB ]=============//
        //============================================//
        public string ConnectionString_VisionCore()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = Vision_Core.Properties.Settings.Default.vision_sql_ip;
            conn_string.Port = 3306;
            conn_string.UserID = Vision_Core.Properties.Settings.Default.vision_sql_login;
            conn_string.Password = Vision_Core.Properties.Settings.Default.vision_sql_password;
            conn_string.Database = Vision_Core.Properties.Settings.Default.vision_sql_database;
            conn_string.CharacterSet = "utf8";
            conn_string.ConvertZeroDateTime = true;

            return conn_string.ToString();

        }






        public int InsertNewEventAlarm_VisionCore(Parts.EventAlarm event_alarm)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();



                string query = "INSERT INTO `all_event_alarms`(`process_status`, `event_name`, `event_type`, `status`, `event_datetime`, `related_unique_id`, `debounce_time`) VALUES ('" +
                    event_alarm.process_status + "', '" +
                    event_alarm.event_name + "', '" +
                    event_alarm.event_type + "', '" +
                    event_alarm.status + "', '" +
                    event_alarm.event_datetime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                    event_alarm.related_unique_id + "', '" +
                    (event_alarm.debounce_time/1000).ToString() + "'); ";

                query += "INSERT INTO `backup_all_event_alarms`(`process_status`, `event_name`, `event_type`, `status`, `event_datetime`, `related_unique_id`, `debounce_time`) VALUES ('" +
                    event_alarm.process_status + "', '" +
                    event_alarm.event_name + "', '" +
                    event_alarm.event_type + "', '" +
                    event_alarm.status + "', '" +
                    event_alarm.event_datetime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                    event_alarm.related_unique_id + "', '" +
                    (event_alarm.debounce_time / 1000).ToString() + "');";


                //console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();



                string query_read = "SELECT `alarm_unique_id` from `all_event_alarms` ORDER BY `alarm_unique_id` DESC LIMIT 1; ";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int alarm_unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        alarm_unique_id = (int)dataReader.GetValue(0);
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return alarm_unique_id;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }


        }





        public List<Parts.EventAlarm> SearchForAllEventAlarms_VisionCore(string process_status, int limit, DateTime process_date, bool process_between_dates = false)
        {
            List<Parts.EventAlarm> eventAlarms = new List<Parts.EventAlarm>();

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();



                string query_read = "SELECT * FROM `all_event_alarms` WHERE `process_status` = '" + process_status + "' ORDER BY `alarm_unique_id` ASC LIMIT " + limit.ToString() + ";";

                if (process_between_dates)
                {
                    query_read = "SELECT * FROM `all_event_alarms` WHERE `process_status` = '" + process_status + "' AND `event_datetime` LIKE '%" + process_date.ToString("yyyy-MM-dd") + "%' ORDER BY `alarm_unique_id` ASC LIMIT " + limit.ToString() + ";";
                };

                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();



                //console.ThreadLog(query_read);
                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int row_count = 0;


                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        //alarm_unique_id = (int)dataReader.GetValue(0);

                        // console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());

                        Parts.EventAlarm eventAlarm = new Parts.EventAlarm();


                        //console.ThreadLog("Found event_datetime");

                        DateTime datetime;

                        if (DateTime.TryParseExact(dataReader.GetValue(dataReader.GetOrdinal("event_datetime")).ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                        {
                            
                            eventAlarm.alarm_unique_id = (int)(dataReader.GetValue(dataReader.GetOrdinal("alarm_unique_id")));
                            eventAlarm.event_name = dataReader.GetValue(dataReader.GetOrdinal("event_name")).ToString();
                            eventAlarm.event_type = dataReader.GetValue(dataReader.GetOrdinal("event_type")).ToString();
                            eventAlarm.status = dataReader.GetValue(dataReader.GetOrdinal("status")).ToString();
                            eventAlarm.related_unique_id = (int)(dataReader.GetValue(dataReader.GetOrdinal("related_unique_id")));
                            eventAlarm.process_status = (dataReader.GetValue(dataReader.GetOrdinal("process_status"))).ToString();
                            eventAlarm.debounce_time = (int)(dataReader.GetValue(dataReader.GetOrdinal("debounce_time")));
                            eventAlarm.related_data = dataReader.GetValue(dataReader.GetOrdinal("related_data")).ToString();
                            eventAlarm.event_datetime = datetime;

                            if (dataReader.GetValue(dataReader.GetOrdinal("confidence")).ToString() != "")
                            {
                                eventAlarm.confidence = (int)(dataReader.GetValue(dataReader.GetOrdinal("confidence")));
                            }
                            else {
                                eventAlarm.confidence = 0;
                            };
                            
                            eventAlarms.Add(eventAlarm);

                        }
                        else
                        {
                            console.ThreadLog("Error >> Event DateTime In Database Is Incorrect Format alarm_unique_id = " + (dataReader.GetValue(dataReader.GetOrdinal("alarm_unique_id"))).ToString());
                        };


                        row_count++;
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return eventAlarms;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return eventAlarms;
            }


        }

        public void ResetEventAlarms_VisionCore()
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();


                string query = "UPDATE `event_alarms` SET `process_status`= 'analyzed' WHERE `process_status`= 'processing';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
            }


        }


        public List<Parts.EventAlarm> SearchForEventAlarms_VisionCore(string process_status, int limit, DateTime process_date, bool process_between_dates = false)
        {
            List<Parts.EventAlarm> eventAlarms = new List<Parts.EventAlarm>();

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();


                string query_read = "SELECT * FROM `event_alarms` WHERE `process_status` = '" + process_status + "' ORDER BY `alarm_unique_id` ASC LIMIT " + limit.ToString() + ";";

                if (process_between_dates)
                {
                    query_read = "SELECT * FROM `event_alarms` WHERE `process_status` = '" + process_status + "' AND `event_datetime` LIKE '%" + process_date.ToString("yyyy-MM-dd") + "%' ORDER BY `alarm_unique_id` ASC LIMIT " + limit.ToString() + ";";
                };

                console.ThreadLog(query_read);


                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int row_count = 0;


                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        //alarm_unique_id = (int)dataReader.GetValue(0);

                        // console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());

                        Parts.EventAlarm eventAlarm = new Parts.EventAlarm();


                        //console.ThreadLog("Found event_datetime");

                        DateTime datetime;

                        if (DateTime.TryParseExact(dataReader.GetValue(dataReader.GetOrdinal("event_datetime")).ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                        {
                            eventAlarm.alarm_unique_id = (int)(dataReader.GetValue(dataReader.GetOrdinal("alarm_unique_id")));
                            eventAlarm.event_name = dataReader.GetValue(dataReader.GetOrdinal("event_name")).ToString();
                            eventAlarm.event_type = dataReader.GetValue(dataReader.GetOrdinal("event_type")).ToString();
                            eventAlarm.status = dataReader.GetValue(dataReader.GetOrdinal("status")).ToString();
                            eventAlarm.related_unique_id = (int)(dataReader.GetValue(dataReader.GetOrdinal("related_unique_id")));
                            eventAlarm.process_status = (dataReader.GetValue(dataReader.GetOrdinal("process_status"))).ToString();
                            eventAlarm.debounce_time = (int)(dataReader.GetValue(dataReader.GetOrdinal("debounce_time")));
                            eventAlarm.related_data = dataReader.GetValue(dataReader.GetOrdinal("related_data")).ToString();
                            eventAlarm.event_datetime = datetime;
                            eventAlarm.confidence = (int)dataReader.GetValue(dataReader.GetOrdinal("confidence"));
                            eventAlarm.owner = dataReader.GetValue(dataReader.GetOrdinal("owner")).ToString();
                            eventAlarms.Add(eventAlarm);

                        }
                        else
                        {
                            console.ThreadLog( "Error >> Event DateTime In Database Is Incorrect Format alarm_unique_id = " + (dataReader.GetValue(dataReader.GetOrdinal("alarm_unique_id"))).ToString() );
                        };


                        row_count++;
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return eventAlarms;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return eventAlarms;
            }


        }


        public bool UpdateEventAlarmsFromGUI_VisionCore(List<Parts.EventAlarm> event_alarms)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());
            try
            {
                connection.Open();

                string query = "";

                if (event_alarms.Count <= 0)
                {
                    console.ThreadLog("UpdateEventAlarms_VisionCore() >> No Event Alarms Found...");
                    connection.Close();
                    return true;
                };

                foreach (Parts.EventAlarm event_alarm in event_alarms)
                {

                    console.ThreadLog("`alarm_unique_id` = '" + event_alarm.alarm_unique_id.ToString() + "`process_status` = '" + event_alarm.process_status);

                    query += "UPDATE `event_alarms` SET " +
                    "`process_status` = '" + event_alarm.process_status + "', " +
                    "`owner` = '" + event_alarm.owner + "', " +
                    "`related_data` = '" + event_alarm.related_data + "', " +
                    "`confidence` = '12' " +
                    "WHERE `alarm_unique_id` = '" + event_alarm.alarm_unique_id.ToString() + "'; ";
                };



                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return false;
            }


        }

        //"SELECT * FROM `event_alarms` WHERE `process_status` = '" + process_status + "' ORDER BY `alarm_unique_id` ASC LIMIT " + limit.ToString() + ";";

        public bool UpdateEventAlarms_VisionCore(List<Parts.EventAlarm> event_alarms, string process_status)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());
            try
            {
                connection.Open();

                string query = "";

                if (event_alarms.Count <= 0)
                {
                    console.ThreadLog("UpdateEventAlarms_VisionCore() >> No Event Alarms Found...");
                    connection.Close();
                    return true;
                };

                foreach (Parts.EventAlarm event_alarm in event_alarms)
                {
                    query += "UPDATE `event_alarms` SET " +
                    "`process_status` = '" + process_status + "' " +
                    "WHERE `alarm_unique_id` = '" + event_alarm.alarm_unique_id.ToString() + "'; ";
                };



                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return false;
            }


        }



        public bool UpdateAllEventAlarm_VisionCore(ContainerDetector.Detection detection)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());
            try
            {
                connection.Open();


                string query = "UPDATE `all_event_alarms` SET " +
                    "`process_status` = '" + detection.process_status + "', " +
                    "`status` = '" + detection.status + "', " +
                    "`related_data` = '" + detection.container_id + "', " +
                    "`related_unique_id` = '" + detection.container_unique_id.ToString() + "', " +
                    "`confidence` = '" + detection.confidence.ToString() + "' " +
                    "WHERE `alarm_unique_id` = '" + detection.unique_id.ToString() + "';";

                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();


                console.ThreadLog("Container Status == " + detection.status);
                //  COPY EVENT OVER
                if (detection.status == "Container Found")
                {
                    string query_copy = "INSERT INTO `event_alarms` SELECT * FROM `all_event_alarms`" +
                                         "WHERE `alarm_unique_id` = '" + detection.unique_id.ToString() + "'; " +
                                         "INSERT INTO `backup_event_alarms` SELECT * FROM `all_event_alarms`" +
                                         "WHERE `alarm_unique_id` = '" + detection.unique_id.ToString() + "'; ";

                    console.ThreadLog("DB Query = " + query_copy);

                    MySqlCommand cmd_copy = new MySqlCommand(query_copy, connection);

                    cmd_copy.ExecuteNonQuery();
                };


                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return false;
            }


        }




        public int InsertNewContainerChainEvent_VisionCore(ContainerChain.ChainRecording chainRecording)
        {


            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();

                //string query = "INSERT INTO `container_chain_events`(`container_unique_id`, `container_id`, `status`,  `start_datetime`,  `stop_datetime`) VALUES ('" +
                //    chainRecording.container_unique_id + "', '" +
                //    chainRecording.container_id + "', '" +
                //    chainRecording.status + "', '" +
                //    chainRecording.start_datetime + "', '" +
                //    chainRecording.stop_datetime + "'); SELECT LAST_INSERT_ID();";

                ////console.ThreadLog("DB Query = " + query);

                //MySqlCommand cmd = new MySqlCommand(query, connection);


                //cmd.ExecuteNonQuery();



                string query_read = "INSERT INTO `container_chain_events`(`container_unique_id`, `container_id`, `status`,  `start_datetime`,  `stop_datetime`) VALUES ('" +
                    chainRecording.container_unique_id + "', '" +
                    chainRecording.container_id + "', '" +
                    chainRecording.status + "', '" +
                    chainRecording.start_datetime + "', '" +
                    chainRecording.stop_datetime + "'); SELECT LAST_INSERT_ID();";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int event_unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        event_unique_id = Convert.ToInt32(dataReader.GetValue(0));
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                console.ThreadLog("!IMPORTANT! >>>> Found Event Unique Id = " + event_unique_id.ToString());

                connection.Close();

                chainRecording.unique_id = event_unique_id;
                InsertNewContainerChainEvent_WebGUI(chainRecording);
                //UpdateContainerWithContainerChainEvent_WebGUI(chainRecording);

                return event_unique_id;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }

        }



        public int InsertNewVideoFile_VisionCore(Parts.VideoFile videoFile)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();

                string query = "INSERT INTO `video_files`(`event_unique_id`, `type`, `status`, `channel_number`, `ftp_url`, `file_name`,  `start_datetime`,  `end_datetime`) VALUES ('" +
                    videoFile.relation_data.unique_id + "', '" +
                    videoFile.relation_data.type + "', '" +
                    videoFile.status + "', '" +
                    videoFile.channel_number + "', '" +
                    videoFile.ftp_url + "', '" +
                    videoFile.file_name + "', '" +
                    videoFile.start_datetime + "', '" +
                    videoFile.end_datetime + "')";

                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();



                string query_read = "SELECT `video_unique_id` from `video_files` ORDER BY `video_unique_id` DESC LIMIT 1; ";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int video_unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        video_unique_id = (int)dataReader.GetValue(0);
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                videoFile.video_unique_id = video_unique_id;

                InsertNewVideoFile_WebGUI(videoFile);

                return video_unique_id;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }

        }






        public void UpdateVideoFile_VisionCore(Parts.VideoFile videoFile)
        {

            Thread dbThread = new Thread(delegate () { UpdateVideoFile_VisionCore_Thread(videoFile); });
            dbThread.IsBackground = true;
            dbThread.Start();
            dbThread.Join();

        }


        public void UpdateVideoFile_VisionCore_Thread(Parts.VideoFile videoFile)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_VisionCore());

            try
            {
                connection.Open();

                string query = "UPDATE `video_files` SET " +
                    "`status` = '" + videoFile.status + "', " +
                    "`ftp_url` = '" + videoFile.ftp_url + "', " +
                    "`file_name` = '" + videoFile.file_name + "' " +
                    "WHERE `video_unique_id` = '" + videoFile.video_unique_id.ToString() + "'";

                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();

                connection.Close();

                UpdateVideoFile_WebGUI_Thread(videoFile);
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
            }

        }


        //============================================//
        //============================================//
        //============================================//





        //============================================//  
        //=========[ WEB VISION CORE DB ]=============//
        //============================================//

        public string ConnectionString_WebVisionCore()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = Vision_Core.Properties.Settings.Default.core_sql_ip;
            conn_string.Port = 3306;
            conn_string.UserID = Vision_Core.Properties.Settings.Default.core_sql_login;
            conn_string.Password = Vision_Core.Properties.Settings.Default.core_sql_password;
            conn_string.Database = Vision_Core.Properties.Settings.Default.visioncore_gui_sql_database;
            conn_string.CharacterSet = "utf8";
            conn_string.ConvertZeroDateTime = true;
            return conn_string.ToString();
        }



        public int SelectSystem_WebVisionCore()
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                connection.Open();


                string query_read = "SELECT * from `systems` WHERE `window_title` = '" + Vision_Core.Properties.Settings.Default.system_internal_name + "';";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadLog(query_read);

                int unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        unique_id = (int)dataReader.GetValue(0);
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return unique_id;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }

        }

        public List<Parts.Setting> GetSystemSettings_WebVisionCore(int system_unique_id)
        {
            List<Parts.Setting> systemSettings = new List<Parts.Setting>();


            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                connection.Open();


                string query_read = "SELECT * from `system_settings` WHERE `system_unique_id` = '" + system_unique_id + "';";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadLog(query_read);

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        Parts.Setting systemSetting = new Parts.Setting(
                            dataReader.GetValue(dataReader.GetOrdinal("setting_name")).ToString(),
                            dataReader.GetValue(dataReader.GetOrdinal("setting_data")).ToString(),
                            mainWindow
                        );

                        systemSettings.Add(systemSetting);
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return systemSettings;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return systemSettings;
            }

            
        }


        public void UpdateSystemSettings_WebVisionCore(int system_unique_id)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                List<Parts.Setting> database_system_settings = GetSystemSettings_WebVisionCore(system_unique_id);

                connection.Open();

                string query = "";
                foreach (Parts.Setting systemSetting in mainWindow.cfg.systemSettings)
                {
                    bool query_added = false;

                    foreach (Parts.Setting database_system_setting in database_system_settings)
                    {
                        if (!query_added && database_system_setting.setting_name == systemSetting.setting_name)
                        {
                            query += "UPDATE `system_settings` SET " +
                                "`setting_data` = '" + systemSetting.setting_data + "' " +
                                "WHERE `system_unique_id` = '" + system_unique_id.ToString() + "' AND " +
                                "`setting_name` = '" + systemSetting.setting_name + "'; ";

                            query_added = true;
                        };
                    };

                    if (!query_added)
                    {
                        query += "INSERT INTO `system_settings`(`system_unique_id`, `setting_name`, `setting_data`) VALUES ('" +
                            system_unique_id.ToString() + "', '" +
                            systemSetting.setting_name + "', '" +
                            systemSetting.setting_data + "'); ";
                    }


                };


                //console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
            }


        }


        public List<Parts.EventAlarm> SearchForEventAlarms_WebVisionCore(DateTime process_date)
        {
            List<Parts.EventAlarm> eventAlarms = new List<Parts.EventAlarm>();

            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                connection.Open();


                string query_read = "SELECT * FROM `ready_event_alarms` WHERE `event_datetime` LIKE '%" + process_date.ToString("yyyy-MM-dd") + "%'";


                console.ThreadLog(query_read);


                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int row_count = 0;


                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        //alarm_unique_id = (int)dataReader.GetValue(0);

                        // console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());

                        Parts.EventAlarm eventAlarm = new Parts.EventAlarm();


                        //console.ThreadLog("Found event_datetime");

                        DateTime datetime;

                        if (DateTime.TryParseExact(dataReader.GetValue(dataReader.GetOrdinal("event_datetime")).ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                        {
                            eventAlarm.alarm_unique_id = (int)(dataReader.GetValue(dataReader.GetOrdinal("alarm_unique_id")));
                            eventAlarm.event_name = dataReader.GetValue(dataReader.GetOrdinal("event_name")).ToString();
                            eventAlarm.event_type = dataReader.GetValue(dataReader.GetOrdinal("event_type")).ToString();
                            eventAlarm.status = dataReader.GetValue(dataReader.GetOrdinal("status")).ToString();
                            eventAlarm.related_unique_id = (int)(dataReader.GetValue(dataReader.GetOrdinal("related_unique_id")));
                            eventAlarm.process_status = (dataReader.GetValue(dataReader.GetOrdinal("process_status"))).ToString();
                            eventAlarm.debounce_time = (int)(dataReader.GetValue(dataReader.GetOrdinal("debounce_time")));
                            eventAlarm.related_data = dataReader.GetValue(dataReader.GetOrdinal("related_data")).ToString();
                            eventAlarm.confidence = (int)dataReader.GetValue(dataReader.GetOrdinal("confidence"));
                            eventAlarm.event_datetime = datetime;
                            eventAlarm.owner = dataReader.GetValue(dataReader.GetOrdinal("owner")).ToString();
                            eventAlarms.Add(eventAlarm);

                        }
                        else
                        {
                            console.ThreadLog("Error >> Event DateTime In Database Is Incorrect Format alarm_unique_id = " + (dataReader.GetValue(dataReader.GetOrdinal("alarm_unique_id"))).ToString());
                        };


                        row_count++;
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return eventAlarms;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return eventAlarms;
            }


        }

        public void DeleteEventAlarms_WebGUI(DateTime process_date)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                connection.Open();


                string query_delete = "DELETE FROM `ready_event_alarms` WHERE `event_datetime` LIKE '%" + process_date.ToString("yyyy-MM-dd") + "%'";
                MySqlCommand cmd = new MySqlCommand(query_delete, connection);
                cmd.ExecuteNonQuery();
                console.ThreadLog("Delete: " + query_delete);

                string query_delete_2 = "DELETE FROM `matched_event_alarms` WHERE `event_datetime` LIKE '%" + process_date.ToString("yyyy-MM-dd") + "%'";
                MySqlCommand cmd_2 = new MySqlCommand(query_delete_2, connection);
                cmd_2.ExecuteNonQuery();
                console.ThreadLog("Delete: " + query_delete_2);

                connection.Close();

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
            }
        }

        public int InsertEventAlarms_WebGUI(List<Parts.EventAlarm> event_alarms)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_WebVisionCore());

            try
            {
                connection.Open();

                string query = "";
                foreach (Parts.EventAlarm event_alarm in event_alarms)
                {
                    query += "INSERT INTO `event_alarms`(`alarm_unique_id`, `process_status`, `event_name`, `event_type`, `status`, `event_datetime`, `related_data`, `related_unique_id`, `confidence`, `owner`, `debounce_time`) VALUES ('" +
                    event_alarm.alarm_unique_id + "', '" +
                    event_alarm.process_status + "', '" +
                    event_alarm.event_name + "', '" +
                    event_alarm.event_type + "', '" +
                    event_alarm.status + "', '" +
                    event_alarm.event_datetime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                    event_alarm.related_data + "', '" +
                    event_alarm.related_unique_id + "', '" +
                    event_alarm.confidence + "', '" +
                    event_alarm.owner + "', '" +
                    event_alarm.debounce_time.ToString() + "'); ";

                }


                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();



                string query_read = "SELECT `alarm_unique_id` from `event_alarms` ORDER BY `alarm_unique_id` DESC LIMIT 1; ";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int alarm_unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        alarm_unique_id = (int)dataReader.GetValue(0);
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return alarm_unique_id;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }


        }
        //============================================//
        //============================================//
        //============================================//





        //============================================//  
        //=============[ WEB GUI DB ]=================//
        //============================================//

        public string ConnectionString_WebGUI()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = Vision_Core.Properties.Settings.Default.core_sql_ip;
            conn_string.Port = 3306;
            conn_string.UserID = Vision_Core.Properties.Settings.Default.core_sql_login;
            conn_string.Password = Vision_Core.Properties.Settings.Default.core_sql_password;
            conn_string.Database = Vision_Core.Properties.Settings.Default.core_sql_database;
            conn_string.CharacterSet = "utf8";
            conn_string.ConvertZeroDateTime = true;
            return conn_string.ToString();
        }


  




        public int SelectContainerUniqueId_WebGUI(string container_id)
        {


            MySqlConnection connection = new MySqlConnection(ConnectionString_WebGUI());

            try
            {
                connection.Open();


                string query_read = "SELECT `container_unique_id` from `containers` WHERE `container_id` = '" + container_id + "';";
                MySqlCommand cmd_read = new MySqlCommand(query_read, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadLog(query_read);

                int container_unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        container_unique_id = (int)dataReader.GetValue(0);
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                return container_unique_id;
            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }

        }



        public void InsertNewVideoFile_WebGUI(Parts.VideoFile videoFile)
        {



            MySqlConnection connection = new MySqlConnection(ConnectionString_WebGUI());

            try
            {
                connection.Open();

                string query = "INSERT INTO `video_files`(`video_unique_id`, `event_unique_id`, `type`, `status`, `channel_number`, `ftp_url`, `file_name`,  `start_datetime`,  `end_datetime`) VALUES ('" +
                    videoFile.video_unique_id + "', '" +
                    videoFile.relation_data.unique_id + "', '" +
                    videoFile.relation_data.type + "', '" +
                    videoFile.status + "', '" +
                    videoFile.channel_number + "', '" +
                    videoFile.ftp_url + "', '" +
                    videoFile.file_name + "', '" +
                    videoFile.start_datetime + "', '" +
                    videoFile.end_datetime + "')";

                //console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();



                connection.Close();

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);

            }

        }



        public void UpdateVideoFile_WebGUI_Thread(Parts.VideoFile videoFile)
        {



            MySqlConnection connection = new MySqlConnection(ConnectionString_WebGUI());

            try
            {
                connection.Open();

                string query = "UPDATE `video_files` SET " +
                    "`status` = '" + videoFile.status + "', " +
                    "`ftp_url` = '" + videoFile.ftp_url + "', " +
                    "`file_name` = '" + videoFile.file_name + "' " +
                    "WHERE `video_unique_id` = '" + videoFile.video_unique_id.ToString() + "'";

                console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
            }

        }



        public void InsertNewContainerChainEvent_WebGUI(ContainerChain.ChainRecording chainRecording)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_WebGUI());

            try
            {
                connection.Open();

                string query = "INSERT INTO `container_chain_events`(`event_unique_id`, `container_unique_id`, `container_id`, `status`,  `start_datetime`,  `stop_datetime`) VALUES ('" +
                    chainRecording.unique_id + "', '" +
                    chainRecording.container_unique_id + "', '" +
                    chainRecording.container_id + "', '" +
                    chainRecording.status + "', '" +
                    chainRecording.start_datetime + "', '" +
                    chainRecording.stop_datetime + "')";

                //console.ThreadLog("DB Query = " + query);

                MySqlCommand cmd = new MySqlCommand(query, connection);


                cmd.ExecuteNonQuery();



                

                connection.Close();


            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                
            }

        }



        public int UpdateContainerWithContainerChainEvent_WebGUI(ContainerChain.ChainRecording chainRecording)
        {



            MySqlConnection connection = new MySqlConnection(ConnectionString_WebGUI());

            try
            {
               

                chainRecording.container_unique_id = SelectContainerUniqueId_WebGUI(chainRecording.container_id);

                if (chainRecording.container_unique_id != -1)
                {
                    return chainRecording.container_unique_id;
                };

                connection.Open();

                string query = "INSERT INTO `containers`(`container_id`, `order_unique_id`) " +
                    "VALUES ('" +
                    chainRecording.container_id + "', " +
                    "'-1'); SELECT LAST_INSERT_ID();";

                console.ThreadLog("DB Query = " + query);


                MySqlCommand cmd_read = new MySqlCommand(query, connection);
                //Execute command
                MySqlDataReader dataReader = cmd_read.ExecuteReader();

                //console.ThreadVarDump(JsonConvert.SerializeObject(dataReader));

                int unique_id = -1;

                while (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        unique_id = Convert.ToInt32(dataReader.GetValue(0));
                        //console.ThreadLog(dataReader.GetInt32(0).ToString() + " -- " + dataReader.GetString(0));
                        //console.ThreadLog(dataReader.GetName(0).ToString() + " -- " + dataReader.GetValue(0).ToString());
                    }

                    dataReader.NextResult();
                };

                connection.Close();

                console.ThreadLog("!IMPORTANT! >>>> Found Container Unique Id = " + unique_id.ToString());

                return unique_id;

            }
            catch (Exception ex)
            {
                console.ThreadLog(ex.Message);
                return -1;
            }

        }





        public void InsertSystemCheckInStatus_WebGUI(string external_ip, string device_server_ip, string system_status, bool error, int interval_check)
        {

            MySqlConnection connection = new MySqlConnection(ConnectionString_WebGUI());

            try
            {
                connection.Open();
                string query = "INSERT INTO `systems`(`external_ip`, `device_server_ip`, `system_status`, `system_internal_name`, `timestamp`, `error`, `interval_check`) VALUES ('"
                    + external_ip + "', '" + device_server_ip + "', '" + system_status + "', '" + Vision_Core.Properties.Settings.Default.system_internal_name + "', '" + Tools.UnixTimeStampUTC() + "', '" + (error ? 1 : 0).ToString() + "', '" + interval_check.ToString() + "') ON DUPLICATE KEY UPDATE " +
                    "`external_ip` = VALUES(`external_ip`)," +
                    "`system_status` = VALUES(`system_status`)," +
                    "`timestamp` = VALUES(`timestamp`)," +
                    "`error` = VALUES(`error`)," +
                    "`interval_check` = VALUES(`interval_check`)," +
                    "`device_server_ip` = VALUES(`device_server_ip`);";

                //console.ThreadLog(query);

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                console.Log(ex.Message);
 
            }

        }


        //============================================//
        //============================================//
        //============================================//

    }
}
