using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FellowshipFinderUser
{
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
  
        public Form7()
        {
            InitializeComponent();
            getProfilePicUser();
            loadNameUser();
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

                        pictureBox3.Image = new Bitmap(ms);


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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedItem.ToString() == "Others")
            {

                textBox5.Visible = true;
                label5.Visible = true;
            }
            else
            {
                textBox5.Visible = false;
                label5.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
    
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string catagory;

            if (isValid())
            {
                if (comboBox1.SelectedItem.ToString() == "Others")
                {
                    if (string.IsNullOrEmpty(textBox5.Text))
                    {
                        MessageBox.Show("Please Fill Up The Manditory Fields", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        catagory = textBox5.Text;
                        insertIntoDatabase(catagory);
                        clearFields();
                    
                    }
                }
                else
                {
                    catagory = comboBox1.Text;

                    insertIntoDatabase(catagory);
                    clearFields();
           
                }

               
            }
            else
            {
                MessageBox.Show("Please Fill Up The Manditory Fields","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void clearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";

        }

        private void insertIntoDatabase(string catagory)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

            string query = "Select UserName from verificationRequests where UserName= '" + Form1.userName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Request has been  sent already", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string query1 = "INSERT INTO verificationRequests(UserName,FirstName,LastName,Email,GroupName,Catagory,Description,Acceptance) VALUES(@UserName,@firstName,@lastName,@Email,@GroupName,@Catagory,@Description,@acceptance)";
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName", Form1.userName);
                cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@GroupName", textBox4.Text);
                cmd.Parameters.AddWithValue("@Catagory", catagory);
                cmd.Parameters.AddWithValue("@Description", textBox6.Text);
                cmd.Parameters.AddWithValue("@acceptance", 0);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Request Sent Successfully","Sent",MessageBoxButtons.OK,MessageBoxIcon.Information);

                Form2 form = new Form2();
                this.Hide();
                form.Show();
                

            }
        }

        private bool isValid()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text)) 
            {
                return false;
            }
            else if (string.IsNullOrEmpty(textBox6.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Environment.Exit(1);

            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.SelectNextControl(textBox2, true, true, true, true);
                textBox2.Focus();

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.SelectNextControl(textBox3, true, true, true, true);
                textBox3.Focus();

            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.SelectNextControl(textBox4, true, true, true, true);
                textBox4.Focus();

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.SelectNextControl(comboBox1, true, true, true, true);


            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.SelectNextControl(textBox6, true, true, true, true);
                textBox6.Focus();

            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form13 from = new Form13();
            this.Hide();
            from.Show();
        }
    }
}
