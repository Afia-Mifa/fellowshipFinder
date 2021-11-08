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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        DataTable dbDataset;
        //public static string userName=Form1.userName;
        public static string fellowSearch;
        int buttonClickCount = 0;
        int buttonClickCount1 = 0;
        List<string> fellowList = new List<string>();
        List<string> postsList = new List<string>();
        List<string> postsListUser = new List<string>();
        List<string> userNameList = new List<string>();

        public Form2()
        {
          
            InitializeComponent();  
            getDataInTable();
            getProfilePic();
            autoComplete();
            getBadge();
            loadfellowList();
            addToPostList();
            addPostToHome();
            addToPostListuser();
            loadPostsUser();
        }

        SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        private void addToPostListuser()
        {

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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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
                                        postsListUser.Add(cmd2.ExecuteScalar().ToString());
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

        void loadPostsUser()
        {
            for (int i = 0; i < postsListUser.Count; i++)
            {

                Panel panel19 = new Panel();

                this.flowLayoutPanel1.Controls.Add(panel19);

                PictureBox pictureBox11 = new PictureBox();
                PictureBox pictureBox12 = new PictureBox();
                PictureBox pictureBox13 = new PictureBox();
                PictureBox pictureBox14 = new PictureBox();
                PictureBox pictureBox15 = new PictureBox();

                pictureBox13.BackColor = System.Drawing.Color.White;
                pictureBox13.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_like_1814076;
                pictureBox13.Location = new System.Drawing.Point(63, 235);
                pictureBox13.Name = "pictureBox13";
                pictureBox13.Size = new System.Drawing.Size(25, 25);
                pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox13.TabIndex = 27;
                pictureBox13.TabStop = false;




                pictureBox15.BackColor = System.Drawing.Color.White;
                pictureBox15.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_share2_1814119;
                pictureBox15.Location = new System.Drawing.Point(341, 235);
                pictureBox15.Name = "pictureBox15";
                pictureBox15.Size = new System.Drawing.Size(25, 25);
                pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox15.TabIndex = 29;
                pictureBox15.TabStop = false;




                pictureBox14.BackColor = System.Drawing.Color.White;
                pictureBox14.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_Like_Love_Heart_Appreciate_Enabled_Feelings_1329083;
                pictureBox14.Location = new System.Drawing.Point(195, 236);
                pictureBox14.Name = "pictureBox14";
                pictureBox14.Size = new System.Drawing.Size(25, 25);
                pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox14.TabIndex = 28;
                pictureBox14.TabStop = false;


                pictureBox11.Image = global::FellowshipFinderUser.Properties.Resources.purpleBackLight;
                pictureBox11.Location = new System.Drawing.Point(5, 14);
                pictureBox11.Name = "pictureBox11";
                pictureBox11.Size = new System.Drawing.Size(399, 215);
                pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox11.TabIndex = 0;
                pictureBox11.TabStop = false;



                pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                pictureBox12.Image = global::FellowshipFinderUser.Properties.Resources.no_profile_picture_icon_24;
                pictureBox12.Location = new System.Drawing.Point(17, 25);
                pictureBox12.Name = "pictureBox12";
                pictureBox12.Size = new System.Drawing.Size(25, 25);
                pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox12.TabIndex = 24;
                pictureBox12.TabStop = false;

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

                            pictureBox12.Image = new Bitmap(ms);

                        }
                    }
                }
                con.Close();



                Label label1 = new Label();
                Label label2 = new Label();

                label1.AutoSize = true;
                label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(32, 30);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(46, 18);
                label1.TabIndex = 25;




                try
                {

                    if (con.State == ConnectionState.Closed)
                    {

                        string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);

                        con.Open();
                        label1.Text = cmd2.ExecuteScalar().ToString().Trim();
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



                label2.AutoSize = true;
                label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(47, 62);
                label2.Name = "label2";
                label2.Size = new System.Drawing.Size(60, 24);
                label2.TabIndex = 26;
                label2.Text = postsListUser[i];



                panel19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                panel19.Controls.Add(label2);
                panel19.Controls.Add(pictureBox15);
                panel19.Controls.Add(pictureBox14);
                panel19.Controls.Add(pictureBox13);
                panel19.Controls.Add(label1);
                panel19.Controls.Add(pictureBox12);
                panel19.Controls.Add(pictureBox11);
                panel19.Location = new System.Drawing.Point(3, 3);
                panel19.Name = "panel19";
                panel19.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
                panel19.Size = new System.Drawing.Size(411, 265);
                panel19.TabIndex = 0;

            }

        }


















        public void loadfellowList()
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

                      fellowList.Add(reader.GetString(i));
               
                    }
                }
            }
            con.Close();

        }


        private void addToPostList()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

            for (int i = 0; i < fellowList.Count; i++)
            {
                string query = "SELECT post1,post2,post3, post4,post5,post6, post7,post8,post9,post10 from posts where username='" + fellowList[i] + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader;

                try
                {
                    con.Open();
                    reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int ii = 0; ii < 10; ii++)
                        {
                            if (!reader.IsDBNull(ii))
                            {
                                if (ii == 0)
                                {
                                    try
                                    {


                                        if (con1.State == ConnectionState.Closed)

                                        {

                                            string query2 = "Select post1 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);
                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 1)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post2 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);


                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 2)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post3 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);



                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                                else if (ii == 3)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post4 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);


                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 4)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post5 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);



                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 5)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post6 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);


                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 6)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post7 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);



                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }

                                else if (ii == 7)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post8 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);



                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 8)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post9 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);

                                        }



                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }


                                }
                                else if (ii == 9)
                                {
                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)
                                        {

                                            string query2 = "Select post10 from posts where userName= '" + fellowList[i] + "'";

                                            SqlCommand cmd2 = new SqlCommand(query2, con1);

                                            con1.Open();
                                            postsList.Add(cmd2.ExecuteScalar().ToString());
                                            con1.Close();
                                            userNameList.Add(fellowList[i]);


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

        }

        void addPostToHome()
        {
            for (int i = 0; i < postsList.Count; i++)
            {
                Panel panel19 = new Panel();

                this.flowLayoutPanel1.Controls.Add(panel19);

                PictureBox pictureBox11 = new PictureBox();
                PictureBox pictureBox12 = new PictureBox();
                PictureBox pictureBox13 = new PictureBox();
                PictureBox pictureBox14 = new PictureBox();
                PictureBox pictureBox15 = new PictureBox();

                pictureBox13.BackColor = System.Drawing.Color.White;
                pictureBox13.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_like_1814076;
                pictureBox13.Location = new System.Drawing.Point(63, 235);
                pictureBox13.Name = "pictureBox13";
                pictureBox13.Size = new System.Drawing.Size(25, 25);
                pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox13.TabIndex = 27;
                pictureBox13.TabStop = false;




                pictureBox15.BackColor = System.Drawing.Color.White;
                pictureBox15.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_share2_1814119;
                pictureBox15.Location = new System.Drawing.Point(341, 235);
                pictureBox15.Name = "pictureBox15";
                pictureBox15.Size = new System.Drawing.Size(25, 25);
                pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox15.TabIndex = 29;
                pictureBox15.TabStop = false;




                pictureBox14.BackColor = System.Drawing.Color.White;
                pictureBox14.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_Like_Love_Heart_Appreciate_Enabled_Feelings_1329083;
                pictureBox14.Location = new System.Drawing.Point(195, 236);
                pictureBox14.Name = "pictureBox14";
                pictureBox14.Size = new System.Drawing.Size(25, 25);
                pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox14.TabIndex = 28;
                pictureBox14.TabStop = false;


                pictureBox11.Image = global::FellowshipFinderUser.Properties.Resources.purpleBackLight;
                pictureBox11.Location = new System.Drawing.Point(5, 14);
                pictureBox11.Name = "pictureBox11";
                pictureBox11.Size = new System.Drawing.Size(399, 215);
                pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox11.TabIndex = 0;
                pictureBox11.TabStop = false;

                // left += 14;


                pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                pictureBox12.Image = global::FellowshipFinderUser.Properties.Resources.no_profile_picture_icon_24;
                pictureBox12.Location = new System.Drawing.Point(17, 25);
                pictureBox12.Name = "pictureBox12";
                pictureBox12.Size = new System.Drawing.Size(25, 25);
                pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox12.TabIndex = 24;
                pictureBox12.TabStop = false;

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + userNameList[i] + "'", con);

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
                        SqlCommand cmd1 = new SqlCommand("select profilePicture from fellowshipUsersList where userName='" + userNameList[i] + "'", con1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)

                        {

                            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePicture"]);

                            pictureBox12.Image = new Bitmap(ms);

                        }
                    }
                }
                con.Close();



                Label label1 = new Label();
                Label label2 = new Label();

                label1.AutoSize = true;
                label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(32, 30);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(46, 18);
                label1.TabIndex = 25;




                try
                {

                    if (con.State == ConnectionState.Closed)
                    {

                        string query2 = "Select FullName from fellowshipUsersList where userName= '" + userNameList[i] + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);

                        con.Open();
                        label1.Text = cmd2.ExecuteScalar().ToString().Trim();
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



                label2.AutoSize = true;
                label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(47, 62);
                label2.Name = "label2";
                label2.Size = new System.Drawing.Size(60, 24);
                label2.TabIndex = 26;
                label2.Text = postsList[i];



                panel19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                panel19.Controls.Add(label2);
                panel19.Controls.Add(pictureBox15);
                panel19.Controls.Add(pictureBox14);
                panel19.Controls.Add(pictureBox13);
                panel19.Controls.Add(label1);
                panel19.Controls.Add(pictureBox12);
                panel19.Controls.Add(pictureBox11);
                panel19.Location = new System.Drawing.Point(3, 3);
                panel19.Name = "panel19";
                panel19.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
                panel19.Size = new System.Drawing.Size(411, 265);
                panel19.TabIndex = 0;


                //left += 3;
                count--;
            }   
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

                                        string query2 = "Update posts Set post1='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post2='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post3='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post4='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post5='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post6='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post7='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post8='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post9='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update posts Set post10='" + richTextBox1.Text + "' where userName= '" + Form1.userName + "'";

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


        private void button11_Click(object sender, EventArgs e)
        {
                post();
 
                Panel panel19 = new Panel();
                PictureBox pictureBox11 = new PictureBox();
                PictureBox pictureBox12 = new PictureBox();
                PictureBox pictureBox13 = new PictureBox();
                PictureBox pictureBox14 = new PictureBox();
                PictureBox pictureBox15 = new PictureBox();

                pictureBox13.BackColor = System.Drawing.Color.White;
                pictureBox13.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_like_1814076;
                pictureBox13.Location = new System.Drawing.Point(63, 235);
                pictureBox13.Name = "pictureBox13";
                pictureBox13.Size = new System.Drawing.Size(25, 25);
                pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox13.TabIndex = 27;
                pictureBox13.TabStop = false;




                pictureBox15.BackColor = System.Drawing.Color.White;
                pictureBox15.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_share2_1814119;
                pictureBox15.Location = new System.Drawing.Point(341, 235);
                pictureBox15.Name = "pictureBox15";
                pictureBox15.Size = new System.Drawing.Size(25, 25);
                pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox15.TabIndex = 29;
                pictureBox15.TabStop = false;




                pictureBox14.BackColor = System.Drawing.Color.White;
                pictureBox14.Image = global::FellowshipFinderUser.Properties.Resources.iconfinder_Like_Love_Heart_Appreciate_Enabled_Feelings_1329083;
                pictureBox14.Location = new System.Drawing.Point(195, 236);
                pictureBox14.Name = "pictureBox14";
                pictureBox14.Size = new System.Drawing.Size(25, 25);
                pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox14.TabIndex = 28;
                pictureBox14.TabStop = false;


                pictureBox11.Image = global::FellowshipFinderUser.Properties.Resources.purpleBackLight;
                pictureBox11.Location = new System.Drawing.Point(5, 14);
                pictureBox11.Name = "pictureBox11";
                pictureBox11.Size = new System.Drawing.Size(399, 215);
                pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox11.TabIndex = 0;
                pictureBox11.TabStop = false;


                pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                pictureBox12.Image = global::FellowshipFinderUser.Properties.Resources.no_profile_picture_icon_24;
                pictureBox12.Location = new System.Drawing.Point(17, 25);
                pictureBox12.Name = "pictureBox12";
                pictureBox12.Size = new System.Drawing.Size(25, 25);
                pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox12.TabIndex = 24;
                pictureBox12.TabStop = false;

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

                            pictureBox12.Image = new Bitmap(ms);

                        }
                    }
                }
                con.Close();



                Label label1 = new Label();
                Label label2 = new Label();

                label1.AutoSize = true;
                label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label1.Location = new System.Drawing.Point(32, 30);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(46, 18);
                label1.TabIndex = 25;




                try
                {

                    if (con.State == ConnectionState.Closed)
                    {

                        string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form1.userName + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);

                        con.Open();
                        label1.Text = cmd2.ExecuteScalar().ToString().Trim();
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



                label2.AutoSize = true;
                label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Location = new System.Drawing.Point(47, 62);
                label2.Name = "label2";
                label2.Size = new System.Drawing.Size(60, 24);
                label2.TabIndex = 26;
                label2.Text = richTextBox1.Text;



                panel19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                panel19.Controls.Add(label2);
                panel19.Controls.Add(pictureBox15);
                panel19.Controls.Add(pictureBox14);
                panel19.Controls.Add(pictureBox13);
                panel19.Controls.Add(label1);
                panel19.Controls.Add(pictureBox12);
                panel19.Controls.Add(pictureBox11);
                panel19.Location = new System.Drawing.Point(3, 3);
                panel19.Name = "panel19";
                panel19.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
                panel19.Size = new System.Drawing.Size(411, 265);
                panel19.TabIndex = 0;


                this.flowLayoutPanel1.Controls.Add(panel19);

        }





        public void getBadge()
        {
            bool status;

            Form4 form = new Form4();
            status = form.getStatus();

            if (status)
            {
                pictureBox10.Visible = true;
            }
            else
            {
                pictureBox10.Visible = false;
            }


        }


        public void getProfilePic1()
        {


            con.Open();

            SqlCommand cmd = new SqlCommand("select ProfilePicture from fellowshipUsersList where userName='" + Form1.userName + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)

            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePicture"]);

                pictureBox5.Image = new Bitmap(ms);
                pictureBox8.Image = new Bitmap(ms);

            }
            con.Close();


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
                        pictureBox8.Image = new Bitmap(ms);

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
                    //button9.Text = cmd2.ExecuteScalar().ToString();
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
            Form formBackground = new Form();
            try
            {
                using (Form12 subForm = new Form12())
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Maximized;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    subForm.Owner = formBackground;
                    subForm.ShowDialog();

                    formBackground.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        void getDataInTable()
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM fellowshipUsersList", con);
            dbDataset = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dbDataset.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dbDataset;


        }

        void autoComplete()
        {

            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string query = "SELECT * from fellowshipUsersList";
            SqlCommand com = new SqlCommand(query,con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = com.ExecuteReader();

                while (reader.Read())
                {
                    coll.Add(reader.GetString(0));

                }                


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            textBox1.AutoCompleteCustomSource=coll;

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbDataset);
            DV.RowFilter = string.Format("userName LIKE '%{0}%'",textBox1.Text);
            dataGridView1.DataSource = DV;


        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // label1.Text = textBox1.Text;

             if (!string.IsNullOrEmpty(textBox1.Text))
             {

                 try
                 {
                     string query1 = "Select userName from fellowshipUsersList where userName= '" + textBox1.Text + "'";
                     SqlCommand cmd = new SqlCommand(query1, con);

                     con.Open();

                     fellowSearch = cmd.ExecuteScalar().ToString();

                     Form9 form = new Form9();
                     form.Show();

                     con.Close();

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
             else
             {
                 Form2 form2 = new Form2();
                 this.Hide();
                 form2.Show();
             }



        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
            panel10.Visible = false;
            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
            panel10.Visible = false;
            Form6 form = new Form6();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel12.Visible = false;
            DialogResult dialogResult = MessageBox.Show("Do you want to Log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Form1 form = new Form1();
                this.Hide();
                form.Show();

            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel10.Visible = false;
            buttonClickCount++;

            if (buttonClickCount % 2 == 0)
            {

                panel12.Visible = false;
            }
            else
            {  
                panel12.Visible = true;
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
            panel10.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
            buttonClickCount1++;

            if (buttonClickCount1 % 2 == 0)
            {
                panel10.Visible = false;
            }
            else
            {
                panel10.Visible = true;
            }
        }

        bool verifyRequestSendingEligibility()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

            string query = "Select UserName from verificationRequests where UserName= '" + Form1.userName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Request has been sent already", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
      

        }

        bool verifyRequestSendingEligibility1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

            string query = "Select UserName from acceptedGRequests where UserName= '" + Form1.userName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Request has been sent already", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
       

        }




        private void button9_Click(object sender, EventArgs e)
        {
            if (verifyRequestSendingEligibility()&&verifyRequestSendingEligibility1())
            {
                 
                    
                    Form7 form = new Form7();
                    this.Hide();
                    form.Show();       




            }
        }

        bool requestSentcheck()
        {


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

            string query = "Select UserName from verificationRequests where UserName= '" + Form1.userName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if (dtbl.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;

            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool status;
            Form4 form = new Form4();
            
            status = form.getInformation();

            if (requestSentcheck()||status)
            {            

                  this.Hide();
                  form.Show();
                
              

            }  
            else
            {
                MessageBox.Show("Please make a request first", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
    
        }

        void deleteAccount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

            string query0 = "DELETE fellowshipUsersList WHERE UserName= '" + Form1.userName + "'";
            string query1 = "DELETE fellows WHERE UserName= '" + Form1.userName + "'";
            string query2 = "DELETE Posts WHERE UserName= '" + Form1.userName + "'";
            string query3 = "DELETE groups WHERE UserName= '" + Form1.userName + "'";
            string query4 = "DELETE groupInvitations WHERE UserName= '" + Form1.userName + "'";
            string query5 = "DELETE fellowRequestsSent WHERE UserName= '" + Form1.userName + "'";
            string query6 = "DELETE fellowRequestsRecieved WHERE UserName= '" + Form1.userName + "'";
            string query7 = "DELETE groupYouManage WHERE UserName= '" + Form1.userName + "'";

            SqlCommand cmd0 = new SqlCommand(query0,con);
            SqlCommand cmd1 = new SqlCommand(query1,con);
            SqlCommand cmd2 = new SqlCommand(query2,con);
            SqlCommand cmd3 = new SqlCommand(query3,con);
            SqlCommand cmd4 = new SqlCommand(query4,con);
            SqlCommand cmd5 = new SqlCommand(query5,con);
            SqlCommand cmd6 = new SqlCommand(query6,con);
            SqlCommand cmd7 = new SqlCommand(query7,con);

            try
            {
                con.Open();
                cmd0.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Account Deleted Successfully", "Account delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 form = new Form1();
                this.Hide();
                form.Show();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("You will loose all you account data. Do you want to proceed to delete?", "Account Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                deleteAccount();

            }
            else
            {
               
            }
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

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox10, "Verified");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(pictureBox1, "Home");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(pictureBox4, "Fellows");
        }

      
        int count = 1;

        private void button12_Click_1(object sender, EventArgs e)
        {
           
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form13 from = new Form13();
            this.Hide();
            from.Show();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox6, "Notifications");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Chat");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }
    }
}
