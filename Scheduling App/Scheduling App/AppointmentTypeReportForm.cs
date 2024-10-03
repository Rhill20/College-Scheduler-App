using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class AppointmentTypeReportForm : Form
    {
        private MySqlConnection connection;

        public AppointmentTypeReportForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            // Combo Presaved Options
            for (int year = 2020; year <= 2030; year++)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedIndex = DateTime.Now.Year - 2020; // Current year

            
            comboBoxMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames);
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1; //current month 

            
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

            GenerateReport(selectedYear, selectedMonth);
        }

        private void GenerateReport(int year, int month)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = "SELECT start, type FROM appointment WHERE YEAR(start) = @year AND MONTH(start) = @month";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Appointment> appointments = new List<Appointment>();

                while (reader.Read())
                {
                    appointments.Add(new Appointment
                    {
                        Start = (DateTime)reader["start"],
                        Type = reader["type"].ToString()
                    });
                }

                reader.Close();

                //lambda expression to group by type and count
                var reportData = appointments
                    .GroupBy(a => a.Type)
                    .Select(g => new { Type = g.Key, Count = g.Count() })
                    .ToList();

                textBoxReport.Clear();
                textBoxReport.AppendText($"Appointment Types Report for {comboBoxMonth.SelectedItem} {year}" + Environment.NewLine);
                textBoxReport.AppendText("----------------------------------------" + Environment.NewLine);

                foreach (var data in reportData)
                {
                    textBoxReport.AppendText($"- {data.Type}: {data.Count}" + Environment.NewLine);
                }
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
