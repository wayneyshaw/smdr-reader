namespace MiSMDR
{
    partial class PluginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.startImport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.bnBrowseRecordFile = new System.Windows.Forms.Button();
            this.tbFileLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startImport
            // 
            this.startImport.Enabled = false;
            this.startImport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startImport.Location = new System.Drawing.Point(279, 69);
            this.startImport.Name = "startImport";
            this.startImport.Size = new System.Drawing.Size(60, 23);
            this.startImport.TabIndex = 42;
            this.startImport.Text = "Apply";
            this.startImport.UseVisualStyleBackColor = true;
            this.startImport.Click += new System.EventHandler(this.startImport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(261, 23);
            this.progressBar1.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "Update File:";
            // 
            // bnBrowseRecordFile
            // 
            this.bnBrowseRecordFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnBrowseRecordFile.Location = new System.Drawing.Point(279, 26);
            this.bnBrowseRecordFile.Name = "bnBrowseRecordFile";
            this.bnBrowseRecordFile.Size = new System.Drawing.Size(60, 25);
            this.bnBrowseRecordFile.TabIndex = 38;
            this.bnBrowseRecordFile.Text = "Browse";
            this.bnBrowseRecordFile.UseVisualStyleBackColor = true;
            this.bnBrowseRecordFile.Click += new System.EventHandler(this.bnBrowseRecordFile_Click);
            // 
            // tbFileLoc
            // 
            this.tbFileLoc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileLoc.Location = new System.Drawing.Point(12, 29);
            this.tbFileLoc.Name = "tbFileLoc";
            this.tbFileLoc.Size = new System.Drawing.Size(261, 20);
            this.tbFileLoc.TabIndex = 39;
            this.tbFileLoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbFileLoc_MouseDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 24);
            this.label1.TabIndex = 43;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 128);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startImport);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bnBrowseRecordFile);
            this.Controls.Add(this.tbFileLoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply an Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startImport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bnBrowseRecordFile;
        private System.Windows.Forms.TextBox tbFileLoc;
        private System.Windows.Forms.Label label1;
    }
}