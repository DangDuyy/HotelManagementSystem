namespace HotelManagement
{
    partial class AssigmentForQLvaNV
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
            this.btt_assigmentWork = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btt_assigmentWork
            // 
            this.btt_assigmentWork.BackColor = System.Drawing.Color.Transparent;
            this.btt_assigmentWork.BorderRadius = 20;
            this.btt_assigmentWork.BorderThickness = 1;
            this.btt_assigmentWork.DefaultAutoSize = true;
            this.btt_assigmentWork.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.btt_assigmentWork.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_assigmentWork.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btt_assigmentWork.Location = new System.Drawing.Point(720, 925);
            this.btt_assigmentWork.Margin = new System.Windows.Forms.Padding(6);
            this.btt_assigmentWork.Name = "btt_assigmentWork";
            this.btt_assigmentWork.Size = new System.Drawing.Size(252, 50);
            this.btt_assigmentWork.TabIndex = 138;
            this.btt_assigmentWork.Text = "Assign Work";
            this.btt_assigmentWork.Click += new System.EventHandler(this.btt_assigmentWork_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeight = 46;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1667, 876);
            this.dataGridView1.TabIndex = 140;
            // 
            // AssigmentForQLvaNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 1173);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btt_assigmentWork);
            this.Name = "AssigmentForQLvaNV";
            this.Text = "AssigmentForQLvaNV";
            this.Load += new System.EventHandler(this.AssigmentForQLvaNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btt_assigmentWork;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}