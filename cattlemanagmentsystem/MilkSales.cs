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

namespace cattlemanagmentsystem
{
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            populate();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
     

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Cow Ob = new Cow();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Milk_Prodction Ob = new Milk_Prodction();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }


        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        private void QuantityTb_TextChanged(object sender, EventArgs e)
        {
            int price = 0, quantity = 0;
            if (Price.Text != "") { price = Convert.ToInt32(Price.Text); }
            if (QuantityTb.Text != "") { quantity = Convert.ToInt32(QuantityTb.Text); }
            int total = price * quantity;
            TotalTb.Text = Convert.ToString(total);
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\cms.mdf;Integrated Security = True; Connect Timeout = 30");

        private void populate()
        {
            Con.Open();
            string Query = "select * from MilkSalesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder bulider = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MilkSalesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            Price.Text = "";
            ClientName.Text = "";
            PhoneTb.Text = "";
            QuantityTb.Text = "";
            TotalTb.Text = "";
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Price.Text == "" || ClientName.Text == "" || PhoneTb.Text == "" || QuantityTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into MilkSalesTbl values('" + Date.Value.Date + "','" + Price.Text + "','" + ClientName.Text + "','" + PhoneTb.Text + "','" + QuantityTb.Text + "','" + TotalTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Saved Successfully");

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        int key = 0;
        private void MilkSalesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Date.Text = MilkSalesDGV.SelectedRows[0].Cells[1].Value.ToString();
            Price.Text = MilkSalesDGV.SelectedRows[0].Cells[2].Value.ToString();
            ClientName.Text = MilkSalesDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = MilkSalesDGV.SelectedRows[0].Cells[4].Value.ToString();
            QuantityTb.Text = MilkSalesDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalTb.Text = MilkSalesDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (Price.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(MilkSalesDGV.SelectedRows[0].Cells[0].Value.ToString());

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Price.Text == "" || ClientName.Text == "" || PhoneTb.Text == "" || QuantityTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update MilkSalesTbl set Date='" + Date.Value.Date + "',Uprice='" + Price.Text + "',ClientName='" + ClientName.Text + "',ClientPhone='" + PhoneTb.Text + "',Quantity='" + QuantityTb.Text + "',Amount='" + TotalTb.Text + "' where SId='" + key + "';";

                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sales Updated Successfully");

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Milk Sales To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete From MilkSalesTbl where SId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sales Deleted Successfully");

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
