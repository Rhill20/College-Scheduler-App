namespace Scheduling_App
{
    partial class DeleteCustomerForm
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
            comboBoxCustomers = new ComboBox();
            btnDelete = new Button();
            btnCancel = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // comboBoxCustomers
            // 
            comboBoxCustomers.FormattingEnabled = true;
            comboBoxCustomers.Location = new Point(57, 126);
            comboBoxCustomers.Name = "comboBoxCustomers";
            comboBoxCustomers.Size = new Size(151, 23);
            comboBoxCustomers.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(61, 163);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(147, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(61, 201);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(147, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(52, 52);
            label4.Name = "label4";
            label4.Size = new Size(168, 30);
            label4.TabIndex = 11;
            label4.Text = "Delete Customer";
            // 
            // DeleteCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 290);
            Controls.Add(label4);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(comboBoxCustomers);
            Name = "DeleteCustomerForm";
            Text = "DeleteCustomerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCustomers;
        private Button btnDelete;
        private Button btnCancel;
        private Label label4;
    }
}