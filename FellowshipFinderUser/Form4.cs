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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        public Form4()
        {
            InitializeComponent();
            getInformation();
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


        public bool getInformation()
        {

            try
            {
                string query = "Select username from acceptedGRequests where userName= '" + Form1.userName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);


                if (dtbl.Rows.Count == 1)
                {
                    if (con.State == ConnectionState.Closed)
                    {

                        string query1 = "Select firstname from acceptedGRequests where userName= '" + Form1.userName + "'";
                        string query2 = "Select lastName from acceptedGRequests where userName= '" + Form1.userName + "'";
                        string query3 = "Select email from acceptedGRequests where userName= '" + Form1.userName + "'";
                        string query4 = "Select groupname from acceptedGRequests where userName= '" + Form1.userName + "'";
                        string query5 = "Select catgory from acceptedGRequests where userName= '" + Form1.userName + "'";
                        string query6 = "Select description from acceptedGRequests where userName= '" + Form1.userName + "'";


                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        SqlCommand cmd3 = new SqlCommand(query3, con);
                        SqlCommand cmd4 = new SqlCommand(query4, con);
                        SqlCommand cmd5 = new SqlCommand(query5, con);
                        SqlCommand cmd6 = new SqlCommand(query6, con);



                        con.Open();
                        label8.Text = cmd1.ExecuteScalar().ToString();
                        label9.Text = cmd2.ExecuteScalar().ToString();
                        label10.Text = cmd3.ExecuteScalar().ToString();
                        label11.Text = cmd4.ExecuteScalar().ToString();
                        label12.Text = cmd5.ExecuteScalar().ToString();
                        label13.Text = cmd6.ExecuteScalar().ToString();
                        con.Close();

                        label14.Text = "Request Accepted";
                        label14.ForeColor = Color.DarkGreen;

                        return true;

                    }
                }
                else
                {
                    string query7 = "Select username from verificationRequests where userName= '" + Form1.userName + "'";
                    SqlDataAdapter sda1 = new SqlDataAdapter(query7, con);

                    DataTable dtbl1 = new DataTable();
                    sda1.Fill(dtbl1);

                    if (dtbl1.Rows.Count == 1)
                    {
                        if (con.State == ConnectionState.Closed)
                        {

                            string query1 = "Select firstname from verificationRequests where userName= '" + Form1.userName + "'";
                            string query2 = "Select lastName from verificationRequests where userName= '" + Form1.userName + "'";
                            string query3 = "Select email from verificationRequests where userName= '" + Form1.userName + "'";
                            string query4 = "Select groupname from verificationRequests where userName= '" + Form1.userName + "'";
                            string query5 = "Select catagory from verificationRequests where userName= '" + Form1.userName + "'";
                            string query6 = "Select description from verificationRequests where userName= '" + Form1.userName + "'";


                            SqlCommand cmd1 = new SqlCommand(query1, con);
                            SqlCommand cmd2 = new SqlCommand(query2, con);
                            SqlCommand cmd3 = new SqlCommand(query3, con);
                            SqlCommand cmd4 = new SqlCommand(query4, con);
                            SqlCommand cmd5 = new SqlCommand(query5, con);
                            SqlCommand cmd6 = new SqlCommand(query6, con);



                            con.Open();
                            label8.Text = cmd1.ExecuteScalar().ToString();
                            label9.Text = cmd2.ExecuteScalar().ToString();
                            label10.Text = cmd3.ExecuteScalar().ToString();
                            label11.Text = cmd4.ExecuteScalar().ToString();
                            label12.Text = cmd5.ExecuteScalar().ToString();
                            label13.Text = cmd6.ExecuteScalar().ToString();
                            con.Close();

                            label14.Text = "Request Pending";
                            label14.ForeColor = Color.CornflowerBlue;

                            return true;

                        }


                    }
                    else
                    {
                        return false;
                    }

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

            return false;


        }


        public bool getStatus()
        {

            try
            {
                string query = "Select username from acceptedGRequests where userName= '" + Form1.userName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);


                if (dtbl.Rows.Count == 1)
                {
                   
                        return true;

                    
                }
                else
                {
                    string query7 = "Select username from verificationRequests where userName= '" + Form1.userName + "'";
                    SqlDataAdapter sda1 = new SqlDataAdapter(query7, con);

                    DataTable dtbl1 = new DataTable();
                    sda1.Fill(dtbl1);

                    if (dtbl1.Rows.Count == 1)
                    {
                       

                            return false;

                        


                    }
                  
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

            return false;


        }


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            this.Hide();
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

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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

                Form1 form = new Form1();
                this.Hide();
                form.Show();


            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
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
