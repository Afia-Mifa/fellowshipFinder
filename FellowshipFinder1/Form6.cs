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

namespace FellowshipFinder1
{
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        public Form6()
        {
            InitializeComponent();
            getDataInAcceptanceTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void getDataInAcceptanceTable()
        {


            SqlCommand cmd = new SqlCommand("SELECT *FROM acceptedGRequests", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();


            dataGridView1.DataSource = dt;
      
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
