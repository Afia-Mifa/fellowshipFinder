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

namespace FellowshipFinder1
{
    public partial class Form8 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        int adminId;
        string imageLocationProfile;
        string imageLocationCover;
        int buttonCount1 = 0;
        int buttonCount2 = 0;
        int buttonCount3 = 0;
        int buttonCount4 = 0;
        int buttonCount5 = 0;
        int buttonCount6 = 0;
        int buttonCount7 = 0;

        public Form8()
        {
            InitializeComponent();
            adminId = Convert.ToInt32(Form1.adminId);
            getProfilePic();
            getCoverPic();
            getInformation();

          

        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            imageLocationProfile = openFileExplorer(pictureBox2,imageLocationProfile);
            label23.Visible = true;
            button3.Visible = true;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private string openFileExplorer(PictureBox pictureBox, string imageLocation)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {
                imageLocation = file.FileName.ToString();
                pictureBox.ImageLocation = imageLocation;

            }
            return imageLocation;
        }



        private void saveProfilePhoto()
        {
            byte[] images1 = null;
            FileStream stream1 = new FileStream(imageLocationProfile, FileMode.Open, FileAccess.Read);
            BinaryReader brs1 = new BinaryReader(stream1);
            images1 = brs1.ReadBytes((int)stream1.Length);

            con.Open();
            string query = "Update fellowshipAdminDetails Set ProfilePic= @profilePic where adminId= '" + adminId + "'"; ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@profilePic", images1));
            int N = cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Profile picture updated Successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }


        private void saveCoverPhoto()
        {
            byte[] images1 = null;
            FileStream stream1 = new FileStream(imageLocationCover, FileMode.Open, FileAccess.Read);
            BinaryReader brs1 = new BinaryReader(stream1);
            images1 = brs1.ReadBytes((int)stream1.Length);

            con.Open();
            string query = "Update fellowshipAdminDetails Set coverPic= @coverPic where adminId= '" + adminId + "'"; ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@coverPic", images1));
            int N = cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Cover picture updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        public void getProfilePic()
        {
           

            con.Open();

            SqlCommand cmd = new SqlCommand("select ProfilePic from fellowshipAdminDetails where AdminId='"+adminId+"'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)

            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["ProfilePic"]);

                pictureBox2.Image = new Bitmap(ms);

            }
            con.Close();
        }

