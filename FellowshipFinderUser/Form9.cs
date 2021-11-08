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
    public partial class Form9 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
       // public static string userNameMain=Form2.userName;


        public Form9()
        {
            InitializeComponent();
            getCoverPic();
            getProfilePic();
            getInformation();
            getProfilePicUser();
            loadNameUser();
            getBadge();
            isOwnProfile();
            requestButton();
        }

        void requestButton()
        {

            if (requestEligible())
            {

                button12.Enabled = true;
                button12.Text = "Add Fellow";
            }
            else
            {
               
                button12.Enabled = false;
                button12.Text = "Requested";
            }
            if (Fellow())
            {
                button12.Enabled = false;
                button12.Text = "Fellow";
            }


        }

        void isOwnProfile()
        {
            if (Form2.fellowSearch.Equals(Form1.userName))
            {
                button12.Visible = false;
            }
            else
            {
                button12.Visible = true;
            }

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
            Application.Exit();
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

                        pictureBox8.Image = new Bitmap(ms);


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


        public void getProfilePic()
        {


            con.Open();

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + Form2.fellowSearch + "'", con);

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
                    SqlCommand cmd1 = new SqlCommand("select profilePicture from fellowshipUsersList where userName='" + Form2.fellowSearch + "'", con1);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)

                    {

                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePicture"]);

                        pictureBox1.Image = new Bitmap(ms);

                    }
                }
            }
            con.Close();
        }




        public void getCoverPic()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + Form2.fellowSearch + "'", con);
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
                    SqlCommand cmd1 = new SqlCommand("select coverPicture from fellowshipUsersList where userName='" + Form2.fellowSearch + "'", con1);
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

                    string query1 = "Select Fullname from fellowshipUsersList where userName= '" + Form2.fellowSearch + "'";
                    string query2 = "Select about from fellowshipUsersList where userName= '" + Form2.fellowSearch + "'";
                    string query3 = "Select PresentCity from fellowshipUsersList where userName= '" + Form2.fellowSearch + "'";
                    string query4 = "Select PermanentCity from fellowshipUsersList where userName= '" + Form2.fellowSearch + "'";
                    string query5 = "Select interestList from fellowshipUsersList where userName= '" + Form2.fellowSearch + "'";


                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    SqlCommand cmd5 = new SqlCommand(query5, con);



                    con.Open();
                    label1.Text = cmd1.ExecuteScalar().ToString();
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



 
        int left= 269;
        int count=1;

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

                left += 50;
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

  

        private void button2_Click_1(object sender, EventArgs e)
        {
            
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
           
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
           


        }

        private void saveCoverPhoto()
        {
          

        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
           // profileImageLocation = openFileExplorer(pictureBox1, profileImageLocation,button7,button9);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           // coverImageLocation = openFileExplorer(pictureBox2, coverImageLocation,button8,button10);
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
     
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveCoverPhoto();
  
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }


        private void recieveRequestTableInsert()
        {
            string query = "SELECT req1,req2,req3,req4,req5,req6,req7,req8,req9,req10 from fellowRequestsRecieved where username='" + Form2.fellowSearch + "'";
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
                                

                                    string query1 = "Select * from fellowRequestsRecieved Where userName= '" + Form2.fellowSearch + "' and req1= '" + Form1.userName + "'";
                                    SqlDataAdapter sda = new SqlDataAdapter(query1, con1);//need to use !=NULL for it to work

                                    DataTable dtbl = new DataTable();
                                    sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {
                                    MessageBox.Show("Exists");
                                }
                                else
                                {

                                    try
                                    {

                                        if (con1.State == ConnectionState.Closed)

                                        {

                                            string query2 = "Update fellowRequestsRecieved Set req1='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";


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
                                }

                                   
                                break;
                            }
                            else if (i == 1)
                            {
                                try
                                {

                                    if (con1.State == ConnectionState.Closed)
                                    {
                                      
                                        string query2 = "Update fellowRequestsRecieved Set req2='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req3='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req4='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req5='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req6='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req7='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req8='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req9='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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

                                        string query2 = "Update fellowRequestsRecieved Set req10='" + Form1.userName + "' where userName= '" + Form2.fellowSearch + "'";

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




        private void sentRequestTableInsert()
        {
            string query = "SELECT req1,req2,req3,req4,req5,req6,req7,req8,req9,req10 from fellowRequestsSent where username='" + Form1.userName + "'";
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

                                        string query2 = "Update fellowRequestsSent Set req1='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                                        string query2 = "Update fellowRequestsSent Set req2='" + Form2.fellowSearch + "' where userName= '" +Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req3='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

      
                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req4='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req5='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                          
                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req6='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req7='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                      
                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req8='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req9='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                               
                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

                                        string query2 = "Update fellowRequestsSent Set req10='" + Form2.fellowSearch + "' where userName= '" + Form1.userName + "'";

                                        SqlCommand cmd2 = new SqlCommand(query2, con1);

                                        con1.Open();
                                        cmd2.ExecuteNonQuery();
                                        con1.Close();

                                        MessageBox.Show("Request Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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




        private bool requestEligible()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query = "SELECT req1,req2,req3,req4,req5,req6,req7,req8,req9,req10 from fellowRequestsSent where username='" + Form1.userName + "'";
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

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req1= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }
                             
                         
                            }
                            else if (i == 1)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req2= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                      
                            }
                            else if (i == 2)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req3= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                  
                            }
                            else if (i == 3)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req4= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                            }
                            else if (i == 4)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req5= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                     
                            }
                            else if (i == 5)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req6= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                            }
                            else if (i == 6)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req7= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                    
                            }

                            else if (i == 7)
                            {
                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req8= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                            }
                            else if (i == 8)
                            {

                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req9= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                            }
                            else if (i == 9)
                            {
                                string query1 = "Select * from fellowRequestsSent Where userName= '" + Form1.userName + "' and req10= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

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

            return true;

        }



        private bool Fellow()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query = "SELECT fel1,fel2,fel3,fel4,fel5,fel6,fel7,fel8,fel9,fel10 from fellows where username='" + Form1.userName + "'";
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

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel1= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }

                         
                            }
                            else if (i == 1)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel2= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }


                              
                            }
                            else if (i == 2)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel3= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }

                          
                            }
                            else if (i == 3)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel4= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }


                         
                            }
                            else if (i == 4)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel5= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }

                          
                            }
                            else if (i == 5)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel6= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }


                      
                            }
                            else if (i == 6)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel7= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }

                 
                            }

                            else if (i == 7)
                            {
                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel8= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }


                            }
                            else if (i == 8)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel9= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

                                }


                            }
                            else if (i == 9)
                            {
                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel10= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return true;

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

            return false;

        }














        private void button12_Click(object sender, EventArgs e)
        {
           
            

                recieveRequestTableInsert();
                sentRequestTableInsert();
                button12.Text = "Requested";
                button12.Enabled = false;
                
                       
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

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
            else
            {
                
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Form13 from = new Form13();
            this.Hide();
            from.Show();
        }
    }
}


