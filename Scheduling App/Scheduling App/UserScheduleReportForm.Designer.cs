namespace Scheduling_App
{
    partial class UserScheduleReportForm
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
            comboBoxYear = new ComboBox();
            comboBoxMonth = new ComboBox();
            comboBoxUser = new ComboBox();
            buttonRunReport = new Button();
            textBoxReport = new RichTextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(159, 106);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(121, 23);
            comboBoxYear.TabIndex = 0;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(12, 106);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(121, 23);
            comboBoxMonth.TabIndex = 1;
            // 
            // comboBoxUser
            // 
            comboBoxUser.FormattingEnabled = true;
            comboBoxUser.Location = new Point(302, 106);
            comboBoxUser.Name = "comboBoxUser";
            comboBoxUser.Size = new Size(121, 23);
            comboBoxUser.TabIndex = 2;
            // 
            // buttonRunReport
            // 
            buttonRunReport.Location = new Point(455, 106);
            buttonRunReport.Name = "buttonRunReport";
            buttonRunReport.Size = new Size(75, 23);
            buttonRunReport.TabIndex = 4;
            buttonRunReport.Text = "Run Report";
            buttonRunReport.UseVisualStyleBackColor = true;
            // 
            // textBoxReport
            // 
            textBoxReport.Location = new Point(12, 166);
            textBoxReport.Name = "textBoxReport";
            textBoxReport.ReadOnly = true;
            textBoxReport.Size = new Size(518, 246);
            textBoxReport.TabIndex = 5;
            textBoxReport.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 45);
            label4.Name = "label4";
            label4.Size = new Size(242, 30);
            label4.TabIndex = 13;
            label4.Text = "Monthly User Schedules ";
            // 
            // UserScheduleReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 450);
            Controls.Add(label4);
            Controls.Add(textBoxReport);
            Controls.Add(buttonRunReport);
            Controls.Add(comboBoxUser);
            Controls.Add(comboBoxMonth);
            Controls.Add(comboBoxYear);
            Name = "UserScheduleReportForm";
            Text = "UserScheduleReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxYear;
        private ComboBox comboBoxMonth;
        private ComboBox comboBoxUser;
        private Button buttonRunReport;
        private RichTextBox textBoxReport;
        private Label label4;
    }
}