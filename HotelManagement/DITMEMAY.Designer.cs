namespace HotelManagement
{
    partial class DITMEMAY
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
            this.btt_assigmentWork.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.btt_assigmentWork.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_assigmentWork.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btt_assigmentWork.Location = new System.Drawing.Point(482, 584);
            this.btt_assigmentWork.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btt_assigmentWork.Name = "btt_assigmentWork";
            this.btt_assigmentWork.Size = new System.Drawing.Size(168, 32);
            this.btt_assigmentWork.TabIndex = 137;
            this.btt_assigmentWork.Text = "Assign Work";
            this.btt_assigmentWork.Click += new System.EventHandler(this.btt_assigmentWork_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeight = 46;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(76, 17);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1111, 561);
            this.dataGridView1.TabIndex = 139;
            // 
            // DITMEMAY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 675);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btt_assigmentWork);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DITMEMAY";
            this.Text = "DITMEMAY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DITMEMAY_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btt_assigmentWork;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}