using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class AddCustomerForm : Form
    {
        private MySqlConnection connection;
        private int generatedCustomerId;

        public AddCustomerForm()
        {
            InitializeComponent();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            LoadCountries();   
            GenerateUniqueCustomerId();
            comboBoxCountry.SelectedIndexChanged += ComboBoxCountry_SelectedIndexChanged; // Handles country selection change
        }

        private void GenerateUniqueCustomerId()
        {
            Random random = new Random();
            bool idExists = true;

            while (idExists)
            {
                generatedCustomerId = random.Next(1000, 9999); 
                idExists = CheckIfCustomerIdExists(generatedCustomerId);
            }

            // Generated ID non editable
            txtCustomerID.Text = generatedCustomerId.ToString();
        }

        private bool CheckIfCustomerIdExists(int customerId)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM customer WHERE customerId = @customerId";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking customer ID: " + ex.Message);
                return true; 
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadCountries()
        {
            try
            {
                connection.Open();

                // Load countries
                string countryQuery = "SELECT countryId, country FROM country";
                MySqlCommand cmd = new MySqlCommand(countryQuery, connection);
                MySqlDataAdapter countryAdapter = new MySqlDataAdapter(cmd);
                DataTable countryTable = new DataTable();
                countryAdapter.Fill(countryTable);

                // Inserted a blank row at the top 
                DataRow blankRow = countryTable.NewRow();
                blankRow["country"] = "-- Select Country --";
                blankRow["countryId"] = DBNull.Value;
                countryTable.Rows.InsertAt(blankRow, 0);

                comboBoxCountry.DisplayMember = "country";
                comboBoxCountry.ValueMember = "countryId";
                comboBoxCountry.DataSource = countryTable;

                comboBoxCountry.SelectedIndex = 0; 
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


        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCountry.SelectedValue != null)
            {
                int selectedCountryId = (int)comboBoxCountry.SelectedValue;
                LoadCities(selectedCountryId);
            }
        }

        private void LoadCities(int countryId)
        {
            try
            {
                connection.Open();

                // Loads cities based on selected country
                string cityQuery = "SELECT cityId, city FROM city WHERE countryId = @countryId";
                MySqlCommand cmd = new MySqlCommand(cityQuery, connection);
                cmd.Parameters.AddWithValue("@countryId", countryId);
                MySqlDataAdapter cityAdapter = new MySqlDataAdapter(cmd);
                DataTable cityTable = new DataTable();
                cityAdapter.Fill(cityTable);

                comboBoxCity.DisplayMember = "city";
                comboBoxCity.ValueMember = "cityId";
                comboBoxCity.DataSource = cityTable;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // combo box error handling 
            if (comboBoxCity.SelectedValue == null || comboBoxCountry.SelectedValue == null)
            {
                MessageBox.Show("Please select both a city and a country before adding a customer.");
                return;
            }

            int cityId = (int)comboBoxCity.SelectedValue;
            string postalCode = "12345"; // Just a generic postal code, that part wasnt in rubric so I'm not sure what to do with it

            if (ValidateInput(name, address, phone))
            {
                try
                {
                    connection.Open();

                    // Insert into address table
                    string insertAddressQuery = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) VALUES (@address, '', @cityId, @postalCode, @phone, NOW(), 'admin', 'admin')";
                    MySqlCommand cmd = new MySqlCommand(insertAddressQuery, connection);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@cityId", cityId);
                    cmd.Parameters.AddWithValue("@postalCode", postalCode);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();

                    // Retrieve the last inserted address ID
                    long addressId = cmd.LastInsertedId;

                    // Insert into customer table with the auto generated customerId
                    string insertCustomerQuery = "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdateBy) VALUES (@customerId, @name, @addressId, 1, NOW(), 'admin', 'admin')";
                    cmd = new MySqlCommand(insertCustomerQuery, connection);
                    cmd.Parameters.AddWithValue("@customerId", generatedCustomerId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer added successfully!");
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
    }
}
