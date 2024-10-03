namespace Scheduling_App
{
    partial class AppointmentTypeReportForm
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
            buttonRunReport = new Button();
            textBoxReport = new TextBox();
            label1 = new Label();
            label4 = new Label();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(27, 100);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(121, 23);
            comboBoxYear.TabIndex = 0;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(154, 100);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(121, 23);
            comboBoxMonth.TabIndex = 1;
            // 
            // buttonRunReport
            // 
            buttonRunReport.Location = new Point(307, 100);
            buttonRunReport.Name = "buttonRunReport";
            buttonRunReport.Size = new Size(75, 23);
            buttonRunReport.TabIndex = 2;
            buttonRunReport.Text = "Run Report";
            buttonRunReport.UseVisualStyleBackColor = true;
            // 
            // textBoxReport
            // 
            textBoxReport.Location = new Point(12, 140);
            textBoxReport.Multiline = true;
            textBoxReport.Name = "textBoxReport";
            textBoxReport.Size = new Size(387, 210);
            textBoxReport.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(292, 27);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(51, 42);
            label4.Name = "label4";
            label4.Size = new Size(295, 30);
            label4.TabIndex = 11;
            label4.Text = "Appointment Types By Month ";
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(337, 415);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 12;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // AppointmentTypeReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 450);
            Controls.Add(buttonExit);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(textBoxReport);
            Controls.Add(buttonRunReport);
            Controls.Add(comboBoxMonth);
            Controls.Add(comboBoxYear);
            Name = "AppointmentTypeReportForm";
            Text = "AppointmentTypeReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxYear;
        private ComboBox comboBoxMonth;
        private Button buttonRunReport;
        private TextBox textBoxReport;
        private Label label1;
        private Label label4;
        private Button buttonExit;
    }
}