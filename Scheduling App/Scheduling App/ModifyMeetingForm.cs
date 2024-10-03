using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class ModifyMeetingForm : Form
    {
        private MySqlConnection connection;

        public ModifyMeetingForm()
        {
            InitializeComponent();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            txtUserTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, easternZone);
            txtEasternTime.Text = easternTime.ToString("MM/dd/yyyy hh:mm tt");

            InitializeDateTimePicker();
            InitializeComboBoxes();
        }

        private void InitializeDateTimePicker()
        {
            // Revision 2 Im leaving the boxes blank so the user is forced to select a date instead. 
            dateTimePickerMeetingDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerMeetingDate.CustomFormat = " "; // Keep it blank initially
            dateTimePickerMeetingDate.ValueChanged += DateTimePickerMeetingDate_ValueChanged;

            
            dateTimePickerNewMeetingDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerNewMeetingDate.CustomFormat = " "; // Keeping it blank initially
            dateTimePickerNewMeetingDate.ValueChanged += DateTimePickerNewMeetingDate_ValueChanged;
        }

        private void DateTimePickerNewMeetingDate_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxMeetings.SelectedItem != null)
            {
                dateTimePickerNewMeetingDate.CustomFormat = "MM/dd/yyyy"; 
            }
            else
            {
                dateTimePickerNewMeetingDate.CustomFormat = " "; //keep balnk 
            }
        }

        private void InitializeComboBoxes()
        {
            // 30 min intervals for time slots
            comboBoxTimeSlots.Items.Clear();
            for (int hour = 9; hour <= 16; hour++)
            {
                comboBoxTimeSlots.Items.Add($"{hour:00}:00 - {hour:00}:30");
                comboBoxTimeSlots.Items.Add($"{hour:00}:30 - {hour + 1:00}:00");
            }

            // app types 
            comboBoxAppointmentType.Items.AddRange(new string[] { "Consultation", "Follow-Up", "New Business", "Closure" });

            comboBoxCustomer.DataSource = null;
            comboBoxMeetings.SelectedIndexChanged += comboBoxMeetings_SelectedIndexChanged;
        }

        private void DateTimePickerMeetingDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerMeetingDate.CustomFormat = "MM/dd/yyyy";
            DateTime selectedDate = dateTimePickerMeetingDate.Value.Date;
            LoadMeetingsForSelectedDate(selectedDate);
        }

        private void LoadMeetingsForSelectedDate(DateTime selectedDate)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                comboBoxMeetings.Items.Clear();

                string query = @"SELECT appointmentId, title, start, end 
                         FROM appointment 
                         WHERE DATE(start) = @selectedDate";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // local time 
                TimeZoneInfo userTimeZone = TimeZoneInfo.Local;

                foreach (DataRow row in dt.Rows)
                {
                    // Convert UTC
                    DateTime startTimeUtc = (DateTime)row["start"];
                    DateTime endTimeUtc = (DateTime)row["end"];
                    DateTime startTimeLocal = TimeZoneInfo.ConvertTimeFromUtc(startTimeUtc, userTimeZone);
                    DateTime endTimeLocal = TimeZoneInfo.ConvertTimeFromUtc(endTimeUtc, userTimeZone);

                    string meetingDetails = $"{row["title"]} ({startTimeLocal:hh:mm tt} - {endTimeLocal:hh:mm tt})";
                    comboBoxMeetings.Items.Add(new ComboBoxItem { Text = meetingDetails, Value = row["appointmentId"] });
                }

                if (comboBoxMeetings.Items.Count > 0)
                {
                    comboBoxMeetings.SelectedIndex = 0;
                    LoadSelectedMeetingDetails((int)((ComboBoxItem)comboBoxMeetings.SelectedItem).Value);
                }
                else
                {
                    MessageBox.Show("No meetings found for the selected date.");
                    dateTimePickerNewMeetingDate.CustomFormat = " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading meetings: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void comboBoxMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMeetings.SelectedItem != null)
            {
                int appointmentId = (int)((ComboBoxItem)comboBoxMeetings.SelectedItem).Value;
                LoadSelectedMeetingDetails(appointmentId);
            }
        }

        private void LoadSelectedMeetingDetails(int appointmentId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = @"SELECT title, description, location, contact, type, url, start, end, customerId 
                         FROM appointment 
                         WHERE appointmentId = @appointmentId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTitle.Text = reader["title"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                    txtLocation.Text = reader["location"].ToString();
                    txtContact.Text = reader["contact"].ToString();
                    txtURL.Text = reader["url"].ToString();

                    // Convert UTC to Local Time
                    DateTime startTimeLocal = ((DateTime)reader["start"]).ToLocalTime();
                    DateTime endTimeLocal = ((DateTime)reader["end"]).ToLocalTime();

                    PopulateTimeSlotComboBox(comboBoxTimeSlots);

                    string timeSlot = $"{startTimeLocal:hh:mm tt} - {endTimeLocal:hh:mm tt}";
                    int index = comboBoxTimeSlots.Items.IndexOf(timeSlot);
                    if (index != -1)
                    {
                        comboBoxTimeSlots.SelectedIndex = index;
                    }

                    comboBoxAppointmentType.SelectedItem = reader["type"].ToString();

                    
                    dateTimePickerNewMeetingDate.Value = startTimeLocal.Date;
                    dateTimePickerNewMeetingDate.CustomFormat = "MM/dd/yyyy"; 

                    // Load customers after meeting is selected
                    int customerId = (int)reader["customerId"];
                    reader.Close();
                    LoadCustomers(customerId);
                }
                else
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading meeting details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void LoadCustomers(int customerId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string customerQuery = "SELECT customerId, customerName FROM customer";
                MySqlCommand cmd = new MySqlCommand(customerQuery, connection);
                MySqlDataAdapter customerAdapter = new MySqlDataAdapter(cmd);
                DataTable customerTable = new DataTable();
                customerAdapter.Fill(customerTable);

                comboBoxCustomer.DisplayMember = "customerName";
                comboBoxCustomer.ValueMember = "customerId";
                comboBoxCustomer.DataSource = customerTable;

                comboBoxCustomer.SelectedValue = customerId; // Set selected customer based on meeting
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading customers: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxMeetings.SelectedItem == null)
            {
                MessageBox.Show("Please select a meeting to modify.");
                return;
            }

            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string location = txtLocation.Text.Trim();
            string contact = txtContact.Text.Trim();
            string url = txtURL.Text.Trim();
            string appointmentType = comboBoxAppointmentType.SelectedItem.ToString();
            DateTime selectedDate = dateTimePickerNewMeetingDate.Value.Date; // new date
            string timeSlot = comboBoxTimeSlots.SelectedItem.ToString();
            DateTime startTimeLocal = DateTime.Parse(selectedDate.ToString("yyyy-MM-dd") + " " + timeSlot.Split('-')[0].Trim());
            DateTime endTimeLocal = DateTime.Parse(selectedDate.ToString("yyyy-MM-dd") + " " + timeSlot.Split('-')[1].Trim());

            // Local to UTC
            DateTime startTimeUtc = TimeZoneInfo.ConvertTimeToUtc(startTimeLocal);
            DateTime endTimeUtc = TimeZoneInfo.ConvertTimeToUtc(endTimeLocal);
            int appointmentId = (int)((ComboBoxItem)comboBoxMeetings.SelectedItem).Value;

            if (ValidateInput(title, startTimeUtc, endTimeUtc))
            {
                if (CheckForOverlappingAppointments(startTimeUtc, endTimeUtc, appointmentId))
                {
                    MessageBox.Show("The selected time slot overlaps with another appointment. Please choose a different time.");
                    return;
                }

                try
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    string updateQuery = @"UPDATE appointment 
                                           SET title = @title, description = @description, location = @location, contact = @contact, url = @url, start = @start, end = @end, type = @type, customerId = @customerId
                                           WHERE appointmentId = @appointmentId";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@url", url);
                    cmd.Parameters.AddWithValue("@start", startTimeUtc);  
                    cmd.Parameters.AddWithValue("@end", endTimeUtc);      
                    cmd.Parameters.AddWithValue("@type", appointmentType);
                    cmd.Parameters.AddWithValue("@customerId", (int)comboBoxCustomer.SelectedValue);
                    cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Meeting updated successfully!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the meeting: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private bool ValidateInput(string title, DateTime startTime, DateTime endTime)
        {
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Title is required.");
                return false;
            }

            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be after start time.");
                return false;
            }

            // UTC to Eastern to check business hours
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startTimeEST = TimeZoneInfo.ConvertTimeFromUtc(startTime, estZone);
            DateTime endTimeEST = TimeZoneInfo.ConvertTimeFromUtc(endTime, estZone);

            // Withing 9-5 EST and Mon-Fri
            if (startTimeEST.Hour < 9 || endTimeEST.Hour > 17 || startTimeEST.DayOfWeek == DayOfWeek.Saturday || startTimeEST.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Meetings must be scheduled during business hours (9:00 a.m. to 5:00 p.m.), Monday to Friday, EST.");
                return false;
            }

            return true;
        }

        private bool CheckForOverlappingAppointments(DateTime startTime, DateTime endTime, int appointmentId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = @"SELECT COUNT(*) 
                                 FROM appointment 
                                 WHERE appointmentId != @appointmentId 
                                   AND ((@startTime >= start AND @startTime < end) OR (@endTime > start AND @endTime <= end) OR (@startTime < start AND @endTime > end))";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking for overlapping appointments: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateTimeSlotComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            DateTime startTime = DateTime.Today.AddHours(0); // 0-24 for overseas people and general time zone compliance 
            DateTime endTime = DateTime.Today.AddHours(24); 

            while (startTime < endTime)
            {
                DateTime slotEndTime = startTime.AddMinutes(30);
                comboBox.Items.Add($"{startTime:hh:mm tt} - {slotEndTime:hh:mm tt}");
                startTime = slotEndTime;
            }
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        private void ModifyMeetingForm_Load(object sender, EventArgs e)
        {
        }
    }
}
