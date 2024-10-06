using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VivexBanka
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }
        public static String AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cedomir93\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Unos ispravnih podataka
            if (string.IsNullOrEmpty(AccNumTb.Text) || string.IsNullOrEmpty(PinTb.Text))
            {
                MessageBox.Show("Please enter both Account Number and PIN!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Da li je PIN tacan
            if (!int.TryParse(PinTb.Text, out int pin))
            {
                MessageBox.Show("PIN must be a numeric value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Con.Open();
                // Proveravanje da li je konekcija otvorena
                Console.WriteLine("Connection opened successfully.");
                string query = "SELECT COUNT(*) FROM AccountTbl WHERE AccNum = @AccNum AND PIN = @PIN"; //SQL komanda
                SqlCommand cmd = new SqlCommand(query, Con);

                // Add parameters to avoid type conversion issues
                cmd.Parameters.AddWithValue("@AccNum", AccNumTb.Text);
                cmd.Parameters.AddWithValue("@PIN", pin); 

                // ExecuteScalar da bi smo vratili broj
                int result = (int)cmd.ExecuteScalar();

                // proverimo rezultat
                if (result == 1)
                {
                    // Successful login
                    AccNumber = AccNumTb.Text;
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    // Logovanje nije uspesno
                    MessageBox.Show("Wrong Account Number or PIN code! Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Provera da li je uspesna komanda
                Console.WriteLine("Query executed successfully.");
            }
            catch (Exception ex)
            {
                // Izbacivanje errora kada je debug
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                // Ovde se zatvara konekcija
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
