using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class DeleteMeetingForm : Form
    {
        private MySqlConnection connection;

        public DeleteMeetingForm()
        {
            InitializeComponent();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            txtUserTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, easternZone);
            txtEasternTime.Text = easternTime.ToString("MM/dd/yyyy hh:mm tt");

            InitializeDateTimePicker();


        }

        private void InitializeDateTimePicker()
        {
            dateTimePickerMeetingDate.Format = DateTimePickerFormat.Short;
            dateTimePickerMeetingDate.ValueChanged += DateTimePickerMeetingDate_ValueChanged;
        }

        private void DateTimePickerMeetingDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickerMeetingDate.Value.Date;
            LoadMeetingsForSelectedDate(selectedDate);
        }

        private void LoadMeetingsForSelectedDate(DateTime selectedDate)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                // Clear the combo box
                comboBoxMeetings.Items.Clear();

                string query = @"SELECT appointmentId, title, start, end 
                                 FROM appointment 
                                 WHERE DATE(start) = @selectedDate";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    // Convert UTC to local time
                    DateTime startUtc = (DateTime)row["start"];
                    DateTime endUtc = (DateTime)row["end"];
                    DateTime startLocal = startUtc.ToLocalTime();
                    DateTime endLocal = endUtc.ToLocalTime();

                    // Displaymeeting details in combo box
                    string meetingDetails = $"{row["title"]} ({startLocal:hh:mm tt} - {endLocal:hh:mm tt})";
                    comboBoxMeetings.Items.Add(new ComboBoxItem { Text = meetingDetails, Value = row["appointmentId"] });
                }

                if (comboBoxMeetings.Items.Count > 0)
                {
                    comboBoxMeetings.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No meetings found for the selected date.");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxMeetings.SelectedItem != null)
            {
                ComboBoxItem selectedMeeting = (ComboBoxItem)comboBoxMeetings.SelectedItem;
                int appointmentId = (int)selectedMeeting.Value;

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the meeting: {selectedMeeting.Text}?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteMeeting(appointmentId);
                }
            }
            else
            {
                MessageBox.Show("Please select a meeting to delete.");
            }
        }

        private void DeleteMeeting(int appointmentId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string deleteQuery = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Meeting deleted successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the meeting: " + ex.Message);
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

        // ComboBoxItem class to hold the meeting details and appointment ID
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
    }
}
