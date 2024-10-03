using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class CustomerMeetingReportForm : Form
    {
        private MySqlConnection connection;

        public CustomerMeetingReportForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            // year comboBox Options
            for (int year = 2020; year <= 2030; year++)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedIndex = DateTime.Now.Year - 2020; 

            // month comboBox Options
            comboBoxMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames);
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;

            // manually added event handler for buttonRunReport, designer was not liking me when trying 
            buttonRunReport.Click += ButtonRunReport_Click;
        }

        private void ButtonRunReport_Click(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem == null || comboBoxMonth.SelectedItem == null)
            {
                MessageBox.Show("Please select both a year and a month.");
                return;
            }

            int selectedYear = (int)comboBoxYear.SelectedItem;
            int selectedMonth = comboBoxMonth.SelectedIndex + 1;

            GenerateCustomerMeetingReport(selectedYear, selectedMonth);
        }

        private void GenerateCustomerMeetingReport(int year, int month)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = @"
                    SELECT c.customerName, COUNT(a.appointmentId) AS MeetingCount
                    FROM appointment a
                    JOIN customer c ON a.customerId = c.customerId
                    WHERE YEAR(a.start) = @year AND MONTH(a.start) = @month
                    GROUP BY c.customerName";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<CustomerMeeting> customerMeetings = new List<CustomerMeeting>();

                while (reader.Read())
                {
                    customerMeetings.Add(new CustomerMeeting
                    {
                        CustomerName = reader["customerName"].ToString(),
                        MeetingCount = Convert.ToInt32(reader["MeetingCount"])
                    });
                }

                reader.Close();

                //  lambda expression
                textBoxReport.Clear();
                textBoxReport.AppendText($"Customer Meeting Report for {comboBoxMonth.SelectedItem} {year}" + Environment.NewLine);
                textBoxReport.AppendText("----------------------------------------" + Environment.NewLine);

                customerMeetings.ForEach(cm =>
                {
                    textBoxReport.AppendText($"- {cm.CustomerName}: {cm.MeetingCount} meetings" + Environment.NewLine);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the report: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class CustomerMeeting
    {
        public string CustomerName { get; set; }
        public int MeetingCount { get; set; }
    }
}
