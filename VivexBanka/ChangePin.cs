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
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cedomir93\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        string Acc = Login.AccNumber;
        private void xLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (tbNew1.Text == "" || tbNew2.Text == "")
            {
                MessageBox.Show("Enter and Confirm a new PIN!");
                return;
            }
            else if (tbNew2.Text != tbNew1.Text)
            {
                MessageBox.Show("PIN1 and PIN2 are different!");
                return;
            }

            try
            {
                Con.Open();

                // Update query to correctly change the PIN
                string query = "update AccountTbl set PIN = @PIN where AccNum = @AccNum";
                SqlCommand cmd = new SqlCommand(query, Con);

                // Add the new PIN and account number parameters
                cmd.Parameters.AddWithValue("@PIN", Convert.ToInt32(tbNew2.Text));
                cmd.Parameters.AddWithValue("@AccNum", Acc);

                cmd.ExecuteNonQuery();
                MessageBox.Show("PIN change successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Close();

                // Redirect to login after successful PIN change
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
}
