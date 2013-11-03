namespace MiSMDR
{
    partial class MiForm
    {
        /// <summary>
	///
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
            System.Windows.Forms.Label lbSettingsHeader;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiForm));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.connTab = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtb_license = new System.Windows.Forms.RichTextBox();
            this.pb_alert = new System.Windows.Forms.PictureBox();
            this.lb_LicenseMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_LicenseHeader = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tb_contactEmail = new System.Windows.Forms.TextBox();
            this.bn_ChangeLicense = new System.Windows.Forms.Button();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_reseller = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tb_expiry = new System.Windows.Forms.TextBox();
            this.lb_reseller = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbWelcomeContent = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbMMDemo = new System.Windows.Forms.RadioButton();
            this.lbStatus = new System.Windows.Forms.Label();
            this.rbMMLive = new System.Windows.Forms.RadioButton();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbStatusLabel = new System.Windows.Forms.Label();
            this.bnConnect = new System.Windows.Forms.Button();
            this.lbPortLabel = new System.Windows.Forms.Label();
            this.lbServerLabel = new System.Windows.Forms.Label();
            this.bnDisconnect = new System.Windows.Forms.Button();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbIncomingCount = new System.Windows.Forms.Label();
            this.bnExport = new System.Windows.Forms.Button();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.lbDurationTotal = new System.Windows.Forms.Label();
            this.lbOutgoingCount = new System.Windows.Forms.Label();
            this.lbInternalCount = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.lbTotalDurationText = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.bnSClearFields = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bnSaveCurrentSearch = new System.Windows.Forms.Button();
            this.cbSavedSearchOverwrite = new System.Windows.Forms.CheckBox();
            this.bnSearch2 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label56 = new System.Windows.Forms.Label();
            this.cbCallCategory = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.fromExactMatch = new System.Windows.Forms.CheckBox();
            this.toExactMatch = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.cbUnanswered = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.tbAnswerTime = new System.Windows.Forms.TextBox();
            this.cbAnswerTime = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.cbDuration = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DayFilter = new System.Windows.Forms.TextBox();
            this.rbAllDates = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.EndDateFilter1 = new System.Windows.Forms.DateTimePicker();
            this.StartDateFilter1 = new System.Windows.Forms.DateTimePicker();
            this.rbDateRange = new System.Windows.Forms.RadioButton();
            this.rbSingleDate = new System.Windows.Forms.RadioButton();
            this.hiddenSavedSearchName = new System.Windows.Forms.TextBox();
            this.hiddenSavedSearchID = new System.Windows.Forms.TextBox();
            this.savedSearchBox = new System.Windows.Forms.GroupBox();
            this.bnLoadSavedSearch = new System.Windows.Forms.Button();
            this.bnDeleteSavedSearch = new System.Windows.Forms.Button();
            this.lbSavedSearches = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.callInfo = new MiSMDR.CallInfo();
            this.keyInternal = new MiSMDR.GridColourKey();
            this.keyIncoming = new MiSMDR.GridColourKey();
            this.keyUnknown = new MiSMDR.GridColourKey();
            this.keyOutgoing = new MiSMDR.GridColourKey();
            this.summaryPage = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tb_LongCallDefinition = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.summaries_PeriodGroup = new System.Windows.Forms.Panel();
            this.summaries_UpdateLabel = new System.Windows.Forms.Label();
            this.ps_rb_periodDay = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.ps_rb_periodHour = new System.Windows.Forms.RadioButton();
            this.ps_rb_periodMonth = new System.Windows.Forms.RadioButton();
            this.ps_rb_periodWeek = new System.Windows.Forms.RadioButton();
            this.ps_callcount_int = new System.Windows.Forms.Label();
            this.ps_totalcallcost = new System.Windows.Forms.Label();
            this.ps_talktime_tot = new System.Windows.Forms.Label();
            this.ps_talktime_int = new System.Windows.Forms.Label();
            this.ps_talktime_inc = new System.Windows.Forms.Label();
            this.ps_talktime_out = new System.Windows.Forms.Label();
            this.ps_callcount_una = new System.Windows.Forms.Label();
            this.ps_callcount_inc = new System.Windows.Forms.Label();
            this.ps_callcount_out = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvLatest1 = new System.Windows.Forms.DataGridView();
            this.dgvLatest4 = new System.Windows.Forms.DataGridView();
            this.dgvLatest2 = new System.Windows.Forms.DataGridView();
            this.reportTab = new System.Windows.Forms.TabPage();
            this.statisticsBox = new System.Windows.Forms.GroupBox();
            this.callSummaryReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bnCallSummarySearch = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.csDay = new System.Windows.Forms.TextBox();
            this.csAllDates = new System.Windows.Forms.RadioButton();
            this.label60 = new System.Windows.Forms.Label();
            this.csEndDate = new System.Windows.Forms.DateTimePicker();
            this.csStartDate = new System.Windows.Forms.DateTimePicker();
            this.csDateRange = new System.Windows.Forms.RadioButton();
            this.csSingleDate = new System.Windows.Forms.RadioButton();
            this.addressTab = new System.Windows.Forms.TabPage();
            this.tbAddressBookHelp = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.addressDataGrid = new System.Windows.Forms.DataGridView();
            this.tbNumberID = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bnContactDelete = new System.Windows.Forms.Button();
            this.tbContactNumber = new System.Windows.Forms.TextBox();
            this.bnUpdateCont = new System.Windows.Forms.Button();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.tbContactName = new System.Windows.Forms.TextBox();
            this.bnCreateContact = new System.Windows.Forms.Button();
            this.cbContactType = new System.Windows.Forms.ComboBox();
            this.tbOldName = new System.Windows.Forms.TextBox();
            this.tbSelectedContactID = new System.Windows.Forms.TextBox();
            this.tbOldType = new System.Windows.Forms.TextBox();
            this.tbOldNumber = new System.Windows.Forms.TextBox();
            this.callCostsTab = new System.Windows.Forms.TabPage();
            this.tbCallCostHelp = new System.Windows.Forms.RichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.callCostsGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbCCExactMatch = new System.Windows.Forms.RadioButton();
            this.tbCCExactMatch = new System.Windows.Forms.TextBox();
            this.tbCCStartsWith = new System.Windows.Forms.TextBox();
            this.rbCCStartsWith = new System.Windows.Forms.RadioButton();
            this.rbCCRegEx = new System.Windows.Forms.RadioButton();
            this.tbCCRegEx = new System.Windows.Forms.TextBox();
            this.bnCCDelete = new System.Windows.Forms.Button();
            this.bnCCTest = new System.Windows.Forms.Button();
            this.bnCCUpdate = new System.Windows.Forms.Button();
            this.tbCCName = new System.Windows.Forms.TextBox();
            this.bnCCCreate = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbCCChargeUnfinished = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbCCRateBlock = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCCBlockSize = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbCCConnCost = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bnSearchCallCosts = new System.Windows.Forms.Button();
            this.tbCallCostID = new System.Windows.Forms.TextBox();
            this.logTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnSaveLog = new System.Windows.Forms.Button();
            this.bnClearLog = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRawFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSMDRSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMiSMDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbStatusText1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusCalls = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatusText2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.exportSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMitelDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SystemTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDBPort = new System.Windows.Forms.TextBox();
            this.tbDBServer = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            lbSettingsHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabContainer.SuspendLayout();
            this.connTab.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_alert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.savedSearchBox.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.summaryPage.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.summaries_PeriodGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatest4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatest2)).BeginInit();
            this.reportTab.SuspendLayout();
            this.statisticsBox.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.addressTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressDataGrid)).BeginInit();
            this.groupBox18.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.callCostsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callCostsGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.logTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SystemTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSettingsHeader
            // 
            lbSettingsHeader.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            lbSettingsHeader.Location = new System.Drawing.Point(3, 10);
            lbSettingsHeader.Name = "lbSettingsHeader";
            lbSettingsHeader.Size = new System.Drawing.Size(299, 21);
            lbSettingsHeader.TabIndex = 11;
            lbSettingsHeader.Text = "Connection Settings";
            lbSettingsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tabContainer
            // 
            this.tabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContainer.Controls.Add(this.connTab);
            this.tabContainer.Controls.Add(this.searchTab);
            this.tabContainer.Controls.Add(this.summaryPage);
            this.tabContainer.Controls.Add(this.reportTab);
            this.tabContainer.Controls.Add(this.addressTab);
            this.tabContainer.Controls.Add(this.callCostsTab);
            this.tabContainer.Controls.Add(this.logTab);
            this.tabContainer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabContainer.Location = new System.Drawing.Point(4, 27);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1008, 560);
            this.tabContainer.TabIndex = 0;
            // 
            // connTab
            // 
            this.connTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.connTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connTab.Controls.Add(this.panel4);
            this.connTab.Controls.Add(this.panel1);
            this.connTab.Location = new System.Drawing.Point(4, 22);
            this.connTab.Name = "connTab";
            this.connTab.Padding = new System.Windows.Forms.Padding(3);
            this.connTab.Size = new System.Drawing.Size(1000, 534);
            this.connTab.TabIndex = 5;
            this.connTab.Text = "Connection Status";
            this.connTab.ToolTipText = "The welcome screen";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rtb_license);
            this.panel4.Controls.Add(this.pb_alert);
            this.panel4.Controls.Add(this.lb_LicenseMessage);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lb_LicenseHeader);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.tb_contactEmail);
            this.panel4.Controls.Add(this.bn_ChangeLicense);
            this.panel4.Controls.Add(this.tb_type);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.tb_reseller);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.tb_expiry);
            this.panel4.Controls.Add(this.lb_reseller);
            this.panel4.Controls.Add(this.tb_name);
            this.panel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(-1, 353);
            this.panel4.MinimumSize = new System.Drawing.Size(1000, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 180);
            this.panel4.TabIndex = 16;
            // 
            // rtb_license
            // 
            this.rtb_license.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtb_license.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_license.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_license.Location = new System.Drawing.Point(292, 66);
            this.rtb_license.Name = "rtb_license";
            this.rtb_license.ReadOnly = true;
            this.rtb_license.Size = new System.Drawing.Size(350, 110);
            this.rtb_license.TabIndex = 30;
            this.rtb_license.Text = "";
            this.rtb_license.Visible = false;
            this.rtb_license.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb_LicenseHeader_LinkClicked);
            // 
            // pb_alert
            // 
            this.pb_alert.Image = global::MiSMDR.Properties.Resources.alert;
            this.pb_alert.Location = new System.Drawing.Point(256, 62);
            this.pb_alert.Name = "pb_alert";
            this.pb_alert.Size = new System.Drawing.Size(27, 27);
            this.pb_alert.TabIndex = 20;
            this.pb_alert.TabStop = false;
            // 
            // lb_LicenseMessage
            // 
            this.lb_LicenseMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LicenseMessage.Location = new System.Drawing.Point(289, 64);
            this.lb_LicenseMessage.Name = "lb_LicenseMessage";
            this.lb_LicenseMessage.Size = new System.Drawing.Size(308, 111);
            this.lb_LicenseMessage.TabIndex = 19;
            this.lb_LicenseMessage.Text = "Your license will expire in 18 days.";
            this.lb_LicenseMessage.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = global::MiSMDR.Properties.Resources.logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(27, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 101);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lb_LicenseHeader
            // 
            this.lb_LicenseHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_LicenseHeader.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LicenseHeader.Location = new System.Drawing.Point(668, 16);
            this.lb_LicenseHeader.Name = "lb_LicenseHeader";
            this.lb_LicenseHeader.Size = new System.Drawing.Size(156, 20);
            this.lb_LicenseHeader.TabIndex = 18;
            this.lb_LicenseHeader.Text = "License Information";
            this.lb_LicenseHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(668, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(74, 14);
            this.label29.TabIndex = 16;
            this.label29.Text = "Contact Email:";
            // 
            // tb_contactEmail
            // 
            this.tb_contactEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_contactEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_contactEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_contactEmail.Enabled = false;
            this.tb_contactEmail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_contactEmail.Location = new System.Drawing.Point(748, 90);
            this.tb_contactEmail.Name = "tb_contactEmail";
            this.tb_contactEmail.ReadOnly = true;
            this.tb_contactEmail.Size = new System.Drawing.Size(150, 13);
            this.tb_contactEmail.TabIndex = 17;
            // 
            // bn_ChangeLicense
            // 
            this.bn_ChangeLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bn_ChangeLicense.Location = new System.Drawing.Point(878, 133);
            this.bn_ChangeLicense.Name = "bn_ChangeLicense";
            this.bn_ChangeLicense.Size = new System.Drawing.Size(96, 23);
            this.bn_ChangeLicense.TabIndex = 15;
            this.bn_ChangeLicense.Text = "Change License";
            this.bn_ChangeLicense.UseVisualStyleBackColor = true;
            this.bn_ChangeLicense.Click += new System.EventHandler(this.bn_ChangeLicense_Click);
            // 
            // tb_type
            // 
            this.tb_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_type.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_type.Enabled = false;
            this.tb_type.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_type.Location = new System.Drawing.Point(748, 66);
            this.tb_type.Name = "tb_type";
            this.tb_type.ReadOnly = true;
            this.tb_type.Size = new System.Drawing.Size(150, 13);
            this.tb_type.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(668, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 14);
            this.label19.TabIndex = 13;
            this.label19.Text = "License Type:";
            // 
            // tb_reseller
            // 
            this.tb_reseller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_reseller.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_reseller.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_reseller.Enabled = false;
            this.tb_reseller.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_reseller.Location = new System.Drawing.Point(723, 138);
            this.tb_reseller.Name = "tb_reseller";
            this.tb_reseller.ReadOnly = true;
            this.tb_reseller.Size = new System.Drawing.Size(150, 13);
            this.tb_reseller.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(668, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 14);
            this.label20.TabIndex = 5;
            this.label20.Text = "Licensed to:";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(669, 114);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 14);
            this.label24.TabIndex = 6;
            this.label24.Text = "Expiry Date:";
            // 
            // tb_expiry
            // 
            this.tb_expiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_expiry.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_expiry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_expiry.Enabled = false;
            this.tb_expiry.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_expiry.Location = new System.Drawing.Point(740, 114);
            this.tb_expiry.Name = "tb_expiry";
            this.tb_expiry.ReadOnly = true;
            this.tb_expiry.Size = new System.Drawing.Size(150, 13);
            this.tb_expiry.TabIndex = 11;
            // 
            // lb_reseller
            // 
            this.lb_reseller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_reseller.AutoSize = true;
            this.lb_reseller.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_reseller.Location = new System.Drawing.Point(669, 137);
            this.lb_reseller.Name = "lb_reseller";
            this.lb_reseller.Size = new System.Drawing.Size(49, 14);
            this.lb_reseller.TabIndex = 7;
            this.lb_reseller.Text = "Reseller:";
            this.lb_reseller.Visible = false;
            // 
            // tb_name
            // 
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tb_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_name.Enabled = false;
            this.tb_name.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.Location = new System.Drawing.Point(740, 42);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(150, 13);
            this.tb_name.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbWelcomeContent);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.MinimumSize = new System.Drawing.Size(1000, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 363);
            this.panel1.TabIndex = 12;
            // 
            // tbWelcomeContent
            // 
            this.tbWelcomeContent.BackColor = System.Drawing.Color.White;
            this.tbWelcomeContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWelcomeContent.Location = new System.Drawing.Point(4, 22);
            this.tbWelcomeContent.Name = "tbWelcomeContent";
            this.tbWelcomeContent.ReadOnly = true;
            this.tbWelcomeContent.Size = new System.Drawing.Size(526, 287);
            this.tbWelcomeContent.TabIndex = 15;
            this.tbWelcomeContent.TabStop = false;
            this.tbWelcomeContent.Text = "";
            this.tbWelcomeContent.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.tbWelcomeContent_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 14);
            this.label6.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbDBPort);
            this.panel2.Controls.Add(this.tbDBServer);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.rbMMDemo);
            this.panel2.Controls.Add(this.lbStatus);
            this.panel2.Controls.Add(lbSettingsHeader);
            this.panel2.Controls.Add(this.rbMMLive);
            this.panel2.Controls.Add(this.tbPort);
            this.panel2.Controls.Add(this.tbServer);
            this.panel2.Controls.Add(this.lbStatusLabel);
            this.panel2.Controls.Add(this.bnConnect);
            this.panel2.Controls.Add(this.lbPortLabel);
            this.panel2.Controls.Add(this.lbServerLabel);
            this.panel2.Controls.Add(this.bnDisconnect);
            this.panel2.Location = new System.Drawing.Point(672, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 326);
            this.panel2.TabIndex = 1;
            // 
            // rbMMDemo
            // 
            this.rbMMDemo.AutoSize = true;
            this.rbMMDemo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMMDemo.Location = new System.Drawing.Point(45, 56);
            this.rbMMDemo.Name = "rbMMDemo";
            this.rbMMDemo.Size = new System.Drawing.Size(121, 18);
            this.rbMMDemo.TabIndex = 29;
            this.rbMMDemo.TabStop = true;
            this.rbMMDemo.Text = "Use demo database";
            this.rbMMDemo.UseVisualStyleBackColor = true;
            this.rbMMDemo.CheckedChanged += new System.EventHandler(this.rbDemoLive_CheckedChanged);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(100, 113);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(101, 16);
            this.lbStatus.TabIndex = 28;
            this.lbStatus.Text = "Not Connected";
            // 
            // rbMMLive
            // 
            this.rbMMLive.AutoSize = true;
            this.rbMMLive.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMMLive.Location = new System.Drawing.Point(45, 81);
            this.rbMMLive.Name = "rbMMLive";
            this.rbMMLive.Size = new System.Drawing.Size(222, 18);
            this.rbMMLive.TabIndex = 2;
            this.rbMMLive.TabStop = true;
            this.rbMMLive.Text = "Download call records from Mitel System";
            this.rbMMLive.UseVisualStyleBackColor = true;
            this.rbMMLive.CheckedChanged += new System.EventHandler(this.rbDemoLive_CheckedChanged);
            // 
            // tbPort
            // 
            this.tbPort.Enabled = false;
            this.tbPort.Location = new System.Drawing.Point(103, 172);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(67, 20);
            this.tbPort.TabIndex = 4;
            // 
            // tbServer
            // 
            this.tbServer.Enabled = false;
            this.tbServer.Location = new System.Drawing.Point(103, 144);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(164, 20);
            this.tbServer.TabIndex = 3;
            // 
            // lbStatusLabel
            // 
            this.lbStatusLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusLabel.Location = new System.Drawing.Point(45, 115);
            this.lbStatusLabel.Name = "lbStatusLabel";
            this.lbStatusLabel.Size = new System.Drawing.Size(52, 14);
            this.lbStatusLabel.TabIndex = 9;
            this.lbStatusLabel.Text = "Status:";
            this.lbStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnConnect
            // 
            this.bnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.bnConnect.Enabled = false;
            this.bnConnect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnConnect.Location = new System.Drawing.Point(45, 201);
            this.bnConnect.Name = "bnConnect";
            this.bnConnect.Size = new System.Drawing.Size(97, 23);
            this.bnConnect.TabIndex = 5;
            this.bnConnect.Text = "Connect";
            this.bnConnect.UseVisualStyleBackColor = false;
            this.bnConnect.Click += new System.EventHandler(this.bnConnect_Click);
            // 
            // lbPortLabel
            // 
            this.lbPortLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPortLabel.Location = new System.Drawing.Point(42, 175);
            this.lbPortLabel.Name = "lbPortLabel";
            this.lbPortLabel.Size = new System.Drawing.Size(55, 15);
            this.lbPortLabel.TabIndex = 6;
            this.lbPortLabel.Text = "Port:";
            this.lbPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbServerLabel
            // 
            this.lbServerLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerLabel.Location = new System.Drawing.Point(42, 145);
            this.lbServerLabel.Name = "lbServerLabel";
            this.lbServerLabel.Size = new System.Drawing.Size(55, 18);
            this.lbServerLabel.TabIndex = 5;
            this.lbServerLabel.Text = "Server:";
            this.lbServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnDisconnect
            // 
            this.bnDisconnect.BackColor = System.Drawing.SystemColors.Control;
            this.bnDisconnect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnDisconnect.Location = new System.Drawing.Point(170, 201);
            this.bnDisconnect.Name = "bnDisconnect";
            this.bnDisconnect.Size = new System.Drawing.Size(97, 23);
            this.bnDisconnect.TabIndex = 6;
            this.bnDisconnect.Text = "Disconnect";
            this.bnDisconnect.UseVisualStyleBackColor = false;
            this.bnDisconnect.Click += new System.EventHandler(this.bnDisconnect_Click);
            // 
            // searchTab
            // 
            this.searchTab.AutoScroll = true;
            this.searchTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTab.Controls.Add(this.panel6);
            this.searchTab.Controls.Add(this.bnSClearFields);
            this.searchTab.Controls.Add(this.label3);
            this.searchTab.Controls.Add(this.bnSaveCurrentSearch);
            this.searchTab.Controls.Add(this.cbSavedSearchOverwrite);
            this.searchTab.Controls.Add(this.bnSearch2);
            this.searchTab.Controls.Add(this.groupBox9);
            this.searchTab.Controls.Add(this.hiddenSavedSearchName);
            this.searchTab.Controls.Add(this.hiddenSavedSearchID);
            this.searchTab.Controls.Add(this.savedSearchBox);
            this.searchTab.Controls.Add(this.groupBox10);
            this.searchTab.Controls.Add(this.keyInternal);
            this.searchTab.Controls.Add(this.keyIncoming);
            this.searchTab.Controls.Add(this.keyUnknown);
            this.searchTab.Controls.Add(this.keyOutgoing);
            this.searchTab.Location = new System.Drawing.Point(4, 22);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1000, 534);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search Call Records";
            this.searchTab.UseVisualStyleBackColor = true;
            this.searchTab.SizeChanged += new System.EventHandler(this.searchTab_SizeChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Location = new System.Drawing.Point(2, 237);
            this.panel6.MinimumSize = new System.Drawing.Size(992, 293);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(992, 293);
            this.panel6.TabIndex = 114;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Location = new System.Drawing.Point(-7, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 263);
            this.panel3.TabIndex = 113;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(11, 3);
            this.dataGridView.MinimumSize = new System.Drawing.Size(500, 200);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(985, 254);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.Sorted += new System.EventHandler(this.dataGridView_Sorted);
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.lbIncomingCount);
            this.panel5.Controls.Add(this.bnExport);
            this.panel5.Controls.Add(this.lbTotalCost);
            this.panel5.Controls.Add(this.lbDurationTotal);
            this.panel5.Controls.Add(this.lbOutgoingCount);
            this.panel5.Controls.Add(this.lbInternalCount);
            this.panel5.Controls.Add(this.label57);
            this.panel5.Controls.Add(this.label58);
            this.panel5.Controls.Add(this.lbTotalDurationText);
            this.panel5.Controls.Add(this.label59);
            this.panel5.Controls.Add(this.label62);
            this.panel5.Location = new System.Drawing.Point(-5, 264);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(997, 35);
            this.panel5.TabIndex = 112;
            // 
            // lbIncomingCount
            // 
            this.lbIncomingCount.BackColor = System.Drawing.Color.Transparent;
            this.lbIncomingCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIncomingCount.ForeColor = System.Drawing.Color.Black;
            this.lbIncomingCount.Location = new System.Drawing.Point(687, 10);
            this.lbIncomingCount.Name = "lbIncomingCount";
            this.lbIncomingCount.Size = new System.Drawing.Size(55, 15);
            this.lbIncomingCount.TabIndex = 111;
            this.lbIncomingCount.Text = "0";
            this.lbIncomingCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnExport
            // 
            this.bnExport.BackColor = System.Drawing.Color.Transparent;
            this.bnExport.Enabled = false;
            this.bnExport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnExport.Location = new System.Drawing.Point(907, 6);
            this.bnExport.Name = "bnExport";
            this.bnExport.Size = new System.Drawing.Size(90, 23);
            this.bnExport.TabIndex = 6;
            this.bnExport.Text = "Export to File";
            this.bnExport.UseVisualStyleBackColor = false;
            this.bnExport.Click += new System.EventHandler(this.bnExport_Click);
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalCost.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCost.Location = new System.Drawing.Point(821, 10);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(75, 15);
            this.lbTotalCost.TabIndex = 103;
            this.lbTotalCost.Text = "$0.00";
            this.lbTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDurationTotal
            // 
            this.lbDurationTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbDurationTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDurationTotal.ForeColor = System.Drawing.Color.Black;
            this.lbDurationTotal.Location = new System.Drawing.Point(98, 10);
            this.lbDurationTotal.Name = "lbDurationTotal";
            this.lbDurationTotal.Size = new System.Drawing.Size(89, 15);
            this.lbDurationTotal.TabIndex = 109;
            this.lbDurationTotal.Text = "00:00:00";
            this.lbDurationTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOutgoingCount
            // 
            this.lbOutgoingCount.BackColor = System.Drawing.Color.Transparent;
            this.lbOutgoingCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutgoingCount.ForeColor = System.Drawing.Color.Black;
            this.lbOutgoingCount.Location = new System.Drawing.Point(497, 10);
            this.lbOutgoingCount.Name = "lbOutgoingCount";
            this.lbOutgoingCount.Size = new System.Drawing.Size(56, 15);
            this.lbOutgoingCount.TabIndex = 107;
            this.lbOutgoingCount.Text = "0";
            this.lbOutgoingCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbInternalCount
            // 
            this.lbInternalCount.BackColor = System.Drawing.Color.Transparent;
            this.lbInternalCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInternalCount.ForeColor = System.Drawing.Color.Black;
            this.lbInternalCount.Location = new System.Drawing.Point(308, 10);
            this.lbInternalCount.Name = "lbInternalCount";
            this.lbInternalCount.Size = new System.Drawing.Size(56, 15);
            this.lbInternalCount.TabIndex = 105;
            this.lbInternalCount.Text = "0";
            this.lbInternalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(748, 10);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(66, 15);
            this.label57.TabIndex = 102;
            this.label57.Text = "Total Cost:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(559, 10);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(122, 15);
            this.label58.TabIndex = 110;
            this.label58.Text = "Incoming Call Count:";
            // 
            // lbTotalDurationText
            // 
            this.lbTotalDurationText.AutoSize = true;
            this.lbTotalDurationText.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalDurationText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDurationText.Location = new System.Drawing.Point(6, 10);
            this.lbTotalDurationText.Name = "lbTotalDurationText";
            this.lbTotalDurationText.Size = new System.Drawing.Size(88, 15);
            this.lbTotalDurationText.TabIndex = 108;
            this.lbTotalDurationText.Text = "Total Duration:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(189, 10);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(113, 15);
            this.label59.TabIndex = 104;
            this.label59.Text = "Internal Call Count:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(370, 10);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(121, 15);
            this.label62.TabIndex = 106;
            this.label62.Text = "Outgoing Call Count:";
            // 
            // bnSClearFields
            // 
            this.bnSClearFields.BackColor = System.Drawing.SystemColors.Control;
            this.bnSClearFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSClearFields.Location = new System.Drawing.Point(300, 209);
            this.bnSClearFields.Name = "bnSClearFields";
            this.bnSClearFields.Size = new System.Drawing.Size(84, 23);
            this.bnSClearFields.TabIndex = 4;
            this.bnSClearFields.Text = "Clear Fields";
            this.bnSClearFields.UseVisualStyleBackColor = false;
            this.bnSClearFields.Click += new System.EventHandler(this.bnSClearFields_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "* Click column to sort";
            // 
            // bnSaveCurrentSearch
            // 
            this.bnSaveCurrentSearch.BackColor = System.Drawing.SystemColors.Control;
            this.bnSaveCurrentSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSaveCurrentSearch.Location = new System.Drawing.Point(391, 209);
            this.bnSaveCurrentSearch.Name = "bnSaveCurrentSearch";
            this.bnSaveCurrentSearch.Size = new System.Drawing.Size(84, 23);
            this.bnSaveCurrentSearch.TabIndex = 3;
            this.bnSaveCurrentSearch.Text = "Save Search";
            this.bnSaveCurrentSearch.UseVisualStyleBackColor = false;
            this.bnSaveCurrentSearch.Click += new System.EventHandler(this.bnSaveCurrentSearch_Click);
            // 
            // cbSavedSearchOverwrite
            // 
            this.cbSavedSearchOverwrite.AutoSize = true;
            this.cbSavedSearchOverwrite.Location = new System.Drawing.Point(577, 210);
            this.cbSavedSearchOverwrite.Name = "cbSavedSearchOverwrite";
            this.cbSavedSearchOverwrite.Size = new System.Drawing.Size(74, 17);
            this.cbSavedSearchOverwrite.TabIndex = 22;
            this.cbSavedSearchOverwrite.Text = "Overwrite";
            this.cbSavedSearchOverwrite.UseVisualStyleBackColor = true;
            this.cbSavedSearchOverwrite.Visible = false;
            // 
            // bnSearch2
            // 
            this.bnSearch2.BackColor = System.Drawing.SystemColors.Control;
            this.bnSearch2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnSearch2.Location = new System.Drawing.Point(481, 209);
            this.bnSearch2.Name = "bnSearch2";
            this.bnSearch2.Size = new System.Drawing.Size(84, 23);
            this.bnSearch2.TabIndex = 2;
            this.bnSearch2.Text = "Search";
            this.bnSearch2.UseVisualStyleBackColor = false;
            this.bnSearch2.Click += new System.EventHandler(this.bnSearch_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.groupBox14);
            this.groupBox9.Controls.Add(this.groupBox16);
            this.groupBox9.Controls.Add(this.groupBox13);
            this.groupBox9.Font = new System.Drawing.Font("Arial", 8F);
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(559, 199);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Search";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label56);
            this.groupBox14.Controls.Add(this.cbCallCategory);
            this.groupBox14.Controls.Add(this.label55);
            this.groupBox14.Controls.Add(this.label33);
            this.groupBox14.Controls.Add(this.tbTo);
            this.groupBox14.Controls.Add(this.label48);
            this.groupBox14.Controls.Add(this.label52);
            this.groupBox14.Controls.Add(this.tbFrom);
            this.groupBox14.Controls.Add(this.fromExactMatch);
            this.groupBox14.Controls.Add(this.toExactMatch);
            this.groupBox14.Location = new System.Drawing.Point(6, 111);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(548, 81);
            this.groupBox14.TabIndex = 3;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Call Participants";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(23, 36);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(52, 14);
            this.label56.TabIndex = 16;
            this.label56.Text = "Direction:";
            // 
            // cbCallCategory
            // 
            this.cbCallCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCallCategory.FormattingEnabled = true;
            this.cbCallCategory.Items.AddRange(new object[] {
            "All",
            "Incoming",
            "Outgoing",
            "Internal"});
            this.cbCallCategory.Location = new System.Drawing.Point(81, 33);
            this.cbCallCategory.Name = "cbCallCategory";
            this.cbCallCategory.Size = new System.Drawing.Size(106, 22);
            this.cbCallCategory.TabIndex = 1;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(204, 36);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(34, 14);
            this.label55.TabIndex = 23;
            this.label55.Text = "From:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(241, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(74, 14);
            this.label33.TabIndex = 17;
            this.label33.Text = "Name/Number";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(416, 33);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(125, 20);
            this.tbTo.TabIndex = 4;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(413, 16);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(74, 14);
            this.label48.TabIndex = 19;
            this.label48.Text = "Name/Number";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(385, 36);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(16, 14);
            this.label52.TabIndex = 20;
            this.label52.Text = "to";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(244, 33);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(125, 20);
            this.tbFrom.TabIndex = 2;
            // 
            // fromExactMatch
            // 
            this.fromExactMatch.AutoSize = true;
            this.fromExactMatch.Location = new System.Drawing.Point(244, 57);
            this.fromExactMatch.Name = "fromExactMatch";
            this.fromExactMatch.Size = new System.Drawing.Size(85, 18);
            this.fromExactMatch.TabIndex = 3;
            this.fromExactMatch.Text = "Exact Match";
            this.fromExactMatch.UseVisualStyleBackColor = true;
            // 
            // toExactMatch
            // 
            this.toExactMatch.AutoSize = true;
            this.toExactMatch.Location = new System.Drawing.Point(416, 57);
            this.toExactMatch.Name = "toExactMatch";
            this.toExactMatch.Size = new System.Drawing.Size(85, 18);
            this.toExactMatch.TabIndex = 5;
            this.toExactMatch.Text = "Exact Match";
            this.toExactMatch.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.cbUnanswered);
            this.groupBox16.Controls.Add(this.label53);
            this.groupBox16.Controls.Add(this.tbAnswerTime);
            this.groupBox16.Controls.Add(this.cbAnswerTime);
            this.groupBox16.Controls.Add(this.label54);
            this.groupBox16.Controls.Add(this.tbDuration);
            this.groupBox16.Controls.Add(this.cbDuration);
            this.groupBox16.Location = new System.Drawing.Point(289, 14);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(265, 96);
            this.groupBox16.TabIndex = 2;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Call Timing";
            // 
            // cbUnanswered
            // 
            this.cbUnanswered.AutoSize = true;
            this.cbUnanswered.Location = new System.Drawing.Point(84, 71);
            this.cbUnanswered.Name = "cbUnanswered";
            this.cbUnanswered.Size = new System.Drawing.Size(89, 18);
            this.cbUnanswered.TabIndex = 28;
            this.cbUnanswered.Text = "Unanswered";
            this.cbUnanswered.UseVisualStyleBackColor = true;
            this.cbUnanswered.CheckedChanged += new System.EventHandler(this.cbUnanswered_CheckedChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 19);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(75, 14);
            this.label53.TabIndex = 23;
            this.label53.Text = "Answer Time:";
            // 
            // tbAnswerTime
            // 
            this.tbAnswerTime.Location = new System.Drawing.Point(183, 16);
            this.tbAnswerTime.Name = "tbAnswerTime";
            this.tbAnswerTime.Size = new System.Drawing.Size(77, 20);
            this.tbAnswerTime.TabIndex = 2;
            // 
            // cbAnswerTime
            // 
            this.cbAnswerTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnswerTime.FormattingEnabled = true;
            this.cbAnswerTime.Items.AddRange(new object[] {
            "less than",
            "greater than"});
            this.cbAnswerTime.Location = new System.Drawing.Point(84, 16);
            this.cbAnswerTime.Name = "cbAnswerTime";
            this.cbAnswerTime.Size = new System.Drawing.Size(93, 22);
            this.cbAnswerTime.TabIndex = 1;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(31, 46);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(50, 14);
            this.label54.TabIndex = 26;
            this.label54.Text = "Duration:";
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(183, 43);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(77, 20);
            this.tbDuration.TabIndex = 4;
            // 
            // cbDuration
            // 
            this.cbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDuration.FormattingEnabled = true;
            this.cbDuration.Items.AddRange(new object[] {
            "less than",
            "greater than"});
            this.cbDuration.Location = new System.Drawing.Point(84, 43);
            this.cbDuration.Name = "cbDuration";
            this.cbDuration.Size = new System.Drawing.Size(93, 22);
            this.cbDuration.TabIndex = 3;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label4);
            this.groupBox13.Controls.Add(this.DayFilter);
            this.groupBox13.Controls.Add(this.rbAllDates);
            this.groupBox13.Controls.Add(this.label2);
            this.groupBox13.Controls.Add(this.EndDateFilter1);
            this.groupBox13.Controls.Add(this.StartDateFilter1);
            this.groupBox13.Controls.Add(this.rbDateRange);
            this.groupBox13.Controls.Add(this.rbSingleDate);
            this.groupBox13.Location = new System.Drawing.Point(6, 14);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(277, 96);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Call Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "days";
            // 
            // DayFilter
            // 
            this.DayFilter.Location = new System.Drawing.Point(66, 43);
            this.DayFilter.Name = "DayFilter";
            this.DayFilter.Size = new System.Drawing.Size(21, 20);
            this.DayFilter.TabIndex = 14;
            this.DayFilter.Text = "7";
            this.DayFilter.Leave += new System.EventHandler(this.DayFilter_Leave);
            // 
            // rbAllDates
            // 
            this.rbAllDates.AutoSize = true;
            this.rbAllDates.Location = new System.Drawing.Point(6, 17);
            this.rbAllDates.Name = "rbAllDates";
            this.rbAllDates.Size = new System.Drawing.Size(37, 18);
            this.rbAllDates.TabIndex = 1;
            this.rbAllDates.Text = "All";
            this.rbAllDates.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "to";
            // 
            // EndDateFilter1
            // 
            this.EndDateFilter1.Enabled = false;
            this.EndDateFilter1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDateFilter1.Location = new System.Drawing.Point(179, 69);
            this.EndDateFilter1.Name = "EndDateFilter1";
            this.EndDateFilter1.Size = new System.Drawing.Size(91, 20);
            this.EndDateFilter1.TabIndex = 6;
            // 
            // StartDateFilter1
            // 
            this.StartDateFilter1.Enabled = false;
            this.StartDateFilter1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateFilter1.Location = new System.Drawing.Point(66, 69);
            this.StartDateFilter1.Name = "StartDateFilter1";
            this.StartDateFilter1.Size = new System.Drawing.Size(91, 20);
            this.StartDateFilter1.TabIndex = 5;
            // 
            // rbDateRange
            // 
            this.rbDateRange.AutoSize = true;
            this.rbDateRange.Location = new System.Drawing.Point(6, 71);
            this.rbDateRange.Name = "rbDateRange";
            this.rbDateRange.Size = new System.Drawing.Size(56, 18);
            this.rbDateRange.TabIndex = 4;
            this.rbDateRange.Text = "Range";
            this.rbDateRange.UseVisualStyleBackColor = true;
            this.rbDateRange.CheckedChanged += new System.EventHandler(this.rbDateRange_CheckedChanged);
            // 
            // rbSingleDate
            // 
            this.rbSingleDate.AutoSize = true;
            this.rbSingleDate.Checked = true;
            this.rbSingleDate.Location = new System.Drawing.Point(6, 44);
            this.rbSingleDate.Name = "rbSingleDate";
            this.rbSingleDate.Size = new System.Drawing.Size(46, 18);
            this.rbSingleDate.TabIndex = 2;
            this.rbSingleDate.TabStop = true;
            this.rbSingleDate.Text = "Last";
            this.rbSingleDate.UseVisualStyleBackColor = true;
            this.rbSingleDate.CheckedChanged += new System.EventHandler(this.rbSingleDate_CheckedChanged);
            // 
            // hiddenSavedSearchName
            // 
            this.hiddenSavedSearchName.Location = new System.Drawing.Point(606, 210);
            this.hiddenSavedSearchName.Name = "hiddenSavedSearchName";
            this.hiddenSavedSearchName.Size = new System.Drawing.Size(10, 21);
            this.hiddenSavedSearchName.TabIndex = 100;
            this.hiddenSavedSearchName.Visible = false;
            // 
            // hiddenSavedSearchID
            // 
            this.hiddenSavedSearchID.Location = new System.Drawing.Point(590, 210);
            this.hiddenSavedSearchID.Name = "hiddenSavedSearchID";
            this.hiddenSavedSearchID.Size = new System.Drawing.Size(10, 21);
            this.hiddenSavedSearchID.TabIndex = 7;
            this.hiddenSavedSearchID.Visible = false;
            // 
            // savedSearchBox
            // 
            this.savedSearchBox.BackColor = System.Drawing.Color.Transparent;
            this.savedSearchBox.Controls.Add(this.bnLoadSavedSearch);
            this.savedSearchBox.Controls.Add(this.bnDeleteSavedSearch);
            this.savedSearchBox.Controls.Add(this.lbSavedSearches);
            this.savedSearchBox.Font = new System.Drawing.Font("Arial", 8F);
            this.savedSearchBox.Location = new System.Drawing.Point(571, 6);
            this.savedSearchBox.Name = "savedSearchBox";
            this.savedSearchBox.Size = new System.Drawing.Size(186, 199);
            this.savedSearchBox.TabIndex = 5;
            this.savedSearchBox.TabStop = false;
            this.savedSearchBox.Text = "Saved Searches";
            // 
            // bnLoadSavedSearch
            // 
            this.bnLoadSavedSearch.BackColor = System.Drawing.SystemColors.Control;
            this.bnLoadSavedSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnLoadSavedSearch.Location = new System.Drawing.Point(96, 169);
            this.bnLoadSavedSearch.Name = "bnLoadSavedSearch";
            this.bnLoadSavedSearch.Size = new System.Drawing.Size(84, 23);
            this.bnLoadSavedSearch.TabIndex = 2;
            this.bnLoadSavedSearch.Text = "Load";
            this.bnLoadSavedSearch.UseVisualStyleBackColor = false;
            this.bnLoadSavedSearch.Click += new System.EventHandler(this.bnLoadSavedSearch_Click);
            // 
            // bnDeleteSavedSearch
            // 
            this.bnDeleteSavedSearch.BackColor = System.Drawing.SystemColors.Control;
            this.bnDeleteSavedSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnDeleteSavedSearch.Location = new System.Drawing.Point(6, 169);
            this.bnDeleteSavedSearch.Name = "bnDeleteSavedSearch";
            this.bnDeleteSavedSearch.Size = new System.Drawing.Size(84, 23);
            this.bnDeleteSavedSearch.TabIndex = 1;
            this.bnDeleteSavedSearch.Text = "Delete";
            this.bnDeleteSavedSearch.UseVisualStyleBackColor = false;
            this.bnDeleteSavedSearch.Click += new System.EventHandler(this.bnDeleteSavedSearch_Click);
            // 
            // lbSavedSearches
            // 
            this.lbSavedSearches.DisplayMember = "ID";
            this.lbSavedSearches.FormattingEnabled = true;
            this.lbSavedSearches.ItemHeight = 14;
            this.lbSavedSearches.Location = new System.Drawing.Point(6, 20);
            this.lbSavedSearches.Name = "lbSavedSearches";
            this.lbSavedSearches.Size = new System.Drawing.Size(174, 144);
            this.lbSavedSearches.TabIndex = 18;
            this.lbSavedSearches.ValueMember = "ID";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.callInfo);
            this.groupBox10.Font = new System.Drawing.Font("Arial", 8F);
            this.groupBox10.Location = new System.Drawing.Point(763, 6);
            this.groupBox10.MinimumSize = new System.Drawing.Size(231, 199);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(231, 199);
            this.groupBox10.TabIndex = 99;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Call Details:";
            // 
            // callInfo
            // 
            this.callInfo.BackColor = System.Drawing.Color.Transparent;
            this.callInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callInfo.Location = new System.Drawing.Point(6, 13);
            this.callInfo.Name = "callInfo";
            this.callInfo.Size = new System.Drawing.Size(219, 179);
            this.callInfo.TabIndex = 82;
            // 
            // keyInternal
            // 
            this.keyInternal.BackColor = System.Drawing.Color.Transparent;
            this.keyInternal.Location = new System.Drawing.Point(648, 210);
            this.keyInternal.Name = "keyInternal";
            this.keyInternal.Size = new System.Drawing.Size(109, 20);
            this.keyInternal.TabIndex = 79;
            // 
            // keyIncoming
            // 
            this.keyIncoming.BackColor = System.Drawing.Color.Transparent;
            this.keyIncoming.Location = new System.Drawing.Point(885, 210);
            this.keyIncoming.Name = "keyIncoming";
            this.keyIncoming.Size = new System.Drawing.Size(109, 20);
            this.keyIncoming.TabIndex = 81;
            // 
            // keyUnknown
            // 
            this.keyUnknown.BackColor = System.Drawing.Color.Transparent;
            this.keyUnknown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyUnknown.Location = new System.Drawing.Point(256, 212);
            this.keyUnknown.Name = "keyUnknown";
            this.keyUnknown.Size = new System.Drawing.Size(15, 20);
            this.keyUnknown.TabIndex = 78;
            this.keyUnknown.Visible = false;
            // 
            // keyOutgoing
            // 
            this.keyOutgoing.BackColor = System.Drawing.Color.Transparent;
            this.keyOutgoing.Location = new System.Drawing.Point(763, 210);
            this.keyOutgoing.Name = "keyOutgoing";
            this.keyOutgoing.Size = new System.Drawing.Size(109, 20);
            this.keyOutgoing.TabIndex = 80;
            // 
            // summaryPage
            // 
            this.summaryPage.Controls.Add(this.label31);
            this.summaryPage.Controls.Add(this.label26);
            this.summaryPage.Controls.Add(this.tb_LongCallDefinition);
            this.summaryPage.Controls.Add(this.groupBox12);
            this.summaryPage.Controls.Add(this.label10);
            this.summaryPage.Controls.Add(this.label9);
            this.summaryPage.Controls.Add(this.label8);
            this.summaryPage.Controls.Add(this.dgvLatest1);
            this.summaryPage.Controls.Add(this.dgvLatest4);
            this.summaryPage.Controls.Add(this.dgvLatest2);
            this.summaryPage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryPage.Location = new System.Drawing.Point(4, 22);
            this.summaryPage.Name = "summaryPage";
            this.summaryPage.Padding = new System.Windows.Forms.Padding(3);
            this.summaryPage.Size = new System.Drawing.Size(1000, 534);
            this.summaryPage.TabIndex = 9;
            this.summaryPage.Text = "Call Summaries";
            this.summaryPage.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(909, 371);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 14);
            this.label31.TabIndex = 33;
            this.label31.Text = "seconds";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(749, 371);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(118, 14);
            this.label26.TabIndex = 32;
            this.label26.Text = "Show calls longer than";
            // 
            // tb_LongCallDefinition
            // 
            this.tb_LongCallDefinition.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LongCallDefinition.Location = new System.Drawing.Point(873, 368);
            this.tb_LongCallDefinition.Name = "tb_LongCallDefinition";
            this.tb_LongCallDefinition.Size = new System.Drawing.Size(33, 20);
            this.tb_LongCallDefinition.TabIndex = 31;
            this.tb_LongCallDefinition.Text = "300";
            this.tb_LongCallDefinition.Leave += new System.EventHandler(this.tb_LongCallDefinition_Leave);
            this.tb_LongCallDefinition.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_LongCallDefinition_KeyUp);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.summaries_PeriodGroup);
            this.groupBox12.Controls.Add(this.ps_callcount_int);
            this.groupBox12.Controls.Add(this.ps_totalcallcost);
            this.groupBox12.Controls.Add(this.ps_talktime_tot);
            this.groupBox12.Controls.Add(this.ps_talktime_int);
            this.groupBox12.Controls.Add(this.ps_talktime_inc);
            this.groupBox12.Controls.Add(this.ps_talktime_out);
            this.groupBox12.Controls.Add(this.ps_callcount_una);
            this.groupBox12.Controls.Add(this.ps_callcount_inc);
            this.groupBox12.Controls.Add(this.ps_callcount_out);
            this.groupBox12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(45, 33);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(387, 332);
            this.groupBox12.TabIndex = 30;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Call Summary";
            // 
            // summaries_PeriodGroup
            // 
            this.summaries_PeriodGroup.Controls.Add(this.summaries_UpdateLabel);
            this.summaries_PeriodGroup.Controls.Add(this.ps_rb_periodDay);
            this.summaries_PeriodGroup.Controls.Add(this.label7);
            this.summaries_PeriodGroup.Controls.Add(this.ps_rb_periodHour);
            this.summaries_PeriodGroup.Controls.Add(this.ps_rb_periodMonth);
            this.summaries_PeriodGroup.Controls.Add(this.ps_rb_periodWeek);
            this.summaries_PeriodGroup.Location = new System.Drawing.Point(6, 19);
            this.summaries_PeriodGroup.Name = "summaries_PeriodGroup";
            this.summaries_PeriodGroup.Size = new System.Drawing.Size(375, 53);
            this.summaries_PeriodGroup.TabIndex = 30;
            // 
            // summaries_UpdateLabel
            // 
            this.summaries_UpdateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.summaries_UpdateLabel.Location = new System.Drawing.Point(35, 29);
            this.summaries_UpdateLabel.Name = "summaries_UpdateLabel";
            this.summaries_UpdateLabel.Size = new System.Drawing.Size(169, 23);
            this.summaries_UpdateLabel.TabIndex = 31;
            this.summaries_UpdateLabel.Text = "Data is being calculated...";
            this.summaries_UpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.summaries_UpdateLabel.Visible = false;
            // 
            // ps_rb_periodDay
            // 
            this.ps_rb_periodDay.AutoSize = true;
            this.ps_rb_periodDay.Checked = true;
            this.ps_rb_periodDay.Location = new System.Drawing.Point(110, 7);
            this.ps_rb_periodDay.Name = "ps_rb_periodDay";
            this.ps_rb_periodDay.Size = new System.Drawing.Size(43, 18);
            this.ps_rb_periodDay.TabIndex = 1;
            this.ps_rb_periodDay.TabStop = true;
            this.ps_rb_periodDay.Text = "day";
            this.ps_rb_periodDay.UseVisualStyleBackColor = true;
            this.ps_rb_periodDay.CheckedChanged += new System.EventHandler(this.ps_rb_period_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Show:";
            // 
            // ps_rb_periodHour
            // 
            this.ps_rb_periodHour.AutoSize = true;
            this.ps_rb_periodHour.Location = new System.Drawing.Point(57, 7);
            this.ps_rb_periodHour.Name = "ps_rb_periodHour";
            this.ps_rb_periodHour.Size = new System.Drawing.Size(47, 18);
            this.ps_rb_periodHour.TabIndex = 0;
            this.ps_rb_periodHour.Text = "hour";
            this.ps_rb_periodHour.UseVisualStyleBackColor = true;
            this.ps_rb_periodHour.CheckedChanged += new System.EventHandler(this.ps_rb_period_CheckedChanged);
            // 
            // ps_rb_periodMonth
            // 
            this.ps_rb_periodMonth.AutoSize = true;
            this.ps_rb_periodMonth.Location = new System.Drawing.Point(217, 7);
            this.ps_rb_periodMonth.Name = "ps_rb_periodMonth";
            this.ps_rb_periodMonth.Size = new System.Drawing.Size(54, 18);
            this.ps_rb_periodMonth.TabIndex = 3;
            this.ps_rb_periodMonth.Text = "month";
            this.ps_rb_periodMonth.UseVisualStyleBackColor = true;
            this.ps_rb_periodMonth.CheckedChanged += new System.EventHandler(this.ps_rb_period_CheckedChanged);
            // 
            // ps_rb_periodWeek
            // 
            this.ps_rb_periodWeek.AutoSize = true;
            this.ps_rb_periodWeek.Location = new System.Drawing.Point(159, 7);
            this.ps_rb_periodWeek.Name = "ps_rb_periodWeek";
            this.ps_rb_periodWeek.Size = new System.Drawing.Size(52, 18);
            this.ps_rb_periodWeek.TabIndex = 2;
            this.ps_rb_periodWeek.Text = "week";
            this.ps_rb_periodWeek.UseVisualStyleBackColor = true;
            this.ps_rb_periodWeek.CheckedChanged += new System.EventHandler(this.ps_rb_period_CheckedChanged);
            // 
            // ps_callcount_int
            // 
            this.ps_callcount_int.AutoSize = true;
            this.ps_callcount_int.Location = new System.Drawing.Point(18, 133);
            this.ps_callcount_int.Name = "ps_callcount_int";
            this.ps_callcount_int.Size = new System.Drawing.Size(151, 14);
            this.ps_callcount_int.TabIndex = 8;
            this.ps_callcount_int.Text = "0 Internal Calls in the past day";
            // 
            // ps_totalcallcost
            // 
            this.ps_totalcallcost.AutoSize = true;
            this.ps_totalcallcost.Location = new System.Drawing.Point(18, 294);
            this.ps_totalcallcost.Name = "ps_totalcallcost";
            this.ps_totalcallcost.Size = new System.Drawing.Size(100, 14);
            this.ps_totalcallcost.TabIndex = 7;
            this.ps_totalcallcost.Text = "$0.00 call cost total";
            // 
            // ps_talktime_tot
            // 
            this.ps_talktime_tot.AutoSize = true;
            this.ps_talktime_tot.Location = new System.Drawing.Point(18, 273);
            this.ps_talktime_tot.Name = "ps_talktime_tot";
            this.ps_talktime_tot.Size = new System.Drawing.Size(113, 14);
            this.ps_talktime_tot.TabIndex = 6;
            this.ps_talktime_tot.Text = "00:00:00 talk time total";
            // 
            // ps_talktime_int
            // 
            this.ps_talktime_int.AutoSize = true;
            this.ps_talktime_int.Location = new System.Drawing.Point(18, 233);
            this.ps_talktime_int.Name = "ps_talktime_int";
            this.ps_talktime_int.Size = new System.Drawing.Size(161, 14);
            this.ps_talktime_int.TabIndex = 5;
            this.ps_talktime_int.Text = "00:00:00 talk time (internal calls)";
            // 
            // ps_talktime_inc
            // 
            this.ps_talktime_inc.AutoSize = true;
            this.ps_talktime_inc.Location = new System.Drawing.Point(18, 211);
            this.ps_talktime_inc.Name = "ps_talktime_inc";
            this.ps_talktime_inc.Size = new System.Drawing.Size(168, 14);
            this.ps_talktime_inc.TabIndex = 4;
            this.ps_talktime_inc.Text = "00:00:00 talk time (incoming calls)";
            // 
            // ps_talktime_out
            // 
            this.ps_talktime_out.AutoSize = true;
            this.ps_talktime_out.Location = new System.Drawing.Point(18, 189);
            this.ps_talktime_out.Name = "ps_talktime_out";
            this.ps_talktime_out.Size = new System.Drawing.Size(167, 14);
            this.ps_talktime_out.TabIndex = 3;
            this.ps_talktime_out.Text = "00:00:00 talk time (outgoing calls)";
            // 
            // ps_callcount_una
            // 
            this.ps_callcount_una.AutoSize = true;
            this.ps_callcount_una.Location = new System.Drawing.Point(18, 152);
            this.ps_callcount_una.Name = "ps_callcount_una";
            this.ps_callcount_una.Size = new System.Drawing.Size(179, 14);
            this.ps_callcount_una.TabIndex = 2;
            this.ps_callcount_una.Text = "0 Unanswered Calls in the past day";
            // 
            // ps_callcount_inc
            // 
            this.ps_callcount_inc.AutoSize = true;
            this.ps_callcount_inc.Location = new System.Drawing.Point(18, 113);
            this.ps_callcount_inc.Name = "ps_callcount_inc";
            this.ps_callcount_inc.Size = new System.Drawing.Size(158, 14);
            this.ps_callcount_inc.TabIndex = 1;
            this.ps_callcount_inc.Text = "0 Incoming Calls in the past day";
            // 
            // ps_callcount_out
            // 
            this.ps_callcount_out.AutoSize = true;
            this.ps_callcount_out.Location = new System.Drawing.Point(18, 94);
            this.ps_callcount_out.Name = "ps_callcount_out";
            this.ps_callcount_out.Size = new System.Drawing.Size(159, 14);
            this.ps_callcount_out.TabIndex = 0;
            this.ps_callcount_out.Text = "0 Outgoing Calls in the past day";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(534, 371);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "Last 5 Long Outgoing Calls";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(534, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "Last 5 Outgoing Calls";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(534, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 14);
            this.label8.TabIndex = 26;
            this.label8.Text = "Last 5 Unanswered Calls";
            // 
            // dgvLatest1
            // 
            this.dgvLatest1.AllowUserToAddRows = false;
            this.dgvLatest1.AllowUserToDeleteRows = false;
            this.dgvLatest1.AllowUserToResizeRows = false;
            this.dgvLatest1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLatest1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLatest1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLatest1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLatest1.ColumnHeadersHeight = 22;
            this.dgvLatest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLatest1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLatest1.Location = new System.Drawing.Point(537, 49);
            this.dgvLatest1.MultiSelect = false;
            this.dgvLatest1.Name = "dgvLatest1";
            this.dgvLatest1.RowHeadersVisible = false;
            this.dgvLatest1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLatest1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLatest1.Size = new System.Drawing.Size(421, 134);
            this.dgvLatest1.TabIndex = 23;
            this.dgvLatest1.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvLatest1_Paint);
            // 
            // dgvLatest4
            // 
            this.dgvLatest4.AllowUserToAddRows = false;
            this.dgvLatest4.AllowUserToDeleteRows = false;
            this.dgvLatest4.AllowUserToResizeRows = false;
            this.dgvLatest4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLatest4.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLatest4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLatest4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLatest4.ColumnHeadersHeight = 22;
            this.dgvLatest4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLatest4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLatest4.Location = new System.Drawing.Point(537, 388);
            this.dgvLatest4.MultiSelect = false;
            this.dgvLatest4.Name = "dgvLatest4";
            this.dgvLatest4.RowHeadersVisible = false;
            this.dgvLatest4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLatest4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLatest4.Size = new System.Drawing.Size(421, 133);
            this.dgvLatest4.TabIndex = 25;
            this.dgvLatest4.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvLatest4_Paint);
            // 
            // dgvLatest2
            // 
            this.dgvLatest2.AllowUserToAddRows = false;
            this.dgvLatest2.AllowUserToDeleteRows = false;
            this.dgvLatest2.AllowUserToResizeRows = false;
            this.dgvLatest2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLatest2.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLatest2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLatest2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLatest2.ColumnHeadersHeight = 22;
            this.dgvLatest2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLatest2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLatest2.Location = new System.Drawing.Point(537, 219);
            this.dgvLatest2.MultiSelect = false;
            this.dgvLatest2.Name = "dgvLatest2";
            this.dgvLatest2.RowHeadersVisible = false;
            this.dgvLatest2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLatest2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLatest2.Size = new System.Drawing.Size(421, 133);
            this.dgvLatest2.TabIndex = 24;
            this.dgvLatest2.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvLatest2_Paint);
            // 
            // reportTab
            // 
            this.reportTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reportTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportTab.Controls.Add(this.statisticsBox);
            this.reportTab.Location = new System.Drawing.Point(4, 22);
            this.reportTab.Name = "reportTab";
            this.reportTab.Padding = new System.Windows.Forms.Padding(3);
            this.reportTab.Size = new System.Drawing.Size(1000, 534);
            this.reportTab.TabIndex = 4;
            this.reportTab.Text = "Call Report";
            this.reportTab.UseVisualStyleBackColor = true;
            // 
            // statisticsBox
            // 
            this.statisticsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statisticsBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statisticsBox.Controls.Add(this.callSummaryReport);
            this.statisticsBox.Controls.Add(this.bnCallSummarySearch);
            this.statisticsBox.Controls.Add(this.groupBox17);
            this.statisticsBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsBox.Location = new System.Drawing.Point(2, 2);
            this.statisticsBox.MinimumSize = new System.Drawing.Size(989, 531);
            this.statisticsBox.Name = "statisticsBox";
            this.statisticsBox.Size = new System.Drawing.Size(989, 531);
            this.statisticsBox.TabIndex = 8;
            this.statisticsBox.TabStop = false;
            this.statisticsBox.Text = "Simple Call Summary";
            // 
            // callSummaryReport
            // 
            this.callSummaryReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.callSummaryReport.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.callSummaryReport.LocalReport.DisplayName = "Call Summary";
            this.callSummaryReport.Location = new System.Drawing.Point(6, 111);
            this.callSummaryReport.MinimumSize = new System.Drawing.Size(977, 414);
            this.callSummaryReport.Name = "callSummaryReport";
            this.callSummaryReport.ShowDocumentMapButton = false;
            this.callSummaryReport.Size = new System.Drawing.Size(977, 414);
            this.callSummaryReport.TabIndex = 3;
            // 
            // bnCallSummarySearch
            // 
            this.bnCallSummarySearch.BackColor = System.Drawing.SystemColors.Control;
            this.bnCallSummarySearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCallSummarySearch.Location = new System.Drawing.Point(289, 82);
            this.bnCallSummarySearch.Name = "bnCallSummarySearch";
            this.bnCallSummarySearch.Size = new System.Drawing.Size(75, 23);
            this.bnCallSummarySearch.TabIndex = 2;
            this.bnCallSummarySearch.Text = "Search";
            this.bnCallSummarySearch.UseVisualStyleBackColor = false;
            this.bnCallSummarySearch.Click += new System.EventHandler(this.bnCallSummarySearch_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label5);
            this.groupBox17.Controls.Add(this.csDay);
            this.groupBox17.Controls.Add(this.csAllDates);
            this.groupBox17.Controls.Add(this.label60);
            this.groupBox17.Controls.Add(this.csEndDate);
            this.groupBox17.Controls.Add(this.csStartDate);
            this.groupBox17.Controls.Add(this.csDateRange);
            this.groupBox17.Controls.Add(this.csSingleDate);
            this.groupBox17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.Location = new System.Drawing.Point(6, 14);
            this.groupBox17.MinimumSize = new System.Drawing.Size(277, 91);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(277, 91);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Call Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "days";
            // 
            // csDay
            // 
            this.csDay.Location = new System.Drawing.Point(66, 41);
            this.csDay.Name = "csDay";
            this.csDay.Size = new System.Drawing.Size(21, 20);
            this.csDay.TabIndex = 16;
            this.csDay.Text = "7";
            this.csDay.Leave += new System.EventHandler(this.csDay_Leave);
            // 
            // csAllDates
            // 
            this.csAllDates.AutoSize = true;
            this.csAllDates.Location = new System.Drawing.Point(6, 19);
            this.csAllDates.Name = "csAllDates";
            this.csAllDates.Size = new System.Drawing.Size(37, 18);
            this.csAllDates.TabIndex = 1;
            this.csAllDates.Text = "All";
            this.csAllDates.UseVisualStyleBackColor = true;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(160, 67);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(16, 14);
            this.label60.TabIndex = 13;
            this.label60.Text = "to";
            // 
            // csEndDate
            // 
            this.csEndDate.Enabled = false;
            this.csEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.csEndDate.Location = new System.Drawing.Point(179, 63);
            this.csEndDate.Name = "csEndDate";
            this.csEndDate.Size = new System.Drawing.Size(91, 20);
            this.csEndDate.TabIndex = 6;
            // 
            // csStartDate
            // 
            this.csStartDate.Enabled = false;
            this.csStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.csStartDate.Location = new System.Drawing.Point(66, 63);
            this.csStartDate.Name = "csStartDate";
            this.csStartDate.Size = new System.Drawing.Size(91, 20);
            this.csStartDate.TabIndex = 5;
            // 
            // csDateRange
            // 
            this.csDateRange.AutoSize = true;
            this.csDateRange.Location = new System.Drawing.Point(6, 65);
            this.csDateRange.Name = "csDateRange";
            this.csDateRange.Size = new System.Drawing.Size(56, 18);
            this.csDateRange.TabIndex = 4;
            this.csDateRange.Text = "Range";
            this.csDateRange.UseVisualStyleBackColor = true;
            this.csDateRange.CheckedChanged += new System.EventHandler(this.csDateRange_CheckedChanged);
            // 
            // csSingleDate
            // 
            this.csSingleDate.AutoSize = true;
            this.csSingleDate.Checked = true;
            this.csSingleDate.Location = new System.Drawing.Point(6, 42);
            this.csSingleDate.Name = "csSingleDate";
            this.csSingleDate.Size = new System.Drawing.Size(46, 18);
            this.csSingleDate.TabIndex = 2;
            this.csSingleDate.TabStop = true;
            this.csSingleDate.Text = "Last";
            this.csSingleDate.UseVisualStyleBackColor = true;
            this.csSingleDate.CheckedChanged += new System.EventHandler(this.csSingleDay_CheckedChanged);
            // 
            // addressTab
            // 
            this.addressTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addressTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressTab.Controls.Add(this.tbAddressBookHelp);
            this.addressTab.Controls.Add(this.groupBox6);
            this.addressTab.Controls.Add(this.addressDataGrid);
            this.addressTab.Controls.Add(this.tbNumberID);
            this.addressTab.Controls.Add(this.groupBox18);
            this.addressTab.Controls.Add(this.cbContactType);
            this.addressTab.Controls.Add(this.tbOldName);
            this.addressTab.Controls.Add(this.tbSelectedContactID);
            this.addressTab.Controls.Add(this.tbOldType);
            this.addressTab.Controls.Add(this.tbOldNumber);
            this.addressTab.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTab.Location = new System.Drawing.Point(4, 22);
            this.addressTab.Name = "addressTab";
            this.addressTab.Size = new System.Drawing.Size(1000, 534);
            this.addressTab.TabIndex = 8;
            this.addressTab.Text = "Address Book";
            this.addressTab.UseVisualStyleBackColor = true;
            // 
            // tbAddressBookHelp
            // 
            this.tbAddressBookHelp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbAddressBookHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAddressBookHelp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddressBookHelp.Location = new System.Drawing.Point(368, 5);
            this.tbAddressBookHelp.MinimumSize = new System.Drawing.Size(320, 480);
            this.tbAddressBookHelp.Name = "tbAddressBookHelp";
            this.tbAddressBookHelp.ReadOnly = true;
            this.tbAddressBookHelp.Size = new System.Drawing.Size(320, 524);
            this.tbAddressBookHelp.TabIndex = 0;
            this.tbAddressBookHelp.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Location = new System.Drawing.Point(368, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(0, 0);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            // 
            // addressDataGrid
            // 
            this.addressDataGrid.AllowUserToAddRows = false;
            this.addressDataGrid.AllowUserToDeleteRows = false;
            this.addressDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.addressDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.addressDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.addressDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addressDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.addressDataGrid.Location = new System.Drawing.Point(6, 142);
            this.addressDataGrid.MinimumSize = new System.Drawing.Size(356, 394);
            this.addressDataGrid.MultiSelect = false;
            this.addressDataGrid.Name = "addressDataGrid";
            this.addressDataGrid.ReadOnly = true;
            this.addressDataGrid.RowHeadersVisible = false;
            this.addressDataGrid.Size = new System.Drawing.Size(356, 394);
            this.addressDataGrid.TabIndex = 2;
            this.addressDataGrid.SelectionChanged += new System.EventHandler(this.addressDataGrid_SelectionChanged);
            // 
            // tbNumberID
            // 
            this.tbNumberID.Enabled = false;
            this.tbNumberID.Location = new System.Drawing.Point(775, 30);
            this.tbNumberID.Name = "tbNumberID";
            this.tbNumberID.Size = new System.Drawing.Size(18, 20);
            this.tbNumberID.TabIndex = 14;
            this.tbNumberID.Visible = false;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.groupBox5);
            this.groupBox18.Controls.Add(this.bnCreateContact);
            this.groupBox18.Font = new System.Drawing.Font("Arial", 8F);
            this.groupBox18.Location = new System.Drawing.Point(6, 6);
            this.groupBox18.MinimumSize = new System.Drawing.Size(356, 130);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(356, 130);
            this.groupBox18.TabIndex = 1;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Address Book";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bnContactDelete);
            this.groupBox5.Controls.Add(this.tbContactNumber);
            this.groupBox5.Controls.Add(this.bnUpdateCont);
            this.groupBox5.Controls.Add(this.label64);
            this.groupBox5.Controls.Add(this.label63);
            this.groupBox5.Controls.Add(this.tbContactName);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.MinimumSize = new System.Drawing.Size(257, 105);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(257, 105);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Edit Contact";
            // 
            // bnContactDelete
            // 
            this.bnContactDelete.BackColor = System.Drawing.SystemColors.Control;
            this.bnContactDelete.Font = new System.Drawing.Font("Arial", 8.25F);
            this.bnContactDelete.Location = new System.Drawing.Point(80, 77);
            this.bnContactDelete.Name = "bnContactDelete";
            this.bnContactDelete.Size = new System.Drawing.Size(75, 23);
            this.bnContactDelete.TabIndex = 3;
            this.bnContactDelete.Text = "Delete Selected";
            this.bnContactDelete.UseVisualStyleBackColor = false;
            this.bnContactDelete.Click += new System.EventHandler(this.bnABDelete_Click);
            // 
            // tbContactNumber
            // 
            this.tbContactNumber.Location = new System.Drawing.Point(80, 51);
            this.tbContactNumber.Name = "tbContactNumber";
            this.tbContactNumber.Size = new System.Drawing.Size(159, 20);
            this.tbContactNumber.TabIndex = 2;
            this.tbContactNumber.TextChanged += new System.EventHandler(this.tbContactNumber_TextChanged);
            // 
            // bnUpdateCont
            // 
            this.bnUpdateCont.BackColor = System.Drawing.SystemColors.Control;
            this.bnUpdateCont.Enabled = false;
            this.bnUpdateCont.Font = new System.Drawing.Font("Arial", 8.25F);
            this.bnUpdateCont.Location = new System.Drawing.Point(164, 77);
            this.bnUpdateCont.Name = "bnUpdateCont";
            this.bnUpdateCont.Size = new System.Drawing.Size(75, 23);
            this.bnUpdateCont.TabIndex = 4;
            this.bnUpdateCont.Text = "Save";
            this.bnUpdateCont.UseVisualStyleBackColor = false;
            this.bnUpdateCont.Click += new System.EventHandler(this.bnABUpdate_Click);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(19, 54);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(47, 14);
            this.label64.TabIndex = 3;
            this.label64.Text = "Number:";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(19, 27);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(37, 14);
            this.label63.TabIndex = 2;
            this.label63.Text = "Name:";
            // 
            // tbContactName
            // 
            this.tbContactName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbContactName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbContactName.Location = new System.Drawing.Point(80, 24);
            this.tbContactName.Name = "tbContactName";
            this.tbContactName.Size = new System.Drawing.Size(159, 20);
            this.tbContactName.TabIndex = 1;
            // 
            // bnCreateContact
            // 
            this.bnCreateContact.BackColor = System.Drawing.SystemColors.Control;
            this.bnCreateContact.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCreateContact.Location = new System.Drawing.Point(271, 24);
            this.bnCreateContact.Name = "bnCreateContact";
            this.bnCreateContact.Size = new System.Drawing.Size(79, 23);
            this.bnCreateContact.TabIndex = 2;
            this.bnCreateContact.Text = "Create New";
            this.bnCreateContact.UseVisualStyleBackColor = false;
            this.bnCreateContact.Click += new System.EventHandler(this.bnABCreate_Click);
            // 
            // cbContactType
            // 
            this.cbContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContactType.FormattingEnabled = true;
            this.cbContactType.Items.AddRange(new object[] {
            "Internal",
            "External"});
            this.cbContactType.Location = new System.Drawing.Point(759, 96);
            this.cbContactType.Name = "cbContactType";
            this.cbContactType.Size = new System.Drawing.Size(101, 22);
            this.cbContactType.TabIndex = 8;
            this.cbContactType.Visible = false;
            // 
            // tbOldName
            // 
            this.tbOldName.Enabled = false;
            this.tbOldName.Location = new System.Drawing.Point(799, 57);
            this.tbOldName.Name = "tbOldName";
            this.tbOldName.Size = new System.Drawing.Size(18, 20);
            this.tbOldName.TabIndex = 13;
            this.tbOldName.Visible = false;
            // 
            // tbSelectedContactID
            // 
            this.tbSelectedContactID.Enabled = false;
            this.tbSelectedContactID.Location = new System.Drawing.Point(799, 30);
            this.tbSelectedContactID.Name = "tbSelectedContactID";
            this.tbSelectedContactID.Size = new System.Drawing.Size(17, 20);
            this.tbSelectedContactID.TabIndex = 10;
            this.tbSelectedContactID.Visible = false;
            // 
            // tbOldType
            // 
            this.tbOldType.Enabled = false;
            this.tbOldType.Location = new System.Drawing.Point(822, 57);
            this.tbOldType.Name = "tbOldType";
            this.tbOldType.Size = new System.Drawing.Size(24, 20);
            this.tbOldType.TabIndex = 12;
            this.tbOldType.Visible = false;
            // 
            // tbOldNumber
            // 
            this.tbOldNumber.Enabled = false;
            this.tbOldNumber.Location = new System.Drawing.Point(822, 30);
            this.tbOldNumber.Name = "tbOldNumber";
            this.tbOldNumber.Size = new System.Drawing.Size(24, 20);
            this.tbOldNumber.TabIndex = 11;
            this.tbOldNumber.Visible = false;
            // 
            // callCostsTab
            // 
            this.callCostsTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.callCostsTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.callCostsTab.Controls.Add(this.tbCallCostHelp);
            this.callCostsTab.Controls.Add(this.groupBox8);
            this.callCostsTab.Controls.Add(this.callCostsGrid);
            this.callCostsTab.Controls.Add(this.groupBox1);
            this.callCostsTab.Controls.Add(this.bnSearchCallCosts);
            this.callCostsTab.Controls.Add(this.tbCallCostID);
            this.callCostsTab.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callCostsTab.Location = new System.Drawing.Point(4, 22);
            this.callCostsTab.Name = "callCostsTab";
            this.callCostsTab.Padding = new System.Windows.Forms.Padding(3);
            this.callCostsTab.Size = new System.Drawing.Size(1000, 534);
            this.callCostsTab.TabIndex = 2;
            this.callCostsTab.Text = "Call Costs";
            this.callCostsTab.UseVisualStyleBackColor = true;
            // 
            // tbCallCostHelp
            // 
            this.tbCallCostHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCallCostHelp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCallCostHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCallCostHelp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCallCostHelp.Location = new System.Drawing.Point(694, 14);
            this.tbCallCostHelp.MinimumSize = new System.Drawing.Size(280, 490);
            this.tbCallCostHelp.Name = "tbCallCostHelp";
            this.tbCallCostHelp.ReadOnly = true;
            this.tbCallCostHelp.Size = new System.Drawing.Size(280, 490);
            this.tbCallCostHelp.TabIndex = 0;
            this.tbCallCostHelp.Text = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Location = new System.Drawing.Point(694, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(0, 0);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            // 
            // callCostsGrid
            // 
            this.callCostsGrid.AllowUserToAddRows = false;
            this.callCostsGrid.AllowUserToDeleteRows = false;
            this.callCostsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.callCostsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.callCostsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.callCostsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.callCostsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.callCostsGrid.Location = new System.Drawing.Point(6, 192);
            this.callCostsGrid.MinimumSize = new System.Drawing.Size(682, 341);
            this.callCostsGrid.MultiSelect = false;
            this.callCostsGrid.Name = "callCostsGrid";
            this.callCostsGrid.ReadOnly = true;
            this.callCostsGrid.RowHeadersVisible = false;
            this.callCostsGrid.Size = new System.Drawing.Size(682, 341);
            this.callCostsGrid.TabIndex = 17;
            this.callCostsGrid.SelectionChanged += new System.EventHandler(this.callCostsGrid_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.bnCCDelete);
            this.groupBox1.Controls.Add(this.bnCCTest);
            this.groupBox1.Controls.Add(this.bnCCUpdate);
            this.groupBox1.Controls.Add(this.tbCCName);
            this.groupBox1.Controls.Add(this.bnCCCreate);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.MinimumSize = new System.Drawing.Size(682, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Call Cost Filter";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbCCExactMatch);
            this.groupBox3.Controls.Add(this.tbCCExactMatch);
            this.groupBox3.Controls.Add(this.tbCCStartsWith);
            this.groupBox3.Controls.Add(this.rbCCStartsWith);
            this.groupBox3.Controls.Add(this.rbCCRegEx);
            this.groupBox3.Controls.Add(this.tbCCRegEx);
            this.groupBox3.Location = new System.Drawing.Point(6, 45);
            this.groupBox3.MinimumSize = new System.Drawing.Size(288, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 103);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Number Matching Information";
            // 
            // rbCCExactMatch
            // 
            this.rbCCExactMatch.AutoSize = true;
            this.rbCCExactMatch.Location = new System.Drawing.Point(6, 44);
            this.rbCCExactMatch.Name = "rbCCExactMatch";
            this.rbCCExactMatch.Size = new System.Drawing.Size(87, 18);
            this.rbCCExactMatch.TabIndex = 3;
            this.rbCCExactMatch.Text = "Exact Match:";
            this.rbCCExactMatch.UseVisualStyleBackColor = true;
            this.rbCCExactMatch.CheckedChanged += new System.EventHandler(this.rbCC_CheckedChanged);
            // 
            // tbCCExactMatch
            // 
            this.tbCCExactMatch.Enabled = false;
            this.tbCCExactMatch.Location = new System.Drawing.Point(132, 43);
            this.tbCCExactMatch.Name = "tbCCExactMatch";
            this.tbCCExactMatch.Size = new System.Drawing.Size(148, 20);
            this.tbCCExactMatch.TabIndex = 4;
            this.tbCCExactMatch.TextChanged += new System.EventHandler(this.CallCostTextBoxes_TextChanged);
            // 
            // tbCCStartsWith
            // 
            this.tbCCStartsWith.Location = new System.Drawing.Point(132, 16);
            this.tbCCStartsWith.Name = "tbCCStartsWith";
            this.tbCCStartsWith.Size = new System.Drawing.Size(148, 20);
            this.tbCCStartsWith.TabIndex = 2;
            this.tbCCStartsWith.TextChanged += new System.EventHandler(this.CallCostTextBoxes_TextChanged);
            // 
            // rbCCStartsWith
            // 
            this.rbCCStartsWith.AutoSize = true;
            this.rbCCStartsWith.Checked = true;
            this.rbCCStartsWith.Location = new System.Drawing.Point(6, 17);
            this.rbCCStartsWith.Name = "rbCCStartsWith";
            this.rbCCStartsWith.Size = new System.Drawing.Size(81, 18);
            this.rbCCStartsWith.TabIndex = 1;
            this.rbCCStartsWith.TabStop = true;
            this.rbCCStartsWith.Text = "Starts With:";
            this.rbCCStartsWith.UseVisualStyleBackColor = true;
            this.rbCCStartsWith.CheckedChanged += new System.EventHandler(this.rbCC_CheckedChanged);
            // 
            // rbCCRegEx
            // 
            this.rbCCRegEx.AutoSize = true;
            this.rbCCRegEx.Location = new System.Drawing.Point(6, 56);
            this.rbCCRegEx.Name = "rbCCRegEx";
            this.rbCCRegEx.Size = new System.Drawing.Size(119, 46);
            this.rbCCRegEx.TabIndex = 5;
            this.rbCCRegEx.Text = "\nRegular Expression\n(Advanced)";
            this.rbCCRegEx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCCRegEx.UseVisualStyleBackColor = true;
            this.rbCCRegEx.CheckedChanged += new System.EventHandler(this.rbCC_CheckedChanged);
            // 
            // tbCCRegEx
            // 
            this.tbCCRegEx.Enabled = false;
            this.tbCCRegEx.Location = new System.Drawing.Point(132, 69);
            this.tbCCRegEx.Name = "tbCCRegEx";
            this.tbCCRegEx.Size = new System.Drawing.Size(148, 20);
            this.tbCCRegEx.TabIndex = 6;
            // 
            // bnCCDelete
            // 
            this.bnCCDelete.BackColor = System.Drawing.SystemColors.Control;
            this.bnCCDelete.Enabled = false;
            this.bnCCDelete.Font = new System.Drawing.Font("Arial", 8.25F);
            this.bnCCDelete.Location = new System.Drawing.Point(434, 152);
            this.bnCCDelete.Name = "bnCCDelete";
            this.bnCCDelete.Size = new System.Drawing.Size(75, 23);
            this.bnCCDelete.TabIndex = 4;
            this.bnCCDelete.Text = "Delete";
            this.bnCCDelete.UseVisualStyleBackColor = false;
            this.bnCCDelete.Click += new System.EventHandler(this.bnCCDelete_Click);
            // 
            // bnCCTest
            // 
            this.bnCCTest.BackColor = System.Drawing.SystemColors.Control;
            this.bnCCTest.Location = new System.Drawing.Point(596, 51);
            this.bnCCTest.Name = "bnCCTest";
            this.bnCCTest.Size = new System.Drawing.Size(82, 23);
            this.bnCCTest.TabIndex = 3;
            this.bnCCTest.Text = "Test Rules";
            this.bnCCTest.UseVisualStyleBackColor = false;
            this.bnCCTest.Click += new System.EventHandler(this.bnCCTest_Click);
            // 
            // bnCCUpdate
            // 
            this.bnCCUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.bnCCUpdate.Enabled = false;
            this.bnCCUpdate.Font = new System.Drawing.Font("Arial", 8.25F);
            this.bnCCUpdate.Location = new System.Drawing.Point(515, 152);
            this.bnCCUpdate.Name = "bnCCUpdate";
            this.bnCCUpdate.Size = new System.Drawing.Size(75, 23);
            this.bnCCUpdate.TabIndex = 5;
            this.bnCCUpdate.Text = "Save";
            this.bnCCUpdate.UseVisualStyleBackColor = false;
            this.bnCCUpdate.Click += new System.EventHandler(this.bnCCUpdate_Click);
            // 
            // tbCCName
            // 
            this.tbCCName.Location = new System.Drawing.Point(138, 19);
            this.tbCCName.Name = "tbCCName";
            this.tbCCName.Size = new System.Drawing.Size(148, 20);
            this.tbCCName.TabIndex = 1;
            // 
            // bnCCCreate
            // 
            this.bnCCCreate.BackColor = System.Drawing.SystemColors.Control;
            this.bnCCCreate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCCCreate.Location = new System.Drawing.Point(596, 22);
            this.bnCCCreate.Name = "bnCCCreate";
            this.bnCCCreate.Size = new System.Drawing.Size(82, 23);
            this.bnCCCreate.TabIndex = 2;
            this.bnCCCreate.Text = "Create New";
            this.bnCCCreate.UseVisualStyleBackColor = false;
            this.bnCCCreate.Click += new System.EventHandler(this.bnCCCreate_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbCCChargeUnfinished);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.tbCCRateBlock);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.tbCCBlockSize);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.tbCCConnCost);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Location = new System.Drawing.Point(300, 18);
            this.groupBox7.MinimumSize = new System.Drawing.Size(290, 130);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(290, 130);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Cost Breakdown";
            // 
            // cbCCChargeUnfinished
            // 
            this.cbCCChargeUnfinished.AutoSize = true;
            this.cbCCChargeUnfinished.Checked = true;
            this.cbCCChargeUnfinished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCCChargeUnfinished.Location = new System.Drawing.Point(96, 94);
            this.cbCCChargeUnfinished.Name = "cbCCChargeUnfinished";
            this.cbCCChargeUnfinished.Size = new System.Drawing.Size(161, 18);
            this.cbCCChargeUnfinished.TabIndex = 4;
            this.cbCCChargeUnfinished.Text = "Charge for incomplete Block";
            this.cbCCChargeUnfinished.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 14);
            this.label18.TabIndex = 10;
            this.label18.Text = "Connection Cost";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 8;
            this.label14.Text = "Rate per Block";
            // 
            // tbCCRateBlock
            // 
            this.tbCCRateBlock.Location = new System.Drawing.Point(96, 65);
            this.tbCCRateBlock.Name = "tbCCRateBlock";
            this.tbCCRateBlock.Size = new System.Drawing.Size(134, 20);
            this.tbCCRateBlock.TabIndex = 3;
            this.tbCCRateBlock.Text = "0";
            this.tbCCRateBlock.TextChanged += new System.EventHandler(this.tbCallCostNumbers_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 14);
            this.label16.TabIndex = 9;
            this.label16.Text = "Block Size";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(236, 68);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 14);
            this.label23.TabIndex = 18;
            this.label23.Text = "cents";
            // 
            // tbCCBlockSize
            // 
            this.tbCCBlockSize.Location = new System.Drawing.Point(96, 39);
            this.tbCCBlockSize.Name = "tbCCBlockSize";
            this.tbCCBlockSize.Size = new System.Drawing.Size(134, 20);
            this.tbCCBlockSize.TabIndex = 2;
            this.tbCCBlockSize.Text = "0";
            this.tbCCBlockSize.TextChanged += new System.EventHandler(this.tbCallCostNumbers_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(236, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 14);
            this.label22.TabIndex = 17;
            this.label22.Text = "seconds";
            // 
            // tbCCConnCost
            // 
            this.tbCCConnCost.Location = new System.Drawing.Point(96, 13);
            this.tbCCConnCost.Name = "tbCCConnCost";
            this.tbCCConnCost.Size = new System.Drawing.Size(134, 20);
            this.tbCCConnCost.TabIndex = 1;
            this.tbCCConnCost.Text = "0";
            this.tbCCConnCost.TextChanged += new System.EventHandler(this.tbCallCostNumbers_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(236, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 14);
            this.label21.TabIndex = 16;
            this.label21.Text = "cents";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "Filter Name:";
            // 
            // bnSearchCallCosts
            // 
            this.bnSearchCallCosts.Font = new System.Drawing.Font("Arial", 9F);
            this.bnSearchCallCosts.Location = new System.Drawing.Point(1109, 160);
            this.bnSearchCallCosts.Name = "bnSearchCallCosts";
            this.bnSearchCallCosts.Size = new System.Drawing.Size(123, 23);
            this.bnSearchCallCosts.TabIndex = 21;
            this.bnSearchCallCosts.Text = "Search";
            this.bnSearchCallCosts.UseVisualStyleBackColor = true;
            this.bnSearchCallCosts.Visible = false;
            // 
            // tbCallCostID
            // 
            this.tbCallCostID.Location = new System.Drawing.Point(1214, 189);
            this.tbCallCostID.Name = "tbCallCostID";
            this.tbCallCostID.Size = new System.Drawing.Size(18, 20);
            this.tbCallCostID.TabIndex = 23;
            this.tbCallCostID.Visible = false;
            // 
            // logTab
            // 
            this.logTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTab.Controls.Add(this.groupBox2);
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(1000, 534);
            this.logTab.TabIndex = 3;
            this.logTab.Text = "Debug Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.bnSaveLog);
            this.groupBox2.Controls.Add(this.bnClearLog);
            this.groupBox2.Controls.Add(this.tbLog);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.MinimumSize = new System.Drawing.Size(986, 527);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(986, 527);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MiStatus";
            // 
            // bnSaveLog
            // 
            this.bnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnSaveLog.BackColor = System.Drawing.SystemColors.Control;
            this.bnSaveLog.Font = new System.Drawing.Font("Arial", 9F);
            this.bnSaveLog.Location = new System.Drawing.Point(824, 498);
            this.bnSaveLog.Name = "bnSaveLog";
            this.bnSaveLog.Size = new System.Drawing.Size(75, 23);
            this.bnSaveLog.TabIndex = 10;
            this.bnSaveLog.Text = "Save Log";
            this.bnSaveLog.UseVisualStyleBackColor = false;
            this.bnSaveLog.Click += new System.EventHandler(this.bnSaveLog_Click);
            // 
            // bnClearLog
            // 
            this.bnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnClearLog.BackColor = System.Drawing.SystemColors.Control;
            this.bnClearLog.Font = new System.Drawing.Font("Arial", 9F);
            this.bnClearLog.Location = new System.Drawing.Point(905, 498);
            this.bnClearLog.Name = "bnClearLog";
            this.bnClearLog.Size = new System.Drawing.Size(75, 23);
            this.bnClearLog.TabIndex = 1;
            this.bnClearLog.Text = "Clear Log";
            this.bnClearLog.UseVisualStyleBackColor = false;
            this.bnClearLog.Click += new System.EventHandler(this.bnClearLog_Click);
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Gainsboro;
            this.tbLog.Location = new System.Drawing.Point(6, 19);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(974, 473);
            this.tbLog.TabIndex = 7;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1012, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Tag = "";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.viewLogToolStripMenuItem,
            this.rawDataToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.viewLogToolStripMenuItem.Text = "View Connection History";
            this.viewLogToolStripMenuItem.Click += new System.EventHandler(this.viewLogToolStripMenuItem_Click);
            // 
            // rawDataToolStripMenuItem
            // 
            this.rawDataToolStripMenuItem.Name = "rawDataToolStripMenuItem";
            this.rawDataToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.rawDataToolStripMenuItem.Text = "View Raw Connection Data";
            this.rawDataToolStripMenuItem.Click += new System.EventHandler(this.rawDataToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importRawFileToolStripMenuItem,
            this.applyUpdateToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // importRawFileToolStripMenuItem
            // 
            this.importRawFileToolStripMenuItem.Name = "importRawFileToolStripMenuItem";
            this.importRawFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.importRawFileToolStripMenuItem.Text = "Import Raw File";
            this.importRawFileToolStripMenuItem.Click += new System.EventHandler(this.importRawFileToolStripMenuItem_Click);
            // 
            // applyUpdateToolStripMenuItem
            // 
            this.applyUpdateToolStripMenuItem.Name = "applyUpdateToolStripMenuItem";
            this.applyUpdateToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.applyUpdateToolStripMenuItem.Text = "Apply Update";
            this.applyUpdateToolStripMenuItem.Click += new System.EventHandler(this.applyUpdateToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSMDRSupportToolStripMenuItem,
            this.aboutMiSMDRToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MiSMDRSupportToolStripMenuItem
            // 
            this.MiSMDRSupportToolStripMenuItem.Name = "MiSMDRSupportToolStripMenuItem";
            this.MiSMDRSupportToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.MiSMDRSupportToolStripMenuItem.Text = "MiSMDR Support Site";
            this.MiSMDRSupportToolStripMenuItem.Click += new System.EventHandler(this.MiSMDRSupportToolStripMenuItem_Click);
            // 
            // aboutMiSMDRToolStripMenuItem
            // 
            this.aboutMiSMDRToolStripMenuItem.Name = "aboutMiSMDRToolStripMenuItem";
            this.aboutMiSMDRToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutMiSMDRToolStripMenuItem.Text = "About MiSMDR";
            this.aboutMiSMDRToolStripMenuItem.Click += new System.EventHandler(this.aboutMiSMDRToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "84_green.png");
            this.imageList.Images.SetKeyName(1, "84_red.png");
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatusText1,
            this.lbStatusCalls,
            this.lbStatusText2,
            this.connectionStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 594);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1012, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lbStatusText1
            // 
            this.lbStatusText1.Name = "lbStatusText1";
            this.lbStatusText1.Size = new System.Drawing.Size(16, 17);
            this.lbStatusText1.Text = "...";
            // 
            // lbStatusCalls
            // 
            this.lbStatusCalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbStatusCalls.Name = "lbStatusCalls";
            this.lbStatusCalls.Size = new System.Drawing.Size(0, 17);
            // 
            // lbStatusText2
            // 
            this.lbStatusText2.Name = "lbStatusText2";
            this.lbStatusText2.Size = new System.Drawing.Size(0, 17);
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.Image = ((System.Drawing.Image)(resources.GetObject("connectionStatusLabel.Image")));
            this.connectionStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(981, 17);
            this.connectionStatusLabel.Spring = true;
            this.connectionStatusLabel.Text = "Not Connected";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.connectionStatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(869, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "Receiver Extensions";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(722, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 9;
            this.label27.Text = "Receivers";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(487, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(87, 13);
            this.label28.TabIndex = 7;
            this.label28.Text = "Caller Extensions";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(348, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(38, 13);
            this.label30.TabIndex = 8;
            this.label30.Text = "Callers";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Total Call Costs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Total Duration:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Externals";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Internals:";
            // 
            // exportSaveDialog
            // 
            this.exportSaveDialog.FileName = "MitelData_Log";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // connectionHistoryToolStripMenuItem
            // 
            this.connectionHistoryToolStripMenuItem.Name = "connectionHistoryToolStripMenuItem";
            this.connectionHistoryToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // viewMitelDataToolStripMenuItem
            // 
            this.viewMitelDataToolStripMenuItem.Name = "viewMitelDataToolStripMenuItem";
            this.viewMitelDataToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(23, 23);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.SystemTrayMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MiSMDR";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // SystemTrayMenu
            // 
            this.SystemTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smRestore,
            this.smExit});
            this.SystemTrayMenu.Name = "SystemTrayMenu";
            this.SystemTrayMenu.Size = new System.Drawing.Size(146, 48);
            // 
            // smRestore
            // 
            this.smRestore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetPositionToolStripMenuItem});
            this.smRestore.Name = "smRestore";
            this.smRestore.Size = new System.Drawing.Size(145, 22);
            this.smRestore.Text = "Show MiSMDR";
            this.smRestore.Click += new System.EventHandler(this.smRestore_Click);
            // 
            // resetPositionToolStripMenuItem
            // 
            this.resetPositionToolStripMenuItem.Name = "resetPositionToolStripMenuItem";
            this.resetPositionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetPositionToolStripMenuItem.Text = "Reset Position";
            this.resetPositionToolStripMenuItem.Click += new System.EventHandler(this.resetPositionToolStripMenuItem_Click);
            // 
            // smExit
            // 
            this.smExit.Name = "smExit";
            this.smExit.Size = new System.Drawing.Size(145, 22);
            this.smExit.Text = "Exit MiSMDR";
            this.smExit.Click += new System.EventHandler(this.smExit_Click);
            // 
            // tbDBPort
            // 
            this.tbDBPort.Enabled = false;
            this.tbDBPort.Location = new System.Drawing.Point(103, 278);
            this.tbDBPort.Name = "tbDBPort";
            this.tbDBPort.Size = new System.Drawing.Size(67, 20);
            this.tbDBPort.TabIndex = 31;
            //this.tbDBPort.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbDBServer
            // 
            this.tbDBServer.Enabled = false;
            this.tbDBServer.Location = new System.Drawing.Point(103, 250);
            this.tbDBServer.Name = "tbDBServer";
            this.tbDBServer.Size = new System.Drawing.Size(164, 20);
            this.tbDBServer.TabIndex = 30;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(42, 281);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(55, 15);
            this.label32.TabIndex = 33;
            this.label32.Text = "DB Port:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(26, 251);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(71, 18);
            this.label34.TabIndex = 32;
            this.label34.Text = "DB Server:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.label34.Click += new System.EventHandler(this.label34_Click);
            // 
            // MiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1012, 616);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1020, 650);
            this.Name = "MiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiSMDR Call Accounting";
            this.Load += new System.EventHandler(this.MiForm_Load);
            this.Shown += new System.EventHandler(this.MiForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiForm_FormClosing);
            this.Resize += new System.EventHandler(this.MiForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabContainer.ResumeLayout(false);
            this.connTab.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_alert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.savedSearchBox.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.summaryPage.ResumeLayout(false);
            this.summaryPage.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.summaries_PeriodGroup.ResumeLayout(false);
            this.summaries_PeriodGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatest4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatest2)).EndInit();
            this.reportTab.ResumeLayout(false);
            this.statisticsBox.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.addressTab.ResumeLayout(false);
            this.addressTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressDataGrid)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.callCostsTab.ResumeLayout(false);
            this.callCostsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callCostsGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.logTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.SystemTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.TabPage callCostsTab;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbCCRateBlock;
        private System.Windows.Forms.TextBox tbCCBlockSize;
        private System.Windows.Forms.TextBox tbCCConnCost;
        private System.Windows.Forms.TextBox tbCCRegEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bnCCCreate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button bnClearLog;
        private System.Windows.Forms.Button bnSaveLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusText1;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bnCCDelete;
        private System.Windows.Forms.TabPage reportTab;
        private System.Windows.Forms.GroupBox statisticsBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bnConnect;
        private System.Windows.Forms.Button bnDisconnect;
        private System.Windows.Forms.TabPage searchTab;
        private CallInfo callInfo;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lbServerLabel;
        private System.Windows.Forms.Label lbPortLabel;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ToolStripMenuItem rawDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusCalls;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusText2;
        private GridColourKey keyInternal;
        private GridColourKey keyOutgoing;
        private GridColourKey keyIncoming;
        private System.Windows.Forms.SaveFileDialog exportSaveDialog;
        private GridColourKey keyUnknown;
        private System.Windows.Forms.TabPage connTab;
        private System.Windows.Forms.Label lbStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMiSMDRToolStripMenuItem;
        private System.Windows.Forms.GroupBox savedSearchBox;
        private System.Windows.Forms.ListBox lbSavedSearches;
        private System.Windows.Forms.Button bnDeleteSavedSearch;
        private System.Windows.Forms.Button bnLoadSavedSearch;
        private System.Windows.Forms.TextBox hiddenSavedSearchID;
        private System.Windows.Forms.TextBox hiddenSavedSearchName;
        private System.Windows.Forms.Button bnCCUpdate;
        private System.Windows.Forms.Button bnSearchCallCosts;
        private System.Windows.Forms.TextBox tbCallCostID;
        private System.Windows.Forms.DataGridView callCostsGrid;
        private System.Windows.Forms.DateTimePicker EndDateFilter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker StartDateFilter1;
        private System.Windows.Forms.RadioButton rbDateRange;
        private System.Windows.Forms.RadioButton rbSingleDate;
        private System.Windows.Forms.RadioButton rbAllDates;
        private System.Windows.Forms.CheckBox toExactMatch;
        private System.Windows.Forms.CheckBox fromExactMatch;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.ComboBox cbCallCategory;
        private System.Windows.Forms.Button bnSearch2;
        private System.Windows.Forms.ComboBox cbDuration;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox cbAnswerTime;
        private System.Windows.Forms.TextBox tbAnswerTime;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button bnSaveCurrentSearch;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TabPage addressTab;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.RadioButton csAllDates;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.DateTimePicker csEndDate;
        private System.Windows.Forms.DateTimePicker csStartDate;
        private System.Windows.Forms.RadioButton csDateRange;
        private System.Windows.Forms.RadioButton csSingleDate;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox tbContactNumber;
        private System.Windows.Forms.TextBox tbContactName;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.DataGridView addressDataGrid;
        private System.Windows.Forms.Button bnUpdateCont;
        private System.Windows.Forms.Button bnCreateContact;
        private System.Windows.Forms.TextBox tbSelectedContactID;
        private System.Windows.Forms.TextBox tbNumberID;
        private System.Windows.Forms.Button bnContactDelete;
        private System.Windows.Forms.Button bnCallSummarySearch;
        private System.Windows.Forms.CheckBox cbSavedSearchOverwrite;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbCCStartsWith;
        private System.Windows.Forms.RadioButton rbCCRegEx;
        private System.Windows.Forms.RadioButton rbCCExactMatch;
        private System.Windows.Forms.TextBox tbCCExactMatch;
        private System.Windows.Forms.TextBox tbCCStartsWith;
        private System.Windows.Forms.Button bnCCTest;
        private System.Windows.Forms.TextBox tbCCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnSClearFields;
        private Microsoft.Reporting.WinForms.ReportViewer callSummaryReport;
        private System.Windows.Forms.RadioButton rbMMLive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.CheckBox cbCCChargeUnfinished;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewMitelDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem MiSMDRSupportToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbContactType;
        private System.Windows.Forms.TextBox tbOldName;
        private System.Windows.Forms.TextBox tbOldType;
        private System.Windows.Forms.TextBox tbOldNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox tbWelcomeContent;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox tbCallCostHelp;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox tbAddressBookHelp;
        private System.Windows.Forms.CheckBox cbUnanswered;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DayFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox csDay;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip SystemTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem smRestore;
        private System.Windows.Forms.ToolStripMenuItem smExit;
        private System.Windows.Forms.ToolStripMenuItem resetPositionToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbMMDemo;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRawFileToolStripMenuItem;
        private System.Windows.Forms.TabPage summaryPage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvLatest1;
        private System.Windows.Forms.DataGridView dgvLatest4;
        private System.Windows.Forms.DataGridView dgvLatest2;
        private System.Windows.Forms.RadioButton ps_rb_periodWeek;
        private System.Windows.Forms.RadioButton ps_rb_periodDay;
        private System.Windows.Forms.RadioButton ps_rb_periodHour;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label ps_talktime_tot;
        private System.Windows.Forms.Label ps_talktime_int;
        private System.Windows.Forms.Label ps_talktime_inc;
        private System.Windows.Forms.Label ps_talktime_out;
        private System.Windows.Forms.Label ps_callcount_una;
        private System.Windows.Forms.Label ps_callcount_inc;
        private System.Windows.Forms.Label ps_callcount_out;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton ps_rb_periodMonth;
        private System.Windows.Forms.Label ps_totalcallcost;
        private System.Windows.Forms.Label ps_callcount_int;
        private System.Windows.Forms.Label summaries_UpdateLabel;
        private System.Windows.Forms.ToolStripMenuItem applyUpdateToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb_reseller;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tb_expiry;
        private System.Windows.Forms.Label lb_reseller;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button bn_ChangeLicense;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tb_contactEmail;
        private System.Windows.Forms.Label lb_LicenseHeader;
        private System.Windows.Forms.Label lb_LicenseMessage;
        private System.Windows.Forms.PictureBox pb_alert;
        private System.Windows.Forms.RichTextBox rtb_license;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tb_LongCallDefinition;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel summaries_PeriodGroup;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbIncomingCount;
        private System.Windows.Forms.Button bnExport;
        private System.Windows.Forms.Label lbTotalCost;
        private System.Windows.Forms.Label lbDurationTotal;
        private System.Windows.Forms.Label lbOutgoingCount;
        private System.Windows.Forms.Label lbInternalCount;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label lbTotalDurationText;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox tbDBPort;
        private System.Windows.Forms.TextBox tbDBServer;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label34;
    }
}

