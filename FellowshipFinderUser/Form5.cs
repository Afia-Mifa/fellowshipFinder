using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FellowshipFinderUser
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        //private static string userName = Form1.userName;
        public static string selectedUserName;

        public Form5()
        {
            InitializeComponent();
            addItemToList();
            getProfilePic();
            loadName();
        }

        public void getProfilePic()
        {


            con.Open();

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + Form1.userName + "'", con);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(10))
                {





                }
                else
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
                    SqlCommand cmd1 = new SqlCommand("select profilePicture from fellowshipUsersList where userName='" + Form1.userName + "'", con1);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)

                    {

                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePicture"]);

                        pictureBox5.Image = new Bitmap(ms);
                       

                    }
                }
            }
            con.Close();
        }

        private void loadName()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    button1.Text = cmd2.ExecuteScalar().ToString();
                    con.Close();


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }



        public void addItemToList()
        {
            SqlCommand cmd;
        
            listView1.Columns.Add("  ", 50);
            listView1.Columns.Add("  ", 500);
            listView1.View = View.Details;

            con.Open();
            cmd = new SqlCommand("SELECT req1,req2,req3,req4,req5,req6 ,req7,req8,req9,req10  FROM fellowRequestsRecieved where userName='" + Form1.userName + "'", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < 10; i++)
                {
                    if (reader.IsDBNull(i))
                    {


                        //Do Nothing


                    }
                    else
                    {

                        listView1.Items.Add(reader.GetString(i));
                        listView1.Items[i].SubItems.Add("Has sent a fellow request");
                    }
                }
            }
            con.Close();
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

                private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            selectedUserName = listView1.SelectedItems[0].Text;
            Form10 form = new Form10();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);


            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form13 from = new Form13();
            this.Hide();
            from.Show();
        }
    }
}
