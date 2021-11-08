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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        Form3 form3 = new Form3();

        public Form4()
        {
            InitializeComponent();
            getDataInTable();

        }

        private void getDataInTable()
        {

            SqlCommand cmd = new SqlCommand("SELECT *FROM verificationRequests", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();


            dataGridView1.DataSource = dt;
        }


    }
}
