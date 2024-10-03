using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class AddMeetingForm : Form
    {
        private MySqlConnection connection;

        public AddMeetingForm()
        {
            InitializeComponent();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);

            txtUserTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, easternZone);
            txtEasternTime.Text = easternTime.ToString("MM/dd/yyyy hh:mm tt");

            LoadCustomers();
            InitializeTypeComboBox();
            InitializeDateAndTimeControls();
        }

        private void LoadCustomers()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = "SELECT customerId, customerName FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBoxCustomer.DisplayMember = "customerName";
                comboBoxCustomer.ValueMember = "customerId";
                comboBoxCustomer.DataSource = dt;
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

        private void InitializeTypeComboBox()
        {
            comboBoxType.Items.Add("Consultation");
            comboBoxType.Items.Add("Follow-up");
            comboBoxType.Items.Add("New Business");
            comboBoxType.Items.Add("Closure");
            comboBoxType.SelectedIndex = 0;
        }

        private void InitializeDateAndTimeControls()
        {
            // Initialize the DatePicker 
            dateTimePickerDate.Format = DateTimePickerFormat.Short;

            //  30 minute intervals
            PopulateTimeSlotComboBox(comboBoxTimeSlot);
        }

        private void PopulateTimeSlotComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            DateTime startTime = DateTime.Today.AddHours(0); 
            DateTime endTime = DateTime.Today.AddHours(24); // had to add all 24 hours for people overseas and their perspective time zones relative to EST 

            while (startTime < endTime)
            {
                DateTime slotEndTime = startTime.AddMinutes(30); // wasnt sure if there should be a 30 minute interval or not but thats how i implemented it 
                comboBox.Items.Add($"{startTime:hh:mm tt} - {slotEndTime:hh:mm tt}");
                startTime = slotEndTime;
            }

            comboBox.SelectedIndex = 0; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int customerId = (int)comboBoxCustomer.SelectedValue;
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string location = txtLocation.Text.Trim();
            string contact = txtContact.Text.Trim();
            string type = comboBoxType.SelectedItem.ToString();
            string url = txtURL.Text.Trim();
            DateTime selectedDate = dateTimePickerDate.Value.Date;
            string selectedTimeSlot = comboBoxTimeSlot.SelectedItem.ToString();

            // Parse the selected time slot to get the start and end times
            string[] timeParts = selectedTimeSlot.Split('-');
            DateTime startTime = DateTime.Parse(selectedDate.ToString("MM/dd/yyyy") + " " + timeParts[0].Trim());
            DateTime endTime = DateTime.Parse(selectedDate.ToString("MM/dd/yyyy") + " " + timeParts[1].Trim());

            // Convert to UTC
            DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(startTime, TimeZoneInfo.Local);
            DateTime endUtc = TimeZoneInfo.ConvertTimeToUtc(endTime, TimeZoneInfo.Local);

            if (ValidateInput(customerId, title, startUtc, endUtc))
            {
                if (CheckForOverlappingAppointments(customerId, startUtc, endUtc))
                {
                    MessageBox.Show("The selected time slot overlaps with an existing appointment. Please choose a different time.");
                }
                else
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed) connection.Open();

                        string insertQuery = @"INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) 
                                               VALUES (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, NOW(), 'admin', 'admin')";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@userId", 1);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@url", url);
                        cmd.Parameters.AddWithValue("@start", startUtc);
                        cmd.Parameters.AddWithValue("@end", endUtc);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Meeting added successfully!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the meeting: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private bool CheckForOverlappingAppointments(int customerId, DateTime startUtc, DateTime endUtc)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string query = @"SELECT COUNT(*) FROM appointment 
                                 WHERE customerId = @customerId AND 
                                       ((start < @end AND end > @start))";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@start", startUtc);
                cmd.Parameters.AddWithValue("@end", endUtc);

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

        private bool ValidateInput(int customerId, string title, DateTime startTime, DateTime endTime)
        {
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Title is required.");
                return false;
            }

            if (startTime >= endTime)
            {
                MessageBox.Show("The start time must be before the end time.");
                return false;
            }

            // Convert startTime and endTime to est
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(startTime, estZone);
            DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(endTime, estZone);

            
            DateTime businessStartEst = startEst.Date.AddHours(9);  // 9 for est
            DateTime businessEndEst = startEst.Date.AddHours(17);   // 5 for est 

            if (startEst < businessStartEst || endEst > businessEndEst || startEst.DayOfWeek == DayOfWeek.Saturday || startEst.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Meetings must be scheduled during business hours (9:00 a.m. to 5:00 p.m.), Monday to Friday, Eastern Standard Time.");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
