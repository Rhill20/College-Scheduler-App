using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace Scheduling_App
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> translations = new Dictionary<string, string>
        {
            { "EN", "The username and password do not match." },
            { "ES", "El nombre de usuario y la contraseña no coinciden." }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // language ComboBox Options
            comboBoxLanguage.Items.Add("EN");
            comboBoxLanguage.Items.Add("ES");
            comboBoxLanguage.SelectedIndex = 0; // Default to English

            // user location 
            txtLocation.Text = GetUserLocation();

            // english defaulted 
            TranslateFields(comboBoxLanguage.SelectedItem.ToString());
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string language = comboBoxLanguage.SelectedItem.ToString();

            bool isSuccess = VerifyLogin(username, password);
            LogUserLogin(username, isSuccess);

            if (isSuccess)
            {
                MessageBox.Show("Login successful!");

                
                Home homeForm = new Home();
                homeForm.Show();
                this.Hide(); // if i use close the main form wont open 
            }
            else
            {
                MessageBox.Show(TranslateMessage(language));
            }
        }

        private bool VerifyLogin(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM user WHERE userName = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }

        private string TranslateMessage(string languageCode)
        {
            return translations.ContainsKey(languageCode) ? translations[languageCode] : translations["EN"];
        }
        //saved at C:\Users\Username\AppData\Local\Scheduling_App\Login_History.txt
        // Note for revision 2: If the user login was correct it will say login successful, if not it will say login failed. Both are appended to the file....
        // ... this is saved the the file path on line 84. 
        private void LogUserLogin(string username, bool isSuccess)
        {
            // path to the local app data folder for the user 
            string logFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Scheduling_App");

            // creates if not present 
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            // Set the log file
            string logFilePath = Path.Combine(logFolderPath, "Login_History.txt");
            
            string status = isSuccess ? "successful" : "failed";
            string logEntry = $"{DateTime.Now}: {username} login {status}";

            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
        private string GetUserLocation()
        {
            try
            {
                // using api for the location
                using (var webClient = new WebClient())
                {
                    string ip = webClient.DownloadString("https://api.ipify.org");
                    string locationInfo = webClient.DownloadString($"http://ip-api.com/json/{ip}");
                    var json = JObject.Parse(locationInfo);
                    return json["city"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not determine location: " + ex.Message);
                return "Unknown Location";
            }
        }

        private void TranslateFields(string languageCode)
        {
            if (languageCode == "ES")
            {
                lblUsername.Text = "Nombre de usuario";
                lblPassword.Text = "Contraseña";
                btnLogin.Text = "Iniciar sesión";
            }
            else
            {
                lblUsername.Text = "Username";
                lblPassword.Text = "Password";
                btnLogin.Text = "Login";
            }
        }
        // another weird designer issue had to remake this event handler 
        private void comboBoxLanguage_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TranslateFields(comboBoxLanguage.SelectedItem.ToString());
        }
    }
}
