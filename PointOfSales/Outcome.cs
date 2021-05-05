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
    public partial class Outcome : Form
    {
        public Outcome()
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

        private void Outcome_Load(object sender, EventArgs e)
        {
            populate();
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

        private void CatIdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into OutcomeTb1 values (" + OutId.Text + ",'" + OutName.Text + "','" + OutDate.Text + "'," + OutTotal.Text + ",'" + OutDesc.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Outcome Added Successful");
                Con.Close();
                populate();
                OutId.Text = ""; OutName.Text = ""; OutDate.Text = ""; OutTotal.Text = ""; OutDesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (OutId.Text == "" || OutName.Text == "" || OutDate.Text == "" || OutTotal.Text == "" || OutDesc.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update OutcomeTb1 set AdminName='" + OutName.Text + "', OutDate='" + OutDate.Text + "', OutTotal=" + OutTotal.Text + ", Description='" + OutDesc.Text + "' where OutId=" + OutId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Outcome Updated Successfully");
                    Con.Close();
                    populate();
                }
                OutId.Text = ""; OutName.Text = ""; OutDate.Text = ""; OutTotal.Text = ""; OutDesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (OutId.Text == "")
                {
                    MessageBox.Show("Select The Outcome to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from OutcomeTb1 where OutId=" + OutId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Outcome Deleted Successfully");
                    Con.Close();
                    populate();
                }
                OutId.Text = ""; OutName.Text = ""; OutDate.Text = ""; OutTotal.Text = ""; OutDesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OutDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OutId.Text = OutDGV.SelectedRows[0].Cells[0].Value.ToString();
            OutName.Text = OutDGV.SelectedRows[0].Cells[1].Value.ToString();
            OutDate.Text = OutDGV.SelectedRows[0].Cells[2].Value.ToString();
            OutTotal.Text = OutDGV.SelectedRows[0].Cells[3].Value.ToString();
            OutDesc.Text = OutDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }
    }
}
