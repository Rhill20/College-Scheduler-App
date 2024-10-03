namespace Scheduling_App
{
    partial class AddCustomerForm
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
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxCountry = new ComboBox();
            comboBoxCity = new ComboBox();
            txtCustomerID = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 128);
            txtName.Name = "txtName";
            txtName.Size = new Size(143, 23);
            txtName.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(160, 171);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(143, 23);
            txtAddress.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(160, 215);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(143, 23);
            txtPhone.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(87, 324);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(182, 324);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 131);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 7;
            label1.Text = "Customer Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 174);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 8;
            label2.Text = "Customer Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 218);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 9;
            label3.Text = "Customer Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(99, 34);
            label4.Name = "label4";
            label4.Size = new Size(146, 30);
            label4.TabIndex = 10;
            label4.Text = "Add Customer";
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(41, 279);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(121, 23);
            comboBoxCountry.TabIndex = 11;
            // 
            // comboBoxCity
            // 
            comboBoxCity.FormattingEnabled = true;
            comboBoxCity.Location = new Point(182, 279);
            comboBoxCity.Name = "comboBoxCity";
            comboBoxCity.Size = new Size(121, 23);
            comboBoxCity.TabIndex = 12;
            // 
            // txtCustomerID
            // 
            txtCustomerID.Location = new Point(160, 89);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.ReadOnly = true;
            txtCustomerID.Size = new Size(143, 23);
            txtCustomerID.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 92);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 14;
            label5.Text = "Customer ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 261);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 15;
            label6.Text = "Customer Country";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(199, 261);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 16;
            label7.Text = "Customer City";
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 404);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtCustomerID);
            Controls.Add(comboBoxCity);
            Controls.Add(comboBoxCountry);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Name = "AddCustomerForm";
            Text = "AddCustomerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxCountry;
        private ComboBox comboBoxCity;
        private TextBox txtCustomerID;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}