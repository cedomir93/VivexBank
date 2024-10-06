using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VivexBanka
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cedomir93\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        string Acc = Login.AccNumber;
        private void addTransaction()
        {
            string TrType = "Deposit";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + tbDeposit.Text + ", '" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account is successfully created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (tbDeposit.Text == "" || Convert.ToInt32(tbDeposit.Text) <= 0)
            {
                MessageBox.Show("Enter a valid amount to deposit.");
                return;
            }

            
            newBalance = oldBalance + Convert.ToInt32(tbDeposit.Text);
            try
            {
                Con.Open();

                
                string query = "update AccountTbl set Balance = Balance + @DepositAmount where AccNum = @AccNum";
                SqlCommand cmd = new SqlCommand(query, Con);

                cmd.Parameters.AddWithValue("@DepositAmount", Convert.ToInt32(tbDeposit.Text));
                cmd.Parameters.AddWithValue("@AccNum", Acc);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Your deposit has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Close();
                addTransaction();
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int oldBalance;
        int newBalance;
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            getBalance();
        }
    }
}
