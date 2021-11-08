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
    public partial class Form13 : Form
    {
        int top = 3;
        int left = 64;

        List<string> fellowNames = new List<string>();

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        public Form13()
        {
            InitializeComponent();
            loadNameUser(Form1.userName);
            getProfilePic(Form1.userName, pictureBox5);
            addItemToList();
            loadFellowdata();

        }

        private void loadNameUser(string userName)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    button2.Text = cmd2.ExecuteScalar().ToString();
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


        public void getProfilePic(string userName,PictureBox pictureBox)
        {


            con.Open();

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='"+ userName + "'", con);

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
                    SqlCommand cmd1 = new SqlCommand("select profilePicture from fellowshipUsersList where userName='"+ userName + "'", con1);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)

                    {

                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePicture"]);

                        pictureBox.Image = new Bitmap(ms);
                        

                    }
                }
            }
            con.Close();
        }


        public void addItemToList()
        {
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("SELECT fel1,fel2,fel3,fel4,fel5,fel6,fel7,fel8,fel9,fel10 from fellows where userName='" + Form1.userName + "'", con);
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

                        fellowNames.Add(reader.GetString(i));
                                             
                    }
                }
            }
            con.Close();
        }


        PictureBox pictureBox3;
        Button button3;
        List<Button> btnArray = new List<Button>();
 



        void loadFellowdata()
        {

            for (int i = 0; i < fellowNames.Count; i++)
            {
                   SqlConnection con0 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

                    pictureBox3 = new PictureBox();

                    pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(231)))), ((int)(((byte)(254)))));
                    pictureBox3.Location = new System.Drawing.Point(10, 13);
                    pictureBox3.Name = "pictureBox1";
                    pictureBox3.Size = new System.Drawing.Size(25, 25);
                    pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pictureBox3.TabIndex = 1;
                    pictureBox3.TabStop = false;

                con0.Open();

                    SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='"+fellowNames[i]+"'", con0);

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
                            SqlCommand cmd1 = new SqlCommand("select profilePicture from fellowshipUsersList where userName='"+fellowNames[i]+"'", con1);
                            SqlDataAdapter da = new SqlDataAdapter(cmd1);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)

                            {

                                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePicture"]);

                                pictureBox3.Image = new Bitmap(ms);


                            }
                        }
                    }
                    con0.Close();



                button3 = new Button();

                button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(231)))), ((int)(((byte)(254)))));
                button3.Dock = System.Windows.Forms.DockStyle.Top;
                button3.FlatAppearance.BorderSize = 0;
                button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button3.Location = new System.Drawing.Point(0, 0);
                button3.Name = "button1";
                button3.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
                button3.Size = new System.Drawing.Size(220, 52);
                button3.TabIndex = 0;
                button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                button3.UseVisualStyleBackColor = false;
                button3.Click += new System.EventHandler(button3_Click);


                try
                {

                    if (con0.State == ConnectionState.Closed)
                    {

                        string query2 = "Select FullName from fellowshipUsersList where userName= '" + fellowNames[i] + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con0);

                        con0.Open();
                        button3.Text = cmd2.ExecuteScalar().ToString();
                        con0.Close();


                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con0.Close();
                }



                Panel panel3 = new Panel();

                panel3.Controls.Add(pictureBox3);
                panel3.Controls.Add(button3);
                panel3.Location = new System.Drawing.Point(top, left);
                panel3.Name = "panel3";
                panel3.Size = new System.Drawing.Size(220, 55);
                panel3.TabIndex = 1;

                this.flowLayoutPanel1.Controls.Add(panel3);
                left += 64;

                btnArray.Add(button3);

                //btnArray[i].Click += new System.EventHandler(button3_Click);
             

            }
        }


        private void loadNameFellow(string userName)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select FullName from fellowshipUsersList where userName= '" + userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    label4.Text = cmd2.ExecuteScalar().ToString();
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



        private void button3_MouseHover(object sender, EventArgs e)
        {
            //pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
        }

  

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            //pictureBox3.BackColor =Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
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
            panel4.Controls.Add(childform);
            panel4.Tag = childform;
            childform.BringToFront();
            childform.Show();



        }


        private void button3_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            for (int i = 0; i < fellowNames.Count; i++)
            {
                if (btnSender == btnArray[i])
                {
                    pictureBox9.Visible = true;
                    pictureBox12.Visible = true;
                    label4.Visible = true;
                    label1.Visible = true;
                    loadNameFellow(fellowNames[i]) ;
                    getProfilePic(fellowNames[i],pictureBox12);
                    Form14 form = new Form14();
                    form.label3.Text = "Hi! I am " +fellowNames[i].Trim()+".How are you?";
                    form.label1.Text = "Hi! I am " +Form1.userName.Trim();
                    openChildForm(form);

                }
              
            }
        }

        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);

            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form13 form = new Form13();
            this.Hide();
            form.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
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
    }
}
