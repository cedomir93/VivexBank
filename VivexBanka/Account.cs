using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VivexBanka
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cedomir93\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");


        private void btnLogin_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNameTb.Text == "" || AccNumTb.Text == "" || FnameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "" || occupationtb.Text == "" || pintb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    // Example of encrypting or hashing the PIN (adjust based on your needs)
                    byte[] pinBytes = System.Text.Encoding.UTF8.GetBytes(pintb.Text);

                    string query = "insert into AccountTbl values(@AccNum, @AccName, @Fname, @Dob, @Phone, @Address, @Education, @Occupation, @Pin, @Bal)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@AccNum", AccNumTb.Text);
                    cmd.Parameters.AddWithValue("@AccName", AccNameTb.Text);
                    cmd.Parameters.AddWithValue("@Fname", FnameTb.Text);
                    cmd.Parameters.AddWithValue("@Dob", dobdate.Value.Date);
                    cmd.Parameters.AddWithValue("@Phone", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Address", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Education", educationcb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Occupation", occupationtb.Text);
                    cmd.Parameters.AddWithValue("@Pin", pinBytes);  // Store as varbinary
                    cmd.Parameters.AddWithValue("@Bal", bal);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account is successfully created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
