using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class Home : Form
    {
        private MySqlConnection connection;
        private DateTime selectedDate;
        private bool isLoading = true;

        public Home()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            selectedDate = DateTime.Today;

            // wasnt sure how far the range should be so i set it to 10 years
            for (int year = 2020; year <= 2030; year++)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;

            // Populate month combo
            comboBoxMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames);
            comboBoxMonth.SelectedIndexChanged += ComboBoxMonth_SelectedIndexChanged;

            // date time picker selection 
            dateTimePickerDay.ValueChanged += DateTimePickerDay_ValueChanged;

            this.Load += Home_Load;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            isLoading = false;
            // curr year 
            comboBoxYear.SelectedItem = selectedDate.Year;
            comboBoxMonth.SelectedIndex = selectedDate.Month - 1;
            LoadYearView((int)comboBoxYear.SelectedItem);

            // Check for upcoming appointments when the form loads
            CheckForUpcomingAppointments();
        }
        private void CheckForUpcomingAppointments()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                // cur utc 
                DateTime utcNow = DateTime.UtcNow;
                DateTime utcNext15Minutes = utcNow.AddMinutes(15);

                // Query for appointments within 15 minutes
                string query = @"
            SELECT title, start
            FROM appointment
            WHERE start BETWEEN @utcNow AND @utcNext15Minutes";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@utcNow", utcNow);
                cmd.Parameters.AddWithValue("@utcNext15Minutes", utcNext15Minutes);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // User's local zone 
                    TimeZoneInfo userTimeZone = TimeZoneInfo.Local;

                    while (reader.Read())
                    {
                        // Convert the UTC start time to the user's local time
                        DateTime startTimeUtc = (DateTime)reader["start"];
                        DateTime startTimeLocal = TimeZoneInfo.ConvertTimeFromUtc(startTimeUtc, userTimeZone);

                        // ALERT ALERT 
                        string title = reader["title"].ToString();
                        MessageBox.Show($"You have an upcoming appointment: '{title}' at {startTimeLocal:hh:mm tt}.", "Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking for upcoming appointments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                LoadYearView((int)comboBoxYear.SelectedItem);
            }
        }

        private void ComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading && comboBoxYear.SelectedItem != null)
            {
                LoadMonthView();
            }
        }

        private void DateTimePickerDay_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                LoadDayView(dateTimePickerDay.Value);
            }
        }

        private void LoadYearView(int year)
        {
            ClearAndInitializeDataGridView();

            for (int month = 1; month <= 12; month++)
            {
                dataGridViewCalendar.Columns.Add($"Month{month}", new DateTime(year, month, 1).ToString("MMM"));
            }

            dataGridViewCalendar.Rows.Add();
            LoadAppointmentsForYear(year);

            foreach (DataGridViewColumn column in dataGridViewCalendar.Columns)
            {
                column.Width = dataGridViewCalendar.Width / 12;
            }

            // Reset the month and day selections
            comboBoxMonth.SelectedIndex = -1;
            dateTimePickerDay.CustomFormat = " ";
            dateTimePickerDay.Enabled = false;
        }

        private void LoadMonthView()
        {
            if (comboBoxYear.SelectedItem == null || comboBoxMonth.SelectedItem == null)
                return;

            int selectedYear = (int)comboBoxYear.SelectedItem;
            int selectedMonth = comboBoxMonth.SelectedIndex + 1;
            selectedDate = new DateTime(selectedYear, selectedMonth, 1);

            ClearAndInitializeDataGridView();

            string[] daysOfWeek = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            foreach (var day in daysOfWeek)
            {
                dataGridViewCalendar.Columns.Add(day, day);
            }

            DateTime firstDayOfMonth = new DateTime(selectedYear, selectedMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

            int currentDay = 1;
            int rowIndex = 0;
            dataGridViewCalendar.Rows.Add();

            for (int i = 0; i < (int)firstDayOfMonth.DayOfWeek; i++)
            {
                dataGridViewCalendar.Rows[rowIndex].Cells[i].Value = "";
            }

            for (int i = (int)firstDayOfMonth.DayOfWeek; i < 7; i++)
            {
                dataGridViewCalendar.Rows[rowIndex].Cells[i].Value = currentDay.ToString();
                currentDay++;
            }

            while (currentDay <= daysInMonth)
            {
                dataGridViewCalendar.Rows.Add();
                rowIndex++;

                for (int i = 0; i < 7 && currentDay <= daysInMonth; i++)
                {
                    dataGridViewCalendar.Rows[rowIndex].Cells[i].Value = currentDay.ToString();
                    currentDay++;
                }
            }

            foreach (DataGridViewColumn column in dataGridViewCalendar.Columns)
            {
                column.Width = dataGridViewCalendar.Width / 7;
            }

            dataGridViewCalendar.AutoResizeRows();
            LoadAppointmentsForMonth(selectedDate);

            dateTimePickerDay.CustomFormat = "MMMM dd, yyyy";
            dateTimePickerDay.Enabled = true;
        }

        private void LoadDayView(DateTime date)
        {
            ClearAndInitializeDataGridView();

            // columns for time slots and appointment details
            dataGridViewCalendar.Columns.Add("Time", "Time");
            dataGridViewCalendar.Columns.Add("Details", "Details");

            // 24 hrs
            for (int hour = 0; hour < 24; hour++)
            {
                int rowIndex = dataGridViewCalendar.Rows.Add();
                string timeLabel = $"{hour:00}:00";
                dataGridViewCalendar.Rows[rowIndex].Cells[0].Value = timeLabel;

                // Highlight non buisness hours 
                if (hour < 9 || hour >= 17)
                {
                    dataGridViewCalendar.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            // Load the appointments
            LoadAppointmentsForDay(date);
        }

        private void LoadAppointmentsForYear(int year)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = "SELECT * FROM appointment WHERE YEAR(start) = @year";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@year", year);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime startTimeUtc = (DateTime)reader["start"];
                    DateTime startTimeLocal = startTimeUtc.ToLocalTime();
                    int month = startTimeLocal.Month;

                    string appointmentDetails = $"{reader["title"]} ({startTimeLocal:MMM dd})";
                    dataGridViewCalendar.Rows[0].Cells[month - 1].Value += Environment.NewLine + appointmentDetails;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading appointments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadAppointmentsForMonth(DateTime date)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                string query = "SELECT * FROM appointment WHERE start >= @firstDay AND end <= @lastDay";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@firstDay", firstDayOfMonth);
                cmd.Parameters.AddWithValue("@lastDay", lastDayOfMonth);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime startTimeUtc = (DateTime)reader["start"];
                    DateTime startTimeLocal = startTimeUtc.ToLocalTime();
                    int dayOfMonth = startTimeLocal.Day;

                    int rowIndex = (dayOfMonth + (int)firstDayOfMonth.DayOfWeek - 1) / 7;
                    int columnIndex = (int)startTimeLocal.DayOfWeek;

                    string appointmentDetails = $"{reader["title"]} ({startTimeLocal:hh:mm tt})";
                    dataGridViewCalendar.Rows[rowIndex].Cells[columnIndex].Value += Environment.NewLine + appointmentDetails;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading appointments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadAppointmentsForDay(DateTime date)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                // appointments for the day 
                string query = "SELECT * FROM appointment WHERE DATE(start) = @date";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@date", date.Date); 

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime startTimeUtc = (DateTime)reader["start"];
                    DateTime startTimeLocal = startTimeUtc.ToLocalTime();
                    int rowIndex = startTimeLocal.Hour;

                    string appointmentDetails = $"{reader["title"]} ({startTimeLocal:hh:mm tt})";
                    dataGridViewCalendar.Rows[rowIndex].Cells[1].Value += Environment.NewLine + appointmentDetails;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading appointments: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ClearAndInitializeDataGridView()
        {
            dataGridViewCalendar.Columns.Clear();
            dataGridViewCalendar.Rows.Clear();
            dataGridViewCalendar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewCalendar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCalendar.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        //all the buttons for the tab control 
        private void Addcust_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
        }

        private void Updatecus_Click(object sender, EventArgs e)
        {
            UpdateCustomerForm updateCustomerForm = new UpdateCustomerForm();
            updateCustomerForm.ShowDialog();
        }

        private void Deletecus_Click(object sender, EventArgs e)
        {
            DeleteCustomerForm deleteCustomerForm = new DeleteCustomerForm();
            deleteCustomerForm.ShowDialog();
        }

        private void buttonAddMeeting_Click(object sender, EventArgs e)
        {
            AddMeetingForm addMeetingForm = new AddMeetingForm();
            addMeetingForm.ShowDialog();
        }

        private void buttonDeleteMeeting_Click(object sender, EventArgs e)
        {
            DeleteMeetingForm deleteMeetingForm = new DeleteMeetingForm();
            deleteMeetingForm.ShowDialog();
        }

        private void buttonModMeeting_Click(object sender, EventArgs e)
        {
            ModifyMeetingForm modifyMeetingForm = new ModifyMeetingForm();
            modifyMeetingForm.ShowDialog();
        }

        private void buttonAppTypesReport_Click(object sender, EventArgs e)
        {
            AppointmentTypeReportForm appointmentTypeReportForm = new AppointmentTypeReportForm();
            appointmentTypeReportForm.ShowDialog();
        }

        private void buttonUserReport_Click(object sender, EventArgs e)
        {
            UserScheduleReportForm userScheduleReportForm = new UserScheduleReportForm();
            userScheduleReportForm.ShowDialog();
        }

        private void buttonCustReport_Click(object sender, EventArgs e)
        {
            CustomerMeetingReportForm customerMeetingReportForm = new CustomerMeetingReportForm();
            customerMeetingReportForm.ShowDialog();
        }
    }
}
