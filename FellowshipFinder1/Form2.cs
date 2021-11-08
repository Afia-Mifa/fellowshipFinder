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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        int buttonCount1 = 0;
        int buttonCount2 = 0;




        public Form2()
        {
            InitializeComponent();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            this.Hide();
            form.Show();
        }

        private void verificationRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void addItemToList()
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            SqlCommand cmd;
            DataTable dtbl;
            SqlDataAdapter sda;
            DataSet dtset;
   
            Form3 form = new Form3();
            this.Hide();
            form.Show();


            form.listView1.Columns.Add("Requests", 500);
            form.listView1.Columns.Add("  ", 500);
            form.listView1.View = View.Details;

            con.Open();
            cmd = new SqlCommand("SELECT * FROM verificationRequests", con);
            sda = new SqlDataAdapter(cmd);
            dtset = new DataSet();
            sda.Fill(dtset, "verification Request List");
            con.Close();
            dtbl = dtset.Tables["verification Request List"];

            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                form.listView1.Items.Add("@" + dtbl.Rows[i].ItemArray[0].ToString());
                form.listView1.Items[i].SubItems.Add("Has sent a verification request");

            }

            form.listView1.ForeColor = Color.Blue;
            form.listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

    
        }

        private void addToDataGrid()
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT *FROM verificationRequests", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            Form5 form5 = new Form5();
            form5.dataGridView1.DataSource = dt;

            form5.Show();


        }



        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
         
        }



        private void button7_Click(object sender, EventArgs e)
        {
       
        }

        private void button8_Click(object sender, EventArgs e)
        {
       
        }

    

        private void button1_Click_2(object sender, EventArgs e)
        {
            buttonCount1++;
            if (buttonCount1 % 2 == 0)
            {
                panel4.Visible = false;
                panel6.Visible = false;
            }
            else
            {
                panel4.Visible = true;
                panel6.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonCount2++;
            if (buttonCount2 % 2 == 0)
            {
                panel4.Visible = false;
                panel6.Visible = false;
            }
            else
            {
                panel4.Visible = false;
                panel6.Visible = true;

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form8());
            /*Form8 form = new Form8();
            this.Hide();
            form.Show();*/

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            /*Form3 form = new Form3();
            this.Hide();
            form.Show();*/
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form5());

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        Form activeForm = null;

        void openChildForm(Form childform)
        {
            if (activeForm != null)
            {
                //activeForm.Close();
            }
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel13.Controls.Add(childform);
            panel13.Tag = childform;
            childform.BringToFront();
            childform.Show();



        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
    }
}
