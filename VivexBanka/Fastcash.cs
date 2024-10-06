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
using System.Data.SqlClient;

namespace VivexBanka
{
    public partial class Fastcash : Form
    {
        public Fastcash()
        {
            InitializeComponent();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
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
            lblBalance.Text = "Stanje racuna: " + dt.Rows[0][0].ToString() + " Dinara";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void xLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Fastcash_Load(object sender, EventArgs e)
        {
            getBalance();
        }
        private void addTransaction1()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + 500 + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction2()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + 1000 + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction3()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + 1500 + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction4()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + 2000 + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction5()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + 3000 + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction6()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();

                string query = "insert into TransactionTbl values('" + Acc + "', '" + TrType + "', " + 4000 + ", '" + DateTime.Today.Date.ToString() + "')";
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
        private void btn500Din_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int newBalance = bal - 500;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@WithdrawAmount", 500);
                    cmd.Parameters.AddWithValue("@AccNum", Acc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    addTransaction1();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn1000Din_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int newBalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@WithdrawAmount", 1000);
                    cmd.Parameters.AddWithValue("@AccNum", Acc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    addTransaction2();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn1500Din_Click(object sender, EventArgs e)
        {
            if (bal < 1500)
            {
                MessageBox.Show("Balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int newBalance = bal - 1500;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@WithdrawAmount", 1500);
                    cmd.Parameters.AddWithValue("@AccNum", Acc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    addTransaction3();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn2000Din_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int newBalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@WithdrawAmount", 2000);
                    cmd.Parameters.AddWithValue("@AccNum", Acc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    addTransaction4();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn3000Din_Click(object sender, EventArgs e)
        {
            if (bal < 3000)
            {
                MessageBox.Show("Balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int newBalance = bal - 3000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@WithdrawAmount", 3000);
                    cmd.Parameters.AddWithValue("@AccNum", Acc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    addTransaction5();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn4000Din_Click(object sender, EventArgs e)
        {
            if (bal < 4000)
            {
                MessageBox.Show("Balance cannot be negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int newBalance = bal - 4000;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance = Balance - @WithdrawAmount where AccNum = @AccNum";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@WithdrawAmount", 4000);
                    cmd.Parameters.AddWithValue("@AccNum", Acc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Withdrawal has been successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    addTransaction6();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
