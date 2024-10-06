using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VivexBanka
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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

        private void btnBalance_Click(object sender, EventArgs e)
        {
            Balance balance = new Balance();
            balance.Show();
            this.Hide();
        }
        public static String AccNumber;
        private void Home_Load(object sender, EventArgs e)
        {
            AccNumLbl.Text = "Account Number: " + Login.AccNumber;
            AccNumber = Login.AccNumber;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Hide();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            ChangePin changePin = new ChangePin();
            changePin.Show();
            this.Hide();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
            this.Hide();
        }

        private void btnFastCash_Click(object sender, EventArgs e)
        {
            Fastcash fastcash = new Fastcash();
            fastcash.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ministatement ministatement = new Ministatement();
            ministatement.Show();
            this.Hide();
        }
    }
}
