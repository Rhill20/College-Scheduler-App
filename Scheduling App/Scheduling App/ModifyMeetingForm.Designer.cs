namespace Scheduling_App
{
    partial class ModifyMeetingForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            URL = new Label();
            dateTimePickerMeetingDate = new DateTimePicker();
            comboBoxMeetings = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            Date = new Label();
            label5 = new Label();
            comboBoxCustomer = new ComboBox();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            txtLocation = new TextBox();
            txtContact = new TextBox();
            txtURL = new TextBox();
            comboBoxAppointmentType = new ComboBox();
            dateTimePickerNewMeetingDate = new DateTimePicker();
            comboBoxTimeSlots = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            label8 = new Label();
            label9 = new Label();
            txtEasternTime = new TextBox();
            txtUserTime = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 270);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 302);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 345);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Time Slots";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(285, 265);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 3;
            label4.Text = "Appointment Type";
            // 
            // URL
            // 
            URL.AutoSize = true;
            URL.Location = new Point(15, 412);
            URL.Name = "URL";
            URL.Size = new Size(28, 15);
            URL.TabIndex = 4;
            URL.Text = "URL";
            // 
            // dateTimePickerMeetingDate
            // 
            dateTimePickerMeetingDate.Location = new Point(102, 126);
            dateTimePickerMeetingDate.Name = "dateTimePickerMeetingDate";
            dateTimePickerMeetingDate.Size = new Size(200, 23);
            dateTimePickerMeetingDate.TabIndex = 5;
            // 
            // comboBoxMeetings
            // 
            comboBoxMeetings.FormattingEnabled = true;
            comboBoxMeetings.Location = new Point(130, 155);
            comboBoxMeetings.Name = "comboBoxMeetings";
            comboBoxMeetings.Size = new Size(172, 23);
            comboBoxMeetings.TabIndex = 6;
            comboBoxMeetings.SelectedIndexChanged += comboBoxMeetings_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 337);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 7;
            label6.Text = "Location";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 374);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 8;
            label7.Text = "Contact";
            // 
            // Date
            // 
            Date.AutoSize = true;
            Date.Location = new Point(285, 308);
            Date.Name = "Date";
            Date.Size = new Size(58, 15);
            Date.TabIndex = 9;
            Date.Text = "New Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 192);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "Customer";
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(130, 189);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(172, 23);
            comboBoxCustomer.TabIndex = 11;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(140, 262);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 12;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(140, 302);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(100, 23);
            txtDescription.TabIndex = 13;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(140, 337);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(100, 23);
            txtLocation.TabIndex = 14;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(140, 374);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(100, 23);
            txtContact.TabIndex = 15;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(140, 412);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(100, 23);
            txtURL.TabIndex = 16;
            // 
            // comboBoxAppointmentType
            // 
            comboBoxAppointmentType.FormattingEnabled = true;
            comboBoxAppointmentType.Location = new Point(396, 262);
            comboBoxAppointmentType.Name = "comboBoxAppointmentType";
            comboBoxAppointmentType.Size = new Size(121, 23);
            comboBoxAppointmentType.TabIndex = 17;
            // 
            // dateTimePickerNewMeetingDate
            // 
            dateTimePickerNewMeetingDate.Location = new Point(359, 302);
            dateTimePickerNewMeetingDate.Name = "dateTimePickerNewMeetingDate";
            dateTimePickerNewMeetingDate.Size = new Size(200, 23);
            dateTimePickerNewMeetingDate.TabIndex = 18;
            // 
            // comboBoxTimeSlots
            // 
            comboBoxTimeSlots.FormattingEnabled = true;
            comboBoxTimeSlots.Location = new Point(396, 337);
            comboBoxTimeSlots.Name = "comboBoxTimeSlots";
            comboBoxTimeSlots.Size = new Size(121, 23);
            comboBoxTimeSlots.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(315, 374);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(412, 374);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(319, 165);
            label8.Name = "label8";
            label8.Size = new Size(117, 15);
            label8.TabIndex = 25;
            label8.Text = "Company Time (EST)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(376, 129);
            label9.Name = "label9";
            label9.Size = new Size(60, 15);
            label9.TabIndex = 24;
            label9.Text = "Your Time";
            // 
            // txtEasternTime
            // 
            txtEasternTime.Location = new Point(442, 160);
            txtEasternTime.Name = "txtEasternTime";
            txtEasternTime.Size = new Size(180, 23);
            txtEasternTime.TabIndex = 23;
            // 
            // txtUserTime
            // 
            txtUserTime.Location = new Point(442, 126);
            txtUserTime.Name = "txtUserTime";
            txtUserTime.Size = new Size(180, 23);
            txtUserTime.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 135);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 26;
            label10.Text = "Select Date";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 163);
            label11.Name = "label11";
            label11.Size = new Size(85, 15);
            label11.TabIndex = 27;
            label11.Text = "Select Meeting";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(16, 44);
            label12.Name = "label12";
            label12.Size = new Size(167, 30);
            label12.TabIndex = 32;
            label12.Text = "Modify Meeting ";
            // 
            // ModifyMeetingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 450);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(txtEasternTime);
            Controls.Add(txtUserTime);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(comboBoxTimeSlots);
            Controls.Add(dateTimePickerNewMeetingDate);
            Controls.Add(comboBoxAppointmentType);
            Controls.Add(txtURL);
            Controls.Add(txtContact);
            Controls.Add(txtLocation);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(comboBoxCustomer);
            Controls.Add(label5);
            Controls.Add(Date);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBoxMeetings);
            Controls.Add(dateTimePickerMeetingDate);
            Controls.Add(URL);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModifyMeetingForm";
            Text = "AppointmentManagerForm";
            Load += ModifyMeetingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label URL;
        private DateTimePicker dateTimePickerMeetingDate;
        private ComboBox comboBoxMeetings;
        private Label label6;
        private Label label7;
        private Label Date;
        private Label label5;
        private ComboBox comboBoxCustomer;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtLocation;
        private TextBox txtContact;
        private TextBox txtURL;
        private ComboBox comboBoxAppointmentType;
        private DateTimePicker dateTimePickerNewMeetingDate;
        private ComboBox comboBoxTimeSlots;
        private Button btnSave;
        private Button btnCancel;
        private Label label8;
        private Label label9;
        private TextBox txtEasternTime;
        private TextBox txtUserTime;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}