namespace Scheduling_App
{
    partial class Home
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
            Addcust = new Button();
            Updatecus = new Button();
            Deletecus = new Button();
            label4 = new Label();
            dataGridViewCalendar = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            buttonAppTypesReport = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            button6 = new Button();
            button5 = new Button();
            label2 = new Label();
            dateTimePickerDay = new DateTimePicker();
            comboBoxMonth = new ComboBox();
            comboBoxYear = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCalendar).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // Addcust
            // 
            Addcust.Location = new Point(69, 81);
            Addcust.Name = "Addcust";
            Addcust.Size = new Size(111, 23);
            Addcust.TabIndex = 0;
            Addcust.Text = "Add Customer";
            Addcust.UseVisualStyleBackColor = true;
            Addcust.Click += Addcust_Click;
            // 
            // Updatecus
            // 
            Updatecus.Location = new Point(69, 129);
            Updatecus.Name = "Updatecus";
            Updatecus.Size = new Size(111, 23);
            Updatecus.TabIndex = 1;
            Updatecus.Text = "Update Customer ";
            Updatecus.UseVisualStyleBackColor = true;
            Updatecus.Click += Updatecus_Click;
            // 
            // Deletecus
            // 
            Deletecus.Location = new Point(69, 180);
            Deletecus.Name = "Deletecus";
            Deletecus.Size = new Size(111, 23);
            Deletecus.TabIndex = 2;
            Deletecus.Text = "Delete Customer";
            Deletecus.UseVisualStyleBackColor = true;
            Deletecus.Click += Deletecus_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 16);
            label4.Name = "label4";
            label4.Size = new Size(181, 30);
            label4.TabIndex = 11;
            label4.Text = "Customer Options";
            // 
            // dataGridViewCalendar
            // 
            dataGridViewCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCalendar.Location = new Point(28, 151);
            dataGridViewCalendar.MultiSelect = false;
            dataGridViewCalendar.Name = "dataGridViewCalendar";
            dataGridViewCalendar.ReadOnly = true;
            dataGridViewCalendar.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewCalendar.Size = new Size(925, 513);
            dataGridViewCalendar.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(69, 74);
            button1.Name = "button1";
            button1.Size = new Size(111, 23);
            button1.TabIndex = 13;
            button1.Text = "Add Meeting";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonAddMeeting_Click;
            // 
            // button2
            // 
            button2.Location = new Point(69, 133);
            button2.Name = "button2";
            button2.Size = new Size(111, 23);
            button2.TabIndex = 14;
            button2.Text = "Update Meeting";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonModMeeting_Click;
            // 
            // button3
            // 
            button3.Location = new Point(69, 184);
            button3.Name = "button3";
            button3.Size = new Size(111, 23);
            button3.TabIndex = 15;
            button3.Text = "Delete Meeting";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonDeleteMeeting_Click;
            // 
            // buttonAppTypesReport
            // 
            buttonAppTypesReport.Location = new Point(29, 88);
            buttonAppTypesReport.Name = "buttonAppTypesReport";
            buttonAppTypesReport.Size = new Size(221, 23);
            buttonAppTypesReport.TabIndex = 16;
            buttonAppTypesReport.Text = "Number Of Appointment Types";
            buttonAppTypesReport.UseVisualStyleBackColor = true;
            buttonAppTypesReport.Click += buttonAppTypesReport_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(959, 151);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(289, 517);
            tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(281, 489);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Meeting Optons";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 21);
            label1.Name = "label1";
            label1.Size = new Size(169, 30);
            label1.TabIndex = 19;
            label1.Text = "Meeting Options";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(Addcust);
            tabPage2.Controls.Add(Updatecus);
            tabPage2.Controls.Add(Deletecus);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(281, 489);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Customer Options";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(buttonAppTypesReport);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(281, 489);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Reports";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(29, 222);
            button6.Name = "button6";
            button6.Size = new Size(221, 23);
            button6.TabIndex = 22;
            button6.Text = "Number Of Meeting By Customer";
            button6.UseVisualStyleBackColor = true;
            button6.Click += buttonCustReport_Click;
            // 
            // button5
            // 
            button5.Location = new Point(29, 156);
            button5.Name = "button5";
            button5.Size = new Size(221, 23);
            button5.TabIndex = 21;
            button5.Text = "User Schedules";
            button5.UseVisualStyleBackColor = true;
            button5.Click += buttonUserReport_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(77, 14);
            label2.Name = "label2";
            label2.Size = new Size(83, 30);
            label2.TabIndex = 20;
            label2.Text = "Reports";
            // 
            // dateTimePickerDay
            // 
            dateTimePickerDay.Location = new Point(282, 122);
            dateTimePickerDay.Name = "dateTimePickerDay";
            dateTimePickerDay.Size = new Size(200, 23);
            dateTimePickerDay.TabIndex = 19;
            dateTimePickerDay.ValueChanged += DateTimePickerDay_ValueChanged;
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Location = new Point(155, 122);
            comboBoxMonth.Name = "comboBoxMonth";
            comboBoxMonth.Size = new Size(121, 23);
            comboBoxMonth.TabIndex = 20;
            comboBoxMonth.SelectedIndexChanged += ComboBoxMonth_SelectedIndexChanged;
            // 
            // comboBoxYear
            // 
            comboBoxYear.FormattingEnabled = true;
            comboBoxYear.Location = new Point(28, 122);
            comboBoxYear.Name = "comboBoxYear";
            comboBoxYear.Size = new Size(121, 23);
            comboBoxYear.TabIndex = 21;
            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 104);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 22;
            label3.Text = "Select Year";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(155, 104);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 23;
            label5.Text = "Select Month";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(282, 104);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 24;
            label6.Text = "Select Day";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(28, 9);
            label7.Name = "label7";
            label7.Size = new Size(183, 32);
            label7.TabIndex = 25;
            label7.Text = "Scheduling App";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 706);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(comboBoxYear);
            Controls.Add(comboBoxMonth);
            Controls.Add(dateTimePickerDay);
            Controls.Add(tabControl1);
            Controls.Add(dataGridViewCalendar);
            Name = "Home";
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCalendar).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Addcust;
        private Button Updatecus;
        private Button Deletecus;
        private Label label4;
        private DataGridView dataGridViewCalendar;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button buttonAppTypesReport;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerDay;
        private ComboBox comboBoxMonth;
        private ComboBox comboBoxYear;
        private Label label3;
        private Label label5;
        private Label label6;
        private Button button6;
        private Button button5;
        private Label label7;
    }
}