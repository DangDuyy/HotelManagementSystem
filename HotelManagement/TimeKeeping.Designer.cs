namespace HotelManagement
{
    partial class TimeKeeping
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
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lb_welcome = new System.Windows.Forms.Label();
            this.btt_checkintime = new Guna.UI2.WinForms.Guna2Button();
            this.btt_checkouttime = new Guna.UI2.WinForms.Guna2Button();
            this.datetimeCheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.quanLyKhachSanDataSet14 = new HotelManagement.QuanLyKhachSanDataSet14();
            this.timekeepingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timekeepingTableAdapter = new HotelManagement.QuanLyKhachSanDataSet14TableAdapters.timekeepingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timekeepingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(752, 322);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(359, 130);
            this.guna2DateTimePicker1.TabIndex = 0;
            this.guna2DateTimePicker1.Value = new System.DateTime(2024, 5, 5, 12, 32, 25, 416);
            this.guna2DateTimePicker1.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // lb_welcome
            // 
            this.lb_welcome.AutoSize = true;
            this.lb_welcome.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_welcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.lb_welcome.Location = new System.Drawing.Point(240, 201);
            this.lb_welcome.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lb_welcome.Name = "lb_welcome";
            this.lb_welcome.Size = new System.Drawing.Size(92, 36);
            this.lb_welcome.TabIndex = 122;
            this.lb_welcome.Text = "label";
            // 
            // btt_checkintime
            // 
            this.btt_checkintime.BackColor = System.Drawing.Color.Transparent;
            this.btt_checkintime.BorderColor = System.Drawing.Color.Transparent;
            this.btt_checkintime.BorderRadius = 25;
            this.btt_checkintime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.btt_checkintime.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_checkintime.ForeColor = System.Drawing.Color.White;
            this.btt_checkintime.Location = new System.Drawing.Point(472, 717);
            this.btt_checkintime.Margin = new System.Windows.Forms.Padding(6);
            this.btt_checkintime.Name = "btt_checkintime";
            this.btt_checkintime.Size = new System.Drawing.Size(208, 121);
            this.btt_checkintime.TabIndex = 134;
            this.btt_checkintime.Text = "Check In";
            this.btt_checkintime.Click += new System.EventHandler(this.btt_checkintime_Click);
            // 
            // btt_checkouttime
            // 
            this.btt_checkouttime.BackColor = System.Drawing.Color.Transparent;
            this.btt_checkouttime.BorderColor = System.Drawing.Color.Transparent;
            this.btt_checkouttime.BorderRadius = 25;
            this.btt_checkouttime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.btt_checkouttime.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_checkouttime.ForeColor = System.Drawing.Color.White;
            this.btt_checkouttime.Location = new System.Drawing.Point(957, 717);
            this.btt_checkouttime.Margin = new System.Windows.Forms.Padding(6);
            this.btt_checkouttime.Name = "btt_checkouttime";
            this.btt_checkouttime.Size = new System.Drawing.Size(229, 121);
            this.btt_checkouttime.TabIndex = 135;
            this.btt_checkouttime.Text = "Check Out";
            this.btt_checkouttime.Click += new System.EventHandler(this.btt_checkouttime_Click);
            // 
            // datetimeCheckOut
            // 
            this.datetimeCheckOut.Checked = true;
            this.datetimeCheckOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.datetimeCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimeCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.datetimeCheckOut.Location = new System.Drawing.Point(455, 322);
            this.datetimeCheckOut.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datetimeCheckOut.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datetimeCheckOut.Name = "datetimeCheckOut";
            this.datetimeCheckOut.Size = new System.Drawing.Size(291, 130);
            this.datetimeCheckOut.TabIndex = 137;
            this.datetimeCheckOut.Value = new System.DateTime(2024, 5, 5, 12, 32, 25, 416);
            // 
            // quanLyKhachSanDataSet14
            // 
            this.quanLyKhachSanDataSet14.DataSetName = "QuanLyKhachSanDataSet14";
            this.quanLyKhachSanDataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timekeepingBindingSource
            // 
            this.timekeepingBindingSource.DataMember = "timekeeping";
            this.timekeepingBindingSource.DataSource = this.quanLyKhachSanDataSet14;
            // 
            // timekeepingTableAdapter
            // 
            this.timekeepingTableAdapter.ClearBeforeFill = true;
            // 
            // TimeKeeping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1681, 1058);
            this.Controls.Add(this.datetimeCheckOut);
            this.Controls.Add(this.btt_checkouttime);
            this.Controls.Add(this.btt_checkintime);
            this.Controls.Add(this.lb_welcome);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Name = "TimeKeeping";
            this.Text = "TimeKeeping";
            this.Load += new System.EventHandler(this.TimeKeeping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timekeepingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private System.Windows.Forms.Label lb_welcome;
        private Guna.UI2.WinForms.Guna2Button btt_checkintime;
        private Guna.UI2.WinForms.Guna2Button btt_checkouttime;
        private Guna.UI2.WinForms.Guna2DateTimePicker datetimeCheckOut;
        private QuanLyKhachSanDataSet14 quanLyKhachSanDataSet14;
        private System.Windows.Forms.BindingSource timekeepingBindingSource;
        private QuanLyKhachSanDataSet14TableAdapters.timekeepingTableAdapter timekeepingTableAdapter;
    }
}