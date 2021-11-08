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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        string userName,firstName,lastName,email,groupname,catagory,description;

        public Form5()
        {
            InitializeComponent();
            getDataInTable();
            getDataInAcceptanceTable();
            getDataInRejectionTable();
            disableButtons();
            
   
        }

        private void getDataInTable()
        {

            SqlCommand cmd = new SqlCommand("SELECT *FROM verificationRequests", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();


            dataGridView1.DataSource = dt;
        }

        private void getDataInAcceptanceTable()
        {

           
            SqlCommand cmd = new SqlCommand("SELECT *FROM acceptedGRequests", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();


            dataGridView2.DataSource = dt;
        }

        private void getDataInRejectionTable()
        {

            SqlCommand cmd = new SqlCommand("SELECT *FROM rejectedRequests", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();


            dataGridView3.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDatabase(1, button1, "Accepted", Color.Green, Color.Green);
            insertIntoAcceptedRequest(userName,firstName,lastName,email,groupname,catagory,description);
            deleteFromdatabase(userName);
            getDataInTable();
            getDataInAcceptanceTable();
      
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                      

                try
                {
                    userName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    firstName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    lastName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    email = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    groupname = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    catagory = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    description = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                    if (string.IsNullOrEmpty(userName))
                    {
                        disableButtons();
                    }
                    else
                    {
                        enableButtons();
                    }



                }
                catch
                {
                    MessageBox.Show("Please Click At The Start Of the Row", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertIntoRejectedRequest(userName, firstName, lastName, email, groupname, catagory, description);
            deleteFromdatabase(userName);
            getDataInTable();
            getDataInRejectionTable();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            
        }

        private void UpdateDatabase(int acceptanceVariable, Button buttonName, string buttonNameText, Color buttonColor, Color ItemColor)
        {

            string query1 = "UPDATE verificationRequests SET Acceptance= '" + acceptanceVariable + "' where userName='" + userName + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                buttonName.BackColor = buttonColor;
                buttonName.FlatAppearance.BorderColor = buttonColor;
                buttonName.Text = buttonNameText;
                buttonName.Enabled = false;


            }
            catch (Exception)
            {
                MessageBox.Show("Database Error Occured! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void dataGridView3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void operateOnTheTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.toolStrip1.Visible = true;
            form.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            getDataInTable();
            getDataInAcceptanceTable();
            getDataInRejectionTable();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void deleteFromdatabase(string username)
        {
            string query1 = "DELETE verificationRequests WHERE userName='" + username + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                button3.BackColor = Color.Gray;
                button3.FlatAppearance.BorderColor = Color.Gray;
                button3.Text = "Deleted";
                button3.Enabled = false;

            }
            catch (Exception)
            {
                MessageBox.Show("Database Error Occured! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteFromdatabase(userName);
            getDataInTable();
        }

        private void insertIntoAcceptedRequest(string userName, string firstName, string lastName, string email, string groupName, string catagory, string description)
        {
            string query = "INSERT INTO acceptedGRequests VALUES(@userName,@firstName,@lastName,@email,@groupName,@catagory,@description)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@groupName", groupName);
            cmd.Parameters.AddWithValue("@catagory", catagory);
            cmd.Parameters.AddWithValue("@description", description);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

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

        private void insertIntoRejectedRequest(string userName, string firstName, string lastName, string email, string groupName, string catagory, string description)
        {
            string query = "INSERT INTO rejectedRequests VALUES(@userName,@firstName,@lastName,@email,@groupName,@catagory,@description)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@groupName", groupName);
            cmd.Parameters.AddWithValue("@catagory", catagory);
            cmd.Parameters.AddWithValue("@description", description);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

              
                button2.BackColor = Color.DarkGray;
                button2.FlatAppearance.BorderColor = Color.DarkGray;
                button2.Text = "Rejected";
                button2.Enabled = false;


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

        public void enableButtons()
        {

            button1.BackColor = Color.CornflowerBlue;
            button1.FlatAppearance.BorderColor = Color.CornflowerBlue;
            button1.Text = "Accept";
            button1.Enabled = true;



            button2.BackColor = Color.Tan;
            button2.FlatAppearance.BorderColor = Color.Tan;
            button2.Text = "Reject";
            button2.Enabled = true;

            button3.BackColor = Color.LightCoral;
            button3.FlatAppearance.BorderColor = Color.LightCoral;
            button3.Text = "Delete";
            button3.Enabled = true;

        }

        public void disableButtons()
        {

            button1.BackColor = Color.DarkGray;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.Text = "Accept";
            button1.Enabled = true;



            button2.BackColor = Color.DarkGray;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.Text = "Reject";
            button2.Enabled = true;

            button3.BackColor = Color.DarkGray;
            button3.FlatAppearance.BorderColor = Color.DarkGray;
            button3.Text = "Delete";
            button3.Enabled = true;

        }


    }
}
