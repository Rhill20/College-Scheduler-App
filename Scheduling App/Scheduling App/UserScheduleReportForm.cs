using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq; 
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class UserScheduleReportForm : Form
    {
        private MySqlConnection connection;
        public UserScheduleReportForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            // 10 year gap like the schduler gap 
            for (int year = 2020; year <= 2030; year++)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedIndex = DateTime.Now.Year - 2020; 

            comboBoxMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames);
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1; // curr month 

           
            LoadUsersIntoComboBox();

            // again manually added event handler for buttonRunReport, designer was not liking me when trying
            buttonRunReport.Click += ButtonRunReport_Click;
        }

        private void GenerateUserScheduleReport(int year, int month, int userId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = @"
            SELECT a.start, a.type, u.userName 
            FROM appointment a
            JOIN user u ON a.userId = u.userId
            WHERE YEAR(a.start) = @year AND MONTH(a.start) = @month AND a.userId = @userId";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Appointment> appointments = new List<Appointment>();

                while (reader.Read())
                {
                    appointments.Add(new Appointment
                    {
                        Start = (DateTime)reader["start"],
                        Type = reader["type"].ToString(),
                        UserName = reader["userName"].ToString()
                    });
                }

                reader.Close();

               
                var userSchedules = appointments
                    .GroupBy(a => a.UserName)
                    .Select(g => new UserSchedule
                    {
                        UserName = g.Key,
                        Appointments = g.OrderBy(a => a.Start).ToList() // Lambda used here to order by appointment time
                    })
                    .ToList();

               
                DisplayUserSchedulesReport(userSchedules, year, month);
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


        private void LoadUsersIntoComboBox()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = "SELECT userId, userName FROM user";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxUser.Items.Add(new KeyValuePair<int, string>((int)reader["userId"], reader["userName"].ToString()));
                }

                comboBoxUser.DisplayMember = "Value";
                comboBoxUser.ValueMember = "Key";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading users: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ButtonRunReport_Click(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem == null || comboBoxMonth.SelectedItem == null || comboBoxUser.SelectedItem == null)
            {
                MessageBox.Show("Please select a year, a month, and a user.");
                return;
            }

            int selectedYear = (int)comboBoxYear.SelectedItem;
            int selectedMonth = comboBoxMonth.SelectedIndex + 1;
            var selectedUser = (KeyValuePair<int, string>)comboBoxUser.SelectedItem;

            GenerateUserScheduleReport(selectedYear, selectedMonth, selectedUser.Key);
        }


        private void DisplayUserSchedulesReport(List<UserSchedule> userSchedules, int year, int month)
        {
            textBoxReport.Clear();
            textBoxReport.AppendText($"User Schedule Report for {comboBoxUser.SelectedItem} in {comboBoxMonth.SelectedItem} {year}" + Environment.NewLine);
            textBoxReport.AppendText("----------------------------------------" + Environment.NewLine);

            userSchedules.ForEach(userSchedule =>
            {
                userSchedule.Appointments.ForEach(appointment =>
                {
                    textBoxReport.AppendText($"- {appointment.Start:MMMM dd, yyyy hh:mm tt} | {appointment.Type}" + Environment.NewLine);
                });
                textBoxReport.AppendText(Environment.NewLine); 
            });
        }
    }
}