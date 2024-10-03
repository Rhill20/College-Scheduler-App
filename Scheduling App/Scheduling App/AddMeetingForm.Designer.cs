namespace Scheduling_App
{
    partial class AddMeetingForm
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
            comboBoxCustomer = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            Description = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            txtLocation = new TextBox();
            txtContact = new TextBox();
            txtURL = new TextBox();
            comboBoxType = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            dateTimePickerDate = new DateTimePicker();
            comboBoxTimeSlot = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            txtEasternTime = new TextBox();
            txtUserTime = new TextBox();
            label11 = new Label();
            SuspendLayout();
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(142, 145);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(121, 23);
            comboBoxCustomer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 150);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "Customer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 195);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Title";
            // 
            // Description
            // 
            Description.AutoSize = true;
            Description.Location = new Point(53, 230);
            Description.Name = "Description";
            Description.Size = new Size(67, 15);
            Description.TabIndex = 3;
            Description.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 272);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Location";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 317);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 5;
            label4.Text = "Contact";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(295, 153);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 6;
            label5.Text = "Type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(298, 188);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 7;
            label6.Text = "URL";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(298, 227);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 10;
            label7.Text = "Date";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(298, 267);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 11;
            label8.Text = "Time Slot";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(142, 188);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 12;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(142, 227);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(100, 23);
            txtDescription.TabIndex = 13;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(142, 269);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(100, 23);
            txtLocation.TabIndex = 14;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(142, 314);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(100, 23);
            txtContact.TabIndex = 15;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(394, 185);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(100, 23);
            txtURL.TabIndex = 16;
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(394, 150);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(121, 23);
            comboBoxType.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(309, 317);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(440, 317);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(335, 224);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(221, 23);
            dateTimePickerDate.TabIndex = 20;
            // 
            // comboBoxTimeSlot
            // 
            comboBoxTimeSlot.FormattingEnabled = true;
            comboBoxTimeSlot.Location = new Point(394, 264);
            comboBoxTimeSlot.Name = "comboBoxTimeSlot";
            comboBoxTimeSlot.Size = new Size(121, 23);
            comboBoxTimeSlot.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(363, 89);
            label9.Name = "label9";
            label9.Size = new Size(117, 15);
            label9.TabIndex = 29;
            label9.Text = "Company Time (EST)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(127, 89);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 28;
            label10.Text = "Your Time";
            // 
            // txtEasternTime
            // 
            txtEasternTime.Location = new Point(335, 107);
            txtEasternTime.Name = "txtEasternTime";
            txtEasternTime.Size = new Size(180, 23);
            txtEasternTime.TabIndex = 27;
            // 
            // txtUserTime
            // 
            txtUserTime.Location = new Point(72, 107);
            txtUserTime.Name = "txtUserTime";
            txtUserTime.Size = new Size(180, 23);
            txtUserTime.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(201, 30);
            label11.Name = "label11";
            label11.Size = new Size(182, 30);
            label11.TabIndex = 30;
            label11.Text = "Add New Meeting";
            // 
            // AddMeetingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 376);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(txtEasternTime);
            Controls.Add(txtUserTime);
            Controls.Add(comboBoxTimeSlot);
            Controls.Add(dateTimePickerDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(comboBoxType);
            Controls.Add(txtURL);
            Controls.Add(txtContact);
            Controls.Add(txtLocation);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Description);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxCustomer);
            Name = "AddMeetingForm";
            Text = "AddMeetingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCustomer;
        private Label label1;
        private Label label2;
        private Label Description;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtLocation;
        private TextBox txtContact;
        private TextBox txtURL;
        private ComboBox comboBoxType;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dateTimePickerDate;
        private ComboBox comboBoxTimeSlot;
        private Label label9;
        private Label label10;
        private TextBox txtEasternTime;
        private TextBox txtUserTime;
        private Label label11;
    }
}