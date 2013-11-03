namespace MiSMDR
{
    partial class Licensing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Licensing));
            this.bn_ChangeLicense = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_expiry = new System.Windows.Forms.TextBox();
            this.tb_reseller = new System.Windows.Forms.TextBox();
            this.bn_OK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bn_ChangeLicense
            // 
            this.bn_ChangeLicense.Location = new System.Drawing.Point(12, 160);
            this.bn_ChangeLicense.Name = "bn_ChangeLicense";
            this.bn_ChangeLicense.Size = new System.Drawing.Size(96, 23);
            this.bn_ChangeLicense.TabIndex = 0;
            this.bn_ChangeLicense.Text = "Change License";
            this.bn_ChangeLicense.UseVisualStyleBackColor = true;
            this.bn_ChangeLicense.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Licensed to:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Expiry Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Reseller:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_name
            // 
            this.tb_name.Enabled = false;
            this.tb_name.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.Location = new System.Drawing.Point(129, 27);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(224, 20);
            this.tb_name.TabIndex = 10;
            // 
            // tb_expiry
            // 
            this.tb_expiry.Enabled = false;
            this.tb_expiry.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_expiry.Location = new System.Drawing.Point(129, 54);
            this.tb_expiry.Name = "tb_expiry";
            this.tb_expiry.Size = new System.Drawing.Size(116, 20);
            this.tb_expiry.TabIndex = 11;
            // 
            // tb_reseller
            // 
            this.tb_reseller.Enabled = false;
            this.tb_reseller.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_reseller.Location = new System.Drawing.Point(129, 81);
            this.tb_reseller.Name = "tb_reseller";
            this.tb_reseller.Size = new System.Drawing.Size(224, 20);
            this.tb_reseller.TabIndex = 12;
            // 
            // bn_OK
            // 
            this.bn_OK.Location = new System.Drawing.Point(267, 160);
            this.bn_OK.Name = "bn_OK";
            this.bn_OK.Size = new System.Drawing.Size(75, 23);
            this.bn_OK.TabIndex = 13;
            this.bn_OK.Text = "OK";
            this.bn_OK.UseVisualStyleBackColor = true;
            this.bn_OK.Click += new System.EventHandler(this.bn_OK_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_type);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tb_reseller);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_expiry);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_name);
            this.panel1.Location = new System.Drawing.Point(-14, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 150);
            this.panel1.TabIndex = 14;
            // 
            // tb_type
            // 
            this.tb_type.Enabled = false;
            this.tb_type.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_type.Location = new System.Drawing.Point(129, 109);
            this.tb_type.Name = "tb_type";
            this.tb_type.Size = new System.Drawing.Size(224, 20);
            this.tb_type.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "License Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Licensing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 197);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bn_OK);
            this.Controls.Add(this.bn_ChangeLicense);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Licensing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bn_ChangeLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_expiry;
        private System.Windows.Forms.TextBox tb_reseller;
        private System.Windows.Forms.Button bn_OK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.Label label4;
    }
}