namespace HotelManagement
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eMPLOYEEMANAGERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDEMPLOYEEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETEEMPLOYEEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cHECKTIMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eMPLOYEEMANAGERToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1442, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eMPLOYEEMANAGERToolStripMenuItem
            // 
            this.eMPLOYEEMANAGERToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.eMPLOYEEMANAGERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDEMPLOYEEToolStripMenuItem,
            this.dELETEEMPLOYEEToolStripMenuItem,
            this.cHECKTIMEToolStripMenuItem});
            this.eMPLOYEEMANAGERToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eMPLOYEEMANAGERToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.eMPLOYEEMANAGERToolStripMenuItem.Name = "eMPLOYEEMANAGERToolStripMenuItem";
            this.eMPLOYEEMANAGERToolStripMenuItem.Size = new System.Drawing.Size(228, 29);
            this.eMPLOYEEMANAGERToolStripMenuItem.Text = "EMPLOYEE MANAGER";
            // 
            // aDDEMPLOYEEToolStripMenuItem
            // 
            this.aDDEMPLOYEEToolStripMenuItem.Name = "aDDEMPLOYEEToolStripMenuItem";
            this.aDDEMPLOYEEToolStripMenuItem.Size = new System.Drawing.Size(269, 30);
            this.aDDEMPLOYEEToolStripMenuItem.Text = "ADD EMPLOYEE";
            this.aDDEMPLOYEEToolStripMenuItem.Click += new System.EventHandler(this.aDDEMPLOYEEToolStripMenuItem_Click);
            // 
            // dELETEEMPLOYEEToolStripMenuItem
            // 
            this.dELETEEMPLOYEEToolStripMenuItem.Name = "dELETEEMPLOYEEToolStripMenuItem";
            this.dELETEEMPLOYEEToolStripMenuItem.Size = new System.Drawing.Size(269, 30);
            this.dELETEEMPLOYEEToolStripMenuItem.Text = "UPDATE EMPLOYY";
            this.dELETEEMPLOYEEToolStripMenuItem.Click += new System.EventHandler(this.dELETEEMPLOYEEToolStripMenuItem_Click);
            // 
            // cHECKTIMEToolStripMenuItem
            // 
            this.cHECKTIMEToolStripMenuItem.Name = "cHECKTIMEToolStripMenuItem";
            this.cHECKTIMEToolStripMenuItem.Size = new System.Drawing.Size(269, 30);
            this.cHECKTIMEToolStripMenuItem.Text = "CHECK TIME";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 723);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eMPLOYEEMANAGERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDDEMPLOYEEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELETEEMPLOYEEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHECKTIMEToolStripMenuItem;
    }
}

