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
    public partial class Milk_Prodction : Form
    {
        public Milk_Prodction()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }
        private void label14_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Cow Ob = new Cow();
            Ob.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Milk_Prodction_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\cms.mdf;Integrated Security = True; Connect Timeout = 30");
        private void FillCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string Query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder bulider = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void GetCowName()
        {
            Con.Open();
            string query = "select * from CowTbl where CowId=" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();
            }
            Con.Close();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            Amtb.Text = "";
            noontb.Text = "";
            PmTb.Text = "";
            TotalTb.Text = "";
            key = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || Amtb.Text == "" || PmTb.Text == "" || noontb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into MilkTbl values('" + CowIdCb.SelectedValue.ToString() + "','" + CowNameTb.Text + "','" + Amtb.Text + "','" + noontb.Text + "','" + PmTb.Text + "','" + TotalTb.Text + "','" + Date.Value.Date + "')";
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

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void PmTb_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void PmTb_TextChanged(object sender, EventArgs e)
        {
            int pm = 0, am = 0, noon = 0; 
            if (PmTb.Text != "") { pm = Convert.ToInt32(PmTb.Text); }
            if (Amtb.Text != "") { am = Convert.ToInt32(Amtb.Text); }
            if (noontb.Text != "") { noon = Convert.ToInt32(noontb.Text); }
            int total = am + noon + pm;
            TotalTb.Text = Convert.ToString(total);
        }
        int key = 0;
        private void MilkDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            Amtb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            noontb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmTb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalTb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            Date.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Milk Product To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "Delete From MilkTbl where Mld=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || Amtb.Text == "" || PmTb.Text == "" || noontb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update MilkTbl set CowName='" + CowNameTb.Text + "',AmMilk='" + Amtb.Text + "',NoonMilk='" + noontb.Text + "',PmMilk='" + PmTb.Text + "',TotalMilk='" + TotalTb.Text + "',DateProd='" + Date.Value.Date + "' where Mld='" + key + "';";

                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Successfully");

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
