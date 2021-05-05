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
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-KNP6JF7;Initial Catalog=TEST;Integrated Security=True");

        private void SellerForm_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from SellerTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into SellerTb1 values (" + SId.Text + ",'" + SName.Text + "'," + SAge.Text + ",'"+SPhone.Text+"','"+SPass.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successful");
                Con.Close();
                populate();
                SId.Text = ""; SName.Text = ""; SAge.Text = ""; SPhone.Text = "";SPass.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SId.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            SName.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            SAge.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            SPhone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            SPass.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (SId.Text == "")
                {
                    MessageBox.Show("Select The Seller to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from SellerTb1 where SellerId=" + SId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully");
                    Con.Close();
                    populate();
                    SId.Text = ""; SName.Text = ""; SAge.Text = ""; SPhone.Text = ""; SPass.Text = "";
                }
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
                if (SId.Text == "" || SName.Text == "" || SAge.Text == "" || SPhone.Text == "" || SPass.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update SellerTb1 set SellerName='" + SName.Text + "', SellerAge=" + SAge.Text + ", SellerPhone='" + SPhone.Text + "', SellerPass= '" + SPass.Text + "' where SellerId=" + SId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated Successfully");
                    Con.Close();
                    populate();
                }
                SId.Text = ""; SName.Text = ""; SAge.Text = ""; SPhone.Text = ""; SPass.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Outcome outcome = new Outcome();
            outcome.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }
    }
}