        public void getCoverPic()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select coverPic from fellowshipAdminDetails where AdminId='"+ adminId+"'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)

            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["coverPic"]);

                pictureBox1.Image = new Bitmap(ms);

            }

            con.Close();
        }

        private void getInformation()
        {

            try
            {

                if (con.State == ConnectionState.Closed)
                {                  

                    string query1 = "Select Name from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    string query2 = "Select Designation from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    string query3 = "Select PresentAddress from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    string query4 = "Select PermanentAddress from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    string query5 = "Select About from fellowshipAdminDetails where adminId= '" + adminId + "'";
                 

                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    SqlCommand cmd5 = new SqlCommand(query5, con);



                    con.Open();
                    label7.Text = adminId.ToString();
                    label1.Text = cmd1.ExecuteScalar().ToString();
                    label8.Text = cmd2.ExecuteScalar().ToString();
                    label9.Text = cmd3.ExecuteScalar().ToString();
                    label10.Text = cmd4.ExecuteScalar().ToString();
                    label11.Text = cmd5.ExecuteScalar().ToString();
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

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            loadDesignation();
            textBox1.Visible = true; 
            label14.Visible = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            loadPresentAddress();
            textBox2.Visible = true;
            label15.Visible = true;

        }

        private void label13_Click(object sender, EventArgs e)
        {
            loadPermanentAddress();
            textBox3.Visible = true;  
            label16.Visible = true;
        }



        private void loadName()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select Name from fellowshipAdminDetails where adminId= '" + adminId + "'";
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


        private void loadDesignation()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query2 = "Select Designation from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();
                    textBox1.Text = cmd2.ExecuteScalar().ToString();
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

        private void loadPresentAddress()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query3 = "Select PresentAddress from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    textBox2.Text = cmd3.ExecuteScalar().ToString();
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

        private void loadPermanentAddress()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query4 = "Select PermanentAddress from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd4 = new SqlCommand(query4, con);

                    con.Open();
                    textBox3.Text = cmd4.ExecuteScalar().ToString();
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
                    string query5 = "Select About from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd5 = new SqlCommand(query5, con);

                    con.Open();
                    textBox4.Text = cmd5.ExecuteScalar().ToString();
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



        private void saveDesignation()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query2 = "Update fellowshipAdminDetails Set designation='"+textBox1.Text+"' where adminId= '" + adminId + "'";
                    string query3 = "Select Designation from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlCommand cmd3 = new SqlCommand(query3, con);

                    con.Open();
                    cmd2.ExecuteNonQuery(); 
                    label8.Text = cmd3.ExecuteScalar().ToString();
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

        private void SavePresentAddress()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    string query3 = "Update fellowshipAdminDetails Set PresentAddress='" + textBox2.Text + "' where adminId= '" + adminId + "'";
                    string query4 = "Select PresentAddress from fellowshipAdminDetails where adminId= '" + adminId + "'";

                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    SqlCommand cmd4 = new SqlCommand(query4, con);


                    con.Open();
                    cmd3.ExecuteNonQuery();     
                    textBox2.Text = cmd4.ExecuteScalar().ToString();
                    label9.Text = cmd4.ExecuteScalar().ToString();
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

        private void SavePermanentAddress()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    string query4 = "Update fellowshipAdminDetails Set PermanentAddress='" + textBox3.Text + "' where adminId= '" + adminId + "'";
                    string query5 = "Select PermanentAddress from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    SqlCommand cmd5 = new SqlCommand(query5, con);

                    con.Open();
                    cmd4.ExecuteNonQuery();     
                    textBox3.Text = cmd5.ExecuteScalar().ToString();
                    label10.Text = cmd5.ExecuteScalar().ToString();
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
                    string query5 = "Update fellowshipAdminDetails Set About='" + textBox4.Text + "' where adminId= '" + adminId + "'";
                    string query6 = "Select About from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd5 = new SqlCommand(query5, con);
                    SqlCommand cmd6 = new SqlCommand(query6, con);

                    con.Open();
                    cmd5.ExecuteNonQuery();
                    textBox4.Text = cmd6.ExecuteScalar().ToString();
                    label11.Text = cmd6.ExecuteScalar().ToString();
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
                    string query5 = "Update fellowshipAdminDetails Set Name='" + textBox5.Text + "' where adminId= '" + adminId + "'";
                    string query6 = "Select Name from fellowshipAdminDetails where adminId= '" + adminId + "'";
                    SqlCommand cmd5 = new SqlCommand(query5, con);
                    SqlCommand cmd6 = new SqlCommand(query6, con);

                    con.Open();
                    cmd5.ExecuteNonQuery();
                    textBox5.Text = cmd6.ExecuteScalar().ToString();
                    label1.Text = cmd6.ExecuteScalar().ToString();
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


        private void label17_Click(object sender, EventArgs e)
        {
            loadAbout();
            textBox4.Visible = true;  
            label18.Visible = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            saveDesignation();   
            loadDesignation();
            label14.Visible = false;
            label8.Visible = true;
            textBox1.ForeColor = Color.DarkGray;
            label19.Visible = true;


        }

        private void label15_Click(object sender, EventArgs e)
        {
            SavePresentAddress();
            textBox2.ForeColor = Color.DarkGray;
            label15.Visible = false;
            label9.Visible = true;
            label19.Visible = true;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            SavePermanentAddress();
            textBox3.ForeColor = Color.DarkGray;
            label16.Visible = false;
            label10.Visible = true;
            label19.Visible = true;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            saveAbout();
            textBox4.ForeColor = Color.DarkGray;
            label18.Visible = false;
            label11.Visible = true;
            label19.Visible = true;
        }

        private void label19_Click(object sender, EventArgs e)
        {

            label7.Visible = true;
            label2.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label17.Visible = false;
            label20.Visible = false;
            label19.Visible = false;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            loadName();
 
            textBox5.Visible = true;
            label21.Visible = true;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            saveName();
            textBox5.ForeColor = Color.DarkGray;
            label21.Visible = false;
            label19.Visible = true;
        }

        private void apearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
           imageLocationCover = openFileExplorer(pictureBox1,imageLocationCover);
            button4.Visible = true;
            label23.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveProfilePhoto();
            label22.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveCoverPhoto();
            label22.Visible = true;
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            this.Hide();
            form.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            this.Hide();
            form.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
      
          
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonCount1++;
            if (buttonCount1 % 2 == 0)
            {
                panel5.Visible = false;
                panel3.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;
                panel11.Visible = false;

                textBox1.Visible = false;
                label14.Visible = false;

            }
            else
            {
                panel5.Visible = true;
                panel3.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;
                panel11.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttonCount2++;
            if (buttonCount2 % 2 == 0)
            {
                panel9.Visible = false;
                panel3.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel11.Visible = false;

                textBox2.Visible = false;
                label15.Visible = false;
            }
            else
            {
                panel7.Visible = true;
                panel3.Visible = false;
                panel5.Visible = false;
                panel9.Visible = false;
                panel11.Visible = false;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            buttonCount3++;
            if (buttonCount3 % 2 == 0)
            {
                panel9.Visible = false;
                panel3.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel11.Visible = false;

                textBox3.Visible = false;
                label16.Visible = false;
            }
            else
            {
                panel9.Visible = true;
                panel3.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel11.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttonCount4++;
            if (buttonCount4 % 2 == 0)
            {
                panel11.Visible = false;
                panel3.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;

                textBox4.Visible = false;
                label18.Visible = false;
            }
            else
            {
                panel11.Visible = true;
                panel3.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            buttonCount5++;
            if (buttonCount5 % 2 == 0)
            {
                panel3.Visible = false;
                panel5.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;
                panel11.Visible = false;

                textBox5.Visible = false;
                label21.Visible = false;

            }
            else
            {
                panel3.Visible = true;
                panel5.Visible = false;
                panel7.Visible = false;
                panel9.Visible = false;
                panel11.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            this.Hide();
            form.Show();
        }

        private void personalInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label7.Visible = false;
            label2.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label17.Visible = true;
            label20.Visible = true;
        }

        private void apearanceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void logOutToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to log out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void showOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void shwOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            panel12.Visible = false;
        }
    }
}
