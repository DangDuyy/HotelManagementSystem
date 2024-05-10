namespace HotelManagement
{
    partial class ResetPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPass));
            this.btt_change = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.txt_confirmpass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_newpass = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // btt_change
            // 
            this.btt_change.BackColor = System.Drawing.Color.Transparent;
            this.btt_change.BorderColor = System.Drawing.Color.Transparent;
            this.btt_change.BorderRadius = 25;
            this.btt_change.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.btt_change.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_change.ForeColor = System.Drawing.Color.White;
            this.btt_change.Location = new System.Drawing.Point(368, 509);
            this.btt_change.Margin = new System.Windows.Forms.Padding(6);
            this.btt_change.Name = "btt_change";
            this.btt_change.Size = new System.Drawing.Size(329, 67);
            this.btt_change.TabIndex = 114;
            this.btt_change.Text = "Change Password";
            this.btt_change.Click += new System.EventHandler(this.btt_change_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(136, 392);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 36);
            this.label4.TabIndex = 113;
            this.label4.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(202, 302);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 36);
            this.label3.TabIndex = 112;
            this.label3.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(351, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 44);
            this.label2.TabIndex = 115;
            this.label2.Text = "Reset Password";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.BackgroundImage")));
            this.guna2CircleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2CircleButton1.BorderThickness = 2;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(442, 15);
            this.guna2CircleButton1.Margin = new System.Windows.Forms.Padding(6);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(122, 119);
            this.guna2CircleButton1.TabIndex = 116;
            // 
            // txt_confirmpass
            // 
            this.txt_confirmpass.BackColor = System.Drawing.Color.Transparent;
            this.txt_confirmpass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.txt_confirmpass.BorderRadius = 20;
            this.txt_confirmpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_confirmpass.DefaultText = "";
            this.txt_confirmpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_confirmpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_confirmpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_confirmpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_confirmpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_confirmpass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirmpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_confirmpass.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_confirmpass.IconLeft")));
            this.txt_confirmpass.IconRight = ((System.Drawing.Image)(resources.GetObject("txt_confirmpass.IconRight")));
            this.txt_confirmpass.Location = new System.Drawing.Point(498, 384);
            this.txt_confirmpass.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.txt_confirmpass.Name = "txt_confirmpass";
            this.txt_confirmpass.PasswordChar = '●';
            this.txt_confirmpass.PlaceholderText = "";
            this.txt_confirmpass.SelectedText = "";
            this.txt_confirmpass.Size = new System.Drawing.Size(436, 65);
            this.txt_confirmpass.TabIndex = 111;
            this.txt_confirmpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_confirmpass.UseSystemPasswordChar = true;
            // 
            // txt_newpass
            // 
            this.txt_newpass.BackColor = System.Drawing.Color.Transparent;
            this.txt_newpass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.txt_newpass.BorderRadius = 20;
            this.txt_newpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_newpass.DefaultText = "";
            this.txt_newpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_newpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_newpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_newpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_newpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_newpass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_newpass.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_newpass.IconLeft")));
            this.txt_newpass.IconRight = ((System.Drawing.Image)(resources.GetObject("txt_newpass.IconRight")));
            this.txt_newpass.Location = new System.Drawing.Point(498, 287);
            this.txt_newpass.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.txt_newpass.Name = "txt_newpass";
            this.txt_newpass.PasswordChar = '●';
            this.txt_newpass.PlaceholderText = "";
            this.txt_newpass.SelectedText = "";
            this.txt_newpass.Size = new System.Drawing.Size(436, 65);
            this.txt_newpass.TabIndex = 110;
            this.txt_newpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_newpass.UseSystemPasswordChar = true;
            // 
            // ResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 614);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btt_change);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_confirmpass);
            this.Controls.Add(this.txt_newpass);
            this.Name = "ResetPass";
            this.Text = "ResetPass";
            this.Load += new System.EventHandler(this.ResetPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btt_change;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_confirmpass;
        private Guna.UI2.WinForms.Guna2TextBox txt_newpass;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Label label2;
    }
}