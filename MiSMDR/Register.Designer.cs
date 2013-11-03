namespace MiSMDR
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_register = new System.Windows.Forms.Button();
            this.tb_licencekey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bn_later = new System.Windows.Forms.Button();
            this.bn_buy = new System.Windows.Forms.Button();
            this.lb_registered = new System.Windows.Forms.Label();
            this.bn_exit = new System.Windows.Forms.Button();
            this.rtb_status = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.Location = new System.Drawing.Point(90, 20);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(281, 20);
            this.tb_name.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Owner:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bn_register
            // 
            this.bn_register.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bn_register.Enabled = false;
            this.bn_register.Location = new System.Drawing.Point(294, 167);
            this.bn_register.Name = "bn_register";
            this.bn_register.Size = new System.Drawing.Size(78, 25);
            this.bn_register.TabIndex = 17;
            this.bn_register.Text = "Register";
            this.bn_register.UseVisualStyleBackColor = true;
            this.bn_register.Click += new System.EventHandler(this.bn_register_Click);
            // 
            // tb_licencekey
            // 
            this.tb_licencekey.AllowDrop = true;
            this.tb_licencekey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_licencekey.Location = new System.Drawing.Point(91, 46);
            this.tb_licencekey.Multiline = true;
            this.tb_licencekey.Name = "tb_licencekey";
            this.tb_licencekey.Size = new System.Drawing.Size(281, 90);
            this.tb_licencekey.TabIndex = 16;
            this.tb_licencekey.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.tb_licencekey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tb_licencekey_MouseUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "License Key:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bn_later
            // 
            this.bn_later.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bn_later.Location = new System.Drawing.Point(210, 167);
            this.bn_later.Name = "bn_later";
            this.bn_later.Size = new System.Drawing.Size(78, 25);
            this.bn_later.TabIndex = 25;
            this.bn_later.Text = "Later";
            this.bn_later.UseVisualStyleBackColor = true;
            this.bn_later.Visible = false;
            this.bn_later.Click += new System.EventHandler(this.bn_later_Click);
            // 
            // bn_buy
            // 
            this.bn_buy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bn_buy.Location = new System.Drawing.Point(7, 167);
            this.bn_buy.Name = "bn_buy";
            this.bn_buy.Size = new System.Drawing.Size(78, 25);
            this.bn_buy.TabIndex = 26;
            this.bn_buy.Text = "Buy Online";
            this.bn_buy.UseVisualStyleBackColor = true;
            this.bn_buy.Click += new System.EventHandler(this.bn_buy_Click);
            // 
            // lb_registered
            // 
            this.lb_registered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_registered.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_registered.ForeColor = System.Drawing.Color.Red;
            this.lb_registered.Location = new System.Drawing.Point(91, 142);
            this.lb_registered.Name = "lb_registered";
            this.lb_registered.Size = new System.Drawing.Size(281, 23);
            this.lb_registered.TabIndex = 24;
            this.lb_registered.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bn_exit
            // 
            this.bn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bn_exit.Location = new System.Drawing.Point(90, 167);
            this.bn_exit.Name = "bn_exit";
            this.bn_exit.Size = new System.Drawing.Size(78, 25);
            this.bn_exit.TabIndex = 28;
            this.bn_exit.Text = "Exit MiSMDR";
            this.bn_exit.UseVisualStyleBackColor = true;
            this.bn_exit.Visible = false;
            this.bn_exit.Click += new System.EventHandler(this.bn_exit_Click);
            // 
            // rtb_status
            // 
            this.rtb_status.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_status.Location = new System.Drawing.Point(12, 23);
            this.rtb_status.Name = "rtb_status";
            this.rtb_status.ReadOnly = true;
            this.rtb_status.Size = new System.Drawing.Size(366, 43);
            this.rtb_status.TabIndex = 29;
            this.rtb_status.Text = "";
            this.rtb_status.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb_status_LinkClicked);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 204);
            this.ControlBox = false;
            this.Controls.Add(this.bn_exit);
            this.Controls.Add(this.bn_buy);
            this.Controls.Add(this.bn_later);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bn_register);
            this.Controls.Add(this.tb_licencekey);
            this.Controls.Add(this.lb_registered);
            this.Controls.Add(this.rtb_status);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(392, 238);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MiSMDR Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Register_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_register;
        private System.Windows.Forms.TextBox tb_licencekey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bn_later;
        private System.Windows.Forms.Button bn_buy;
        private System.Windows.Forms.Label lb_registered;
        private System.Windows.Forms.Button bn_exit;
        private System.Windows.Forms.RichTextBox rtb_status;
    }
}