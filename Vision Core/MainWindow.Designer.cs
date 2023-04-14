namespace Vision_Core
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.button_connect = new System.Windows.Forms.Button();
            this.progressBar_download = new System.Windows.Forms.ProgressBar();
            this.timer_download = new System.Windows.Forms.Timer(this.components);
            this.label_download_status = new System.Windows.Forms.Label();
            this.button_restart = new System.Windows.Forms.Button();
            this.tabPage_container_chain = new System.Windows.Forms.TabPage();
            this.button_cc_test_stitcher = new System.Windows.Forms.Button();
            this.checkBox_cc_record_channel_6 = new System.Windows.Forms.CheckBox();
            this.checkBox_cc_record_channel_5 = new System.Windows.Forms.CheckBox();
            this.textBox_container_unique_id = new System.Windows.Forms.TextBox();
            this.button_cc_download = new System.Windows.Forms.Button();
            this.label_cc_ftp_sub_dir = new System.Windows.Forms.Label();
            this.textBox_cc_ftp_sub_dir = new System.Windows.Forms.TextBox();
            this.label_cc_min_length = new System.Windows.Forms.Label();
            this.numericUpDown_cc_min_length = new System.Windows.Forms.NumericUpDown();
            this.label_cc_preroll = new System.Windows.Forms.Label();
            this.numericUpDown_cc_preroll = new System.Windows.Forms.NumericUpDown();
            this.button_cc_clear_console = new System.Windows.Forms.Button();
            this.checkBox_cc_download_device_videos = new System.Windows.Forms.CheckBox();
            this.checkBox_cc_record_channel_4 = new System.Windows.Forms.CheckBox();
            this.checkBox_cc_record_channel_3 = new System.Windows.Forms.CheckBox();
            this.checkBox_cc_record_channel_2 = new System.Windows.Forms.CheckBox();
            this.checkBox_cc_record_channel_1 = new System.Windows.Forms.CheckBox();
            this.textBox_container_number = new System.Windows.Forms.TextBox();
            this.listView_container_chain_files_found = new System.Windows.Forms.ListView();
            this.video_unique_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_file_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_start_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_stop_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_download_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_container_chain_container_chain_events = new System.Windows.Forms.ListView();
            this.head_cc_cc_unique_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_cc_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_container_unique_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_container_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_start_search_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_stop_search_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_total_files = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_total_downloaded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.head_cc_converted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_container_chain_stop_time = new System.Windows.Forms.TextBox();
            this.textBox_container_chain_start_time = new System.Windows.Forms.TextBox();
            this.listBox_container_chain_console = new System.Windows.Forms.ListBox();
            this.checkBox_container_chain_autoscroll = new System.Windows.Forms.CheckBox();
            this.button_container_chain_stop = new System.Windows.Forms.Button();
            this.button_container_chain_start = new System.Windows.Forms.Button();
            this.label_settings_record_lag = new System.Windows.Forms.Label();
            this.numericUpDown_settings_record_lag = new System.Windows.Forms.NumericUpDown();
            this.tabPage_hikvision = new System.Windows.Forms.TabPage();
            this.button_hvs_test = new System.Windows.Forms.Button();
            this.button_hvs_clear_console = new System.Windows.Forms.Button();
            this.listBox_hvs_console = new System.Windows.Forms.ListBox();
            this.checkBox_hvs_console_autoscroll = new System.Windows.Forms.CheckBox();
            this.listView_connected_devices = new System.Windows.Forms.ListView();
            this.connected_devices_device = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connected_devices_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.button_backup_databases = new System.Windows.Forms.Button();
            this.button_load_settings = new System.Windows.Forms.Button();
            this.button_save_settings = new System.Windows.Forms.Button();
            this.tabControl_settings = new System.Windows.Forms.TabControl();
            this.tabPage_settings_server = new System.Windows.Forms.TabPage();
            this.label_server_ip = new System.Windows.Forms.Label();
            this.textBox_server_ip = new System.Windows.Forms.TextBox();
            this.textBox_server_port = new System.Windows.Forms.TextBox();
            this.label_server_port = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.tabPage_settings_system = new System.Windows.Forms.TabPage();
            this.label_system_watchgod_id = new System.Windows.Forms.Label();
            this.textBox_system_watchgod_id = new System.Windows.Forms.TextBox();
            this.checkBox_cc_clean_up = new System.Windows.Forms.CheckBox();
            this.checkBox_cd_clean_up = new System.Windows.Forms.CheckBox();
            this.textBox_save_folder = new System.Windows.Forms.TextBox();
            this.button_choose_save_folder = new System.Windows.Forms.Button();
            this.label_system_internal_name = new System.Windows.Forms.Label();
            this.textBox_system_internal_name = new System.Windows.Forms.TextBox();
            this.tabPage_settings_ftp = new System.Windows.Forms.TabPage();
            this.label_ftp_credentials = new System.Windows.Forms.Label();
            this.textBox_FTP_IP = new System.Windows.Forms.TextBox();
            this.label_FTP_IP = new System.Windows.Forms.Label();
            this.textBox_FTP_user_name = new System.Windows.Forms.TextBox();
            this.label_FTP_user_name = new System.Windows.Forms.Label();
            this.textBox_FTP_password = new System.Windows.Forms.TextBox();
            this.label_FTP_password = new System.Windows.Forms.Label();
            this.tabPage_settings_web_sql = new System.Windows.Forms.TabPage();
            this.textBox_vision_core_gui_sql_database = new System.Windows.Forms.TextBox();
            this.label_vision_core_gui_sql_database = new System.Windows.Forms.Label();
            this.textBox_core_sql_database = new System.Windows.Forms.TextBox();
            this.label_core_sql_database = new System.Windows.Forms.Label();
            this.label_core_sql_credentials = new System.Windows.Forms.Label();
            this.textBox_core_sql_ip = new System.Windows.Forms.TextBox();
            this.label_core_sql_ip = new System.Windows.Forms.Label();
            this.textBox_core_sql_login = new System.Windows.Forms.TextBox();
            this.label_core_sql_login = new System.Windows.Forms.Label();
            this.textBox_core_sql_password = new System.Windows.Forms.TextBox();
            this.label_core_sql_password = new System.Windows.Forms.Label();
            this.tabPage_settings_vision_core_sql = new System.Windows.Forms.TabPage();
            this.label_vision_sql_credentials = new System.Windows.Forms.Label();
            this.label_vision_sql_database = new System.Windows.Forms.Label();
            this.textBox_vision_sql_ip = new System.Windows.Forms.TextBox();
            this.textBox_vision_sql_database = new System.Windows.Forms.TextBox();
            this.label_vision_sql_ip = new System.Windows.Forms.Label();
            this.textBox_vision_sql_login = new System.Windows.Forms.TextBox();
            this.label_vision_sql_login = new System.Windows.Forms.Label();
            this.label_vision_sql_password = new System.Windows.Forms.Label();
            this.textBox_vision_sql_password = new System.Windows.Forms.TextBox();
            this.tabPage_settings_conversion = new System.Windows.Forms.TabPage();
            this.label_settings_conversion_quality = new System.Windows.Forms.Label();
            this.comboBox_settings_conversion_quality = new System.Windows.Forms.ComboBox();
            this.listBox_error = new System.Windows.Forms.ListBox();
            this.button_clear_thread = new System.Windows.Forms.Button();
            this.tabPage_console = new System.Windows.Forms.TabPage();
            this.label_console_error = new System.Windows.Forms.Label();
            this.label_console_main = new System.Windows.Forms.Label();
            this.listBox_console = new System.Windows.Forms.ListBox();
            this.button_clear_console = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_em = new System.Windows.Forms.TabPage();
            this.listView_event_alarm = new System.Windows.Forms.ListView();
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_em_clear_console = new System.Windows.Forms.Button();
            this.checkBox_em_console_autoscroll = new System.Windows.Forms.CheckBox();
            this.listBox_em_console = new System.Windows.Forms.ListBox();
            this.groupBox_em = new System.Windows.Forms.GroupBox();
            this.textBox_em_set_datetime_cd = new System.Windows.Forms.TextBox();
            this.button_em_set_datetime_cd = new System.Windows.Forms.Button();
            this.button_em_test_cd = new System.Windows.Forms.Button();
            this.textBox_em_debounce_countdown_cd = new System.Windows.Forms.TextBox();
            this.numericUpDown_em_trigger_buffer_cd = new System.Windows.Forms.NumericUpDown();
            this.label_em_alarm_debounce_cd = new System.Windows.Forms.Label();
            this.comboBox_em_type_cd = new System.Windows.Forms.ComboBox();
            this.numericUpDown_em_channel_cd = new System.Windows.Forms.NumericUpDown();
            this.button_em_arm_cd = new System.Windows.Forms.Button();
            this.label_em_channel_cd = new System.Windows.Forms.Label();
            this.tabPage_container_process_analyzer = new System.Windows.Forms.TabPage();
            this.button_cpa_pull = new System.Windows.Forms.Button();
            this.button_cpa_push = new System.Windows.Forms.Button();
            this.label_cpa_owner = new System.Windows.Forms.Label();
            this.textBox_cpa_owner = new System.Windows.Forms.TextBox();
            this.checkBox_cpa_process_date = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_cpa_process_datetime = new System.Windows.Forms.DateTimePicker();
            this.checkBox_cpa_reprocess = new System.Windows.Forms.CheckBox();
            this.listView_cpa_event_output_data = new System.Windows.Forms.ListView();
            this.columnHeader69 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox_cpa_last_event_at_next_container = new System.Windows.Forms.CheckBox();
            this.numericUpDown_cpa_debounce = new System.Windows.Forms.NumericUpDown();
            this.label_cpa_debounce = new System.Windows.Forms.Label();
            this.textBox_cpa_debounce_countdown = new System.Windows.Forms.TextBox();
            this.button_cpa_start = new System.Windows.Forms.Button();
            this.listView_cpa_events = new System.Windows.Forms.ListView();
            this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader67 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader65 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader66 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader68 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_cpa_clear_console = new System.Windows.Forms.Button();
            this.checkBox_cpa_console_autoscroll = new System.Windows.Forms.CheckBox();
            this.listBox_cpa_console = new System.Windows.Forms.ListBox();
            this.tabPage_container_detector = new System.Windows.Forms.TabPage();
            this.checkBox_cd_process_date = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_cd_process_datetime = new System.Windows.Forms.DateTimePicker();
            this.button_cd_start = new System.Windows.Forms.Button();
            this.numericUpDown_cd_database_cycle_time = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cd_trigger_settime = new System.Windows.Forms.Button();
            this.button_cd_set_datetime = new System.Windows.Forms.Button();
            this.textBox_cd_trigger_datetime = new System.Windows.Forms.TextBox();
            this.button_cd_test_image_extractor_again = new System.Windows.Forms.Button();
            this.button_cd_test_image_extractor = new System.Windows.Forms.Button();
            this.button_cd_search_events = new System.Windows.Forms.Button();
            this.numericUpDown_cd_recording_channel = new System.Windows.Forms.NumericUpDown();
            this.label_cd_recording_channel = new System.Windows.Forms.Label();
            this.label_cd_recording_timer = new System.Windows.Forms.Label();
            this.textBox_cd_recording_timer = new System.Windows.Forms.TextBox();
            this.label_cd_recording_time = new System.Windows.Forms.Label();
            this.numericUpDown_cd_recording_time = new System.Windows.Forms.NumericUpDown();
            this.label_cd_preroll = new System.Windows.Forms.Label();
            this.numericUpDown_cd_preroll = new System.Windows.Forms.NumericUpDown();
            this.button_cd_event_trigger = new System.Windows.Forms.Button();
            this.listView_cd_queue = new System.Windows.Forms.ListView();
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_cd_clear_console = new System.Windows.Forms.Button();
            this.checkBox_cd_console_autoscroll = new System.Windows.Forms.CheckBox();
            this.listBox_cd_console = new System.Windows.Forms.ListBox();
            this.tabPage_image_extractor = new System.Windows.Forms.TabPage();
            this.numericUpDown_ie_crop_y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ie_crop_x = new System.Windows.Forms.NumericUpDown();
            this.label_ie_crop_position = new System.Windows.Forms.Label();
            this.numericUpDown_ie_crop_height = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ie_crop_width = new System.Windows.Forms.NumericUpDown();
            this.label_ie_crop_size = new System.Windows.Forms.Label();
            this.numericUpDown_ie_extract_rate = new System.Windows.Forms.NumericUpDown();
            this.label_ie_extract_rate = new System.Windows.Forms.Label();
            this.listView_ie_extractor_queue = new System.Windows.Forms.ListView();
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ie_clear_console = new System.Windows.Forms.Button();
            this.checkBox_ie_console_autoscroll = new System.Windows.Forms.CheckBox();
            this.listBox_ie_console = new System.Windows.Forms.ListBox();
            this.tabPage_vision_ai = new System.Windows.Forms.TabPage();
            this.button_test_vision_analyzer_single_image = new System.Windows.Forms.Button();
            this.label_va_min_confidence = new System.Windows.Forms.Label();
            this.numericUpDown_va_min_confidence = new System.Windows.Forms.NumericUpDown();
            this.checkBox_va_object_detection_active = new System.Windows.Forms.CheckBox();
            this.label_va_azure_debounce = new System.Windows.Forms.Label();
            this.numericUpDown_va_azure_debounce = new System.Windows.Forms.NumericUpDown();
            this.listView_va_vision_queue = new System.Windows.Forms.ListView();
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_va_filelist = new System.Windows.Forms.ListView();
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader72 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_va_labels_dectected = new System.Windows.Forms.ListView();
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_va_text_dectected = new System.Windows.Forms.ListView();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader71 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_va_clear_console = new System.Windows.Forms.Button();
            this.checkBox_va_auto_scroll = new System.Windows.Forms.CheckBox();
            this.listBox_va_console = new System.Windows.Forms.ListBox();
            this.tabPage_video_converter = new System.Windows.Forms.TabPage();
            this.listView_vc_queue = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_vc_clear_console = new System.Windows.Forms.Button();
            this.checkBox_vc_auto_scroll = new System.Windows.Forms.CheckBox();
            this.listBox_vc_console = new System.Windows.Forms.ListBox();
            this.tabPage_ftp = new System.Windows.Forms.TabPage();
            this.listView_ftp_queue = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ftp_clear_console = new System.Windows.Forms.Button();
            this.checkBox_ftp_auto_scroll = new System.Windows.Forms.CheckBox();
            this.listBox_ftp_console = new System.Windows.Forms.ListBox();
            this.tabPage_db = new System.Windows.Forms.TabPage();
            this.button_db_test_connections = new System.Windows.Forms.Button();
            this.button_db_clear_console = new System.Windows.Forms.Button();
            this.checkBox_db_auto_scroll = new System.Windows.Forms.CheckBox();
            this.listBox_db_console = new System.Windows.Forms.ListBox();
            this.tabPage_downloader = new System.Windows.Forms.TabPage();
            this.textBox_downloader_countdown_timer = new System.Windows.Forms.TextBox();
            this.button_downloader_clear_console = new System.Windows.Forms.Button();
            this.checkBox_downloader_console_autoscroll = new System.Windows.Forms.CheckBox();
            this.listBox_downloader_console = new System.Windows.Forms.ListBox();
            this.listView_download_queue = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_ftp_upload_status = new System.Windows.Forms.Label();
            this.progressBar_ftp_upload_status = new System.Windows.Forms.ProgressBar();
            this.textBox_current_time = new System.Windows.Forms.TextBox();
            this.label_build_version = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.label_setting_system_name_info = new System.Windows.Forms.Label();
            this.tabPage_container_chain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cc_min_length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cc_preroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_settings_record_lag)).BeginInit();
            this.tabPage_hikvision.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            this.tabControl_settings.SuspendLayout();
            this.tabPage_settings_server.SuspendLayout();
            this.tabPage_settings_system.SuspendLayout();
            this.tabPage_settings_ftp.SuspendLayout();
            this.tabPage_settings_web_sql.SuspendLayout();
            this.tabPage_settings_vision_core_sql.SuspendLayout();
            this.tabPage_settings_conversion.SuspendLayout();
            this.tabPage_console.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_em.SuspendLayout();
            this.groupBox_em.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_em_trigger_buffer_cd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_em_channel_cd)).BeginInit();
            this.tabPage_container_process_analyzer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cpa_debounce)).BeginInit();
            this.tabPage_container_detector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_database_cycle_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_recording_channel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_recording_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_preroll)).BeginInit();
            this.tabPage_image_extractor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_extract_rate)).BeginInit();
            this.tabPage_vision_ai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_va_min_confidence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_va_azure_debounce)).BeginInit();
            this.tabPage_video_converter.SuspendLayout();
            this.tabPage_ftp.SuspendLayout();
            this.tabPage_db.SuspendLayout();
            this.tabPage_downloader.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(6, 6);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(179, 53);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "CONNECT";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.Button_connect_Click);
            // 
            // progressBar_download
            // 
            this.progressBar_download.Location = new System.Drawing.Point(927, 19);
            this.progressBar_download.Name = "progressBar_download";
            this.progressBar_download.Size = new System.Drawing.Size(314, 11);
            this.progressBar_download.TabIndex = 27;
            // 
            // timer_download
            // 
            this.timer_download.Tick += new System.EventHandler(this.Timer_download_Tick);
            // 
            // label_download_status
            // 
            this.label_download_status.AutoSize = true;
            this.label_download_status.Location = new System.Drawing.Point(925, 6);
            this.label_download_status.Name = "label_download_status";
            this.label_download_status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_download_status.Size = new System.Drawing.Size(88, 13);
            this.label_download_status.TabIndex = 53;
            this.label_download_status.Text = "Download Status";
            // 
            // button_restart
            // 
            this.button_restart.Location = new System.Drawing.Point(1247, 5);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(98, 25);
            this.button_restart.TabIndex = 64;
            this.button_restart.Text = "RESTART";
            this.button_restart.UseVisualStyleBackColor = true;
            this.button_restart.Click += new System.EventHandler(this.Button_restart_Click);
            // 
            // tabPage_container_chain
            // 
            this.tabPage_container_chain.Controls.Add(this.button_cc_test_stitcher);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_record_channel_6);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_record_channel_5);
            this.tabPage_container_chain.Controls.Add(this.textBox_container_unique_id);
            this.tabPage_container_chain.Controls.Add(this.button_cc_download);
            this.tabPage_container_chain.Controls.Add(this.label_cc_ftp_sub_dir);
            this.tabPage_container_chain.Controls.Add(this.textBox_cc_ftp_sub_dir);
            this.tabPage_container_chain.Controls.Add(this.label_cc_min_length);
            this.tabPage_container_chain.Controls.Add(this.numericUpDown_cc_min_length);
            this.tabPage_container_chain.Controls.Add(this.label_cc_preroll);
            this.tabPage_container_chain.Controls.Add(this.numericUpDown_cc_preroll);
            this.tabPage_container_chain.Controls.Add(this.button_cc_clear_console);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_download_device_videos);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_record_channel_4);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_record_channel_3);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_record_channel_2);
            this.tabPage_container_chain.Controls.Add(this.checkBox_cc_record_channel_1);
            this.tabPage_container_chain.Controls.Add(this.textBox_container_number);
            this.tabPage_container_chain.Controls.Add(this.listView_container_chain_files_found);
            this.tabPage_container_chain.Controls.Add(this.listView_container_chain_container_chain_events);
            this.tabPage_container_chain.Controls.Add(this.textBox_container_chain_stop_time);
            this.tabPage_container_chain.Controls.Add(this.textBox_container_chain_start_time);
            this.tabPage_container_chain.Controls.Add(this.listBox_container_chain_console);
            this.tabPage_container_chain.Controls.Add(this.checkBox_container_chain_autoscroll);
            this.tabPage_container_chain.Controls.Add(this.button_container_chain_stop);
            this.tabPage_container_chain.Controls.Add(this.button_container_chain_start);
            this.tabPage_container_chain.Location = new System.Drawing.Point(4, 22);
            this.tabPage_container_chain.Name = "tabPage_container_chain";
            this.tabPage_container_chain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_container_chain.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_container_chain.TabIndex = 8;
            this.tabPage_container_chain.Text = "Container Chain";
            this.tabPage_container_chain.UseVisualStyleBackColor = true;
            // 
            // button_cc_test_stitcher
            // 
            this.button_cc_test_stitcher.Location = new System.Drawing.Point(1102, 138);
            this.button_cc_test_stitcher.Name = "button_cc_test_stitcher";
            this.button_cc_test_stitcher.Size = new System.Drawing.Size(223, 23);
            this.button_cc_test_stitcher.TabIndex = 78;
            this.button_cc_test_stitcher.Text = "TEST STITCHER";
            this.button_cc_test_stitcher.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_record_channel_6
            // 
            this.checkBox_cc_record_channel_6.AutoSize = true;
            this.checkBox_cc_record_channel_6.Location = new System.Drawing.Point(1102, 305);
            this.checkBox_cc_record_channel_6.Name = "checkBox_cc_record_channel_6";
            this.checkBox_cc_record_channel_6.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cc_record_channel_6.TabIndex = 77;
            this.checkBox_cc_record_channel_6.Text = "Channel 6";
            this.checkBox_cc_record_channel_6.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_record_channel_5
            // 
            this.checkBox_cc_record_channel_5.AutoSize = true;
            this.checkBox_cc_record_channel_5.Checked = true;
            this.checkBox_cc_record_channel_5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cc_record_channel_5.Location = new System.Drawing.Point(1102, 282);
            this.checkBox_cc_record_channel_5.Name = "checkBox_cc_record_channel_5";
            this.checkBox_cc_record_channel_5.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cc_record_channel_5.TabIndex = 76;
            this.checkBox_cc_record_channel_5.Text = "Channel 5";
            this.checkBox_cc_record_channel_5.UseVisualStyleBackColor = true;
            // 
            // textBox_container_unique_id
            // 
            this.textBox_container_unique_id.Location = new System.Drawing.Point(1103, 112);
            this.textBox_container_unique_id.Name = "textBox_container_unique_id";
            this.textBox_container_unique_id.Size = new System.Drawing.Size(222, 20);
            this.textBox_container_unique_id.TabIndex = 75;
            this.textBox_container_unique_id.Text = "-1";
            // 
            // button_cc_download
            // 
            this.button_cc_download.Location = new System.Drawing.Point(1103, 57);
            this.button_cc_download.Name = "button_cc_download";
            this.button_cc_download.Size = new System.Drawing.Size(222, 23);
            this.button_cc_download.TabIndex = 74;
            this.button_cc_download.Text = "DOWNLOAD";
            this.button_cc_download.UseVisualStyleBackColor = true;
            this.button_cc_download.Click += new System.EventHandler(this.Button_cc_download_Click);
            // 
            // label_cc_ftp_sub_dir
            // 
            this.label_cc_ftp_sub_dir.AutoSize = true;
            this.label_cc_ftp_sub_dir.Location = new System.Drawing.Point(1101, 412);
            this.label_cc_ftp_sub_dir.Name = "label_cc_ftp_sub_dir";
            this.label_cc_ftp_sub_dir.Size = new System.Drawing.Size(94, 13);
            this.label_cc_ftp_sub_dir.TabIndex = 73;
            this.label_cc_ftp_sub_dir.Text = "FTP Sub Directory";
            // 
            // textBox_cc_ftp_sub_dir
            // 
            this.textBox_cc_ftp_sub_dir.Location = new System.Drawing.Point(1201, 409);
            this.textBox_cc_ftp_sub_dir.Name = "textBox_cc_ftp_sub_dir";
            this.textBox_cc_ftp_sub_dir.Size = new System.Drawing.Size(125, 20);
            this.textBox_cc_ftp_sub_dir.TabIndex = 72;
            // 
            // label_cc_min_length
            // 
            this.label_cc_min_length.AutoSize = true;
            this.label_cc_min_length.Location = new System.Drawing.Point(1101, 385);
            this.label_cc_min_length.Name = "label_cc_min_length";
            this.label_cc_min_length.Size = new System.Drawing.Size(115, 13);
            this.label_cc_min_length.TabIndex = 71;
            this.label_cc_min_length.Text = "Minimum Event Length";
            // 
            // numericUpDown_cc_min_length
            // 
            this.numericUpDown_cc_min_length.Location = new System.Drawing.Point(1268, 383);
            this.numericUpDown_cc_min_length.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_cc_min_length.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown_cc_min_length.Name = "numericUpDown_cc_min_length";
            this.numericUpDown_cc_min_length.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_cc_min_length.TabIndex = 70;
            this.numericUpDown_cc_min_length.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label_cc_preroll
            // 
            this.label_cc_preroll.AutoSize = true;
            this.label_cc_preroll.Location = new System.Drawing.Point(1101, 359);
            this.label_cc_preroll.Name = "label_cc_preroll";
            this.label_cc_preroll.Size = new System.Drawing.Size(44, 13);
            this.label_cc_preroll.TabIndex = 69;
            this.label_cc_preroll.Text = "Pre-Roll";
            // 
            // numericUpDown_cc_preroll
            // 
            this.numericUpDown_cc_preroll.Location = new System.Drawing.Point(1268, 357);
            this.numericUpDown_cc_preroll.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_cc_preroll.Name = "numericUpDown_cc_preroll";
            this.numericUpDown_cc_preroll.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_cc_preroll.TabIndex = 68;
            this.numericUpDown_cc_preroll.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // button_cc_clear_console
            // 
            this.button_cc_clear_console.Location = new System.Drawing.Point(1250, 435);
            this.button_cc_clear_console.Name = "button_cc_clear_console";
            this.button_cc_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_cc_clear_console.TabIndex = 67;
            this.button_cc_clear_console.Text = "Clear";
            this.button_cc_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_download_device_videos
            // 
            this.checkBox_cc_download_device_videos.AutoSize = true;
            this.checkBox_cc_download_device_videos.Location = new System.Drawing.Point(1102, 167);
            this.checkBox_cc_download_device_videos.Name = "checkBox_cc_download_device_videos";
            this.checkBox_cc_download_device_videos.Size = new System.Drawing.Size(207, 17);
            this.checkBox_cc_download_device_videos.TabIndex = 66;
            this.checkBox_cc_download_device_videos.Text = "Download Device Videos (Full Length)";
            this.checkBox_cc_download_device_videos.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_record_channel_4
            // 
            this.checkBox_cc_record_channel_4.AutoSize = true;
            this.checkBox_cc_record_channel_4.Checked = true;
            this.checkBox_cc_record_channel_4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cc_record_channel_4.Location = new System.Drawing.Point(1102, 259);
            this.checkBox_cc_record_channel_4.Name = "checkBox_cc_record_channel_4";
            this.checkBox_cc_record_channel_4.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cc_record_channel_4.TabIndex = 65;
            this.checkBox_cc_record_channel_4.Text = "Channel 4";
            this.checkBox_cc_record_channel_4.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_record_channel_3
            // 
            this.checkBox_cc_record_channel_3.AutoSize = true;
            this.checkBox_cc_record_channel_3.Checked = true;
            this.checkBox_cc_record_channel_3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cc_record_channel_3.Location = new System.Drawing.Point(1102, 236);
            this.checkBox_cc_record_channel_3.Name = "checkBox_cc_record_channel_3";
            this.checkBox_cc_record_channel_3.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cc_record_channel_3.TabIndex = 64;
            this.checkBox_cc_record_channel_3.Text = "Channel 3";
            this.checkBox_cc_record_channel_3.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_record_channel_2
            // 
            this.checkBox_cc_record_channel_2.AutoSize = true;
            this.checkBox_cc_record_channel_2.Checked = true;
            this.checkBox_cc_record_channel_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cc_record_channel_2.Location = new System.Drawing.Point(1102, 213);
            this.checkBox_cc_record_channel_2.Name = "checkBox_cc_record_channel_2";
            this.checkBox_cc_record_channel_2.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cc_record_channel_2.TabIndex = 63;
            this.checkBox_cc_record_channel_2.Text = "Channel 2";
            this.checkBox_cc_record_channel_2.UseVisualStyleBackColor = true;
            // 
            // checkBox_cc_record_channel_1
            // 
            this.checkBox_cc_record_channel_1.AutoSize = true;
            this.checkBox_cc_record_channel_1.Checked = true;
            this.checkBox_cc_record_channel_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cc_record_channel_1.Location = new System.Drawing.Point(1102, 190);
            this.checkBox_cc_record_channel_1.Name = "checkBox_cc_record_channel_1";
            this.checkBox_cc_record_channel_1.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cc_record_channel_1.TabIndex = 62;
            this.checkBox_cc_record_channel_1.Text = "Channel 1";
            this.checkBox_cc_record_channel_1.UseVisualStyleBackColor = true;
            // 
            // textBox_container_number
            // 
            this.textBox_container_number.Location = new System.Drawing.Point(1103, 86);
            this.textBox_container_number.Name = "textBox_container_number";
            this.textBox_container_number.Size = new System.Drawing.Size(222, 20);
            this.textBox_container_number.TabIndex = 61;
            this.textBox_container_number.Text = "Container Number";
            // 
            // listView_container_chain_files_found
            // 
            this.listView_container_chain_files_found.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.video_unique_id,
            this.head_cc_file_name,
            this.head_cc_status,
            this.head_cc_start_time,
            this.head_cc_stop_time,
            this.head_cc_download_status,
            this.columnHeader12,
            this.columnHeader21});
            this.listView_container_chain_files_found.HideSelection = false;
            this.listView_container_chain_files_found.Location = new System.Drawing.Point(6, 207);
            this.listView_container_chain_files_found.Name = "listView_container_chain_files_found";
            this.listView_container_chain_files_found.Size = new System.Drawing.Size(1091, 251);
            this.listView_container_chain_files_found.TabIndex = 59;
            this.listView_container_chain_files_found.UseCompatibleStateImageBehavior = false;
            this.listView_container_chain_files_found.View = System.Windows.Forms.View.Details;
            // 
            // video_unique_id
            // 
            this.video_unique_id.Text = "Video Unique Id";
            this.video_unique_id.Width = 100;
            // 
            // head_cc_file_name
            // 
            this.head_cc_file_name.Text = "File Name";
            this.head_cc_file_name.Width = 250;
            // 
            // head_cc_status
            // 
            this.head_cc_status.Text = "Status";
            this.head_cc_status.Width = 120;
            // 
            // head_cc_start_time
            // 
            this.head_cc_start_time.Text = "Start Time";
            this.head_cc_start_time.Width = 160;
            // 
            // head_cc_stop_time
            // 
            this.head_cc_stop_time.Text = "Stop Time";
            this.head_cc_stop_time.Width = 160;
            // 
            // head_cc_download_status
            // 
            this.head_cc_download_status.Text = "Downloaded";
            this.head_cc_download_status.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Converted";
            this.columnHeader12.Width = 75;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Uploaded";
            // 
            // listView_container_chain_container_chain_events
            // 
            this.listView_container_chain_container_chain_events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.head_cc_cc_unique_id,
            this.head_cc_cc_status,
            this.head_cc_container_unique_id,
            this.head_cc_container_id,
            this.head_cc_start_search_time,
            this.head_cc_stop_search_time,
            this.head_cc_total_files,
            this.head_cc_total_downloaded,
            this.head_cc_converted,
            this.columnHeader22});
            this.listView_container_chain_container_chain_events.HideSelection = false;
            this.listView_container_chain_container_chain_events.Location = new System.Drawing.Point(6, 6);
            this.listView_container_chain_container_chain_events.Name = "listView_container_chain_container_chain_events";
            this.listView_container_chain_container_chain_events.Size = new System.Drawing.Size(1091, 195);
            this.listView_container_chain_container_chain_events.TabIndex = 60;
            this.listView_container_chain_container_chain_events.UseCompatibleStateImageBehavior = false;
            this.listView_container_chain_container_chain_events.View = System.Windows.Forms.View.Details;
            // 
            // head_cc_cc_unique_id
            // 
            this.head_cc_cc_unique_id.Text = "Unique Id";
            // 
            // head_cc_cc_status
            // 
            this.head_cc_cc_status.Text = "Status";
            this.head_cc_cc_status.Width = 130;
            // 
            // head_cc_container_unique_id
            // 
            this.head_cc_container_unique_id.Text = "Container Unique Id";
            this.head_cc_container_unique_id.Width = 120;
            // 
            // head_cc_container_id
            // 
            this.head_cc_container_id.Text = "Container Id";
            this.head_cc_container_id.Width = 145;
            // 
            // head_cc_start_search_time
            // 
            this.head_cc_start_search_time.Text = "Start Time";
            this.head_cc_start_search_time.Width = 150;
            // 
            // head_cc_stop_search_time
            // 
            this.head_cc_stop_search_time.Text = "Stop Time";
            this.head_cc_stop_search_time.Width = 150;
            // 
            // head_cc_total_files
            // 
            this.head_cc_total_files.Text = "Video Files";
            this.head_cc_total_files.Width = 100;
            // 
            // head_cc_total_downloaded
            // 
            this.head_cc_total_downloaded.Text = "Downloaded";
            this.head_cc_total_downloaded.Width = 100;
            // 
            // head_cc_converted
            // 
            this.head_cc_converted.Text = "Converted";
            this.head_cc_converted.Width = 75;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Uploaded";
            // 
            // textBox_container_chain_stop_time
            // 
            this.textBox_container_chain_stop_time.Location = new System.Drawing.Point(1103, 32);
            this.textBox_container_chain_stop_time.Name = "textBox_container_chain_stop_time";
            this.textBox_container_chain_stop_time.Size = new System.Drawing.Size(141, 20);
            this.textBox_container_chain_stop_time.TabIndex = 3;
            // 
            // textBox_container_chain_start_time
            // 
            this.textBox_container_chain_start_time.Location = new System.Drawing.Point(1103, 6);
            this.textBox_container_chain_start_time.Name = "textBox_container_chain_start_time";
            this.textBox_container_chain_start_time.Size = new System.Drawing.Size(141, 20);
            this.textBox_container_chain_start_time.TabIndex = 2;
            // 
            // listBox_container_chain_console
            // 
            this.listBox_container_chain_console.FormattingEnabled = true;
            this.listBox_container_chain_console.Location = new System.Drawing.Point(6, 464);
            this.listBox_container_chain_console.Name = "listBox_container_chain_console";
            this.listBox_container_chain_console.Size = new System.Drawing.Size(1320, 173);
            this.listBox_container_chain_console.TabIndex = 58;
            // 
            // checkBox_container_chain_autoscroll
            // 
            this.checkBox_container_chain_autoscroll.AutoSize = true;
            this.checkBox_container_chain_autoscroll.Checked = true;
            this.checkBox_container_chain_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_container_chain_autoscroll.Location = new System.Drawing.Point(1170, 439);
            this.checkBox_container_chain_autoscroll.Name = "checkBox_container_chain_autoscroll";
            this.checkBox_container_chain_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_container_chain_autoscroll.TabIndex = 57;
            this.checkBox_container_chain_autoscroll.Text = "AutoScroll";
            this.checkBox_container_chain_autoscroll.UseVisualStyleBackColor = true;
            // 
            // button_container_chain_stop
            // 
            this.button_container_chain_stop.Location = new System.Drawing.Point(1250, 30);
            this.button_container_chain_stop.Name = "button_container_chain_stop";
            this.button_container_chain_stop.Size = new System.Drawing.Size(75, 23);
            this.button_container_chain_stop.TabIndex = 1;
            this.button_container_chain_stop.Text = "STOP";
            this.button_container_chain_stop.UseVisualStyleBackColor = true;
            this.button_container_chain_stop.Click += new System.EventHandler(this.Button_container_chain_stop_Click);
            // 
            // button_container_chain_start
            // 
            this.button_container_chain_start.Location = new System.Drawing.Point(1251, 4);
            this.button_container_chain_start.Name = "button_container_chain_start";
            this.button_container_chain_start.Size = new System.Drawing.Size(75, 23);
            this.button_container_chain_start.TabIndex = 0;
            this.button_container_chain_start.Text = "START";
            this.button_container_chain_start.UseVisualStyleBackColor = true;
            this.button_container_chain_start.Click += new System.EventHandler(this.Button_container_chain_start_Click);
            // 
            // label_settings_record_lag
            // 
            this.label_settings_record_lag.AutoSize = true;
            this.label_settings_record_lag.Location = new System.Drawing.Point(252, 73);
            this.label_settings_record_lag.Name = "label_settings_record_lag";
            this.label_settings_record_lag.Size = new System.Drawing.Size(77, 13);
            this.label_settings_record_lag.TabIndex = 76;
            this.label_settings_record_lag.Text = "Recording Lag";
            // 
            // numericUpDown_settings_record_lag
            // 
            this.numericUpDown_settings_record_lag.Location = new System.Drawing.Point(419, 70);
            this.numericUpDown_settings_record_lag.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_settings_record_lag.Name = "numericUpDown_settings_record_lag";
            this.numericUpDown_settings_record_lag.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_settings_record_lag.TabIndex = 75;
            this.numericUpDown_settings_record_lag.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tabPage_hikvision
            // 
            this.tabPage_hikvision.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_hikvision.Controls.Add(this.button_hvs_test);
            this.tabPage_hikvision.Controls.Add(this.button_hvs_clear_console);
            this.tabPage_hikvision.Controls.Add(this.listBox_hvs_console);
            this.tabPage_hikvision.Controls.Add(this.checkBox_hvs_console_autoscroll);
            this.tabPage_hikvision.Controls.Add(this.listView_connected_devices);
            this.tabPage_hikvision.Controls.Add(this.button_connect);
            this.tabPage_hikvision.Location = new System.Drawing.Point(4, 22);
            this.tabPage_hikvision.Name = "tabPage_hikvision";
            this.tabPage_hikvision.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_hikvision.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_hikvision.TabIndex = 6;
            this.tabPage_hikvision.Text = "Hikvision";
            // 
            // button_hvs_test
            // 
            this.button_hvs_test.Location = new System.Drawing.Point(6, 262);
            this.button_hvs_test.Name = "button_hvs_test";
            this.button_hvs_test.Size = new System.Drawing.Size(75, 23);
            this.button_hvs_test.TabIndex = 71;
            this.button_hvs_test.Text = "TEST";
            this.button_hvs_test.UseVisualStyleBackColor = true;
            // 
            // button_hvs_clear_console
            // 
            this.button_hvs_clear_console.Location = new System.Drawing.Point(1251, 262);
            this.button_hvs_clear_console.Name = "button_hvs_clear_console";
            this.button_hvs_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_hvs_clear_console.TabIndex = 70;
            this.button_hvs_clear_console.Text = "Clear";
            this.button_hvs_clear_console.UseVisualStyleBackColor = true;
            // 
            // listBox_hvs_console
            // 
            this.listBox_hvs_console.FormattingEnabled = true;
            this.listBox_hvs_console.Location = new System.Drawing.Point(6, 293);
            this.listBox_hvs_console.Name = "listBox_hvs_console";
            this.listBox_hvs_console.Size = new System.Drawing.Size(1320, 342);
            this.listBox_hvs_console.TabIndex = 69;
            // 
            // checkBox_hvs_console_autoscroll
            // 
            this.checkBox_hvs_console_autoscroll.AutoSize = true;
            this.checkBox_hvs_console_autoscroll.Checked = true;
            this.checkBox_hvs_console_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_hvs_console_autoscroll.Location = new System.Drawing.Point(1171, 266);
            this.checkBox_hvs_console_autoscroll.Name = "checkBox_hvs_console_autoscroll";
            this.checkBox_hvs_console_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_hvs_console_autoscroll.TabIndex = 68;
            this.checkBox_hvs_console_autoscroll.Text = "AutoScroll";
            this.checkBox_hvs_console_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listView_connected_devices
            // 
            this.listView_connected_devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.connected_devices_device,
            this.connected_devices_status});
            this.listView_connected_devices.FullRowSelect = true;
            this.listView_connected_devices.GridLines = true;
            this.listView_connected_devices.HideSelection = false;
            this.listView_connected_devices.Location = new System.Drawing.Point(1056, 6);
            this.listView_connected_devices.Name = "listView_connected_devices";
            this.listView_connected_devices.Size = new System.Drawing.Size(270, 250);
            this.listView_connected_devices.TabIndex = 11;
            this.listView_connected_devices.UseCompatibleStateImageBehavior = false;
            this.listView_connected_devices.View = System.Windows.Forms.View.Details;
            // 
            // connected_devices_device
            // 
            this.connected_devices_device.Text = "Device";
            this.connected_devices_device.Width = 149;
            // 
            // connected_devices_status
            // 
            this.connected_devices_status.Text = "Status";
            this.connected_devices_status.Width = 115;
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings.Controls.Add(this.button_backup_databases);
            this.tabPage_settings.Controls.Add(this.button_load_settings);
            this.tabPage_settings.Controls.Add(this.button_save_settings);
            this.tabPage_settings.Controls.Add(this.tabControl_settings);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_settings.TabIndex = 5;
            this.tabPage_settings.Text = "Settings";
            // 
            // button_backup_databases
            // 
            this.button_backup_databases.Location = new System.Drawing.Point(302, 6);
            this.button_backup_databases.Name = "button_backup_databases";
            this.button_backup_databases.Size = new System.Drawing.Size(142, 25);
            this.button_backup_databases.TabIndex = 66;
            this.button_backup_databases.Text = "BACKUP DATABASES";
            this.button_backup_databases.UseVisualStyleBackColor = true;
            // 
            // button_load_settings
            // 
            this.button_load_settings.Location = new System.Drawing.Point(154, 6);
            this.button_load_settings.Name = "button_load_settings";
            this.button_load_settings.Size = new System.Drawing.Size(142, 25);
            this.button_load_settings.TabIndex = 65;
            this.button_load_settings.Text = "LOAD SETTINGS";
            this.button_load_settings.UseVisualStyleBackColor = true;
            this.button_load_settings.Click += new System.EventHandler(this.Button_load_settings_Click);
            // 
            // button_save_settings
            // 
            this.button_save_settings.Location = new System.Drawing.Point(6, 6);
            this.button_save_settings.Name = "button_save_settings";
            this.button_save_settings.Size = new System.Drawing.Size(142, 25);
            this.button_save_settings.TabIndex = 64;
            this.button_save_settings.Text = "SAVE SETTINGS";
            this.button_save_settings.UseVisualStyleBackColor = true;
            this.button_save_settings.Click += new System.EventHandler(this.Button_save_settings_Click);
            // 
            // tabControl_settings
            // 
            this.tabControl_settings.Controls.Add(this.tabPage_settings_server);
            this.tabControl_settings.Controls.Add(this.tabPage_settings_system);
            this.tabControl_settings.Controls.Add(this.tabPage_settings_ftp);
            this.tabControl_settings.Controls.Add(this.tabPage_settings_web_sql);
            this.tabControl_settings.Controls.Add(this.tabPage_settings_vision_core_sql);
            this.tabControl_settings.Controls.Add(this.tabPage_settings_conversion);
            this.tabControl_settings.Location = new System.Drawing.Point(6, 37);
            this.tabControl_settings.Name = "tabControl_settings";
            this.tabControl_settings.SelectedIndex = 0;
            this.tabControl_settings.Size = new System.Drawing.Size(1320, 598);
            this.tabControl_settings.TabIndex = 0;
            // 
            // tabPage_settings_server
            // 
            this.tabPage_settings_server.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings_server.Controls.Add(this.label_server_ip);
            this.tabPage_settings_server.Controls.Add(this.textBox_server_ip);
            this.tabPage_settings_server.Controls.Add(this.textBox_server_port);
            this.tabPage_settings_server.Controls.Add(this.label_server_port);
            this.tabPage_settings_server.Controls.Add(this.textBox_login);
            this.tabPage_settings_server.Controls.Add(this.label_login);
            this.tabPage_settings_server.Controls.Add(this.textBox_password);
            this.tabPage_settings_server.Controls.Add(this.label_password);
            this.tabPage_settings_server.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings_server.Name = "tabPage_settings_server";
            this.tabPage_settings_server.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings_server.Size = new System.Drawing.Size(1312, 572);
            this.tabPage_settings_server.TabIndex = 0;
            this.tabPage_settings_server.Text = "Server";
            // 
            // label_server_ip
            // 
            this.label_server_ip.AutoSize = true;
            this.label_server_ip.Location = new System.Drawing.Point(6, 12);
            this.label_server_ip.Name = "label_server_ip";
            this.label_server_ip.Size = new System.Drawing.Size(51, 13);
            this.label_server_ip.TabIndex = 1;
            this.label_server_ip.Text = "Server IP";
            // 
            // textBox_server_ip
            // 
            this.textBox_server_ip.Location = new System.Drawing.Point(72, 9);
            this.textBox_server_ip.Name = "textBox_server_ip";
            this.textBox_server_ip.Size = new System.Drawing.Size(236, 20);
            this.textBox_server_ip.TabIndex = 0;
            // 
            // textBox_server_port
            // 
            this.textBox_server_port.Location = new System.Drawing.Point(72, 35);
            this.textBox_server_port.Name = "textBox_server_port";
            this.textBox_server_port.Size = new System.Drawing.Size(236, 20);
            this.textBox_server_port.TabIndex = 2;
            // 
            // label_server_port
            // 
            this.label_server_port.AutoSize = true;
            this.label_server_port.Location = new System.Drawing.Point(6, 38);
            this.label_server_port.Name = "label_server_port";
            this.label_server_port.Size = new System.Drawing.Size(60, 13);
            this.label_server_port.TabIndex = 3;
            this.label_server_port.Text = "Server Port";
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(72, 61);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(236, 20);
            this.textBox_login.TabIndex = 4;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(6, 64);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(33, 13);
            this.label_login.TabIndex = 5;
            this.label_login.Text = "Login";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(72, 87);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(236, 20);
            this.textBox_password.TabIndex = 6;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(6, 90);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(53, 13);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "Password";
            // 
            // tabPage_settings_system
            // 
            this.tabPage_settings_system.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings_system.Controls.Add(this.label_setting_system_name_info);
            this.tabPage_settings_system.Controls.Add(this.label_system_watchgod_id);
            this.tabPage_settings_system.Controls.Add(this.textBox_system_watchgod_id);
            this.tabPage_settings_system.Controls.Add(this.checkBox_cc_clean_up);
            this.tabPage_settings_system.Controls.Add(this.checkBox_cd_clean_up);
            this.tabPage_settings_system.Controls.Add(this.label_settings_record_lag);
            this.tabPage_settings_system.Controls.Add(this.textBox_save_folder);
            this.tabPage_settings_system.Controls.Add(this.numericUpDown_settings_record_lag);
            this.tabPage_settings_system.Controls.Add(this.button_choose_save_folder);
            this.tabPage_settings_system.Controls.Add(this.label_system_internal_name);
            this.tabPage_settings_system.Controls.Add(this.textBox_system_internal_name);
            this.tabPage_settings_system.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings_system.Name = "tabPage_settings_system";
            this.tabPage_settings_system.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings_system.Size = new System.Drawing.Size(1312, 572);
            this.tabPage_settings_system.TabIndex = 1;
            this.tabPage_settings_system.Text = "System";
            // 
            // label_system_watchgod_id
            // 
            this.label_system_watchgod_id.AutoSize = true;
            this.label_system_watchgod_id.Location = new System.Drawing.Point(1042, 14);
            this.label_system_watchgod_id.Name = "label_system_watchgod_id";
            this.label_system_watchgod_id.Size = new System.Drawing.Size(71, 13);
            this.label_system_watchgod_id.TabIndex = 110;
            this.label_system_watchgod_id.Text = "WatchGod Id";
            // 
            // textBox_system_watchgod_id
            // 
            this.textBox_system_watchgod_id.Location = new System.Drawing.Point(1125, 11);
            this.textBox_system_watchgod_id.Name = "textBox_system_watchgod_id";
            this.textBox_system_watchgod_id.Size = new System.Drawing.Size(181, 20);
            this.textBox_system_watchgod_id.TabIndex = 109;
            this.textBox_system_watchgod_id.Text = "DEV_1";
            // 
            // checkBox_cc_clean_up
            // 
            this.checkBox_cc_clean_up.AutoSize = true;
            this.checkBox_cc_clean_up.Location = new System.Drawing.Point(9, 160);
            this.checkBox_cc_clean_up.Name = "checkBox_cc_clean_up";
            this.checkBox_cc_clean_up.Size = new System.Drawing.Size(173, 17);
            this.checkBox_cc_clean_up.TabIndex = 108;
            this.checkBox_cc_clean_up.Text = "Clean Up After Processing [CC]";
            this.checkBox_cc_clean_up.UseVisualStyleBackColor = true;
            // 
            // checkBox_cd_clean_up
            // 
            this.checkBox_cd_clean_up.AutoSize = true;
            this.checkBox_cd_clean_up.Location = new System.Drawing.Point(9, 137);
            this.checkBox_cd_clean_up.Name = "checkBox_cd_clean_up";
            this.checkBox_cd_clean_up.Size = new System.Drawing.Size(174, 17);
            this.checkBox_cd_clean_up.TabIndex = 107;
            this.checkBox_cd_clean_up.Text = "Clean Up After Processing [CD]";
            this.checkBox_cd_clean_up.UseVisualStyleBackColor = true;
            // 
            // textBox_save_folder
            // 
            this.textBox_save_folder.Location = new System.Drawing.Point(6, 44);
            this.textBox_save_folder.Name = "textBox_save_folder";
            this.textBox_save_folder.Size = new System.Drawing.Size(299, 20);
            this.textBox_save_folder.TabIndex = 25;
            this.textBox_save_folder.Text = "Save Dir";
            // 
            // button_choose_save_folder
            // 
            this.button_choose_save_folder.Location = new System.Drawing.Point(309, 44);
            this.button_choose_save_folder.Name = "button_choose_save_folder";
            this.button_choose_save_folder.Size = new System.Drawing.Size(168, 20);
            this.button_choose_save_folder.TabIndex = 26;
            this.button_choose_save_folder.Text = "SET ARCHIVE LOCATION";
            this.button_choose_save_folder.UseVisualStyleBackColor = true;
            this.button_choose_save_folder.Click += new System.EventHandler(this.Button_choose_save_folder_Click);
            // 
            // label_system_internal_name
            // 
            this.label_system_internal_name.AutoSize = true;
            this.label_system_internal_name.Location = new System.Drawing.Point(6, 14);
            this.label_system_internal_name.Name = "label_system_internal_name";
            this.label_system_internal_name.Size = new System.Drawing.Size(110, 13);
            this.label_system_internal_name.TabIndex = 62;
            this.label_system_internal_name.Text = "System Internal Name";
            // 
            // textBox_system_internal_name
            // 
            this.textBox_system_internal_name.Location = new System.Drawing.Point(130, 11);
            this.textBox_system_internal_name.MaxLength = 50;
            this.textBox_system_internal_name.Name = "textBox_system_internal_name";
            this.textBox_system_internal_name.Size = new System.Drawing.Size(347, 20);
            this.textBox_system_internal_name.TabIndex = 39;
            this.textBox_system_internal_name.Text = "Container Vision 01 - AWE";
            // 
            // tabPage_settings_ftp
            // 
            this.tabPage_settings_ftp.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings_ftp.Controls.Add(this.label_ftp_credentials);
            this.tabPage_settings_ftp.Controls.Add(this.textBox_FTP_IP);
            this.tabPage_settings_ftp.Controls.Add(this.label_FTP_IP);
            this.tabPage_settings_ftp.Controls.Add(this.textBox_FTP_user_name);
            this.tabPage_settings_ftp.Controls.Add(this.label_FTP_user_name);
            this.tabPage_settings_ftp.Controls.Add(this.textBox_FTP_password);
            this.tabPage_settings_ftp.Controls.Add(this.label_FTP_password);
            this.tabPage_settings_ftp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings_ftp.Name = "tabPage_settings_ftp";
            this.tabPage_settings_ftp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings_ftp.Size = new System.Drawing.Size(1312, 572);
            this.tabPage_settings_ftp.TabIndex = 2;
            this.tabPage_settings_ftp.Text = "FTP";
            // 
            // label_ftp_credentials
            // 
            this.label_ftp_credentials.AutoSize = true;
            this.label_ftp_credentials.Location = new System.Drawing.Point(6, 3);
            this.label_ftp_credentials.Name = "label_ftp_credentials";
            this.label_ftp_credentials.Size = new System.Drawing.Size(82, 13);
            this.label_ftp_credentials.TabIndex = 31;
            this.label_ftp_credentials.Text = "FTP Credentials";
            // 
            // textBox_FTP_IP
            // 
            this.textBox_FTP_IP.Location = new System.Drawing.Point(72, 27);
            this.textBox_FTP_IP.Name = "textBox_FTP_IP";
            this.textBox_FTP_IP.Size = new System.Drawing.Size(236, 20);
            this.textBox_FTP_IP.TabIndex = 28;
            // 
            // label_FTP_IP
            // 
            this.label_FTP_IP.AutoSize = true;
            this.label_FTP_IP.Location = new System.Drawing.Point(6, 30);
            this.label_FTP_IP.Name = "label_FTP_IP";
            this.label_FTP_IP.Size = new System.Drawing.Size(40, 13);
            this.label_FTP_IP.TabIndex = 30;
            this.label_FTP_IP.Text = "FTP IP";
            // 
            // textBox_FTP_user_name
            // 
            this.textBox_FTP_user_name.Location = new System.Drawing.Point(72, 53);
            this.textBox_FTP_user_name.Name = "textBox_FTP_user_name";
            this.textBox_FTP_user_name.Size = new System.Drawing.Size(236, 20);
            this.textBox_FTP_user_name.TabIndex = 29;
            // 
            // label_FTP_user_name
            // 
            this.label_FTP_user_name.AutoSize = true;
            this.label_FTP_user_name.Location = new System.Drawing.Point(6, 56);
            this.label_FTP_user_name.Name = "label_FTP_user_name";
            this.label_FTP_user_name.Size = new System.Drawing.Size(60, 13);
            this.label_FTP_user_name.TabIndex = 33;
            this.label_FTP_user_name.Text = "User Name";
            // 
            // textBox_FTP_password
            // 
            this.textBox_FTP_password.Location = new System.Drawing.Point(72, 79);
            this.textBox_FTP_password.Name = "textBox_FTP_password";
            this.textBox_FTP_password.PasswordChar = '*';
            this.textBox_FTP_password.Size = new System.Drawing.Size(236, 20);
            this.textBox_FTP_password.TabIndex = 30;
            // 
            // label_FTP_password
            // 
            this.label_FTP_password.AutoSize = true;
            this.label_FTP_password.Location = new System.Drawing.Point(6, 82);
            this.label_FTP_password.Name = "label_FTP_password";
            this.label_FTP_password.Size = new System.Drawing.Size(53, 13);
            this.label_FTP_password.TabIndex = 35;
            this.label_FTP_password.Text = "Password";
            // 
            // tabPage_settings_web_sql
            // 
            this.tabPage_settings_web_sql.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings_web_sql.Controls.Add(this.textBox_vision_core_gui_sql_database);
            this.tabPage_settings_web_sql.Controls.Add(this.label_vision_core_gui_sql_database);
            this.tabPage_settings_web_sql.Controls.Add(this.textBox_core_sql_database);
            this.tabPage_settings_web_sql.Controls.Add(this.label_core_sql_database);
            this.tabPage_settings_web_sql.Controls.Add(this.label_core_sql_credentials);
            this.tabPage_settings_web_sql.Controls.Add(this.textBox_core_sql_ip);
            this.tabPage_settings_web_sql.Controls.Add(this.label_core_sql_ip);
            this.tabPage_settings_web_sql.Controls.Add(this.textBox_core_sql_login);
            this.tabPage_settings_web_sql.Controls.Add(this.label_core_sql_login);
            this.tabPage_settings_web_sql.Controls.Add(this.textBox_core_sql_password);
            this.tabPage_settings_web_sql.Controls.Add(this.label_core_sql_password);
            this.tabPage_settings_web_sql.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings_web_sql.Name = "tabPage_settings_web_sql";
            this.tabPage_settings_web_sql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings_web_sql.Size = new System.Drawing.Size(1312, 572);
            this.tabPage_settings_web_sql.TabIndex = 3;
            this.tabPage_settings_web_sql.Text = "Web SQL";
            // 
            // textBox_vision_core_gui_sql_database
            // 
            this.textBox_vision_core_gui_sql_database.Location = new System.Drawing.Point(73, 136);
            this.textBox_vision_core_gui_sql_database.Name = "textBox_vision_core_gui_sql_database";
            this.textBox_vision_core_gui_sql_database.Size = new System.Drawing.Size(236, 20);
            this.textBox_vision_core_gui_sql_database.TabIndex = 62;
            // 
            // label_vision_core_gui_sql_database
            // 
            this.label_vision_core_gui_sql_database.AutoSize = true;
            this.label_vision_core_gui_sql_database.Location = new System.Drawing.Point(7, 139);
            this.label_vision_core_gui_sql_database.Name = "label_vision_core_gui_sql_database";
            this.label_vision_core_gui_sql_database.Size = new System.Drawing.Size(39, 13);
            this.label_vision_core_gui_sql_database.TabIndex = 63;
            this.label_vision_core_gui_sql_database.Text = "VC DB";
            // 
            // textBox_core_sql_database
            // 
            this.textBox_core_sql_database.Location = new System.Drawing.Point(73, 110);
            this.textBox_core_sql_database.Name = "textBox_core_sql_database";
            this.textBox_core_sql_database.Size = new System.Drawing.Size(236, 20);
            this.textBox_core_sql_database.TabIndex = 38;
            // 
            // label_core_sql_database
            // 
            this.label_core_sql_database.AutoSize = true;
            this.label_core_sql_database.Location = new System.Drawing.Point(7, 113);
            this.label_core_sql_database.Name = "label_core_sql_database";
            this.label_core_sql_database.Size = new System.Drawing.Size(53, 13);
            this.label_core_sql_database.TabIndex = 61;
            this.label_core_sql_database.Text = "Database";
            // 
            // label_core_sql_credentials
            // 
            this.label_core_sql_credentials.AutoSize = true;
            this.label_core_sql_credentials.Location = new System.Drawing.Point(5, 8);
            this.label_core_sql_credentials.Name = "label_core_sql_credentials";
            this.label_core_sql_credentials.Size = new System.Drawing.Size(109, 13);
            this.label_core_sql_credentials.TabIndex = 43;
            this.label_core_sql_credentials.Text = "Web SQL Credentials";
            // 
            // textBox_core_sql_ip
            // 
            this.textBox_core_sql_ip.Location = new System.Drawing.Point(73, 32);
            this.textBox_core_sql_ip.Name = "textBox_core_sql_ip";
            this.textBox_core_sql_ip.Size = new System.Drawing.Size(236, 20);
            this.textBox_core_sql_ip.TabIndex = 35;
            // 
            // label_core_sql_ip
            // 
            this.label_core_sql_ip.AutoSize = true;
            this.label_core_sql_ip.Location = new System.Drawing.Point(7, 35);
            this.label_core_sql_ip.Name = "label_core_sql_ip";
            this.label_core_sql_ip.Size = new System.Drawing.Size(17, 13);
            this.label_core_sql_ip.TabIndex = 45;
            this.label_core_sql_ip.Text = "IP";
            // 
            // textBox_core_sql_login
            // 
            this.textBox_core_sql_login.Location = new System.Drawing.Point(73, 58);
            this.textBox_core_sql_login.Name = "textBox_core_sql_login";
            this.textBox_core_sql_login.Size = new System.Drawing.Size(236, 20);
            this.textBox_core_sql_login.TabIndex = 36;
            // 
            // label_core_sql_login
            // 
            this.label_core_sql_login.AutoSize = true;
            this.label_core_sql_login.Location = new System.Drawing.Point(7, 61);
            this.label_core_sql_login.Name = "label_core_sql_login";
            this.label_core_sql_login.Size = new System.Drawing.Size(33, 13);
            this.label_core_sql_login.TabIndex = 47;
            this.label_core_sql_login.Text = "Login";
            // 
            // textBox_core_sql_password
            // 
            this.textBox_core_sql_password.Location = new System.Drawing.Point(73, 84);
            this.textBox_core_sql_password.Name = "textBox_core_sql_password";
            this.textBox_core_sql_password.PasswordChar = '*';
            this.textBox_core_sql_password.Size = new System.Drawing.Size(236, 20);
            this.textBox_core_sql_password.TabIndex = 37;
            // 
            // label_core_sql_password
            // 
            this.label_core_sql_password.AutoSize = true;
            this.label_core_sql_password.Location = new System.Drawing.Point(7, 87);
            this.label_core_sql_password.Name = "label_core_sql_password";
            this.label_core_sql_password.Size = new System.Drawing.Size(53, 13);
            this.label_core_sql_password.TabIndex = 49;
            this.label_core_sql_password.Text = "Password";
            // 
            // tabPage_settings_vision_core_sql
            // 
            this.tabPage_settings_vision_core_sql.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings_vision_core_sql.Controls.Add(this.label_vision_sql_credentials);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.label_vision_sql_database);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.textBox_vision_sql_ip);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.textBox_vision_sql_database);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.label_vision_sql_ip);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.textBox_vision_sql_login);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.label_vision_sql_login);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.label_vision_sql_password);
            this.tabPage_settings_vision_core_sql.Controls.Add(this.textBox_vision_sql_password);
            this.tabPage_settings_vision_core_sql.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings_vision_core_sql.Name = "tabPage_settings_vision_core_sql";
            this.tabPage_settings_vision_core_sql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings_vision_core_sql.Size = new System.Drawing.Size(1312, 572);
            this.tabPage_settings_vision_core_sql.TabIndex = 4;
            this.tabPage_settings_vision_core_sql.Text = "Vision Core SQL";
            // 
            // label_vision_sql_credentials
            // 
            this.label_vision_sql_credentials.AutoSize = true;
            this.label_vision_sql_credentials.Location = new System.Drawing.Point(6, 7);
            this.label_vision_sql_credentials.Name = "label_vision_sql_credentials";
            this.label_vision_sql_credentials.Size = new System.Drawing.Size(139, 13);
            this.label_vision_sql_credentials.TabIndex = 36;
            this.label_vision_sql_credentials.Text = "Vision Core SQL Credentials";
            // 
            // label_vision_sql_database
            // 
            this.label_vision_sql_database.AutoSize = true;
            this.label_vision_sql_database.Location = new System.Drawing.Point(8, 112);
            this.label_vision_sql_database.Name = "label_vision_sql_database";
            this.label_vision_sql_database.Size = new System.Drawing.Size(53, 13);
            this.label_vision_sql_database.TabIndex = 59;
            this.label_vision_sql_database.Text = "Database";
            // 
            // textBox_vision_sql_ip
            // 
            this.textBox_vision_sql_ip.Location = new System.Drawing.Point(74, 31);
            this.textBox_vision_sql_ip.Name = "textBox_vision_sql_ip";
            this.textBox_vision_sql_ip.Size = new System.Drawing.Size(236, 20);
            this.textBox_vision_sql_ip.TabIndex = 31;
            // 
            // textBox_vision_sql_database
            // 
            this.textBox_vision_sql_database.Location = new System.Drawing.Point(74, 109);
            this.textBox_vision_sql_database.Name = "textBox_vision_sql_database";
            this.textBox_vision_sql_database.Size = new System.Drawing.Size(236, 20);
            this.textBox_vision_sql_database.TabIndex = 34;
            // 
            // label_vision_sql_ip
            // 
            this.label_vision_sql_ip.AutoSize = true;
            this.label_vision_sql_ip.Location = new System.Drawing.Point(8, 34);
            this.label_vision_sql_ip.Name = "label_vision_sql_ip";
            this.label_vision_sql_ip.Size = new System.Drawing.Size(17, 13);
            this.label_vision_sql_ip.TabIndex = 38;
            this.label_vision_sql_ip.Text = "IP";
            // 
            // textBox_vision_sql_login
            // 
            this.textBox_vision_sql_login.Location = new System.Drawing.Point(74, 57);
            this.textBox_vision_sql_login.Name = "textBox_vision_sql_login";
            this.textBox_vision_sql_login.Size = new System.Drawing.Size(236, 20);
            this.textBox_vision_sql_login.TabIndex = 32;
            // 
            // label_vision_sql_login
            // 
            this.label_vision_sql_login.AutoSize = true;
            this.label_vision_sql_login.Location = new System.Drawing.Point(8, 60);
            this.label_vision_sql_login.Name = "label_vision_sql_login";
            this.label_vision_sql_login.Size = new System.Drawing.Size(33, 13);
            this.label_vision_sql_login.TabIndex = 40;
            this.label_vision_sql_login.Text = "Login";
            // 
            // label_vision_sql_password
            // 
            this.label_vision_sql_password.AutoSize = true;
            this.label_vision_sql_password.Location = new System.Drawing.Point(8, 86);
            this.label_vision_sql_password.Name = "label_vision_sql_password";
            this.label_vision_sql_password.Size = new System.Drawing.Size(53, 13);
            this.label_vision_sql_password.TabIndex = 42;
            this.label_vision_sql_password.Text = "Password";
            // 
            // textBox_vision_sql_password
            // 
            this.textBox_vision_sql_password.Location = new System.Drawing.Point(74, 83);
            this.textBox_vision_sql_password.Name = "textBox_vision_sql_password";
            this.textBox_vision_sql_password.PasswordChar = '*';
            this.textBox_vision_sql_password.Size = new System.Drawing.Size(236, 20);
            this.textBox_vision_sql_password.TabIndex = 33;
            // 
            // tabPage_settings_conversion
            // 
            this.tabPage_settings_conversion.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_settings_conversion.Controls.Add(this.label_settings_conversion_quality);
            this.tabPage_settings_conversion.Controls.Add(this.comboBox_settings_conversion_quality);
            this.tabPage_settings_conversion.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings_conversion.Name = "tabPage_settings_conversion";
            this.tabPage_settings_conversion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings_conversion.Size = new System.Drawing.Size(1312, 572);
            this.tabPage_settings_conversion.TabIndex = 5;
            this.tabPage_settings_conversion.Text = "Conversion";
            // 
            // label_settings_conversion_quality
            // 
            this.label_settings_conversion_quality.AutoSize = true;
            this.label_settings_conversion_quality.Location = new System.Drawing.Point(8, 9);
            this.label_settings_conversion_quality.Name = "label_settings_conversion_quality";
            this.label_settings_conversion_quality.Size = new System.Drawing.Size(118, 13);
            this.label_settings_conversion_quality.TabIndex = 29;
            this.label_settings_conversion_quality.Text = "Conveted Video Quality";
            // 
            // comboBox_settings_conversion_quality
            // 
            this.comboBox_settings_conversion_quality.FormattingEnabled = true;
            this.comboBox_settings_conversion_quality.Items.AddRange(new object[] {
            "1080x1920",
            "1280x720",
            "1366x768",
            "852x480",
            "640x480",
            "320x200"});
            this.comboBox_settings_conversion_quality.Location = new System.Drawing.Point(128, 6);
            this.comboBox_settings_conversion_quality.Name = "comboBox_settings_conversion_quality";
            this.comboBox_settings_conversion_quality.Size = new System.Drawing.Size(121, 21);
            this.comboBox_settings_conversion_quality.TabIndex = 28;
            this.comboBox_settings_conversion_quality.Text = "320x200";
            // 
            // listBox_error
            // 
            this.listBox_error.FormattingEnabled = true;
            this.listBox_error.Location = new System.Drawing.Point(6, 345);
            this.listBox_error.Name = "listBox_error";
            this.listBox_error.Size = new System.Drawing.Size(1320, 290);
            this.listBox_error.TabIndex = 55;
            // 
            // button_clear_thread
            // 
            this.button_clear_thread.Location = new System.Drawing.Point(1251, 318);
            this.button_clear_thread.Name = "button_clear_thread";
            this.button_clear_thread.Size = new System.Drawing.Size(75, 23);
            this.button_clear_thread.TabIndex = 54;
            this.button_clear_thread.Text = "Clear";
            this.button_clear_thread.UseVisualStyleBackColor = true;
            // 
            // tabPage_console
            // 
            this.tabPage_console.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage_console.Controls.Add(this.listBox_error);
            this.tabPage_console.Controls.Add(this.button_clear_thread);
            this.tabPage_console.Controls.Add(this.label_console_error);
            this.tabPage_console.Controls.Add(this.label_console_main);
            this.tabPage_console.Controls.Add(this.listBox_console);
            this.tabPage_console.Controls.Add(this.button_clear_console);
            this.tabPage_console.Location = new System.Drawing.Point(4, 22);
            this.tabPage_console.Name = "tabPage_console";
            this.tabPage_console.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_console.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_console.TabIndex = 1;
            this.tabPage_console.Text = "Console";
            // 
            // label_console_error
            // 
            this.label_console_error.AutoSize = true;
            this.label_console_error.Location = new System.Drawing.Point(5, 323);
            this.label_console_error.Name = "label_console_error";
            this.label_console_error.Size = new System.Drawing.Size(70, 13);
            this.label_console_error.TabIndex = 58;
            this.label_console_error.Text = "Error Console";
            // 
            // label_console_main
            // 
            this.label_console_main.AutoSize = true;
            this.label_console_main.Location = new System.Drawing.Point(5, 15);
            this.label_console_main.Name = "label_console_main";
            this.label_console_main.Size = new System.Drawing.Size(71, 13);
            this.label_console_main.TabIndex = 51;
            this.label_console_main.Text = "Main Console";
            // 
            // listBox_console
            // 
            this.listBox_console.FormattingEnabled = true;
            this.listBox_console.HorizontalScrollbar = true;
            this.listBox_console.Location = new System.Drawing.Point(6, 35);
            this.listBox_console.Name = "listBox_console";
            this.listBox_console.Size = new System.Drawing.Size(1320, 277);
            this.listBox_console.TabIndex = 9;
            // 
            // button_clear_console
            // 
            this.button_clear_console.Location = new System.Drawing.Point(1251, 6);
            this.button_clear_console.Name = "button_clear_console";
            this.button_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_clear_console.TabIndex = 50;
            this.button_clear_console.Text = "Clear";
            this.button_clear_console.UseVisualStyleBackColor = true;
            this.button_clear_console.Click += new System.EventHandler(this.Button_clear_console_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_em);
            this.tabControl_main.Controls.Add(this.tabPage_container_process_analyzer);
            this.tabControl_main.Controls.Add(this.tabPage_container_detector);
            this.tabControl_main.Controls.Add(this.tabPage_container_chain);
            this.tabControl_main.Controls.Add(this.tabPage_image_extractor);
            this.tabControl_main.Controls.Add(this.tabPage_vision_ai);
            this.tabControl_main.Controls.Add(this.tabPage_video_converter);
            this.tabControl_main.Controls.Add(this.tabPage_ftp);
            this.tabControl_main.Controls.Add(this.tabPage_db);
            this.tabControl_main.Controls.Add(this.tabPage_downloader);
            this.tabControl_main.Controls.Add(this.tabPage_hikvision);
            this.tabControl_main.Controls.Add(this.tabPage_console);
            this.tabControl_main.Controls.Add(this.tabPage_settings);
            this.tabControl_main.Location = new System.Drawing.Point(5, 35);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1340, 667);
            this.tabControl_main.TabIndex = 63;
            // 
            // tabPage_em
            // 
            this.tabPage_em.Controls.Add(this.listView_event_alarm);
            this.tabPage_em.Controls.Add(this.button_em_clear_console);
            this.tabPage_em.Controls.Add(this.checkBox_em_console_autoscroll);
            this.tabPage_em.Controls.Add(this.listBox_em_console);
            this.tabPage_em.Controls.Add(this.groupBox_em);
            this.tabPage_em.Location = new System.Drawing.Point(4, 22);
            this.tabPage_em.Name = "tabPage_em";
            this.tabPage_em.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_em.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_em.TabIndex = 16;
            this.tabPage_em.Text = "Event Manager";
            this.tabPage_em.UseVisualStyleBackColor = true;
            // 
            // listView_event_alarm
            // 
            this.listView_event_alarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader56,
            this.columnHeader62,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader61,
            this.columnHeader60});
            this.listView_event_alarm.HideSelection = false;
            this.listView_event_alarm.Location = new System.Drawing.Point(235, 6);
            this.listView_event_alarm.Name = "listView_event_alarm";
            this.listView_event_alarm.Size = new System.Drawing.Size(1092, 343);
            this.listView_event_alarm.TabIndex = 97;
            this.listView_event_alarm.UseCompatibleStateImageBehavior = false;
            this.listView_event_alarm.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "Alarm Unique Id";
            this.columnHeader56.Width = 120;
            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "Event Name";
            this.columnHeader62.Width = 220;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "Event Type";
            this.columnHeader57.Width = 120;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "Status";
            this.columnHeader58.Width = 220;
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "Related Unique Id";
            this.columnHeader59.Width = 120;
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "Event Time";
            this.columnHeader61.Width = 150;
            // 
            // columnHeader60
            // 
            this.columnHeader60.Text = "Debounce (sec)";
            this.columnHeader60.Width = 120;
            // 
            // button_em_clear_console
            // 
            this.button_em_clear_console.Location = new System.Drawing.Point(1251, 355);
            this.button_em_clear_console.Name = "button_em_clear_console";
            this.button_em_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_em_clear_console.TabIndex = 96;
            this.button_em_clear_console.Text = "Clear";
            this.button_em_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_em_console_autoscroll
            // 
            this.checkBox_em_console_autoscroll.AutoSize = true;
            this.checkBox_em_console_autoscroll.Checked = true;
            this.checkBox_em_console_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_em_console_autoscroll.Location = new System.Drawing.Point(1171, 359);
            this.checkBox_em_console_autoscroll.Name = "checkBox_em_console_autoscroll";
            this.checkBox_em_console_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_em_console_autoscroll.TabIndex = 95;
            this.checkBox_em_console_autoscroll.Text = "AutoScroll";
            this.checkBox_em_console_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listBox_em_console
            // 
            this.listBox_em_console.FormattingEnabled = true;
            this.listBox_em_console.Location = new System.Drawing.Point(6, 384);
            this.listBox_em_console.Name = "listBox_em_console";
            this.listBox_em_console.Size = new System.Drawing.Size(1320, 251);
            this.listBox_em_console.TabIndex = 94;
            // 
            // groupBox_em
            // 
            this.groupBox_em.Controls.Add(this.textBox_em_set_datetime_cd);
            this.groupBox_em.Controls.Add(this.button_em_set_datetime_cd);
            this.groupBox_em.Controls.Add(this.button_em_test_cd);
            this.groupBox_em.Controls.Add(this.textBox_em_debounce_countdown_cd);
            this.groupBox_em.Controls.Add(this.numericUpDown_em_trigger_buffer_cd);
            this.groupBox_em.Controls.Add(this.label_em_alarm_debounce_cd);
            this.groupBox_em.Controls.Add(this.comboBox_em_type_cd);
            this.groupBox_em.Controls.Add(this.numericUpDown_em_channel_cd);
            this.groupBox_em.Controls.Add(this.button_em_arm_cd);
            this.groupBox_em.Controls.Add(this.label_em_channel_cd);
            this.groupBox_em.Location = new System.Drawing.Point(6, 6);
            this.groupBox_em.Name = "groupBox_em";
            this.groupBox_em.Size = new System.Drawing.Size(223, 264);
            this.groupBox_em.TabIndex = 93;
            this.groupBox_em.TabStop = false;
            this.groupBox_em.Text = "Container Detector";
            // 
            // textBox_em_set_datetime_cd
            // 
            this.textBox_em_set_datetime_cd.Location = new System.Drawing.Point(100, 154);
            this.textBox_em_set_datetime_cd.Name = "textBox_em_set_datetime_cd";
            this.textBox_em_set_datetime_cd.Size = new System.Drawing.Size(116, 20);
            this.textBox_em_set_datetime_cd.TabIndex = 98;
            // 
            // button_em_set_datetime_cd
            // 
            this.button_em_set_datetime_cd.Location = new System.Drawing.Point(5, 151);
            this.button_em_set_datetime_cd.Name = "button_em_set_datetime_cd";
            this.button_em_set_datetime_cd.Size = new System.Drawing.Size(89, 23);
            this.button_em_set_datetime_cd.TabIndex = 99;
            this.button_em_set_datetime_cd.Text = "SET TIME";
            this.button_em_set_datetime_cd.UseVisualStyleBackColor = true;
            // 
            // button_em_test_cd
            // 
            this.button_em_test_cd.Location = new System.Drawing.Point(5, 180);
            this.button_em_test_cd.Name = "button_em_test_cd";
            this.button_em_test_cd.Size = new System.Drawing.Size(211, 23);
            this.button_em_test_cd.TabIndex = 97;
            this.button_em_test_cd.Text = "TEST";
            this.button_em_test_cd.UseVisualStyleBackColor = true;
            // 
            // textBox_em_debounce_countdown_cd
            // 
            this.textBox_em_debounce_countdown_cd.Location = new System.Drawing.Point(6, 210);
            this.textBox_em_debounce_countdown_cd.Name = "textBox_em_debounce_countdown_cd";
            this.textBox_em_debounce_countdown_cd.ReadOnly = true;
            this.textBox_em_debounce_countdown_cd.Size = new System.Drawing.Size(211, 20);
            this.textBox_em_debounce_countdown_cd.TabIndex = 96;
            // 
            // numericUpDown_em_trigger_buffer_cd
            // 
            this.numericUpDown_em_trigger_buffer_cd.Location = new System.Drawing.Point(167, 75);
            this.numericUpDown_em_trigger_buffer_cd.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown_em_trigger_buffer_cd.Name = "numericUpDown_em_trigger_buffer_cd";
            this.numericUpDown_em_trigger_buffer_cd.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_em_trigger_buffer_cd.TabIndex = 95;
            this.numericUpDown_em_trigger_buffer_cd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label_em_alarm_debounce_cd
            // 
            this.label_em_alarm_debounce_cd.AutoSize = true;
            this.label_em_alarm_debounce_cd.Location = new System.Drawing.Point(6, 77);
            this.label_em_alarm_debounce_cd.Name = "label_em_alarm_debounce_cd";
            this.label_em_alarm_debounce_cd.Size = new System.Drawing.Size(86, 13);
            this.label_em_alarm_debounce_cd.TabIndex = 94;
            this.label_em_alarm_debounce_cd.Text = "Alarm Debounce";
            // 
            // comboBox_em_type_cd
            // 
            this.comboBox_em_type_cd.FormattingEnabled = true;
            this.comboBox_em_type_cd.Items.AddRange(new object[] {
            "All",
            "None"});
            this.comboBox_em_type_cd.Location = new System.Drawing.Point(6, 48);
            this.comboBox_em_type_cd.Name = "comboBox_em_type_cd";
            this.comboBox_em_type_cd.Size = new System.Drawing.Size(211, 21);
            this.comboBox_em_type_cd.TabIndex = 93;
            this.comboBox_em_type_cd.Text = "All";
            // 
            // numericUpDown_em_channel_cd
            // 
            this.numericUpDown_em_channel_cd.Location = new System.Drawing.Point(167, 22);
            this.numericUpDown_em_channel_cd.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_em_channel_cd.Name = "numericUpDown_em_channel_cd";
            this.numericUpDown_em_channel_cd.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_em_channel_cd.TabIndex = 91;
            this.numericUpDown_em_channel_cd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_em_arm_cd
            // 
            this.button_em_arm_cd.Location = new System.Drawing.Point(6, 236);
            this.button_em_arm_cd.Name = "button_em_arm_cd";
            this.button_em_arm_cd.Size = new System.Drawing.Size(211, 23);
            this.button_em_arm_cd.TabIndex = 92;
            this.button_em_arm_cd.Text = "ARM";
            this.button_em_arm_cd.UseVisualStyleBackColor = true;
            // 
            // label_em_channel_cd
            // 
            this.label_em_channel_cd.AutoSize = true;
            this.label_em_channel_cd.Location = new System.Drawing.Point(6, 24);
            this.label_em_channel_cd.Name = "label_em_channel_cd";
            this.label_em_channel_cd.Size = new System.Drawing.Size(83, 13);
            this.label_em_channel_cd.TabIndex = 90;
            this.label_em_channel_cd.Text = "Device Channel";
            // 
            // tabPage_container_process_analyzer
            // 
            this.tabPage_container_process_analyzer.Controls.Add(this.button_cpa_pull);
            this.tabPage_container_process_analyzer.Controls.Add(this.button_cpa_push);
            this.tabPage_container_process_analyzer.Controls.Add(this.label_cpa_owner);
            this.tabPage_container_process_analyzer.Controls.Add(this.textBox_cpa_owner);
            this.tabPage_container_process_analyzer.Controls.Add(this.checkBox_cpa_process_date);
            this.tabPage_container_process_analyzer.Controls.Add(this.dateTimePicker_cpa_process_datetime);
            this.tabPage_container_process_analyzer.Controls.Add(this.checkBox_cpa_reprocess);
            this.tabPage_container_process_analyzer.Controls.Add(this.listView_cpa_event_output_data);
            this.tabPage_container_process_analyzer.Controls.Add(this.checkBox_cpa_last_event_at_next_container);
            this.tabPage_container_process_analyzer.Controls.Add(this.numericUpDown_cpa_debounce);
            this.tabPage_container_process_analyzer.Controls.Add(this.label_cpa_debounce);
            this.tabPage_container_process_analyzer.Controls.Add(this.textBox_cpa_debounce_countdown);
            this.tabPage_container_process_analyzer.Controls.Add(this.button_cpa_start);
            this.tabPage_container_process_analyzer.Controls.Add(this.listView_cpa_events);
            this.tabPage_container_process_analyzer.Controls.Add(this.button_cpa_clear_console);
            this.tabPage_container_process_analyzer.Controls.Add(this.checkBox_cpa_console_autoscroll);
            this.tabPage_container_process_analyzer.Controls.Add(this.listBox_cpa_console);
            this.tabPage_container_process_analyzer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_container_process_analyzer.Name = "tabPage_container_process_analyzer";
            this.tabPage_container_process_analyzer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_container_process_analyzer.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_container_process_analyzer.TabIndex = 17;
            this.tabPage_container_process_analyzer.Text = "Container Process Analyzer";
            this.tabPage_container_process_analyzer.UseVisualStyleBackColor = true;
            // 
            // button_cpa_pull
            // 
            this.button_cpa_pull.Location = new System.Drawing.Point(235, 194);
            this.button_cpa_pull.Name = "button_cpa_pull";
            this.button_cpa_pull.Size = new System.Drawing.Size(92, 23);
            this.button_cpa_pull.TabIndex = 114;
            this.button_cpa_pull.Text = "PULL";
            this.button_cpa_pull.UseVisualStyleBackColor = true;
            // 
            // button_cpa_push
            // 
            this.button_cpa_push.Location = new System.Drawing.Point(235, 165);
            this.button_cpa_push.Name = "button_cpa_push";
            this.button_cpa_push.Size = new System.Drawing.Size(92, 23);
            this.button_cpa_push.TabIndex = 113;
            this.button_cpa_push.Text = "PUSH";
            this.button_cpa_push.UseVisualStyleBackColor = true;
            // 
            // label_cpa_owner
            // 
            this.label_cpa_owner.AutoSize = true;
            this.label_cpa_owner.Location = new System.Drawing.Point(6, 217);
            this.label_cpa_owner.Name = "label_cpa_owner";
            this.label_cpa_owner.Size = new System.Drawing.Size(103, 13);
            this.label_cpa_owner.TabIndex = 112;
            this.label_cpa_owner.Text = "Process Owner Only";
            // 
            // textBox_cpa_owner
            // 
            this.textBox_cpa_owner.Location = new System.Drawing.Point(113, 214);
            this.textBox_cpa_owner.Name = "textBox_cpa_owner";
            this.textBox_cpa_owner.Size = new System.Drawing.Size(116, 20);
            this.textBox_cpa_owner.TabIndex = 111;
            // 
            // checkBox_cpa_process_date
            // 
            this.checkBox_cpa_process_date.AutoSize = true;
            this.checkBox_cpa_process_date.Location = new System.Drawing.Point(9, 191);
            this.checkBox_cpa_process_date.Name = "checkBox_cpa_process_date";
            this.checkBox_cpa_process_date.Size = new System.Drawing.Size(105, 17);
            this.checkBox_cpa_process_date.TabIndex = 110;
            this.checkBox_cpa_process_date.Text = "Process By Date";
            this.checkBox_cpa_process_date.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_cpa_process_datetime
            // 
            this.dateTimePicker_cpa_process_datetime.CustomFormat = " ddddd, MMMM dd, yyyy";
            this.dateTimePicker_cpa_process_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_cpa_process_datetime.Location = new System.Drawing.Point(9, 165);
            this.dateTimePicker_cpa_process_datetime.Name = "dateTimePicker_cpa_process_datetime";
            this.dateTimePicker_cpa_process_datetime.Size = new System.Drawing.Size(220, 20);
            this.dateTimePicker_cpa_process_datetime.TabIndex = 109;
            // 
            // checkBox_cpa_reprocess
            // 
            this.checkBox_cpa_reprocess.AutoSize = true;
            this.checkBox_cpa_reprocess.Checked = true;
            this.checkBox_cpa_reprocess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cpa_reprocess.Location = new System.Drawing.Point(9, 142);
            this.checkBox_cpa_reprocess.Name = "checkBox_cpa_reprocess";
            this.checkBox_cpa_reprocess.Size = new System.Drawing.Size(201, 17);
            this.checkBox_cpa_reprocess.TabIndex = 108;
            this.checkBox_cpa_reprocess.Text = "Re-process All \"Processing\" On Start";
            this.checkBox_cpa_reprocess.UseVisualStyleBackColor = true;
            // 
            // listView_cpa_event_output_data
            // 
            this.listView_cpa_event_output_data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader69,
            this.columnHeader70});
            this.listView_cpa_event_output_data.HideSelection = false;
            this.listView_cpa_event_output_data.Location = new System.Drawing.Point(6, 240);
            this.listView_cpa_event_output_data.Name = "listView_cpa_event_output_data";
            this.listView_cpa_event_output_data.Size = new System.Drawing.Size(223, 203);
            this.listView_cpa_event_output_data.TabIndex = 107;
            this.listView_cpa_event_output_data.UseCompatibleStateImageBehavior = false;
            this.listView_cpa_event_output_data.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader69
            // 
            this.columnHeader69.Text = "Data";
            this.columnHeader69.Width = 120;
            // 
            // columnHeader70
            // 
            this.columnHeader70.Text = "Value";
            this.columnHeader70.Width = 80;
            // 
            // checkBox_cpa_last_event_at_next_container
            // 
            this.checkBox_cpa_last_event_at_next_container.AutoSize = true;
            this.checkBox_cpa_last_event_at_next_container.Checked = true;
            this.checkBox_cpa_last_event_at_next_container.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cpa_last_event_at_next_container.Location = new System.Drawing.Point(9, 119);
            this.checkBox_cpa_last_event_at_next_container.Name = "checkBox_cpa_last_event_at_next_container";
            this.checkBox_cpa_last_event_at_next_container.Size = new System.Drawing.Size(207, 17);
            this.checkBox_cpa_last_event_at_next_container.TabIndex = 106;
            this.checkBox_cpa_last_event_at_next_container.Text = "Set Event End Time At Next Container";
            this.checkBox_cpa_last_event_at_next_container.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_cpa_debounce
            // 
            this.numericUpDown_cpa_debounce.Location = new System.Drawing.Point(179, 92);
            this.numericUpDown_cpa_debounce.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown_cpa_debounce.Name = "numericUpDown_cpa_debounce";
            this.numericUpDown_cpa_debounce.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_cpa_debounce.TabIndex = 105;
            this.numericUpDown_cpa_debounce.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label_cpa_debounce
            // 
            this.label_cpa_debounce.AutoSize = true;
            this.label_cpa_debounce.Location = new System.Drawing.Point(6, 94);
            this.label_cpa_debounce.Name = "label_cpa_debounce";
            this.label_cpa_debounce.Size = new System.Drawing.Size(57, 13);
            this.label_cpa_debounce.TabIndex = 104;
            this.label_cpa_debounce.Text = "Debounce";
            // 
            // textBox_cpa_debounce_countdown
            // 
            this.textBox_cpa_debounce_countdown.Location = new System.Drawing.Point(6, 66);
            this.textBox_cpa_debounce_countdown.Name = "textBox_cpa_debounce_countdown";
            this.textBox_cpa_debounce_countdown.ReadOnly = true;
            this.textBox_cpa_debounce_countdown.Size = new System.Drawing.Size(223, 20);
            this.textBox_cpa_debounce_countdown.TabIndex = 103;
            // 
            // button_cpa_start
            // 
            this.button_cpa_start.Location = new System.Drawing.Point(6, 6);
            this.button_cpa_start.Name = "button_cpa_start";
            this.button_cpa_start.Size = new System.Drawing.Size(223, 54);
            this.button_cpa_start.TabIndex = 102;
            this.button_cpa_start.Text = "START PROCESS ANALYZER";
            this.button_cpa_start.UseVisualStyleBackColor = true;
            // 
            // listView_cpa_events
            // 
            this.listView_cpa_events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader63,
            this.columnHeader64,
            this.columnHeader67,
            this.columnHeader65,
            this.columnHeader66,
            this.columnHeader68});
            this.listView_cpa_events.HideSelection = false;
            this.listView_cpa_events.Location = new System.Drawing.Point(333, 6);
            this.listView_cpa_events.Name = "listView_cpa_events";
            this.listView_cpa_events.Size = new System.Drawing.Size(993, 382);
            this.listView_cpa_events.TabIndex = 101;
            this.listView_cpa_events.UseCompatibleStateImageBehavior = false;
            this.listView_cpa_events.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader63
            // 
            this.columnHeader63.Text = "Alarm Unique Id";
            this.columnHeader63.Width = 120;
            // 
            // columnHeader64
            // 
            this.columnHeader64.Text = "Container Id";
            this.columnHeader64.Width = 200;
            // 
            // columnHeader67
            // 
            this.columnHeader67.Text = "Related Unique Id";
            this.columnHeader67.Width = 120;
            // 
            // columnHeader65
            // 
            this.columnHeader65.Text = "Process Status";
            this.columnHeader65.Width = 180;
            // 
            // columnHeader66
            // 
            this.columnHeader66.Text = "Status";
            this.columnHeader66.Width = 160;
            // 
            // columnHeader68
            // 
            this.columnHeader68.Text = "Event Time";
            this.columnHeader68.Width = 150;
            // 
            // button_cpa_clear_console
            // 
            this.button_cpa_clear_console.Location = new System.Drawing.Point(1251, 394);
            this.button_cpa_clear_console.Name = "button_cpa_clear_console";
            this.button_cpa_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_cpa_clear_console.TabIndex = 100;
            this.button_cpa_clear_console.Text = "Clear";
            this.button_cpa_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_cpa_console_autoscroll
            // 
            this.checkBox_cpa_console_autoscroll.AutoSize = true;
            this.checkBox_cpa_console_autoscroll.Checked = true;
            this.checkBox_cpa_console_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cpa_console_autoscroll.Location = new System.Drawing.Point(1171, 398);
            this.checkBox_cpa_console_autoscroll.Name = "checkBox_cpa_console_autoscroll";
            this.checkBox_cpa_console_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cpa_console_autoscroll.TabIndex = 99;
            this.checkBox_cpa_console_autoscroll.Text = "AutoScroll";
            this.checkBox_cpa_console_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listBox_cpa_console
            // 
            this.listBox_cpa_console.FormattingEnabled = true;
            this.listBox_cpa_console.Location = new System.Drawing.Point(6, 449);
            this.listBox_cpa_console.Name = "listBox_cpa_console";
            this.listBox_cpa_console.Size = new System.Drawing.Size(1320, 186);
            this.listBox_cpa_console.TabIndex = 98;
            // 
            // tabPage_container_detector
            // 
            this.tabPage_container_detector.Controls.Add(this.checkBox_cd_process_date);
            this.tabPage_container_detector.Controls.Add(this.dateTimePicker_cd_process_datetime);
            this.tabPage_container_detector.Controls.Add(this.button_cd_start);
            this.tabPage_container_detector.Controls.Add(this.numericUpDown_cd_database_cycle_time);
            this.tabPage_container_detector.Controls.Add(this.label1);
            this.tabPage_container_detector.Controls.Add(this.button_cd_trigger_settime);
            this.tabPage_container_detector.Controls.Add(this.button_cd_set_datetime);
            this.tabPage_container_detector.Controls.Add(this.textBox_cd_trigger_datetime);
            this.tabPage_container_detector.Controls.Add(this.button_cd_test_image_extractor_again);
            this.tabPage_container_detector.Controls.Add(this.button_cd_test_image_extractor);
            this.tabPage_container_detector.Controls.Add(this.button_cd_search_events);
            this.tabPage_container_detector.Controls.Add(this.numericUpDown_cd_recording_channel);
            this.tabPage_container_detector.Controls.Add(this.label_cd_recording_channel);
            this.tabPage_container_detector.Controls.Add(this.label_cd_recording_timer);
            this.tabPage_container_detector.Controls.Add(this.textBox_cd_recording_timer);
            this.tabPage_container_detector.Controls.Add(this.label_cd_recording_time);
            this.tabPage_container_detector.Controls.Add(this.numericUpDown_cd_recording_time);
            this.tabPage_container_detector.Controls.Add(this.label_cd_preroll);
            this.tabPage_container_detector.Controls.Add(this.numericUpDown_cd_preroll);
            this.tabPage_container_detector.Controls.Add(this.button_cd_event_trigger);
            this.tabPage_container_detector.Controls.Add(this.listView_cd_queue);
            this.tabPage_container_detector.Controls.Add(this.button_cd_clear_console);
            this.tabPage_container_detector.Controls.Add(this.checkBox_cd_console_autoscroll);
            this.tabPage_container_detector.Controls.Add(this.listBox_cd_console);
            this.tabPage_container_detector.Location = new System.Drawing.Point(4, 22);
            this.tabPage_container_detector.Name = "tabPage_container_detector";
            this.tabPage_container_detector.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_container_detector.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_container_detector.TabIndex = 15;
            this.tabPage_container_detector.Text = "Container Detector";
            this.tabPage_container_detector.UseVisualStyleBackColor = true;
            // 
            // checkBox_cd_process_date
            // 
            this.checkBox_cd_process_date.AutoSize = true;
            this.checkBox_cd_process_date.Checked = true;
            this.checkBox_cd_process_date.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cd_process_date.Location = new System.Drawing.Point(705, 11);
            this.checkBox_cd_process_date.Name = "checkBox_cd_process_date";
            this.checkBox_cd_process_date.Size = new System.Drawing.Size(90, 17);
            this.checkBox_cd_process_date.TabIndex = 101;
            this.checkBox_cd_process_date.Text = "Process Date";
            this.checkBox_cd_process_date.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_cd_process_datetime
            // 
            this.dateTimePicker_cd_process_datetime.CustomFormat = " ddddd, MMMM dd, yyyy";
            this.dateTimePicker_cd_process_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_cd_process_datetime.Location = new System.Drawing.Point(502, 9);
            this.dateTimePicker_cd_process_datetime.Name = "dateTimePicker_cd_process_datetime";
            this.dateTimePicker_cd_process_datetime.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker_cd_process_datetime.TabIndex = 99;
            // 
            // button_cd_start
            // 
            this.button_cd_start.Location = new System.Drawing.Point(1161, 6);
            this.button_cd_start.Name = "button_cd_start";
            this.button_cd_start.Size = new System.Drawing.Size(164, 32);
            this.button_cd_start.TabIndex = 98;
            this.button_cd_start.Text = "START DETECTOR";
            this.button_cd_start.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_cd_database_cycle_time
            // 
            this.numericUpDown_cd_database_cycle_time.Location = new System.Drawing.Point(1095, 9);
            this.numericUpDown_cd_database_cycle_time.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown_cd_database_cycle_time.Name = "numericUpDown_cd_database_cycle_time";
            this.numericUpDown_cd_database_cycle_time.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_cd_database_cycle_time.TabIndex = 97;
            this.numericUpDown_cd_database_cycle_time.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(976, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Database Cycle Time";
            // 
            // button_cd_trigger_settime
            // 
            this.button_cd_trigger_settime.Location = new System.Drawing.Point(350, 6);
            this.button_cd_trigger_settime.Name = "button_cd_trigger_settime";
            this.button_cd_trigger_settime.Size = new System.Drawing.Size(92, 23);
            this.button_cd_trigger_settime.TabIndex = 95;
            this.button_cd_trigger_settime.Text = "TRIGGER";
            this.button_cd_trigger_settime.UseVisualStyleBackColor = true;
            // 
            // button_cd_set_datetime
            // 
            this.button_cd_set_datetime.Location = new System.Drawing.Point(177, 6);
            this.button_cd_set_datetime.Name = "button_cd_set_datetime";
            this.button_cd_set_datetime.Size = new System.Drawing.Size(65, 23);
            this.button_cd_set_datetime.TabIndex = 94;
            this.button_cd_set_datetime.Text = "SET TIME";
            this.button_cd_set_datetime.UseVisualStyleBackColor = true;
            // 
            // textBox_cd_trigger_datetime
            // 
            this.textBox_cd_trigger_datetime.Location = new System.Drawing.Point(248, 8);
            this.textBox_cd_trigger_datetime.Name = "textBox_cd_trigger_datetime";
            this.textBox_cd_trigger_datetime.Size = new System.Drawing.Size(96, 20);
            this.textBox_cd_trigger_datetime.TabIndex = 93;
            // 
            // button_cd_test_image_extractor_again
            // 
            this.button_cd_test_image_extractor_again.Location = new System.Drawing.Point(177, 35);
            this.button_cd_test_image_extractor_again.Name = "button_cd_test_image_extractor_again";
            this.button_cd_test_image_extractor_again.Size = new System.Drawing.Size(131, 23);
            this.button_cd_test_image_extractor_again.TabIndex = 92;
            this.button_cd_test_image_extractor_again.Text = "TEST IE SAME AGAIN";
            this.button_cd_test_image_extractor_again.UseVisualStyleBackColor = true;
            // 
            // button_cd_test_image_extractor
            // 
            this.button_cd_test_image_extractor.Location = new System.Drawing.Point(7, 35);
            this.button_cd_test_image_extractor.Name = "button_cd_test_image_extractor";
            this.button_cd_test_image_extractor.Size = new System.Drawing.Size(164, 23);
            this.button_cd_test_image_extractor.TabIndex = 91;
            this.button_cd_test_image_extractor.Text = "TEST IMAGE EXTRACTOR";
            this.button_cd_test_image_extractor.UseVisualStyleBackColor = true;
            // 
            // button_cd_search_events
            // 
            this.button_cd_search_events.Location = new System.Drawing.Point(7, 6);
            this.button_cd_search_events.Name = "button_cd_search_events";
            this.button_cd_search_events.Size = new System.Drawing.Size(164, 23);
            this.button_cd_search_events.TabIndex = 90;
            this.button_cd_search_events.Text = "SEARCH EVENTS";
            this.button_cd_search_events.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_cd_recording_channel
            // 
            this.numericUpDown_cd_recording_channel.Location = new System.Drawing.Point(1095, 39);
            this.numericUpDown_cd_recording_channel.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown_cd_recording_channel.Name = "numericUpDown_cd_recording_channel";
            this.numericUpDown_cd_recording_channel.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_cd_recording_channel.TabIndex = 89;
            this.numericUpDown_cd_recording_channel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label_cd_recording_channel
            // 
            this.label_cd_recording_channel.AutoSize = true;
            this.label_cd_recording_channel.Location = new System.Drawing.Point(976, 41);
            this.label_cd_recording_channel.Name = "label_cd_recording_channel";
            this.label_cd_recording_channel.Size = new System.Drawing.Size(98, 13);
            this.label_cd_recording_channel.TabIndex = 88;
            this.label_cd_recording_channel.Text = "Recording Channel";
            // 
            // label_cd_recording_timer
            // 
            this.label_cd_recording_timer.AutoSize = true;
            this.label_cd_recording_timer.Location = new System.Drawing.Point(109, 361);
            this.label_cd_recording_timer.Name = "label_cd_recording_timer";
            this.label_cd_recording_timer.Size = new System.Drawing.Size(82, 13);
            this.label_cd_recording_timer.TabIndex = 87;
            this.label_cd_recording_timer.Text = "Recording Time";
            // 
            // textBox_cd_recording_timer
            // 
            this.textBox_cd_recording_timer.Location = new System.Drawing.Point(6, 357);
            this.textBox_cd_recording_timer.Name = "textBox_cd_recording_timer";
            this.textBox_cd_recording_timer.Size = new System.Drawing.Size(97, 20);
            this.textBox_cd_recording_timer.TabIndex = 86;
            // 
            // label_cd_recording_time
            // 
            this.label_cd_recording_time.AutoSize = true;
            this.label_cd_recording_time.Location = new System.Drawing.Point(800, 11);
            this.label_cd_recording_time.Name = "label_cd_recording_time";
            this.label_cd_recording_time.Size = new System.Drawing.Size(113, 13);
            this.label_cd_recording_time.TabIndex = 85;
            this.label_cd_recording_time.Text = "Event Recording Time";
            // 
            // numericUpDown_cd_recording_time
            // 
            this.numericUpDown_cd_recording_time.Location = new System.Drawing.Point(920, 9);
            this.numericUpDown_cd_recording_time.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_cd_recording_time.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numericUpDown_cd_recording_time.Name = "numericUpDown_cd_recording_time";
            this.numericUpDown_cd_recording_time.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_cd_recording_time.TabIndex = 84;
            this.numericUpDown_cd_recording_time.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label_cd_preroll
            // 
            this.label_cd_preroll.AutoSize = true;
            this.label_cd_preroll.Location = new System.Drawing.Point(800, 38);
            this.label_cd_preroll.Name = "label_cd_preroll";
            this.label_cd_preroll.Size = new System.Drawing.Size(75, 13);
            this.label_cd_preroll.TabIndex = 83;
            this.label_cd_preroll.Text = "Event Pre-Roll";
            // 
            // numericUpDown_cd_preroll
            // 
            this.numericUpDown_cd_preroll.Location = new System.Drawing.Point(920, 37);
            this.numericUpDown_cd_preroll.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_cd_preroll.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numericUpDown_cd_preroll.Name = "numericUpDown_cd_preroll";
            this.numericUpDown_cd_preroll.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_cd_preroll.TabIndex = 82;
            this.numericUpDown_cd_preroll.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button_cd_event_trigger
            // 
            this.button_cd_event_trigger.Location = new System.Drawing.Point(314, 35);
            this.button_cd_event_trigger.Name = "button_cd_event_trigger";
            this.button_cd_event_trigger.Size = new System.Drawing.Size(128, 23);
            this.button_cd_event_trigger.TabIndex = 81;
            this.button_cd_event_trigger.Text = "EVENT TRIGGER";
            this.button_cd_event_trigger.UseVisualStyleBackColor = true;
            // 
            // listView_cd_queue
            // 
            this.listView_cd_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader37,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader32,
            this.columnHeader31,
            this.columnHeader36,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35});
            this.listView_cd_queue.HideSelection = false;
            this.listView_cd_queue.Location = new System.Drawing.Point(6, 67);
            this.listView_cd_queue.Name = "listView_cd_queue";
            this.listView_cd_queue.Size = new System.Drawing.Size(1320, 282);
            this.listView_cd_queue.TabIndex = 80;
            this.listView_cd_queue.UseCompatibleStateImageBehavior = false;
            this.listView_cd_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Unique Id";
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Parent U Id";
            this.columnHeader37.Width = 80;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Status";
            this.columnHeader28.Width = 130;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Container Unique Id";
            this.columnHeader29.Width = 120;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Container Id";
            this.columnHeader30.Width = 145;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Event Time";
            this.columnHeader32.Width = 150;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Start";
            this.columnHeader31.Width = 120;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Stop";
            this.columnHeader36.Width = 120;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Video File";
            this.columnHeader33.Width = 100;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Downloaded";
            this.columnHeader34.Width = 100;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Extracted Frames";
            this.columnHeader35.Width = 120;
            // 
            // button_cd_clear_console
            // 
            this.button_cd_clear_console.Location = new System.Drawing.Point(1251, 355);
            this.button_cd_clear_console.Name = "button_cd_clear_console";
            this.button_cd_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_cd_clear_console.TabIndex = 79;
            this.button_cd_clear_console.Text = "Clear";
            this.button_cd_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_cd_console_autoscroll
            // 
            this.checkBox_cd_console_autoscroll.AutoSize = true;
            this.checkBox_cd_console_autoscroll.Checked = true;
            this.checkBox_cd_console_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cd_console_autoscroll.Location = new System.Drawing.Point(1171, 359);
            this.checkBox_cd_console_autoscroll.Name = "checkBox_cd_console_autoscroll";
            this.checkBox_cd_console_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_cd_console_autoscroll.TabIndex = 78;
            this.checkBox_cd_console_autoscroll.Text = "AutoScroll";
            this.checkBox_cd_console_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listBox_cd_console
            // 
            this.listBox_cd_console.FormattingEnabled = true;
            this.listBox_cd_console.Location = new System.Drawing.Point(6, 384);
            this.listBox_cd_console.Name = "listBox_cd_console";
            this.listBox_cd_console.Size = new System.Drawing.Size(1320, 251);
            this.listBox_cd_console.TabIndex = 77;
            // 
            // tabPage_image_extractor
            // 
            this.tabPage_image_extractor.Controls.Add(this.numericUpDown_ie_crop_y);
            this.tabPage_image_extractor.Controls.Add(this.numericUpDown_ie_crop_x);
            this.tabPage_image_extractor.Controls.Add(this.label_ie_crop_position);
            this.tabPage_image_extractor.Controls.Add(this.numericUpDown_ie_crop_height);
            this.tabPage_image_extractor.Controls.Add(this.numericUpDown_ie_crop_width);
            this.tabPage_image_extractor.Controls.Add(this.label_ie_crop_size);
            this.tabPage_image_extractor.Controls.Add(this.numericUpDown_ie_extract_rate);
            this.tabPage_image_extractor.Controls.Add(this.label_ie_extract_rate);
            this.tabPage_image_extractor.Controls.Add(this.listView_ie_extractor_queue);
            this.tabPage_image_extractor.Controls.Add(this.button_ie_clear_console);
            this.tabPage_image_extractor.Controls.Add(this.checkBox_ie_console_autoscroll);
            this.tabPage_image_extractor.Controls.Add(this.listBox_ie_console);
            this.tabPage_image_extractor.Location = new System.Drawing.Point(4, 22);
            this.tabPage_image_extractor.Name = "tabPage_image_extractor";
            this.tabPage_image_extractor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_image_extractor.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_image_extractor.TabIndex = 14;
            this.tabPage_image_extractor.Text = "Image Extractor";
            this.tabPage_image_extractor.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_ie_crop_y
            // 
            this.numericUpDown_ie_crop_y.Location = new System.Drawing.Point(1202, 86);
            this.numericUpDown_ie_crop_y.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numericUpDown_ie_crop_y.Name = "numericUpDown_ie_crop_y";
            this.numericUpDown_ie_crop_y.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_ie_crop_y.TabIndex = 99;
            this.numericUpDown_ie_crop_y.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDown_ie_crop_x
            // 
            this.numericUpDown_ie_crop_x.Location = new System.Drawing.Point(1146, 86);
            this.numericUpDown_ie_crop_x.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericUpDown_ie_crop_x.Name = "numericUpDown_ie_crop_x";
            this.numericUpDown_ie_crop_x.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_ie_crop_x.TabIndex = 98;
            this.numericUpDown_ie_crop_x.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label_ie_crop_position
            // 
            this.label_ie_crop_position.AutoSize = true;
            this.label_ie_crop_position.Location = new System.Drawing.Point(1038, 88);
            this.label_ie_crop_position.Name = "label_ie_crop_position";
            this.label_ie_crop_position.Size = new System.Drawing.Size(97, 13);
            this.label_ie_crop_position.TabIndex = 97;
            this.label_ie_crop_position.Text = "Crop Position X x Y";
            // 
            // numericUpDown_ie_crop_height
            // 
            this.numericUpDown_ie_crop_height.Location = new System.Drawing.Point(1202, 112);
            this.numericUpDown_ie_crop_height.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numericUpDown_ie_crop_height.Name = "numericUpDown_ie_crop_height";
            this.numericUpDown_ie_crop_height.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_ie_crop_height.TabIndex = 96;
            this.numericUpDown_ie_crop_height.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDown_ie_crop_width
            // 
            this.numericUpDown_ie_crop_width.Location = new System.Drawing.Point(1146, 112);
            this.numericUpDown_ie_crop_width.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericUpDown_ie_crop_width.Name = "numericUpDown_ie_crop_width";
            this.numericUpDown_ie_crop_width.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_ie_crop_width.TabIndex = 95;
            this.numericUpDown_ie_crop_width.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label_ie_crop_size
            // 
            this.label_ie_crop_size.AutoSize = true;
            this.label_ie_crop_size.Location = new System.Drawing.Point(1038, 114);
            this.label_ie_crop_size.Name = "label_ie_crop_size";
            this.label_ie_crop_size.Size = new System.Drawing.Size(102, 13);
            this.label_ie_crop_size.TabIndex = 94;
            this.label_ie_crop_size.Text = "Crop Width x Height";
            // 
            // numericUpDown_ie_extract_rate
            // 
            this.numericUpDown_ie_extract_rate.Location = new System.Drawing.Point(139, 6);
            this.numericUpDown_ie_extract_rate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_ie_extract_rate.Name = "numericUpDown_ie_extract_rate";
            this.numericUpDown_ie_extract_rate.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_ie_extract_rate.TabIndex = 91;
            this.numericUpDown_ie_extract_rate.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label_ie_extract_rate
            // 
            this.label_ie_extract_rate.AutoSize = true;
            this.label_ie_extract_rate.Location = new System.Drawing.Point(6, 9);
            this.label_ie_extract_rate.Name = "label_ie_extract_rate";
            this.label_ie_extract_rate.Size = new System.Drawing.Size(129, 13);
            this.label_ie_extract_rate.TabIndex = 90;
            this.label_ie_extract_rate.Text = "Extract Rate (In Seconds)";
            // 
            // listView_ie_extractor_queue
            // 
            this.listView_ie_extractor_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42});
            this.listView_ie_extractor_queue.HideSelection = false;
            this.listView_ie_extractor_queue.Location = new System.Drawing.Point(6, 33);
            this.listView_ie_extractor_queue.Name = "listView_ie_extractor_queue";
            this.listView_ie_extractor_queue.Size = new System.Drawing.Size(753, 602);
            this.listView_ie_extractor_queue.TabIndex = 78;
            this.listView_ie_extractor_queue.UseCompatibleStateImageBehavior = false;
            this.listView_ie_extractor_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "File Name";
            this.columnHeader38.Width = 250;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Status";
            this.columnHeader39.Width = 120;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Reference Type";
            this.columnHeader40.Width = 160;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "Unique Id";
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Image Extractor";
            this.columnHeader42.Width = 120;
            // 
            // button_ie_clear_console
            // 
            this.button_ie_clear_console.Location = new System.Drawing.Point(1251, 4);
            this.button_ie_clear_console.Name = "button_ie_clear_console";
            this.button_ie_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_ie_clear_console.TabIndex = 76;
            this.button_ie_clear_console.Text = "Clear";
            this.button_ie_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_ie_console_autoscroll
            // 
            this.checkBox_ie_console_autoscroll.AutoSize = true;
            this.checkBox_ie_console_autoscroll.Checked = true;
            this.checkBox_ie_console_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ie_console_autoscroll.Location = new System.Drawing.Point(1171, 8);
            this.checkBox_ie_console_autoscroll.Name = "checkBox_ie_console_autoscroll";
            this.checkBox_ie_console_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_ie_console_autoscroll.TabIndex = 75;
            this.checkBox_ie_console_autoscroll.Text = "AutoScroll";
            this.checkBox_ie_console_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listBox_ie_console
            // 
            this.listBox_ie_console.FormattingEnabled = true;
            this.listBox_ie_console.Location = new System.Drawing.Point(765, 176);
            this.listBox_ie_console.Name = "listBox_ie_console";
            this.listBox_ie_console.Size = new System.Drawing.Size(561, 459);
            this.listBox_ie_console.TabIndex = 74;
            // 
            // tabPage_vision_ai
            // 
            this.tabPage_vision_ai.Controls.Add(this.button_test_vision_analyzer_single_image);
            this.tabPage_vision_ai.Controls.Add(this.label_va_min_confidence);
            this.tabPage_vision_ai.Controls.Add(this.numericUpDown_va_min_confidence);
            this.tabPage_vision_ai.Controls.Add(this.checkBox_va_object_detection_active);
            this.tabPage_vision_ai.Controls.Add(this.label_va_azure_debounce);
            this.tabPage_vision_ai.Controls.Add(this.numericUpDown_va_azure_debounce);
            this.tabPage_vision_ai.Controls.Add(this.listView_va_vision_queue);
            this.tabPage_vision_ai.Controls.Add(this.listView_va_filelist);
            this.tabPage_vision_ai.Controls.Add(this.listView_va_labels_dectected);
            this.tabPage_vision_ai.Controls.Add(this.listView_va_text_dectected);
            this.tabPage_vision_ai.Controls.Add(this.button_va_clear_console);
            this.tabPage_vision_ai.Controls.Add(this.checkBox_va_auto_scroll);
            this.tabPage_vision_ai.Controls.Add(this.listBox_va_console);
            this.tabPage_vision_ai.Location = new System.Drawing.Point(4, 22);
            this.tabPage_vision_ai.Name = "tabPage_vision_ai";
            this.tabPage_vision_ai.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_vision_ai.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_vision_ai.TabIndex = 13;
            this.tabPage_vision_ai.Text = "Vision Analyzer";
            this.tabPage_vision_ai.UseVisualStyleBackColor = true;
            // 
            // button_test_vision_analyzer_single_image
            // 
            this.button_test_vision_analyzer_single_image.Location = new System.Drawing.Point(859, 315);
            this.button_test_vision_analyzer_single_image.Name = "button_test_vision_analyzer_single_image";
            this.button_test_vision_analyzer_single_image.Size = new System.Drawing.Size(75, 23);
            this.button_test_vision_analyzer_single_image.TabIndex = 91;
            this.button_test_vision_analyzer_single_image.Text = "Test Image";
            this.button_test_vision_analyzer_single_image.UseVisualStyleBackColor = true;
            // 
            // label_va_min_confidence
            // 
            this.label_va_min_confidence.AutoSize = true;
            this.label_va_min_confidence.Location = new System.Drawing.Point(1156, 323);
            this.label_va_min_confidence.Name = "label_va_min_confidence";
            this.label_va_min_confidence.Size = new System.Drawing.Size(105, 13);
            this.label_va_min_confidence.TabIndex = 90;
            this.label_va_min_confidence.Text = "Minimum Confidence";
            // 
            // numericUpDown_va_min_confidence
            // 
            this.numericUpDown_va_min_confidence.Location = new System.Drawing.Point(1276, 321);
            this.numericUpDown_va_min_confidence.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_va_min_confidence.Name = "numericUpDown_va_min_confidence";
            this.numericUpDown_va_min_confidence.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_va_min_confidence.TabIndex = 89;
            this.numericUpDown_va_min_confidence.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox_va_object_detection_active
            // 
            this.checkBox_va_object_detection_active.AutoSize = true;
            this.checkBox_va_object_detection_active.Location = new System.Drawing.Point(859, 292);
            this.checkBox_va_object_detection_active.Name = "checkBox_va_object_detection_active";
            this.checkBox_va_object_detection_active.Size = new System.Drawing.Size(106, 17);
            this.checkBox_va_object_detection_active.TabIndex = 88;
            this.checkBox_va_object_detection_active.Text = "Object Detection";
            this.checkBox_va_object_detection_active.UseVisualStyleBackColor = true;
            // 
            // label_va_azure_debounce
            // 
            this.label_va_azure_debounce.AutoSize = true;
            this.label_va_azure_debounce.Location = new System.Drawing.Point(1156, 297);
            this.label_va_azure_debounce.Name = "label_va_azure_debounce";
            this.label_va_azure_debounce.Size = new System.Drawing.Size(113, 13);
            this.label_va_azure_debounce.TabIndex = 87;
            this.label_va_azure_debounce.Text = "Azure Debounce (sec)";
            // 
            // numericUpDown_va_azure_debounce
            // 
            this.numericUpDown_va_azure_debounce.Location = new System.Drawing.Point(1276, 295);
            this.numericUpDown_va_azure_debounce.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_va_azure_debounce.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numericUpDown_va_azure_debounce.Name = "numericUpDown_va_azure_debounce";
            this.numericUpDown_va_azure_debounce.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_va_azure_debounce.TabIndex = 86;
            this.numericUpDown_va_azure_debounce.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listView_va_vision_queue
            // 
            this.listView_va_vision_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53});
            this.listView_va_vision_queue.HideSelection = false;
            this.listView_va_vision_queue.Location = new System.Drawing.Point(6, 6);
            this.listView_va_vision_queue.Name = "listView_va_vision_queue";
            this.listView_va_vision_queue.Size = new System.Drawing.Size(626, 280);
            this.listView_va_vision_queue.TabIndex = 79;
            this.listView_va_vision_queue.UseCompatibleStateImageBehavior = false;
            this.listView_va_vision_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "File Name";
            this.columnHeader49.Width = 150;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Status";
            this.columnHeader50.Width = 120;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "Reference Type";
            this.columnHeader51.Width = 160;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "Unique Id";
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "Images Analyzed";
            this.columnHeader53.Width = 120;
            // 
            // listView_va_filelist
            // 
            this.listView_va_filelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader43,
            this.columnHeader46,
            this.columnHeader44,
            this.columnHeader48,
            this.columnHeader47,
            this.columnHeader26,
            this.columnHeader45,
            this.columnHeader72});
            this.listView_va_filelist.HideSelection = false;
            this.listView_va_filelist.Location = new System.Drawing.Point(638, 6);
            this.listView_va_filelist.Name = "listView_va_filelist";
            this.listView_va_filelist.Size = new System.Drawing.Size(688, 280);
            this.listView_va_filelist.TabIndex = 76;
            this.listView_va_filelist.UseCompatibleStateImageBehavior = false;
            this.listView_va_filelist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "File Name";
            this.columnHeader43.Width = 80;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Unique Id";
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "Status";
            this.columnHeader44.Width = 90;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "Text Found";
            this.columnHeader48.Width = 100;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "Valid Text Found";
            this.columnHeader47.Width = 120;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Labels";
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Analyzed";
            // 
            // columnHeader72
            // 
            this.columnHeader72.Text = "Type Code Confidence";
            this.columnHeader72.Width = 120;
            // 
            // listView_va_labels_dectected
            // 
            this.listView_va_labels_dectected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader24,
            this.columnHeader25});
            this.listView_va_labels_dectected.HideSelection = false;
            this.listView_va_labels_dectected.Location = new System.Drawing.Point(523, 292);
            this.listView_va_labels_dectected.Name = "listView_va_labels_dectected";
            this.listView_va_labels_dectected.Size = new System.Drawing.Size(329, 204);
            this.listView_va_labels_dectected.TabIndex = 75;
            this.listView_va_labels_dectected.UseCompatibleStateImageBehavior = false;
            this.listView_va_labels_dectected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Labels";
            this.columnHeader24.Width = 200;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Confidence";
            this.columnHeader25.Width = 100;
            // 
            // listView_va_text_dectected
            // 
            this.listView_va_text_dectected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader71});
            this.listView_va_text_dectected.HideSelection = false;
            this.listView_va_text_dectected.Location = new System.Drawing.Point(6, 292);
            this.listView_va_text_dectected.Name = "listView_va_text_dectected";
            this.listView_va_text_dectected.Size = new System.Drawing.Size(511, 204);
            this.listView_va_text_dectected.TabIndex = 74;
            this.listView_va_text_dectected.UseCompatibleStateImageBehavior = false;
            this.listView_va_text_dectected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Strings Found";
            this.columnHeader23.Width = 220;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "Valid";
            this.columnHeader54.Width = 80;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "Length";
            // 
            // columnHeader71
            // 
            this.columnHeader71.Text = "Confidence";
            this.columnHeader71.Width = 85;
            // 
            // button_va_clear_console
            // 
            this.button_va_clear_console.Location = new System.Drawing.Point(1251, 473);
            this.button_va_clear_console.Name = "button_va_clear_console";
            this.button_va_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_va_clear_console.TabIndex = 73;
            this.button_va_clear_console.Text = "Clear";
            this.button_va_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_va_auto_scroll
            // 
            this.checkBox_va_auto_scroll.AutoSize = true;
            this.checkBox_va_auto_scroll.Checked = true;
            this.checkBox_va_auto_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_va_auto_scroll.Location = new System.Drawing.Point(1171, 477);
            this.checkBox_va_auto_scroll.Name = "checkBox_va_auto_scroll";
            this.checkBox_va_auto_scroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_va_auto_scroll.TabIndex = 72;
            this.checkBox_va_auto_scroll.Text = "AutoScroll";
            this.checkBox_va_auto_scroll.UseVisualStyleBackColor = true;
            // 
            // listBox_va_console
            // 
            this.listBox_va_console.FormattingEnabled = true;
            this.listBox_va_console.Location = new System.Drawing.Point(6, 502);
            this.listBox_va_console.Name = "listBox_va_console";
            this.listBox_va_console.Size = new System.Drawing.Size(1320, 134);
            this.listBox_va_console.TabIndex = 71;
            // 
            // tabPage_video_converter
            // 
            this.tabPage_video_converter.Controls.Add(this.listView_vc_queue);
            this.tabPage_video_converter.Controls.Add(this.button_vc_clear_console);
            this.tabPage_video_converter.Controls.Add(this.checkBox_vc_auto_scroll);
            this.tabPage_video_converter.Controls.Add(this.listBox_vc_console);
            this.tabPage_video_converter.Location = new System.Drawing.Point(4, 22);
            this.tabPage_video_converter.Name = "tabPage_video_converter";
            this.tabPage_video_converter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_video_converter.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_video_converter.TabIndex = 10;
            this.tabPage_video_converter.Text = "Video Converter";
            this.tabPage_video_converter.UseVisualStyleBackColor = true;
            // 
            // listView_vc_queue
            // 
            this.listView_vc_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader18});
            this.listView_vc_queue.HideSelection = false;
            this.listView_vc_queue.Location = new System.Drawing.Point(6, 6);
            this.listView_vc_queue.Name = "listView_vc_queue";
            this.listView_vc_queue.Size = new System.Drawing.Size(709, 362);
            this.listView_vc_queue.TabIndex = 73;
            this.listView_vc_queue.UseCompatibleStateImageBehavior = false;
            this.listView_vc_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "File Name";
            this.columnHeader10.Width = 250;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Status";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Reference Type";
            this.columnHeader15.Width = 160;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Unique Id";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Converted";
            this.columnHeader18.Width = 80;
            // 
            // button_vc_clear_console
            // 
            this.button_vc_clear_console.Location = new System.Drawing.Point(1251, 384);
            this.button_vc_clear_console.Name = "button_vc_clear_console";
            this.button_vc_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_vc_clear_console.TabIndex = 72;
            this.button_vc_clear_console.Text = "Clear";
            this.button_vc_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_vc_auto_scroll
            // 
            this.checkBox_vc_auto_scroll.AutoSize = true;
            this.checkBox_vc_auto_scroll.Checked = true;
            this.checkBox_vc_auto_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_vc_auto_scroll.Location = new System.Drawing.Point(1171, 388);
            this.checkBox_vc_auto_scroll.Name = "checkBox_vc_auto_scroll";
            this.checkBox_vc_auto_scroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_vc_auto_scroll.TabIndex = 71;
            this.checkBox_vc_auto_scroll.Text = "AutoScroll";
            this.checkBox_vc_auto_scroll.UseVisualStyleBackColor = true;
            // 
            // listBox_vc_console
            // 
            this.listBox_vc_console.FormattingEnabled = true;
            this.listBox_vc_console.Location = new System.Drawing.Point(6, 413);
            this.listBox_vc_console.Name = "listBox_vc_console";
            this.listBox_vc_console.Size = new System.Drawing.Size(1320, 225);
            this.listBox_vc_console.TabIndex = 70;
            // 
            // tabPage_ftp
            // 
            this.tabPage_ftp.Controls.Add(this.listView_ftp_queue);
            this.tabPage_ftp.Controls.Add(this.button_ftp_clear_console);
            this.tabPage_ftp.Controls.Add(this.checkBox_ftp_auto_scroll);
            this.tabPage_ftp.Controls.Add(this.listBox_ftp_console);
            this.tabPage_ftp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ftp.Name = "tabPage_ftp";
            this.tabPage_ftp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ftp.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_ftp.TabIndex = 11;
            this.tabPage_ftp.Text = "FTP Uploader";
            this.tabPage_ftp.UseVisualStyleBackColor = true;
            // 
            // listView_ftp_queue
            // 
            this.listView_ftp_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader17,
            this.columnHeader19,
            this.columnHeader20});
            this.listView_ftp_queue.HideSelection = false;
            this.listView_ftp_queue.Location = new System.Drawing.Point(6, 6);
            this.listView_ftp_queue.Name = "listView_ftp_queue";
            this.listView_ftp_queue.Size = new System.Drawing.Size(709, 362);
            this.listView_ftp_queue.TabIndex = 76;
            this.listView_ftp_queue.UseCompatibleStateImageBehavior = false;
            this.listView_ftp_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "File Name";
            this.columnHeader13.Width = 250;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Status";
            this.columnHeader14.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Reference Type";
            this.columnHeader17.Width = 160;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Unique Id";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Uploaded";
            this.columnHeader20.Width = 80;
            // 
            // button_ftp_clear_console
            // 
            this.button_ftp_clear_console.Location = new System.Drawing.Point(1251, 381);
            this.button_ftp_clear_console.Name = "button_ftp_clear_console";
            this.button_ftp_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_ftp_clear_console.TabIndex = 75;
            this.button_ftp_clear_console.Text = "Clear";
            this.button_ftp_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_ftp_auto_scroll
            // 
            this.checkBox_ftp_auto_scroll.AutoSize = true;
            this.checkBox_ftp_auto_scroll.Checked = true;
            this.checkBox_ftp_auto_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ftp_auto_scroll.Location = new System.Drawing.Point(1171, 385);
            this.checkBox_ftp_auto_scroll.Name = "checkBox_ftp_auto_scroll";
            this.checkBox_ftp_auto_scroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_ftp_auto_scroll.TabIndex = 74;
            this.checkBox_ftp_auto_scroll.Text = "AutoScroll";
            this.checkBox_ftp_auto_scroll.UseVisualStyleBackColor = true;
            // 
            // listBox_ftp_console
            // 
            this.listBox_ftp_console.FormattingEnabled = true;
            this.listBox_ftp_console.Location = new System.Drawing.Point(6, 410);
            this.listBox_ftp_console.Name = "listBox_ftp_console";
            this.listBox_ftp_console.Size = new System.Drawing.Size(1320, 225);
            this.listBox_ftp_console.TabIndex = 73;
            // 
            // tabPage_db
            // 
            this.tabPage_db.Controls.Add(this.button_db_test_connections);
            this.tabPage_db.Controls.Add(this.button_db_clear_console);
            this.tabPage_db.Controls.Add(this.checkBox_db_auto_scroll);
            this.tabPage_db.Controls.Add(this.listBox_db_console);
            this.tabPage_db.Location = new System.Drawing.Point(4, 22);
            this.tabPage_db.Name = "tabPage_db";
            this.tabPage_db.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_db.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_db.TabIndex = 12;
            this.tabPage_db.Text = "Database";
            this.tabPage_db.UseVisualStyleBackColor = true;
            // 
            // button_db_test_connections
            // 
            this.button_db_test_connections.Location = new System.Drawing.Point(1171, 7);
            this.button_db_test_connections.Name = "button_db_test_connections";
            this.button_db_test_connections.Size = new System.Drawing.Size(154, 23);
            this.button_db_test_connections.TabIndex = 76;
            this.button_db_test_connections.Text = "Test Connections";
            this.button_db_test_connections.UseVisualStyleBackColor = true;
            // 
            // button_db_clear_console
            // 
            this.button_db_clear_console.Location = new System.Drawing.Point(1251, 381);
            this.button_db_clear_console.Name = "button_db_clear_console";
            this.button_db_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_db_clear_console.TabIndex = 75;
            this.button_db_clear_console.Text = "Clear";
            this.button_db_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_db_auto_scroll
            // 
            this.checkBox_db_auto_scroll.AutoSize = true;
            this.checkBox_db_auto_scroll.Checked = true;
            this.checkBox_db_auto_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_db_auto_scroll.Location = new System.Drawing.Point(1171, 385);
            this.checkBox_db_auto_scroll.Name = "checkBox_db_auto_scroll";
            this.checkBox_db_auto_scroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_db_auto_scroll.TabIndex = 74;
            this.checkBox_db_auto_scroll.Text = "AutoScroll";
            this.checkBox_db_auto_scroll.UseVisualStyleBackColor = true;
            // 
            // listBox_db_console
            // 
            this.listBox_db_console.FormattingEnabled = true;
            this.listBox_db_console.Location = new System.Drawing.Point(6, 410);
            this.listBox_db_console.Name = "listBox_db_console";
            this.listBox_db_console.Size = new System.Drawing.Size(1320, 225);
            this.listBox_db_console.TabIndex = 73;
            // 
            // tabPage_downloader
            // 
            this.tabPage_downloader.Controls.Add(this.textBox_downloader_countdown_timer);
            this.tabPage_downloader.Controls.Add(this.button_downloader_clear_console);
            this.tabPage_downloader.Controls.Add(this.checkBox_downloader_console_autoscroll);
            this.tabPage_downloader.Controls.Add(this.listBox_downloader_console);
            this.tabPage_downloader.Controls.Add(this.listView_download_queue);
            this.tabPage_downloader.Location = new System.Drawing.Point(4, 22);
            this.tabPage_downloader.Name = "tabPage_downloader";
            this.tabPage_downloader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_downloader.Size = new System.Drawing.Size(1332, 641);
            this.tabPage_downloader.TabIndex = 9;
            this.tabPage_downloader.Text = "Downloader";
            this.tabPage_downloader.UseVisualStyleBackColor = true;
            // 
            // textBox_downloader_countdown_timer
            // 
            this.textBox_downloader_countdown_timer.Location = new System.Drawing.Point(1155, 6);
            this.textBox_downloader_countdown_timer.Name = "textBox_downloader_countdown_timer";
            this.textBox_downloader_countdown_timer.Size = new System.Drawing.Size(171, 20);
            this.textBox_downloader_countdown_timer.TabIndex = 71;
            // 
            // button_downloader_clear_console
            // 
            this.button_downloader_clear_console.Location = new System.Drawing.Point(1251, 384);
            this.button_downloader_clear_console.Name = "button_downloader_clear_console";
            this.button_downloader_clear_console.Size = new System.Drawing.Size(75, 23);
            this.button_downloader_clear_console.TabIndex = 70;
            this.button_downloader_clear_console.Text = "Clear";
            this.button_downloader_clear_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_downloader_console_autoscroll
            // 
            this.checkBox_downloader_console_autoscroll.AutoSize = true;
            this.checkBox_downloader_console_autoscroll.Checked = true;
            this.checkBox_downloader_console_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_downloader_console_autoscroll.Location = new System.Drawing.Point(1171, 388);
            this.checkBox_downloader_console_autoscroll.Name = "checkBox_downloader_console_autoscroll";
            this.checkBox_downloader_console_autoscroll.Size = new System.Drawing.Size(74, 17);
            this.checkBox_downloader_console_autoscroll.TabIndex = 69;
            this.checkBox_downloader_console_autoscroll.Text = "AutoScroll";
            this.checkBox_downloader_console_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listBox_downloader_console
            // 
            this.listBox_downloader_console.FormattingEnabled = true;
            this.listBox_downloader_console.Location = new System.Drawing.Point(6, 413);
            this.listBox_downloader_console.Name = "listBox_downloader_console";
            this.listBox_downloader_console.Size = new System.Drawing.Size(1320, 225);
            this.listBox_downloader_console.TabIndex = 67;
            // 
            // listView_download_queue
            // 
            this.listView_download_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader5});
            this.listView_download_queue.HideSelection = false;
            this.listView_download_queue.Location = new System.Drawing.Point(3, 6);
            this.listView_download_queue.Name = "listView_download_queue";
            this.listView_download_queue.Size = new System.Drawing.Size(1146, 362);
            this.listView_download_queue.TabIndex = 67;
            this.listView_download_queue.UseCompatibleStateImageBehavior = false;
            this.listView_download_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Channel #";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start Time";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Stop Time";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Reference Type";
            this.columnHeader8.Width = 160;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Unique Id";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Download Type";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Downloaded";
            this.columnHeader5.Width = 80;
            // 
            // label_ftp_upload_status
            // 
            this.label_ftp_upload_status.AutoSize = true;
            this.label_ftp_upload_status.Location = new System.Drawing.Point(605, 6);
            this.label_ftp_upload_status.Name = "label_ftp_upload_status";
            this.label_ftp_upload_status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_ftp_upload_status.Size = new System.Drawing.Size(74, 13);
            this.label_ftp_upload_status.TabIndex = 68;
            this.label_ftp_upload_status.Text = "Upload Status";
            // 
            // progressBar_ftp_upload_status
            // 
            this.progressBar_ftp_upload_status.Location = new System.Drawing.Point(607, 19);
            this.progressBar_ftp_upload_status.Name = "progressBar_ftp_upload_status";
            this.progressBar_ftp_upload_status.Size = new System.Drawing.Size(314, 11);
            this.progressBar_ftp_upload_status.TabIndex = 67;
            // 
            // textBox_current_time
            // 
            this.textBox_current_time.Location = new System.Drawing.Point(94, 8);
            this.textBox_current_time.Name = "textBox_current_time";
            this.textBox_current_time.Size = new System.Drawing.Size(104, 20);
            this.textBox_current_time.TabIndex = 69;
            // 
            // label_build_version
            // 
            this.label_build_version.AutoSize = true;
            this.label_build_version.Location = new System.Drawing.Point(204, 12);
            this.label_build_version.Name = "label_build_version";
            this.label_build_version.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_build_version.Size = new System.Drawing.Size(68, 13);
            this.label_build_version.TabIndex = 70;
            this.label_build_version.Text = "Build Version";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(5, 5);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(83, 25);
            this.button_start.TabIndex = 71;
            this.button_start.Text = "START ALL";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Button_start_Click);
            // 
            // label_setting_system_name_info
            // 
            this.label_setting_system_name_info.AutoSize = true;
            this.label_setting_system_name_info.Location = new System.Drawing.Point(483, 14);
            this.label_setting_system_name_info.Name = "label_setting_system_name_info";
            this.label_setting_system_name_info.Size = new System.Drawing.Size(484, 13);
            this.label_setting_system_name_info.TabIndex = 111;
            this.label_setting_system_name_info.Text = "!IMPORTANT! >>  [##] = system type, {######} = system name | eg. Vision Core [cd]" +
    " - {Loginator 1}";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1350, 707);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_build_version);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.textBox_current_time);
            this.Controls.Add(this.label_ftp_upload_status);
            this.Controls.Add(this.progressBar_ftp_upload_status);
            this.Controls.Add(this.button_restart);
            this.Controls.Add(this.label_download_status);
            this.Controls.Add(this.progressBar_download);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Vision Core";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabPage_container_chain.ResumeLayout(false);
            this.tabPage_container_chain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cc_min_length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cc_preroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_settings_record_lag)).EndInit();
            this.tabPage_hikvision.ResumeLayout(false);
            this.tabPage_hikvision.PerformLayout();
            this.tabPage_settings.ResumeLayout(false);
            this.tabControl_settings.ResumeLayout(false);
            this.tabPage_settings_server.ResumeLayout(false);
            this.tabPage_settings_server.PerformLayout();
            this.tabPage_settings_system.ResumeLayout(false);
            this.tabPage_settings_system.PerformLayout();
            this.tabPage_settings_ftp.ResumeLayout(false);
            this.tabPage_settings_ftp.PerformLayout();
            this.tabPage_settings_web_sql.ResumeLayout(false);
            this.tabPage_settings_web_sql.PerformLayout();
            this.tabPage_settings_vision_core_sql.ResumeLayout(false);
            this.tabPage_settings_vision_core_sql.PerformLayout();
            this.tabPage_settings_conversion.ResumeLayout(false);
            this.tabPage_settings_conversion.PerformLayout();
            this.tabPage_console.ResumeLayout(false);
            this.tabPage_console.PerformLayout();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_em.ResumeLayout(false);
            this.tabPage_em.PerformLayout();
            this.groupBox_em.ResumeLayout(false);
            this.groupBox_em.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_em_trigger_buffer_cd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_em_channel_cd)).EndInit();
            this.tabPage_container_process_analyzer.ResumeLayout(false);
            this.tabPage_container_process_analyzer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cpa_debounce)).EndInit();
            this.tabPage_container_detector.ResumeLayout(false);
            this.tabPage_container_detector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_database_cycle_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_recording_channel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_recording_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cd_preroll)).EndInit();
            this.tabPage_image_extractor.ResumeLayout(false);
            this.tabPage_image_extractor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_crop_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ie_extract_rate)).EndInit();
            this.tabPage_vision_ai.ResumeLayout(false);
            this.tabPage_vision_ai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_va_min_confidence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_va_azure_debounce)).EndInit();
            this.tabPage_video_converter.ResumeLayout(false);
            this.tabPage_video_converter.PerformLayout();
            this.tabPage_ftp.ResumeLayout(false);
            this.tabPage_ftp.PerformLayout();
            this.tabPage_db.ResumeLayout(false);
            this.tabPage_db.PerformLayout();
            this.tabPage_downloader.ResumeLayout(false);
            this.tabPage_downloader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button button_connect;
        public System.Windows.Forms.ProgressBar progressBar_download;
        public System.Windows.Forms.Timer timer_download;
        private System.Windows.Forms.Label label_download_status;
        public System.Windows.Forms.Button button_restart;
        public System.Windows.Forms.TabPage tabPage_container_chain;
        public System.Windows.Forms.ListView listView_container_chain_container_chain_events;
        public System.Windows.Forms.ColumnHeader head_cc_container_unique_id;
        public System.Windows.Forms.ColumnHeader head_cc_container_id;
        public System.Windows.Forms.ColumnHeader head_cc_start_search_time;
        public System.Windows.Forms.ColumnHeader head_cc_stop_search_time;
        public System.Windows.Forms.ListView listView_container_chain_files_found;
        public System.Windows.Forms.ColumnHeader head_cc_file_name;
        private System.Windows.Forms.ColumnHeader head_cc_status;
        public System.Windows.Forms.ColumnHeader head_cc_start_time;
        public System.Windows.Forms.ColumnHeader head_cc_stop_time;
        private System.Windows.Forms.ColumnHeader head_cc_download_status;
        public System.Windows.Forms.TextBox textBox_container_chain_stop_time;
        public System.Windows.Forms.TextBox textBox_container_chain_start_time;
        public System.Windows.Forms.ListBox listBox_container_chain_console;
        public System.Windows.Forms.CheckBox checkBox_container_chain_autoscroll;
        public System.Windows.Forms.Button button_container_chain_stop;
        public System.Windows.Forms.Button button_container_chain_start;
        private System.Windows.Forms.TabPage tabPage_hikvision;
        public System.Windows.Forms.ListView listView_connected_devices;
        public System.Windows.Forms.ColumnHeader connected_devices_device;
        public System.Windows.Forms.ColumnHeader connected_devices_status;
        private System.Windows.Forms.TabPage tabPage_settings;
        public System.Windows.Forms.Button button_load_settings;
        public System.Windows.Forms.Button button_save_settings;
        private System.Windows.Forms.TabControl tabControl_settings;
        private System.Windows.Forms.TabPage tabPage_settings_server;
        public System.Windows.Forms.Label label_server_ip;
        public System.Windows.Forms.TextBox textBox_server_ip;
        public System.Windows.Forms.TextBox textBox_server_port;
        public System.Windows.Forms.Label label_server_port;
        public System.Windows.Forms.TextBox textBox_login;
        public System.Windows.Forms.Label label_login;
        public System.Windows.Forms.TextBox textBox_password;
        public System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TabPage tabPage_settings_system;
        public System.Windows.Forms.TextBox textBox_save_folder;
        public System.Windows.Forms.Button button_choose_save_folder;
        public System.Windows.Forms.Label label_system_internal_name;
        public System.Windows.Forms.TextBox textBox_system_internal_name;
        private System.Windows.Forms.TabPage tabPage_settings_ftp;
        public System.Windows.Forms.Label label_ftp_credentials;
        public System.Windows.Forms.TextBox textBox_FTP_IP;
        public System.Windows.Forms.Label label_FTP_IP;
        public System.Windows.Forms.TextBox textBox_FTP_user_name;
        public System.Windows.Forms.Label label_FTP_user_name;
        public System.Windows.Forms.TextBox textBox_FTP_password;
        public System.Windows.Forms.Label label_FTP_password;
        private System.Windows.Forms.TabPage tabPage_settings_web_sql;
        public System.Windows.Forms.TextBox textBox_core_sql_database;
        public System.Windows.Forms.Label label_core_sql_database;
        public System.Windows.Forms.Label label_core_sql_credentials;
        public System.Windows.Forms.TextBox textBox_core_sql_ip;
        public System.Windows.Forms.Label label_core_sql_ip;
        public System.Windows.Forms.TextBox textBox_core_sql_login;
        public System.Windows.Forms.Label label_core_sql_login;
        public System.Windows.Forms.TextBox textBox_core_sql_password;
        public System.Windows.Forms.Label label_core_sql_password;
        private System.Windows.Forms.TabPage tabPage_settings_vision_core_sql;
        public System.Windows.Forms.Label label_vision_sql_credentials;
        public System.Windows.Forms.Label label_vision_sql_database;
        public System.Windows.Forms.TextBox textBox_vision_sql_ip;
        public System.Windows.Forms.TextBox textBox_vision_sql_database;
        public System.Windows.Forms.Label label_vision_sql_ip;
        public System.Windows.Forms.TextBox textBox_vision_sql_login;
        public System.Windows.Forms.Label label_vision_sql_login;
        public System.Windows.Forms.Label label_vision_sql_password;
        public System.Windows.Forms.TextBox textBox_vision_sql_password;
        private System.Windows.Forms.TabPage tabPage_settings_conversion;
        public System.Windows.Forms.Label label_settings_conversion_quality;
        public System.Windows.Forms.ComboBox comboBox_settings_conversion_quality;
        public System.Windows.Forms.ListBox listBox_error;
        public System.Windows.Forms.Button button_clear_thread;
        private System.Windows.Forms.TabPage tabPage_console;
        public System.Windows.Forms.ListBox listBox_console;
        public System.Windows.Forms.Button button_clear_console;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_downloader;
        public System.Windows.Forms.ListView listView_download_queue;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.ListBox listBox_downloader_console;
        public System.Windows.Forms.CheckBox checkBox_downloader_console_autoscroll;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader head_cc_cc_unique_id;
        private System.Windows.Forms.ColumnHeader head_cc_cc_status;
        private System.Windows.Forms.ColumnHeader head_cc_total_downloaded;
        public System.Windows.Forms.TextBox textBox_container_number;
        public System.Windows.Forms.CheckBox checkBox_cc_record_channel_1;
        public System.Windows.Forms.CheckBox checkBox_cc_record_channel_4;
        public System.Windows.Forms.CheckBox checkBox_cc_record_channel_3;
        public System.Windows.Forms.CheckBox checkBox_cc_record_channel_2;
        private System.Windows.Forms.ColumnHeader head_cc_total_files;
        private System.Windows.Forms.TabPage tabPage_video_converter;
        public System.Windows.Forms.CheckBox checkBox_vc_auto_scroll;
        public System.Windows.Forms.ListBox listBox_vc_console;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        public System.Windows.Forms.CheckBox checkBox_cc_download_device_videos;
        public System.Windows.Forms.Button button_cc_clear_console;
        public System.Windows.Forms.Button button_downloader_clear_console;
        public System.Windows.Forms.Button button_vc_clear_console;
        public System.Windows.Forms.ListView listView_vc_queue;
        public System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader head_cc_converted;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label_cc_preroll;
        public System.Windows.Forms.NumericUpDown numericUpDown_cc_preroll;
        private System.Windows.Forms.Label label_cc_min_length;
        public System.Windows.Forms.NumericUpDown numericUpDown_cc_min_length;
        private System.Windows.Forms.TabPage tabPage_ftp;
        public System.Windows.Forms.Button button_ftp_clear_console;
        public System.Windows.Forms.CheckBox checkBox_ftp_auto_scroll;
        public System.Windows.Forms.ListBox listBox_ftp_console;
        public System.Windows.Forms.ListView listView_ftp_queue;
        public System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.Label label_cc_ftp_sub_dir;
        public System.Windows.Forms.TextBox textBox_cc_ftp_sub_dir;
        private System.Windows.Forms.Label label_ftp_upload_status;
        public System.Windows.Forms.ProgressBar progressBar_ftp_upload_status;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.TabPage tabPage_db;
        public System.Windows.Forms.Button button_db_clear_console;
        public System.Windows.Forms.CheckBox checkBox_db_auto_scroll;
        public System.Windows.Forms.ListBox listBox_db_console;
        public System.Windows.Forms.Button button_db_test_connections;
        private System.Windows.Forms.ColumnHeader video_unique_id;
        private System.Windows.Forms.TabPage tabPage_vision_ai;
        public System.Windows.Forms.Button button_va_clear_console;
        public System.Windows.Forms.CheckBox checkBox_va_auto_scroll;
        public System.Windows.Forms.ListBox listBox_va_console;
        public System.Windows.Forms.ListView listView_va_text_dectected;
        public System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.TabPage tabPage_image_extractor;
        public System.Windows.Forms.Button button_ie_clear_console;
        public System.Windows.Forms.CheckBox checkBox_ie_console_autoscroll;
        public System.Windows.Forms.ListBox listBox_ie_console;
        public System.Windows.Forms.Button button_cc_download;
        private System.Windows.Forms.Label label_settings_record_lag;
        public System.Windows.Forms.NumericUpDown numericUpDown_settings_record_lag;
        private System.Windows.Forms.TabPage tabPage_container_detector;
        public System.Windows.Forms.Button button_cd_clear_console;
        public System.Windows.Forms.CheckBox checkBox_cd_console_autoscroll;
        public System.Windows.Forms.ListBox listBox_cd_console;
        public System.Windows.Forms.ListView listView_cd_queue;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        public System.Windows.Forms.ColumnHeader columnHeader29;
        public System.Windows.Forms.ColumnHeader columnHeader30;
        public System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        public System.Windows.Forms.Button button_cd_event_trigger;
        private System.Windows.Forms.Label label_cd_preroll;
        public System.Windows.Forms.NumericUpDown numericUpDown_cd_preroll;
        private System.Windows.Forms.Label label_cd_recording_time;
        public System.Windows.Forms.NumericUpDown numericUpDown_cd_recording_time;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.Label label_cd_recording_timer;
        public System.Windows.Forms.TextBox textBox_cd_recording_timer;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.Label label_cd_recording_channel;
        public System.Windows.Forms.NumericUpDown numericUpDown_cd_recording_channel;
        public System.Windows.Forms.ListView listView_ie_extractor_queue;
        public System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        public System.Windows.Forms.TextBox textBox_current_time;
        public System.Windows.Forms.ListView listView_va_filelist;
        public System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        public System.Windows.Forms.TextBox textBox_downloader_countdown_timer;
        public System.Windows.Forms.Button button_hvs_clear_console;
        public System.Windows.Forms.ListBox listBox_hvs_console;
        public System.Windows.Forms.CheckBox checkBox_hvs_console_autoscroll;
        public System.Windows.Forms.Button button_cd_search_events;
        public System.Windows.Forms.ListView listView_va_vision_queue;
        public System.Windows.Forms.ColumnHeader columnHeader49;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader51;
        private System.Windows.Forms.ColumnHeader columnHeader52;
        private System.Windows.Forms.ColumnHeader columnHeader53;
        public System.Windows.Forms.Button button_cd_test_image_extractor;
        public System.Windows.Forms.Button button_cd_test_image_extractor_again;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        public System.Windows.Forms.ListView listView_va_labels_dectected;
        public System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        public System.Windows.Forms.TextBox textBox_cd_trigger_datetime;
        public System.Windows.Forms.Button button_cd_set_datetime;
        public System.Windows.Forms.Button button_cd_trigger_settime;
        private System.Windows.Forms.TabPage tabPage_em;
        public System.Windows.Forms.NumericUpDown numericUpDown_em_channel_cd;
        private System.Windows.Forms.Label label_em_channel_cd;
        private System.Windows.Forms.GroupBox groupBox_em;
        public System.Windows.Forms.Button button_em_clear_console;
        public System.Windows.Forms.CheckBox checkBox_em_console_autoscroll;
        public System.Windows.Forms.ListBox listBox_em_console;
        public System.Windows.Forms.ComboBox comboBox_em_type_cd;
        public System.Windows.Forms.NumericUpDown numericUpDown_em_trigger_buffer_cd;
        private System.Windows.Forms.Label label_em_alarm_debounce_cd;
        public System.Windows.Forms.TextBox textBox_em_debounce_countdown_cd;
        public System.Windows.Forms.NumericUpDown numericUpDown_ie_extract_rate;
        private System.Windows.Forms.Label label_ie_extract_rate;
        public System.Windows.Forms.Button button_em_test_cd;
        public System.Windows.Forms.Button button_em_arm_cd;
        public System.Windows.Forms.ListView listView_event_alarm;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        public System.Windows.Forms.ColumnHeader columnHeader59;
        private System.Windows.Forms.ColumnHeader columnHeader58;
        public System.Windows.Forms.ColumnHeader columnHeader61;
        private System.Windows.Forms.ColumnHeader columnHeader57;
        private System.Windows.Forms.ColumnHeader columnHeader60;
        public System.Windows.Forms.TextBox textBox_em_set_datetime_cd;
        public System.Windows.Forms.Button button_em_set_datetime_cd;
        private System.Windows.Forms.ColumnHeader columnHeader62;
        public System.Windows.Forms.NumericUpDown numericUpDown_cd_database_cycle_time;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_cd_start;
        private System.Windows.Forms.Label label_va_azure_debounce;
        public System.Windows.Forms.NumericUpDown numericUpDown_va_azure_debounce;
        private System.Windows.Forms.Label label_console_error;
        private System.Windows.Forms.Label label_console_main;
        public System.Windows.Forms.Label label_build_version;
        private System.Windows.Forms.TabPage tabPage_container_process_analyzer;
        public System.Windows.Forms.Button button_cpa_start;
        public System.Windows.Forms.ListView listView_cpa_events;
        private System.Windows.Forms.ColumnHeader columnHeader63;
        private System.Windows.Forms.ColumnHeader columnHeader64;
        private System.Windows.Forms.ColumnHeader columnHeader65;
        private System.Windows.Forms.ColumnHeader columnHeader66;
        public System.Windows.Forms.ColumnHeader columnHeader67;
        public System.Windows.Forms.ColumnHeader columnHeader68;
        public System.Windows.Forms.Button button_cpa_clear_console;
        public System.Windows.Forms.CheckBox checkBox_cpa_console_autoscroll;
        public System.Windows.Forms.ListBox listBox_cpa_console;
        public System.Windows.Forms.NumericUpDown numericUpDown_cpa_debounce;
        private System.Windows.Forms.Label label_cpa_debounce;
        public System.Windows.Forms.TextBox textBox_cpa_debounce_countdown;
        public System.Windows.Forms.TextBox textBox_container_unique_id;
        public System.Windows.Forms.ListView listView_cpa_event_output_data;
        private System.Windows.Forms.ColumnHeader columnHeader69;
        private System.Windows.Forms.ColumnHeader columnHeader70;
        public System.Windows.Forms.Button button_start;
        public System.Windows.Forms.CheckBox checkBox_va_object_detection_active;
        public System.Windows.Forms.Button button_hvs_test;
        public System.Windows.Forms.CheckBox checkBox_cc_record_channel_6;
        public System.Windows.Forms.CheckBox checkBox_cc_record_channel_5;
        public System.Windows.Forms.CheckBox checkBox_cd_clean_up;
        private System.Windows.Forms.ColumnHeader columnHeader71;
        public System.Windows.Forms.CheckBox checkBox_cpa_reprocess;
        public System.Windows.Forms.CheckBox checkBox_cpa_last_event_at_next_container;
        private System.Windows.Forms.Label label_va_min_confidence;
        public System.Windows.Forms.NumericUpDown numericUpDown_va_min_confidence;
        private System.Windows.Forms.ColumnHeader columnHeader72;
        public System.Windows.Forms.NumericUpDown numericUpDown_ie_crop_height;
        public System.Windows.Forms.NumericUpDown numericUpDown_ie_crop_width;
        private System.Windows.Forms.Label label_ie_crop_size;
        public System.Windows.Forms.NumericUpDown numericUpDown_ie_crop_y;
        public System.Windows.Forms.NumericUpDown numericUpDown_ie_crop_x;
        private System.Windows.Forms.Label label_ie_crop_position;
        public System.Windows.Forms.Button button_cc_test_stitcher;
        public System.Windows.Forms.DateTimePicker dateTimePicker_cd_process_datetime;
        public System.Windows.Forms.CheckBox checkBox_cd_process_date;
        public System.Windows.Forms.CheckBox checkBox_cc_clean_up;
        public System.Windows.Forms.CheckBox checkBox_cpa_process_date;
        public System.Windows.Forms.DateTimePicker dateTimePicker_cpa_process_datetime;
        private System.Windows.Forms.Label label_cpa_owner;
        public System.Windows.Forms.TextBox textBox_cpa_owner;
        public System.Windows.Forms.Button button_cpa_pull;
        public System.Windows.Forms.Button button_cpa_push;
        public System.Windows.Forms.TextBox textBox_vision_core_gui_sql_database;
        public System.Windows.Forms.Label label_vision_core_gui_sql_database;
        public System.Windows.Forms.Button button_test_vision_analyzer_single_image;
        private System.Windows.Forms.Label label_system_watchgod_id;
        public System.Windows.Forms.TextBox textBox_system_watchgod_id;
        public System.Windows.Forms.Button button_backup_databases;
        public System.Windows.Forms.Label label_setting_system_name_info;
    }
}

