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
    public partial class Form10 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
       // public static string userName=Form5.selectedUserName;

        public Form10()
        {
            InitializeComponent();
            getCoverPic();
            getProfilePic();
            getInformation();
            getBadge();
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
          
        }



        public void getProfilePic()
        {


            con.Open();

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + Form5.selectedUserName + "'", con);

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
                    SqlCommand cmd1 = new SqlCommand("select profilePicture from fellowshipUsersList where userName='" + Form5.selectedUserName + "'", con1);
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

            SqlCommand cmd = new SqlCommand("select * from fellowshipUsersList where userName='" + Form5.selectedUserName + "'", con);
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
                    SqlCommand cmd1 = new SqlCommand("select coverPicture from fellowshipUsersList where userName='" + Form5.selectedUserName + "'", con1);
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

                    string query1 = "Select Fullname from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    string query2 = "Select about from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    string query3 = "Select PresentCity from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    string query4 = "Select PermanentCity from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    string query5 = "Select interestList from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";


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



        int Top = 282;
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

     

        private void loadName()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select FullName from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    //textBox5.Text = cmd2.ExecuteScalar().ToString();
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

                    string query2 = "Select about from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    //textBox6.Text = cmd2.ExecuteScalar().ToString();
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

                    string query2 = "Select presentCity from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    //textBox2.Text = cmd2.ExecuteScalar().ToString();
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

                    string query2 = "Select permanentCity from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    //textBox3.Text = cmd2.ExecuteScalar().ToString();
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

                    string query2 = "Select interestList from fellowshipUsersList where userName= '" + Form5.selectedUserName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                   // textBox4.Text = cmd2.ExecuteScalar().ToString();
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
            
     

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            loadName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadAbout();
        }






        private void pictureBox3_Click(object sender, EventArgs e)
        {
       

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
          
        }
        

        private void senderFellowListInsert()
        {
            string query = "SELECT fel1,fel2,fel3,fel4,fel5,fel6,fel7,fel8,fel9,fel10 from fellows where username='" + Form5.selectedUserName + "'";
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
                                  
                                            string query2 = "Update fellows Set fel1='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";
                               
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
                                      
                                        string query2 = "Update fellows Set fel2='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel3='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel4='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel5='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel6='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel7='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel8='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel9='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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

                                        string query2 = "Update fellows Set fel10='" + Form1.userName + "' where userName= '" + Form5.selectedUserName + "'";

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




        private void recieverFellowListInsert()
        {
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
                        if (reader.IsDBNull(i))
                        {
                            if (i == 0)
                            {
                                try
                                {


                                    if (con1.State == ConnectionState.Closed)

                                    {

                                        string query2 = "Update fellows Set fel1='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel2='" + Form5.selectedUserName + "' where userName= '" +Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel3='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel4='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel5='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel6='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel7='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellows Set fel8='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellow Set fel9='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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

                                        string query2 = "Update fellow Set fel10='" + Form5.selectedUserName + "' where userName= '" + Form1.userName + "'";

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
                            else
                            {
                  
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

        void deleteFromRequestRecieved()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query1 = "Select req1 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query2 = "Select req2 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query3 = "Select req3 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query4 = "Select req4 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query5 = "Select req5 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query6 = "Select req6 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query7 = "Select req7 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query8 = "Select req8 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query9 = "Select req9 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";
            string query10 = "Select req10 from fellowRequestsRecieved Where userName= '" + Form1.userName + "'";


            SqlCommand cmd1 = new SqlCommand(query1,con);
            SqlCommand cmd2 = new SqlCommand(query2,con);
            SqlCommand cmd3 = new SqlCommand(query3,con);
            SqlCommand cmd4 = new SqlCommand(query4,con);
            SqlCommand cmd5 = new SqlCommand(query5,con);
            SqlCommand cmd6 = new SqlCommand(query6,con);
            SqlCommand cmd7 = new SqlCommand(query7,con);
            SqlCommand cmd8 = new SqlCommand(query8,con);
            SqlCommand cmd9 = new SqlCommand(query9,con);
            SqlCommand cmd10 = new SqlCommand(query10,con);
            try
            {
                con.Open();

                if (cmd1.ExecuteScalar().ToString().Equals(Form5.selectedUserName))
                {
                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req1 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();
       

                }
                if (cmd2.ExecuteScalar().ToString().Equals(Form5.selectedUserName))
                {
                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req2 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd3.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req3 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd4.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req4 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd5.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req5 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd6.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req6 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd7.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req7 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd7.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req8 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd9.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req9 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd10.ExecuteScalar().ToString().Equals(Form5.selectedUserName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsRecieved set req10 = NULL where userName='" + Form1.userName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
         
        }


        void deleteFromRequestSend()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query1 = "Select req1 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query2 = "Select req2 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query3 = "Select req3 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query4 = "Select req4 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query5 = "Select req5 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query6 = "Select req6 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query7 = "Select req7 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query8 = "Select req8 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query9 = "Select req9 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";
            string query10 = "Select req10 from fellowRequestsSent Where userName= '" + Form5.selectedUserName + "'";


            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlCommand cmd3 = new SqlCommand(query3, con);
            SqlCommand cmd4 = new SqlCommand(query4, con);
            SqlCommand cmd5 = new SqlCommand(query5, con);
            SqlCommand cmd6 = new SqlCommand(query6, con);
            SqlCommand cmd7 = new SqlCommand(query7, con);
            SqlCommand cmd8 = new SqlCommand(query8, con);
            SqlCommand cmd9 = new SqlCommand(query9, con);
            SqlCommand cmd10 = new SqlCommand(query10, con);
            try
            {
                con.Open();

                if (cmd1.ExecuteScalar().ToString().Equals(Form1.userName))
                {
                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req1 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();
 

                }
                if (cmd2.ExecuteScalar().ToString().Equals(Form1.userName))
                {
                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req2 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd3.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req3 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd4.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req4 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd5.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req5 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd6.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req6 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd7.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req7 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd7.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req8 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd9.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req9 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
                if (cmd10.ExecuteScalar().ToString().Equals(Form1.userName)){


                    SqlCommand cmd01 = new SqlCommand("update fellowRequestsSent set req10 = NULL where userName='" + Form5.selectedUserName + "'", con);
                    cmd01.ExecuteNonQuery();

                }
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



        private bool isFellow()
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

                                    return false;

                                }

                                break;
                            }
                            else if (i == 1)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel2= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                                break;
                            }
                            else if (i == 2)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel3= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                                break;
                            }
                            else if (i == 3)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel4= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                                break;
                            }
                            else if (i == 4)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel5= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                                break;
                            }
                            else if (i == 5)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel6= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                                break;
                            }
                            else if (i == 6)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel7= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }

                                break;
                            }

                            else if (i == 7)
                            {
                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel8= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                                break;
                            }
                            else if (i == 8)
                            {

                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel9= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

                                }


                                break;
                            }
                            else if (i == 9)
                            {
                                string query1 = "Select * from fellows Where userName= '" + Form1.userName + "' and fel10= '" + Form2.fellowSearch + "'";
                                SqlDataAdapter sda = new SqlDataAdapter(query1, con1);

                                DataTable dtbl = new DataTable();
                                sda.Fill(dtbl);


                                if (dtbl.Rows.Count == 1)
                                {

                                    return false;

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

            return true;

        }







        private void button12_Click(object sender, EventArgs e)
        {
            senderFellowListInsert();
            recieverFellowListInsert();
            deleteFromRequestRecieved();
            deleteFromRequestSend();

            button12.Text = "Fellow";
            button12.Enabled = false;
            button1.Visible = false;

        }



        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            deleteFromRequestRecieved();
            deleteFromRequestSend();
        }
    }
}


