namespace MiSMDR
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnSave = new System.Windows.Forms.Button();
            this.cbShowDebug = new System.Windows.Forms.CheckBox();
            this.cbConnectOnStartup = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCallRecordLimit = new System.Windows.Forms.TextBox();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.cbMinimiseToTray = new System.Windows.Forms.CheckBox();
            this.cbShowSplash = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbShowNotifications = new System.Windows.Forms.CheckBox();
            this.tbMitelDataLogPath = new System.Windows.Forms.TextBox();
            this.tbCallRecordLoc = new System.Windows.Forms.TextBox();
            this.bnSelectPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bnBrowseRecordFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDemoRecords = new System.Windows.Forms.TextBox();
            this.bnBrowseDemoFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnResetSettings = new System.Windows.Forms.Button();
            this.bnDemoData = new System.Windows.Forms.Button();
            this.bnDataClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "MitelData_Log.txt";
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "the tooltip appears here";
            this.toolTip1.ToolTipTitle = "help is here";
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(270, 393);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 25);
            this.bnCancel.TabIndex = 6;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(189, 393);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(75, 25);
            this.bnSave.TabIndex = 0;
            this.bnSave.Text = "OK";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // cbShowDebug
            // 
            this.cbShowDebug.AutoSize = true;
            this.cbShowDebug.Checked = true;
            this.cbShowDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowDebug.Location = new System.Drawing.Point(13, 113);
            this.cbShowDebug.Name = "cbShowDebug";
            this.cbShowDebug.Size = new System.Drawing.Size(110, 18);
            this.cbShowDebug.TabIndex = 31;
            this.cbShowDebug.Text = "Show Debug Log";
            this.cbShowDebug.UseVisualStyleBackColor = true;
            // 
            // cbConnectOnStartup
            // 
            this.cbConnectOnStartup.AutoSize = true;
            this.cbConnectOnStartup.Checked = true;
            this.cbConnectOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConnectOnStartup.Location = new System.Drawing.Point(13, 18);
            this.cbConnectOnStartup.Name = "cbConnectOnStartup";
            this.cbConnectOnStartup.Size = new System.Drawing.Size(155, 18);
            this.cbConnectOnStartup.TabIndex = 34;
            this.cbConnectOnStartup.Text = "Connect to Mitel on Startup";
            this.cbConnectOnStartup.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "Limit search results to ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "call records";
            // 
            // tbCallRecordLimit
            // 
            this.tbCallRecordLimit.Location = new System.Drawing.Point(125, 129);
            this.tbCallRecordLimit.Name = "tbCallRecordLimit";
            this.tbCallRecordLimit.Size = new System.Drawing.Size(60, 20);
            this.tbCallRecordLimit.TabIndex = 27;
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Checked = true;
            this.cbStartWithWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStartWithWindows.Location = new System.Drawing.Point(13, 37);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(165, 18);
            this.cbStartWithWindows.TabIndex = 36;
            this.cbStartWithWindows.Text = "MiSMDR starts with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // cbMinimiseToTray
            // 
            this.cbMinimiseToTray.AutoSize = true;
            this.cbMinimiseToTray.Checked = true;
            this.cbMinimiseToTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMinimiseToTray.Location = new System.Drawing.Point(13, 56);
            this.cbMinimiseToTray.Name = "cbMinimiseToTray";
            this.cbMinimiseToTray.Size = new System.Drawing.Size(142, 18);
            this.cbMinimiseToTray.TabIndex = 37;
            this.cbMinimiseToTray.Text = "Minimize to System Tray";
            this.cbMinimiseToTray.UseVisualStyleBackColor = true;
            this.cbMinimiseToTray.CheckedChanged += new System.EventHandler(this.cbMinimiseToTray_CheckedChanged);
            // 
            // cbShowSplash
            // 
            this.cbShowSplash.AutoSize = true;
            this.cbShowSplash.Checked = true;
            this.cbShowSplash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowSplash.Location = new System.Drawing.Point(13, 94);
            this.cbShowSplash.Name = "cbShowSplash";
            this.cbShowSplash.Size = new System.Drawing.Size(181, 18);
            this.cbShowSplash.TabIndex = 38;
            this.cbShowSplash.Text = "Show Splash screen on Startup";
            this.cbShowSplash.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbShowNotifications);
            this.groupBox1.Controls.Add(this.cbShowSplash);
            this.groupBox1.Controls.Add(this.cbMinimiseToTray);
            this.groupBox1.Controls.Add(this.cbStartWithWindows);
            this.groupBox1.Controls.Add(this.tbCallRecordLimit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbConnectOnStartup);
            this.groupBox1.Controls.Add(this.cbShowDebug);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 160);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cbShowNotifications
            // 
            this.cbShowNotifications.AutoSize = true;
            this.cbShowNotifications.Checked = true;
            this.cbShowNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowNotifications.Location = new System.Drawing.Point(32, 75);
            this.cbShowNotifications.Name = "cbShowNotifications";
            this.cbShowNotifications.Size = new System.Drawing.Size(181, 18);
            this.cbShowNotifications.TabIndex = 39;
            this.cbShowNotifications.Text = "Show System Tray Notifications";
            this.cbShowNotifications.UseVisualStyleBackColor = true;
            // 
            // tbMitelDataLogPath
            // 
            this.tbMitelDataLogPath.Location = new System.Drawing.Point(9, 118);
            this.tbMitelDataLogPath.Name = "tbMitelDataLogPath";
            this.tbMitelDataLogPath.Size = new System.Drawing.Size(261, 20);
            this.tbMitelDataLogPath.TabIndex = 0;
            // 
            // tbCallRecordLoc
            // 
            this.tbCallRecordLoc.Location = new System.Drawing.Point(9, 34);
            this.tbCallRecordLoc.Name = "tbCallRecordLoc";
            this.tbCallRecordLoc.Size = new System.Drawing.Size(261, 20);
            this.tbCallRecordLoc.TabIndex = 29;
            // 
            // bnSelectPath
            // 
            this.bnSelectPath.Location = new System.Drawing.Point(276, 116);
            this.bnSelectPath.Name = "bnSelectPath";
            this.bnSelectPath.Size = new System.Drawing.Size(58, 25);
            this.bnSelectPath.TabIndex = 2;
            this.bnSelectPath.Text = "Browse";
            this.bnSelectPath.UseVisualStyleBackColor = true;
            this.bnSelectPath.Click += new System.EventHandler(this.bnSelectPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mitel Raw Log File:";
            // 
            // bnBrowseRecordFile
            // 
            this.bnBrowseRecordFile.Location = new System.Drawing.Point(276, 32);
            this.bnBrowseRecordFile.Name = "bnBrowseRecordFile";
            this.bnBrowseRecordFile.Size = new System.Drawing.Size(58, 25);
            this.bnBrowseRecordFile.TabIndex = 28;
            this.bnBrowseRecordFile.Text = "Browse";
            this.bnBrowseRecordFile.UseVisualStyleBackColor = true;
            this.bnBrowseRecordFile.Click += new System.EventHandler(this.bnBrowseRecordFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "Mitel Call Record File:";
            // 
            // tbDemoRecords
            // 
            this.tbDemoRecords.Location = new System.Drawing.Point(9, 76);
            this.tbDemoRecords.Name = "tbDemoRecords";
            this.tbDemoRecords.Size = new System.Drawing.Size(261, 20);
            this.tbDemoRecords.TabIndex = 32;
            // 
            // bnBrowseDemoFile
            // 
            this.bnBrowseDemoFile.Location = new System.Drawing.Point(276, 74);
            this.bnBrowseDemoFile.Name = "bnBrowseDemoFile";
            this.bnBrowseDemoFile.Size = new System.Drawing.Size(58, 25);
            this.bnBrowseDemoFile.TabIndex = 31;
            this.bnBrowseDemoFile.Text = "Browse";
            this.bnBrowseDemoFile.UseVisualStyleBackColor = true;
            this.bnBrowseDemoFile.Click += new System.EventHandler(this.bnBrowseDemoFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 14);
            this.label6.TabIndex = 33;
            this.label6.Text = "Demo Call Record File:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bnBrowseDemoFile);
            this.groupBox2.Controls.Add(this.tbDemoRecords);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.bnBrowseRecordFile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.bnSelectPath);
            this.groupBox2.Controls.Add(this.tbCallRecordLoc);
            this.groupBox2.Controls.Add(this.tbMitelDataLogPath);
            this.groupBox2.Location = new System.Drawing.Point(5, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 151);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files";
            // 
            // bnResetSettings
            // 
            this.bnResetSettings.Location = new System.Drawing.Point(118, 19);
            this.bnResetSettings.Name = "bnResetSettings";
            this.bnResetSettings.Size = new System.Drawing.Size(105, 25);
            this.bnResetSettings.TabIndex = 33;
            this.bnResetSettings.Text = "Default Settings";
            this.bnResetSettings.UseVisualStyleBackColor = true;
            this.bnResetSettings.Click += new System.EventHandler(this.bnResetSettings_Click);
            // 
            // bnDemoData
            // 
            this.bnDemoData.Location = new System.Drawing.Point(7, 19);
            this.bnDemoData.Name = "bnDemoData";
            this.bnDemoData.Size = new System.Drawing.Size(105, 25);
            this.bnDemoData.TabIndex = 25;
            this.bnDemoData.Text = "Reset Demo Data";
            this.bnDemoData.UseVisualStyleBackColor = true;
            this.bnDemoData.Click += new System.EventHandler(this.bnDemoData_Click);
            // 
            // bnDataClear
            // 
            this.bnDataClear.Location = new System.Drawing.Point(229, 19);
            this.bnDataClear.Name = "bnDataClear";
            this.bnDataClear.Size = new System.Drawing.Size(105, 25);
            this.bnDataClear.TabIndex = 23;
            this.bnDataClear.Text = "Clear Call Records";
            this.bnDataClear.UseVisualStyleBackColor = true;
            this.bnDataClear.Click += new System.EventHandler(this.bnDataClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bnDataClear);
            this.groupBox3.Controls.Add(this.bnDemoData);
            this.groupBox3.Controls.Add(this.bnResetSettings);
            this.groupBox3.Location = new System.Drawing.Point(5, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 57);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Advanced";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 423);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.bnCancel);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.CheckBox cbShowDebug;
        private System.Windows.Forms.CheckBox cbConnectOnStartup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCallRecordLimit;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.CheckBox cbMinimiseToTray;
        private System.Windows.Forms.CheckBox cbShowSplash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbShowNotifications;
        private System.Windows.Forms.TextBox tbMitelDataLogPath;
        private System.Windows.Forms.TextBox tbCallRecordLoc;
        private System.Windows.Forms.Button bnSelectPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnBrowseRecordFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDemoRecords;
        private System.Windows.Forms.Button bnBrowseDemoFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bnResetSettings;
        private System.Windows.Forms.Button bnDemoData;
        private System.Windows.Forms.Button bnDataClear;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}