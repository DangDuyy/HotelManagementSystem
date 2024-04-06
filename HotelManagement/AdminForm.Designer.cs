namespace HotelManagement
{
    partial class AdminForm
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
            this.panel_Son = new System.Windows.Forms.Panel();
            this.btt_Update = new System.Windows.Forms.Button();
            this.btt_AddEmployee = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_Father = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_Father.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Son
            // 
            this.panel_Son.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Son.BackColor = System.Drawing.Color.White;
            this.panel_Son.Location = new System.Drawing.Point(133, 3);
            this.panel_Son.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Son.Name = "panel_Son";
            this.panel_Son.Size = new System.Drawing.Size(720, 529);
            this.panel_Son.TabIndex = 3;
            // 
            // btt_Update
            // 
            this.btt_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btt_Update.Location = new System.Drawing.Point(2, 209);
            this.btt_Update.Margin = new System.Windows.Forms.Padding(2);
            this.btt_Update.Name = "btt_Update";
            this.btt_Update.Size = new System.Drawing.Size(109, 54);
            this.btt_Update.TabIndex = 3;
            this.btt_Update.Text = "UPDATE";
            this.btt_Update.UseVisualStyleBackColor = false;
            // 
            // btt_AddEmployee
            // 
            this.btt_AddEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btt_AddEmployee.Location = new System.Drawing.Point(2, 145);
            this.btt_AddEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btt_AddEmployee.Name = "btt_AddEmployee";
            this.btt_AddEmployee.Size = new System.Drawing.Size(109, 60);
            this.btt_AddEmployee.TabIndex = 0;
            this.btt_AddEmployee.Text = "ADD";
            this.btt_AddEmployee.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(115, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 64);
            this.panel2.TabIndex = 1;
            // 
            // panel_Father
            // 
            this.panel_Father.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Father.BackColor = System.Drawing.Color.IndianRed;
            this.panel_Father.Controls.Add(this.pictureBox1);
            this.panel_Father.Controls.Add(this.btt_Update);
            this.panel_Father.Controls.Add(this.btt_AddEmployee);
            this.panel_Father.Controls.Add(this.panel2);
            this.panel_Father.Location = new System.Drawing.Point(18, 1);
            this.panel_Father.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Father.Name = "panel_Father";
            this.panel_Father.Size = new System.Drawing.Size(111, 533);
            this.panel_Father.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources._258768692_5086046671424593_4224393960284543308_n3;
            this.pictureBox1.Location = new System.Drawing.Point(2, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 534);
            this.Controls.Add(this.panel_Son);
            this.Controls.Add(this.panel_Father);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.panel_Father.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Son;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btt_Update;
        private System.Windows.Forms.Button btt_AddEmployee;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_Father;
    }
}