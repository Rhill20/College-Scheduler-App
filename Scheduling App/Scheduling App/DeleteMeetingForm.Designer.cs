namespace Scheduling_App
{
    partial class DeleteMeetingForm
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
            dateTimePickerMeetingDate = new DateTimePicker();
            comboBoxMeetings = new ComboBox();
            btnDelete = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            txtUserTime = new TextBox();
            txtEasternTime = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label11 = new Label();
            SuspendLayout();
            // 
            // dateTimePickerMeetingDate
            // 
            dateTimePickerMeetingDate.Location = new Point(12, 108);
            dateTimePickerMeetingDate.Name = "dateTimePickerMeetingDate";
            dateTimePickerMeetingDate.Size = new Size(200, 23);
            dateTimePickerMeetingDate.TabIndex = 0;
            // 
            // comboBoxMeetings
            // 
            comboBoxMeetings.FormattingEnabled = true;
            comboBoxMeetings.Location = new Point(12, 174);
            comboBoxMeetings.Name = "comboBoxMeetings";
            comboBoxMeetings.Size = new Size(200, 23);
            comboBoxMeetings.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 224);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(121, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 90);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 4;
            label1.Text = "Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 156);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Meeting";
            // 
            // txtUserTime
            // 
            txtUserTime.Location = new Point(228, 108);
            txtUserTime.Name = "txtUserTime";
            txtUserTime.Size = new Size(180, 23);
            txtUserTime.TabIndex = 6;
            // 
            // txtEasternTime
            // 
            txtEasternTime.Location = new Point(228, 174);
            txtEasternTime.Name = "txtEasternTime";
            txtEasternTime.Size = new Size(180, 23);
            txtEasternTime.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(282, 90);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "Your Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(257, 156);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 9;
            label4.Text = "Company Time (EST)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 22);
            label11.Name = "label11";
            label11.Size = new Size(156, 30);
            label11.TabIndex = 31;
            label11.Text = "Delete Meeting";
            // 
            // DeleteMeetingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 273);
            Controls.Add(label11);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtEasternTime);
            Controls.Add(txtUserTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(comboBoxMeetings);
            Controls.Add(dateTimePickerMeetingDate);
            Name = "DeleteMeetingForm";
            Text = "DeleteMeetingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerMeetingDate;
        private ComboBox comboBoxMeetings;
        private Button btnDelete;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private TextBox txtUserTime;
        private TextBox txtEasternTime;
        private Label label3;
        private Label label4;
        private Label label11;
    }
}