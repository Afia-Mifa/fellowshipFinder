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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        public Form3()
        {
            InitializeComponent();
            getCoverPic();
            getProfilePic();
            getInformation();
            getBadge();
            addToPostList();
           loadPosts();
            
        }

        public void getBadge()
        {
            bool status;

            Form4 form = new Form4();
            status = form.getStatus();

            if (status)
            {
                pictureBox14.Visible = true;
            }
            else
            {
                pictureBox14.Visible = false;
            }


        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);

            }
        }


        public void getProfilePicUser()
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

                        pictureBox9.Image = new Bitmap(ms);


                    }
                }
            }
            con.Close();
        }

        private void loadNameUser()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    button12.Text = cmd2.ExecuteScalar().ToString();
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

                        pictureBox1.Image = new Bitmap(ms);
                        pictureBox7.Image = new Bitmap(ms);
                        pictureBox9.Image = new Bitmap(ms);

                    }
                }
            }
            con.Close();
        }



        public void getCoverPic()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + Form1.userName + "'", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(11))
                {





                }
                else
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
                    SqlCommand cmd1 = new SqlCommand("select coverPicture from fellowshipUsersList where userName='" + Form1.userName + "'", con1);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);

                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)

                    {

                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["coverPicture"]);

                        pictureBox2.Image = new Bitmap(ms);

                    }

                }             
            }   
            con.Close();
        }

        private void getInformation()
        {

            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query1 = "Select Fullname from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    string query2 = "Select about from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    string query3 = "Select PresentCity from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    string query4 = "Select PermanentCity from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    string query5 = "Select interestList from fellowshipUsersList where userName= '" + Form1.userName + "'";


                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    SqlCommand cmd5 = new SqlCommand(query5, con);



                    con.Open();
                    label1.Text = cmd1.ExecuteScalar().ToString();
                    button12.Text = label1.Text;
                    label2.Text = cmd2.ExecuteScalar().ToString();
                    label3.Text = cmd3.ExecuteScalar().ToString();
                    label4.Text = cmd4.ExecuteScalar().ToString();
                    label5.Text = cmd5.ExecuteScalar().ToString();
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






        private void button1_Click(object sender, EventArgs e)
        {
       
            count++;
            //for (int i = 0; i < count; i++)
            //{
                PictureBox pictureBox9 = new PictureBox();

                this.panel6.Controls.Add(pictureBox9);

                pictureBox9.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_social_invite_friends_list_contacts_group_chat_2701089;
                pictureBox9.Location = new System.Drawing.Point(282, 269);
                pictureBox9.Name = "pictureBox9";
                pictureBox9.Size = new System.Drawing.Size(231, 126);
                pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox9.TabIndex = 0;
                pictureBox9.TabStop = false;

 
                count--;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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
                    textBox5.Text = cmd2.ExecuteScalar().ToString();
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

        private void loadAbout()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select about from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    textBox6.Text = cmd2.ExecuteScalar().ToString();
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

        private void loadPresentCity()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select presentCity from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    textBox2.Text = cmd2.ExecuteScalar().ToString();
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

        private void loadPermanentCity()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select permanentCity from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    textBox3.Text = cmd2.ExecuteScalar().ToString();
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

        private void loadInterest()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select interestList from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    textBox4.Text = cmd2.ExecuteScalar().ToString();
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


        private void saveName()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query2 = "Update fellowshipUsersList Set FullName='" + textBox5.Text + "' where userName= '" + Form1.userName + "'";
                    string query3 = "Select Fullname from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    label1.Text = cmd3.ExecuteScalar().ToString();
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



        private void saveAbout()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query2 = "Update fellowshipUsersList Set About='" + textBox6.Text + "' where userName= '" + Form1.userName + "'";
                    string query3 = "Select About from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    label2.Text = cmd3.ExecuteScalar().ToString();
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



        private void savePresentCity()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query2 = "Update fellowshipUsersList Set presentCity='" + textBox2.Text + "' where userName= '" + Form1.userName + "'";
                    string query3 = "Select presentCity from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    label3.Text = cmd3.ExecuteScalar().ToString();
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


        private void savePermanentCity()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query2 = "Update fellowshipUsersList Set permanentCity='" + textBox3.Text + "' where userName= '" + Form1.userName + "'";
                    string query3 = "Select permanentCity from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    label4.Text = cmd3.ExecuteScalar().ToString();
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



        private void saveinterestList()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query2 = "Update fellowshipUsersList Set interestList='" + textBox4.Text + "' where userName= '" + Form1.userName + "'";
                    string query3 = "Select interestList from fellowshipUsersList where userName= '" + Form1.userName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    cmd2.ExecuteNonQuery();
                    label5.Text = cmd3.ExecuteScalar().ToString();
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


        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            loadPresentCity();
            loadPermanentCity();
            loadInterest();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            savePresentCity();
            savePermanentCity();
            saveinterestList();

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true;
            button5.Visible = true;
            loadName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Visible = true;
            button6.Visible = true;
            loadAbout();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveName();
            textBox5.Visible = false;
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveAbout();
            textBox6.Visible = false;
            button6.Visible = false;
        }

        string profileImageLocation = "";
        string coverImageLocation = "";

        private string openFileExplorer(PictureBox pictureBox, string imageLocation,Button button, Button button1)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {
                button.Visible = true;
                button1.Visible = true;

                imageLocation = file.FileName.ToString();
                pictureBox.ImageLocation = imageLocation;

            }
            return imageLocation;
        }



        private void saveProfilePhoto()
        {
            byte[] images1 = null;
            FileStream stream1 = new FileStream(profileImageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs1 = new BinaryReader(stream1);
            images1 = brs1.ReadBytes((int)stream1.Length);

            con.Open();
            string query = "Update fellowshipUsersList Set ProfilePicture= @profilePic where userName= '" + Form1.userName + "'"; ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@profilePic", images1));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Profile Picture Changed successfuly","",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void saveCoverPhoto()
        {
            byte[] images1 = null;
            FileStream stream1 = new FileStream(coverImageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs1 = new BinaryReader(stream1);
            images1 = brs1.ReadBytes((int)stream1.Length);

            con.Open();
            string query = "Update fellowshipUsersList Set coverPicture= @coverPic where userName= '" + Form1.userName + "'"; ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@coverPic", images1));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Cover Picture Changed successfuly", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
            profileImageLocation = openFileExplorer(pictureBox1, profileImageLocation,button7,button9);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            coverImageLocation = openFileExplorer(pictureBox2, coverImageLocation,button8,button10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveProfilePhoto();
            getProfilePic();
            button7.Visible = false;
            button9.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveCoverPhoto();
            button8.Visible = false;
            button10.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
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

                Form1 form = new Form1();
                this.Hide();
                form.Show();

            }
        }

        private void Form3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }



       


   
        int count = 1;
        List<string> postsList = new List<string>();


        private void button11_Click(object sender, EventArgs e)
        {
                 post();

                Panel panel8 = new Panel();
                PictureBox pictureBox15 = new PictureBox();
                PictureBox pictureBox16 = new PictureBox();

                pictureBox15.Image = global::FellowshipFinderUser.Properties.Resources.purpleBackLight;
                pictureBox15.Location = new System.Drawing.Point(19, 20);
                pictureBox15.Name = "pictureBox15";
                pictureBox15.Size = new System.Drawing.Size(307, 186);
                pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox15.TabIndex = 0;
                pictureBox15.TabStop = false;



                pictureBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                pictureBox16.Location = new System.Drawing.Point(35, 38);
                pictureBox16.Name = "pictureBox16";
                pictureBox16.Size = new System.Drawing.Size(25, 25);
                pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox16.TabIndex = 36;
                pictureBox16.TabStop = false;



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

                            pictureBox16.Image = new Bitmap(ms);

                        }
                    }
                }
                con.Close();







                Label label6 = new Label();
                Label label11 = new Label();

                label6.AutoSize = true;
                label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label6.Location = new System.Drawing.Point(65, 40);
                label6.Name = "label6";
                label6.Size = new System.Drawing.Size(46, 18);
                label6.TabIndex = 37;




                try
                {

                    if (con.State == ConnectionState.Closed)
                    {

                        string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);

                        con.Open();
                        label6.Text = cmd2.ExecuteScalar().ToString();
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



                label11.AutoSize = true;
                label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label11.Location = new System.Drawing.Point(64, 68);
                label11.Name = "label11";
                label11.Size = new System.Drawing.Size(70, 24);
                label11.TabIndex = 38;
                label11.Text = richTextBox1.Text;






                panel8.BackColor = System.Drawing.Color.White;
                panel8.Controls.Add(label11);
                panel8.Controls.Add(label6);
                panel8.Controls.Add(pictureBox16);
                panel8.Controls.Add(pictureBox15);
                panel8.Location = new System.Drawing.Point(3, 3);
                panel8.Name = "panel8";
                panel8.Size = new System.Drawing.Size(348, 221);
                panel8.TabIndex = 0;

                this.flowLayoutPanel1.Controls.Add(panel8);
            
        }





        private void post()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query = "SELECT post1,post2,post3, post4,post5,post6, post7,post8,post9,post10 from posts where username='" + Form1.userName + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (reader.IsDBNull(i))
                        {
                            if (i == 0)
                            {
                                try
                                {


                                    if (con1.State == ConnectionState.Closed)

                                    {

                                        string query2 = "Update posts Set post1='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();


                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                                break;
                            }
                            else if (i == 1)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post2='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 2)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post3='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 3)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post4='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 4)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post5='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 5)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post6='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 6)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post7='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }

                            else if (i == 7)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post8='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 8)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post9='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();


                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }
                            else if (i == 9)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Update posts Set post10='" + richTextBox1.Text.Replace("\r\n", "<br />") + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery(); 
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }


                        }

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }



        SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        private void  addToPostList()
        {
        
            string query = "SELECT post1,post2,post3, post4,post5,post6, post7,post8,post9,post10 from posts where username='" + Form1.userName + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader;
            string post="";

            try
            {
                con.Open();
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (i == 0)
                            {
                                try
                                {


                                    if (con1.State == ConnectionState.Closed)

                                    {

                                        string query2 = "Select post1 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();
                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                            }
                            else if (i == 1)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post2 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                
                            }
                            else if (i == 2)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post3 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else if (i == 3)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post4 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                      
                            }
                            else if (i == 4)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post5 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                     
                            }
                            else if (i == 5)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post6 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                   
                            }
                            else if (i == 6)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post7 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                
                            }

                            else if (i == 7)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post8 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();




                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

               
                            }
                            else if (i == 8)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post9 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();


                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                   
                            }
                            else if (i == 9)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {

                                        string query2 = "Select post10 from posts where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        postsList.Add(cmd2.ExecuteScalar().ToString());
                                        con1.Close();



                                    }



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                   
                            }


                        }

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }



        }

        void loadPosts()
        {
            for (int i = 0; i < postsList.Count; i++)
            {

                Panel panel8 = new Panel();
                PictureBox pictureBox15 = new PictureBox();
                PictureBox pictureBox16 = new PictureBox();

                pictureBox15.Image = global::FellowshipFinderUser.Properties.Resources.purpleBackLight;
                pictureBox15.Location = new System.Drawing.Point(19, 20);
                pictureBox15.Name = "pictureBox15";
                pictureBox15.Size = new System.Drawing.Size(307, 186);
                pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox15.TabIndex = 0;
                pictureBox15.TabStop = false;




                pictureBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                pictureBox16.Location = new System.Drawing.Point(35, 38);
                pictureBox16.Name = "pictureBox16";
                pictureBox16.Size = new System.Drawing.Size(25, 25);
                pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox16.TabIndex = 36;
                pictureBox16.TabStop = false;



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

                            pictureBox16.Image = new Bitmap(ms);

                        }
                    }
                }
                con.Close();







                Label label6 = new Label();
                Label label11 = new Label();

                label6.AutoSize = true;
                label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label6.Location = new System.Drawing.Point(65, 40);
                label6.Name = "label6";
                label6.Size = new System.Drawing.Size(46, 18);
                label6.TabIndex = 37;




                try
                {

                    if (con.State == ConnectionState.Closed)
                    {

                        string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);

                        con.Open();
                        label6.Text = cmd2.ExecuteScalar().ToString();
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



                label11.AutoSize = true;
                label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label11.Location = new System.Drawing.Point(64, 77);
                label11.Name = "label11";
                label11.Size = new System.Drawing.Size(70, 24);
                label11.TabIndex = 38;
                label11.Text = postsList[i].Replace("\r\n", "<br />"); ;






                panel8.BackColor = System.Drawing.Color.White;
                panel8.Controls.Add(label11);
                panel8.Controls.Add(label6);
                panel8.Controls.Add(pictureBox16);
                panel8.Controls.Add(pictureBox15);
                panel8.Location = new System.Drawing.Point(3, 3);
                panel8.Name = "panel8";
                panel8.Size = new System.Drawing.Size(348, 221);
                panel8.TabIndex = 0;

                count--;

                this.flowLayoutPanel1.Controls.Add(panel8);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form13 from = new Form13();
            this.Hide();
            from.Show();
        }
    }
}
