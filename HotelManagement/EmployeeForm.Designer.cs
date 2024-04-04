namespace HotelManagement
{
    partial class EmployeeForm
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabEditEmployee = new System.Windows.Forms.TabControl();
            this.tabAddEmployee = new System.Windows.Forms.TabPage();
            this.tabDeleteEmployee = new System.Windows.Forms.TabPage();
            this.tabCheckIn = new System.Windows.Forms.TabPage();
            this.tabCheckOut = new System.Windows.Forms.TabPage();
            this.tabShift = new System.Windows.Forms.TabPage();
            this.tabEditEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1209, 563);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Edit Customer";
            // 
            // tabEditEmployee
            // 
            this.tabEditEmployee.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabEditEmployee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabEditEmployee.Controls.Add(this.tabAddEmployee);
            this.tabEditEmployee.Controls.Add(this.tabDeleteEmployee);
            this.tabEditEmployee.Controls.Add(this.tabPage3);
            this.tabEditEmployee.Controls.Add(this.tabCheckIn);
            this.tabEditEmployee.Controls.Add(this.tabCheckOut);
            this.tabEditEmployee.Controls.Add(this.tabShift);
            this.tabEditEmployee.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEditEmployee.Location = new System.Drawing.Point(81, 82);
            this.tabEditEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabEditEmployee.Name = "tabEditEmployee";
            this.tabEditEmployee.SelectedIndex = 0;
            this.tabEditEmployee.Size = new System.Drawing.Size(1217, 597);
            this.tabEditEmployee.TabIndex = 1;
            // 
            // tabAddEmployee
            // 
            this.tabAddEmployee.BackColor = System.Drawing.Color.White;
            this.tabAddEmployee.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAddEmployee.Location = new System.Drawing.Point(4, 4);
            this.tabAddEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabAddEmployee.Name = "tabAddEmployee";
            this.tabAddEmployee.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabAddEmployee.Size = new System.Drawing.Size(1209, 563);
            this.tabAddEmployee.TabIndex = 0;
            this.tabAddEmployee.Text = "Add Employee";
            // 
            // tabDeleteEmployee
            // 
            this.tabDeleteEmployee.BackColor = System.Drawing.Color.White;
            this.tabDeleteEmployee.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDeleteEmployee.Location = new System.Drawing.Point(4, 4);
            this.tabDeleteEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDeleteEmployee.Name = "tabDeleteEmployee";
            this.tabDeleteEmployee.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDeleteEmployee.Size = new System.Drawing.Size(1209, 563);
            this.tabDeleteEmployee.TabIndex = 1;
            this.tabDeleteEmployee.Text = "Delete Employee";
            // 
            // tabCheckIn
            // 
            this.tabCheckIn.Location = new System.Drawing.Point(4, 4);
            this.tabCheckIn.Name = "tabCheckIn";
            this.tabCheckIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckIn.Size = new System.Drawing.Size(1209, 563);
            this.tabCheckIn.TabIndex = 3;
            this.tabCheckIn.Text = "Check In";
            this.tabCheckIn.UseVisualStyleBackColor = true;
            // 
            // tabCheckOut
            // 
            this.tabCheckOut.Location = new System.Drawing.Point(4, 4);
            this.tabCheckOut.Name = "tabCheckOut";
            this.tabCheckOut.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckOut.Size = new System.Drawing.Size(1209, 563);
            this.tabCheckOut.TabIndex = 4;
            this.tabCheckOut.Text = "Check Out";
            this.tabCheckOut.UseVisualStyleBackColor = true;
            // 
            // tabShift
            // 
            this.tabShift.Location = new System.Drawing.Point(4, 4);
            this.tabShift.Name = "tabShift";
            this.tabShift.Padding = new System.Windows.Forms.Padding(3);
            this.tabShift.Size = new System.Drawing.Size(1209, 563);
            this.tabShift.TabIndex = 5;
            this.tabShift.Text = "Shift";
            this.tabShift.UseVisualStyleBackColor = true;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 760);
            this.Controls.Add(this.tabEditEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.tabEditEmployee.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabEditEmployee;
        private System.Windows.Forms.TabPage tabAddEmployee;
        private System.Windows.Forms.TabPage tabDeleteEmployee;
        private System.Windows.Forms.TabPage tabCheckIn;
        private System.Windows.Forms.TabPage tabCheckOut;
        private System.Windows.Forms.TabPage tabShift;
    }
}