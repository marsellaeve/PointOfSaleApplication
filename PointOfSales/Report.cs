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

namespace SupermarketTuto
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-KNP6JF7;Initial Catalog=TEST;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from OutcomeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OutDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void jumlah()
        {
            Con.Open();
            string query = "select SUM(OutTotal) from OutcomeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TotOutcome.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();
        }
        private void jumlahdua()
        {
            Con.Open();
            string query = "select SUM(TotAmt) from BillTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TotIncome.Text = ds.Tables[0].Rows[0][0].ToString();
            Con.Close();

            int total = Convert.ToInt32(TotIncome.Text) - Convert.ToInt32(TotOutcome.Text);
            hasil.Text = total.ToString();
        }
        private void populatebills()
        {
            Con.Open();
            string query = "select * from BillTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Report_Load(object sender, EventArgs e)
        {
            populate();
            populatebills();
            jumlah();
            jumlahdua();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Outcome outcome = new Outcome();
            outcome.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
