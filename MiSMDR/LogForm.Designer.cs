namespace MiSMDR
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.bnRefresh = new System.Windows.Forms.Button();
            this.bnExport = new System.Windows.Forms.Button();
            this.exportSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bnRefresh
            // 
            this.bnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnRefresh.Location = new System.Drawing.Point(857, 4);
            this.bnRefresh.Name = "bnRefresh";
            this.bnRefresh.Size = new System.Drawing.Size(75, 23);
            this.bnRefresh.TabIndex = 1;
            this.bnRefresh.Text = "Refresh";
            this.bnRefresh.UseVisualStyleBackColor = true;
            this.bnRefresh.Click += new System.EventHandler(this.bnRefresh_Click);
            // 
            // bnExport
            // 
            this.bnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnExport.Location = new System.Drawing.Point(938, 4);
            this.bnExport.Name = "bnExport";
            this.bnExport.Size = new System.Drawing.Size(75, 23);
            this.bnExport.TabIndex = 2;
            this.bnExport.Text = "Export";
            this.bnExport.UseVisualStyleBackColor = true;
            this.bnExport.Click += new System.EventHandler(this.bnExport_Click);
            // 
            // logDataGridView
            // 
            this.logDataGridView.AllowUserToAddRows = false;
            this.logDataGridView.AllowUserToDeleteRows = false;
            this.logDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.logDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.logDataGridView.Location = new System.Drawing.Point(12, 33);
            this.logDataGridView.Name = "logDataGridView";
            this.logDataGridView.ReadOnly = true;
            this.logDataGridView.Size = new System.Drawing.Size(1001, 386);
            this.logDataGridView.TabIndex = 0;
            this.logDataGridView.SelectionChanged += new System.EventHandler(this.logDataGridView_SelectionChanged);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 431);
            this.Controls.Add(this.bnExport);
            this.Controls.Add(this.bnRefresh);
            this.Controls.Add(this.logDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mitel Log";
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnRefresh;
        private System.Windows.Forms.Button bnExport;
        private System.Windows.Forms.SaveFileDialog exportSaveDialog;
        private System.Windows.Forms.DataGridView logDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}