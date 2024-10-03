using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class UpdateCustomerForm : Form
    {
        private MySqlConnection connection;

        public UpdateCustomerForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            LoadCustomerList();

            // Added event handler for country selection change Designer was not liking me when trying again 
            comboBoxCountry.SelectedIndexChanged += ComboBoxCountry_SelectedIndexChanged;
        }

        private void LoadCustomerList()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
                string query = "SELECT customerId, customerName FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DataRow blankRow = dt.NewRow();
                blankRow["customerName"] = "-- Select a customer --";
                blankRow["customerId"] = DBNull.Value;
                dt.Rows.InsertAt(blankRow, 0);

                comboBoxCustomers.DisplayMember = "customerName";
                comboBoxCustomers.ValueMember = "customerId";
                comboBoxCustomers.DataSource = dt;
                comboBoxCustomers.SelectedIndex = 0; // Blank option
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

        private void LoadCountries(int countryId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string countryQuery = "SELECT countryId, country FROM country";
                MySqlCommand cmd = new MySqlCommand(countryQuery, connection);
                MySqlDataAdapter countryAdapter = new MySqlDataAdapter(cmd);
                DataTable countryTable = new DataTable();
                countryAdapter.Fill(countryTable);

                comboBoxCountry.DisplayMember = "country";
                comboBoxCountry.ValueMember = "countryId";
                comboBoxCountry.DataSource = countryTable;

                comboBoxCountry.SelectedValue = countryId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading countries: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadCities(int countryId, int cityId = -1)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string cityQuery = "SELECT cityId, city FROM city WHERE countryId = @countryId";
                MySqlCommand cmd = new MySqlCommand(cityQuery, connection);
                cmd.Parameters.AddWithValue("@countryId", countryId);
                MySqlDataAdapter cityAdapter = new MySqlDataAdapter(cmd);
                DataTable cityTable = new DataTable();
                cityAdapter.Fill(cityTable);

                comboBoxCity.DisplayMember = "city";
                comboBoxCity.ValueMember = "cityId";
                comboBoxCity.DataSource = cityTable;

                if (cityId != -1)
                {
                    comboBoxCity.SelectedValue = cityId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading cities: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadCustomerDetails(int customerId)
        {
            MySqlDataReader reader = null;
            try
            {
                ClearCustomerFields(); // Clear the fields before loading new data

                if (connection.State == ConnectionState.Closed) connection.Open();
                string query = @"SELECT c.customerId, c.customerName, a.address, a.phone, ci.cityId, co.countryId
                                 FROM customer c
                                 JOIN address a ON c.addressId = a.addressId
                                 JOIN city ci ON a.cityId = ci.cityId
                                 JOIN country co ON ci.countryId = co.countryId
                                 WHERE c.customerId = @customerId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtCustomerID.Text = reader["customerId"].ToString();
                    txtName.Text = reader["customerName"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtPhone.Text = reader["phone"].ToString();

                    int countryId = Convert.ToInt32(reader["countryId"]);
                    int cityId = Convert.ToInt32(reader["cityId"]);

                    reader.Close(); // Ensure the reader is closed - Got alot of reader errors when testing this initially 

                    LoadCountries(countryId); // Load countries and select the correct one
                    LoadCities(countryId, cityId); // Load cities and select the correct one
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading customer details: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                connection.Close();
            }
        }

        private void ClearCustomerFields()
        {
            // Clear all fields before loading new customer data
            txtCustomerID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            comboBoxCountry.DataSource = null;
            comboBoxCity.DataSource = null;
        }

        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCountry.SelectedValue != null)
            {
                int selectedCountryId = (int)comboBoxCountry.SelectedValue;
                LoadCities(selectedCountryId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomers.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            int cityId = (int)comboBoxCity.SelectedValue;
            int customerId = (int)comboBoxCustomers.SelectedValue;

            if (ValidateInput(name, address, phone))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    string updateAddressQuery = @"UPDATE address a
                                                  JOIN customer c ON a.addressId = c.addressId
                                                  SET a.address = @address, a.phone = @phone, a.cityId = @cityId, a.lastUpdateBy = 'admin'
                                                  WHERE c.customerId = @customerId";
                    MySqlCommand cmd = new MySqlCommand(updateAddressQuery, connection);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@cityId", cityId);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.ExecuteNonQuery();

                    string updateCustomerQuery = "UPDATE customer SET customerName = @name, lastUpdateBy = 'admin' WHERE customerId = @customerId";
                    cmd = new MySqlCommand(updateCustomerQuery, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer updated successfully!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private bool ValidateInput(string name, string address, string phone)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("All fields are required and cannot be empty.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[\d\-]+$"))
            {
                MessageBox.Show("Phone number can only contain digits and dashes.");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCustomers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxCustomers.SelectedIndex > 0) // Ensure a customer is selected
            {
                int customerId = (int)comboBoxCustomers.SelectedValue;
                LoadCustomerDetails(customerId);
            }
            else
            {
                ClearCustomerFields();
            }
        }
    }
}
