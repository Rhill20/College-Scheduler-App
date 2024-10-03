using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_App
{
    public partial class DeleteCustomerForm : Form
    {
        private MySqlConnection connection;

        public DeleteCustomerForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            LoadCustomerList();
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
                comboBoxCustomers.SelectedIndex = 0; // Default to blank
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomers.SelectedIndex > 0) // customer must be  selected
            {
                string customerName = comboBoxCustomers.Text;
                int customerId = (int)comboBoxCustomers.SelectedValue;

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {customerName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    DeleteCustomer(customerId);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void DeleteCustomer(int customerId)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                // Check if the customer has any associated appointments adding this way later until i was testing and it crashed 
                string checkAppointmentsQuery = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId";
                MySqlCommand checkCmd = new MySqlCommand(checkAppointmentsQuery, connection);
                checkCmd.Parameters.AddWithValue("@customerId", customerId);

                int appointmentCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (appointmentCount > 0)
                {
                    MessageBox.Show("This customer cannot be deleted because they have associated meetings. Please delete the meetings first.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //deletion if no associated appointments
                string deleteQuery = "DELETE FROM customer WHERE customerId = @customerId";
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Customer deleted successfully!");

                LoadCustomerList(); // Refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the customer: " + ex.Message);
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
    }
}
