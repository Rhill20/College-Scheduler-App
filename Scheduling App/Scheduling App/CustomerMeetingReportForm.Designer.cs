namespace Scheduling_App
{
    partial class CustomerMeetingReportForm
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
            label4 = new Label();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(12, 110);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(121, 23);
            comboBoxYear.TabIndex = 0;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(139, 110);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(121, 23);
            comboBoxMonth.TabIndex = 1;
            // 
            // buttonRunReport
            // 
            buttonRunReport.Location = new Point(266, 109);
            buttonRunReport.Name = "buttonRunReport";
            buttonRunReport.Size = new Size(75, 23);
            buttonRunReport.TabIndex = 2;
            buttonRunReport.Text = "Run Report";
            buttonRunReport.UseVisualStyleBackColor = true;
            // 
            // textBoxReport
            // 
            textBoxReport.Location = new Point(12, 139);
            textBoxReport.Multiline = true;
            textBoxReport.Name = "textBoxReport";
            textBoxReport.Size = new Size(329, 201);
            textBoxReport.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 40);
            label4.Name = "label4";
            label4.Size = new Size(296, 30);
            label4.TabIndex = 12;
            label4.Text = "Customer Meetings By Month ";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(255, 363);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 13;
            buttonClose.Text = "Exit";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // CustomerMeetingReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 450);
            Controls.Add(buttonClose);
            Controls.Add(label4);
            Controls.Add(textBoxReport);
            Controls.Add(buttonRunReport);
            Controls.Add(comboBoxMonth);
            Controls.Add(comboBoxYear);
            Name = "CustomerMeetingReportForm";
            Text = "CustomerMeetingReportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxYear;
        private ComboBox comboBoxMonth;
        private Button buttonRunReport;
        private TextBox textBoxReport;
        private Label label4;
        private Button buttonClose;
    }
}