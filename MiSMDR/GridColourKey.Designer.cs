namespace MiSMDR
{
    partial class GridColourKey
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colourPanel = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // colourPanel
            // 
            this.colourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colourPanel.Location = new System.Drawing.Point(3, 4);
            this.colourPanel.Name = "colourPanel";
            this.colourPanel.Size = new System.Drawing.Size(23, 10);
            this.colourPanel.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(32, 3);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(16, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "...";
            // 
            // GridColourKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.colourPanel);
            this.Name = "GridColourKey";
            this.Size = new System.Drawing.Size(114, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel colourPanel;
        private System.Windows.Forms.Label lbName;
    }
}
