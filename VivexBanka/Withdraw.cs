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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cedomir93\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        string Acc = Login.AccNumber;
        int bal;
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblBalance.Text = dt.Rows[0][0].ToString() + " Dinara";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void addTransaction()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + tbWithdraw.Text + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void Withdraw_Load(object sender, EventArgs e)
        {
            getBalance();
        }
        int newBalance;
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (tbWithdraw.Text == "")
            {
                MessageBox.Show("Missing Information! Enter the numberic number to continiue!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(tbWithdraw.Text) <= 0)
            {
                MessageBox.Show("Enter a Valid Amount to Withdraw!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(tbWithdraw.Text) > bal)
            {
                MessageBox.Show("Your balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Subtract the withdraw amount from the current balance
                    newBalance = bal - Convert.ToInt32(tbWithdraw.Text);
                    try
                    {
                        Con.Open();

                        // Update the Balance by subtracting the withdrawal amount
                        string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                        SqlCommand cmd = new SqlCommand(query, Con);

                        // Add parameters for withdrawal amount and account number
                        cmd.Parameters.AddWithValue("@WithdrawAmount", Convert.ToInt32(tbWithdraw.Text));
                        cmd.Parameters.AddWithValue("@AccNum", Acc);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                catch (Exception exz)
                {
                    MessageBox.Show(exz.Message);
                }
            }
        }
    }
}
