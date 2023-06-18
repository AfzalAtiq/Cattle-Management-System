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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cattlemanagmentsystem
{
    public partial class Dashboard : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\cms.mdf;Integrated Security=True;Connect Timeout=30");

        public Dashboard()
        {
            InitializeComponent();
            DashboardDisplay();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
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


        private void label16_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }


        private void label7_Click(object sender, EventArgs e)
        {
            Cow Ob = new Cow();
            Ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void DashboardDisplay()
        {
            Con.Open();
            // for cow count 
            string Query = "select count(*) from Cowtbl";
            SqlCommand cmd = new SqlCommand(Query, Con);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            if (dr.Read())
            {
                count = dr.GetInt32(0);
                label10.Text =  Convert.ToString(count);
            }
            else
            {
                MessageBox.Show("Cow Table Records Not found");
            }
            dr.Close();

            // for total milk liters 
            string Query2 = "select sum(TotalMilk) from MilkTbl";
            SqlCommand cmd2 = new SqlCommand(Query2, Con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            int sum = 0;
            if (dr2.Read())
            {
                sum = dr2.GetInt32(0);
                label13.Text = Convert.ToString(sum);
            }
            else
            {
                MessageBox.Show("Milk Table Records Not found");
            }
            dr2.Close();

            // for lowest milk sales 
            string Query3 = "select min(Amount) from MilkSalesTbl";
            SqlCommand cmd3 = new SqlCommand(Query3, Con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            int low = 0;
            if (dr3.Read())
            {
                low = dr3.GetInt32(0);
                label15.Text = Convert.ToString(low);
            }
            else
            {
                MessageBox.Show("Milk Sales Table Records Not found");
            }
            dr3.Close();

            // for highest milk sales 
            string Query4 = "select max(Amount) from MilkSalesTbl";
            SqlCommand cmd4 = new SqlCommand(Query4, Con);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            int high = 0;
            if (dr4.Read())
            {
                high = dr4.GetInt32(0);
                label20.Text = Convert.ToString(high);
            }
            else
            {
                MessageBox.Show("Milk Sales Table Records Not found");
            }
            dr4.Close();

            // for lowest milk sales 
            string Query5 = "select sum(Amount) from MilkSalesTbl";
            SqlCommand cmd5 = new SqlCommand(Query5, Con);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            int totalSales = 0;
            if (dr5.Read())
            {
                totalSales = dr5.GetInt32(0);
                label21.Text = Convert.ToString(totalSales);
            }
            else
            {
                MessageBox.Show("Milk Sales Table Records Not found");
            }
            dr5.Close();


            Con.Close();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_2(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
