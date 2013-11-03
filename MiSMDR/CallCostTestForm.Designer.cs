namespace MiSMDR
{
    partial class CallCostTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallCostTestForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbTestNumber = new System.Windows.Forms.TextBox();
            this.tbTestDuration = new System.Windows.Forms.TextBox();
            this.lbMatchNotice = new System.Windows.Forms.Label();
            this.picTick = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picCross = new System.Windows.Forms.PictureBox();
            this.testDataGrid = new System.Windows.Forms.DataGridView();
            this.bnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Dialled";
            // 
            // tbTestNumber
            // 
            this.tbTestNumber.Location = new System.Drawing.Point(12, 27);
            this.tbTestNumber.Name = "tbTestNumber";
            this.tbTestNumber.Size = new System.Drawing.Size(158, 20);
            this.tbTestNumber.TabIndex = 1;
            this.tbTestNumber.TextChanged += new System.EventHandler(this.tbTestNumber_TextChanged);
            // 
            // tbTestDuration
            // 
            this.tbTestDuration.Location = new System.Drawing.Point(192, 27);
            this.tbTestDuration.Name = "tbTestDuration";
            this.tbTestDuration.Size = new System.Drawing.Size(36, 20);
            this.tbTestDuration.TabIndex = 2;
            this.tbTestDuration.Text = "30";
            this.tbTestDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTestDuration.TextChanged += new System.EventHandler(this.tbTestNumber_TextChanged);
            // 
            // lbMatchNotice
            // 
            this.lbMatchNotice.AutoSize = true;
            this.lbMatchNotice.Location = new System.Drawing.Point(34, 57);
            this.lbMatchNotice.Name = "lbMatchNotice";
            this.lbMatchNotice.Size = new System.Drawing.Size(131, 14);
            this.lbMatchNotice.TabIndex = 3;
            this.lbMatchNotice.Text = "Currently does not match.";
            // 
            // picTick
            // 
            this.picTick.Image = global::MiSMDR.Properties.Resources.tick;
            this.picTick.Location = new System.Drawing.Point(12, 55);
            this.picTick.Name = "picTick";
            this.picTick.Size = new System.Drawing.Size(16, 17);
            this.picTick.TabIndex = 4;
            this.picTick.TabStop = false;
            this.picTick.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "secs";
            // 
            // picCross
            // 
            this.picCross.Image = global::MiSMDR.Properties.Resources.cross;
            this.picCross.Location = new System.Drawing.Point(12, 55);
            this.picCross.Name = "picCross";
            this.picCross.Size = new System.Drawing.Size(16, 17);
            this.picCross.TabIndex = 10;
            this.picCross.TabStop = false;
            // 
            // testDataGrid
            // 
            this.testDataGrid.AllowUserToAddRows = false;
            this.testDataGrid.AllowUserToDeleteRows = false;
            this.testDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.testDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.testDataGrid.Location = new System.Drawing.Point(12, 78);
            this.testDataGrid.MultiSelect = false;
            this.testDataGrid.Name = "testDataGrid";
            this.testDataGrid.Size = new System.Drawing.Size(248, 95);
            this.testDataGrid.TabIndex = 11;
            // 
            // bnClose
            // 
            this.bnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bnClose.Location = new System.Drawing.Point(95, 179);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(75, 25);
            this.bnClose.TabIndex = 9;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // CallCostTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(272, 209);
            this.Controls.Add(this.testDataGrid);
            this.Controls.Add(this.picCross);
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picTick);
            this.Controls.Add(this.lbMatchNotice);
            this.Controls.Add(this.tbTestDuration);
            this.Controls.Add(this.tbTestNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(280, 235);
            this.Name = "CallCostTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Call Cost Rule";
            ((System.ComponentModel.ISupportInitialize)(this.picTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTestNumber;
        private System.Windows.Forms.TextBox tbTestDuration;
        private System.Windows.Forms.Label lbMatchNotice;
        private System.Windows.Forms.PictureBox picTick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picCross;
        private System.Windows.Forms.DataGridView testDataGrid;
        private System.Windows.Forms.Button bnClose;
    }
}