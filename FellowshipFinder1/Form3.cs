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
    public partial class Form3 : Form
    { 
        
        public static List<string> userNameList = new List<string>();
        string userName;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");



        public Form3()
        {
            InitializeComponent();
            addItemToList();

            if (listView1.Items.Count == 0)
            {
                label15.Text = "No More Requests At This Moment";
                label15.ForeColor = Color.DarkGray;
                label15.Visible = true;
            }
            else
            {
                label15.Visible = false;
            }

        }

 

        private void listView1_Click(object sender, EventArgs e)
        {

            Form4 form4 = new Form4(); //new instance needs to created everytime i try to reopen the form
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            userName = listView1.SelectedItems[0].Text;
            userName = userName.Remove(0, 1);

            string query = "Select UserName from verificationRequests where UserName= '" + userName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            SqlDataAdapter sda1 = new SqlDataAdapter("Select UserName from acceptedGRequests where UserName= '" + userName + "'", con);
            DataTable dtbl1 = new DataTable();
            sda1.Fill(dtbl1);



            if (dtbl1.Rows.Count == 1)
            {
                groupBox1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = false;
                label15.Visible = true;
                label15.ForeColor = Color.Green;
                label15.Text = "Accepted";
            }
            else
            {


                if (dtbl.Rows.Count == 1)
                {
                    string query0 = "Select Acceptance from verificationRequests where UserName= '" + userName + "'";
                    SqlCommand cmd = new SqlCommand(query0, con);

                    try
                    {

                        con.Open();
                        string acceptanceStatusString = cmd.ExecuteScalar().ToString();
                        con.Close();
                        int acceptanceStatus = Convert.ToInt32(acceptanceStatusString);

                        if (acceptanceStatus == 1)
                        {

                            groupBox1.Visible = false;
                            button2.Visible = false;
                            button3.Visible = false;
                            button1.Visible = false;
                            label15.Visible = true;
                            label15.ForeColor = Color.Green;
                            label15.Text = "Accepted";

                        }
                        else
                        {
                            try
                            {

                                if (con.State == ConnectionState.Closed)
                                {
                                    label15.Visible = false;

                                    string query1 = "Select FirstName from verificationRequests where UserName= '" + userName + "'";
                                    string query2 = "Select LastName from verificationRequests where UserName= '" + userName + "'";
                                    string query3 = "Select Email from verificationRequests where UserName= '" + userName + "'";
                                    string query4 = "Select GroupName from verificationRequests where UserName= '" + userName + "'";
                                    string query5 = "Select Catagory from verificationRequests where UserName= '" + userName + "'";
                                    string query6 = "Select Description from verificationRequests where UserName= '" + userName + "'";
                                    string query7 = "Select UserName from verificationRequests where UserName= '" + userName + "'";

                                    SqlCommand cmd1 = new SqlCommand(query1, con);
                                    SqlCommand cmd2 = new SqlCommand(query2, con);
                                    SqlCommand cmd3 = new SqlCommand(query3, con);
                                    SqlCommand cmd4 = new SqlCommand(query4, con);
                                    SqlCommand cmd5 = new SqlCommand(query5, con);
                                    SqlCommand cmd6 = new SqlCommand(query6, con);
                                    SqlCommand cmd7 = new SqlCommand(query7, con);


                                    con.Open();

                                    label7.Text = cmd1.ExecuteScalar().ToString();
                                    label8.Text = cmd2.ExecuteScalar().ToString();
                                    label9.Text = cmd3.ExecuteScalar().ToString();
                                    label10.Text = cmd4.ExecuteScalar().ToString();
                                    label11.Text = cmd5.ExecuteScalar().ToString();
                                    label12.Text = cmd6.ExecuteScalar().ToString();
                                    label14.Text = cmd7.ExecuteScalar().ToString();

                                    con.Close();


                                    groupBox1.Visible = true;
                                    button2.Visible = true;
                                    button3.Visible = true;
                                    button1.Visible = true;

                                    button3.BackColor = Color.CornflowerBlue;
                                    button3.Text = "Accept";
                                    button3.Enabled = true;

                                    button2.BackColor = Color.Salmon;
                                    button2.Text = "Delete";
                                    button2.Enabled = true;

                                    button1.BackColor = Color.Tan;
                                    button1.Text = "Reject";
                                    button1.Enabled = true;

                                }



                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    label15.ForeColor = Color.Red;
                    label15.Visible = true;
                    groupBox1.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;

                }
            }


        }




        public void button1_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].Remove();
        }

   
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDatabase(1,button3, "Accepted",Color.Green,Color.LightGreen);
            insertIntoAcceptedRequest(label14.Text, label8.Text, label9.Text, label10.Text, label11.Text, label12.Text, label7.Text);
            deleteFromdatabase(label14.Text,Color.LightGreen);
        }


        private void UpdateDatabase(int acceptanceVariable,Button buttonName,string buttonNameText,Color buttonColor,Color ItemColor)
        {

            string query1 = "UPDATE verificationRequests SET Acceptance= '" + acceptanceVariable + "' where userName='" + label14.Text + "'";
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
                listView1.SelectedItems[0].BackColor = ItemColor;


            }
            catch (Exception)
            {
                MessageBox.Show("Database Error Occured! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteFromdatabase(label14.Text,Color.Red);
        }

        public void deleteFromdatabase(string username,Color color)
        {
            string query1 = "DELETE verificationRequests WHERE userName='" + username + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                button2.BackColor = Color.Gray;   
                button2.FlatAppearance.BorderColor = Color.Gray;
                button2.Text = "Deleted";
                button2.Enabled = false;
             

                listView1.SelectedItems[0].BackColor = color;
                

            }
            catch (Exception)
            {
                MessageBox.Show("Database Error Occured! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadListView()
        {
            SqlCommand cmd;
            DataTable dtbl;
            SqlDataAdapter sda;
            DataSet dtset;

            Form3 form = new Form3();
            this.Hide();
            form.Show();


            form.listView1.Columns.Add("Requests", 500);
            form.listView1.Columns.Add("  ", 500);
            form.listView1.View = View.Details;

            con.Open();
            cmd = new SqlCommand("SELECT * FROM verificationRequests", con);
            sda = new SqlDataAdapter(cmd);
            dtset = new DataSet();
            sda.Fill(dtset, "verification Request List");
            con.Close();
            dtbl = dtset.Tables["verification Request List"];

            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                form.listView1.Items.Add("@" + dtbl.Rows[i].ItemArray[0].ToString());
                form.listView1.Items[i].SubItems.Add("Has sent a verification request");

            }

            form.listView1.ForeColor = Color.Blue;
            form.listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void insertIntoAcceptedRequest(string userName,string firstName,string lastName,string email,string groupName,string catagory,string description)
        {
            string query = "INSERT INTO acceptedGRequests VALUES(@userName,@firstName,@lastName,@email,@groupName,@catagory,@description)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@userName",userName);
            cmd.Parameters.AddWithValue("@firstName",firstName);
            cmd.Parameters.AddWithValue("@lastName",lastName);
            cmd.Parameters.AddWithValue("@email",email);
            cmd.Parameters.AddWithValue("@groupName",groupName);
            cmd.Parameters.AddWithValue("@catagory",catagory);
            cmd.Parameters.AddWithValue("@description",description);
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            UpdateDatabase(2,button1,"Rejected",Color.DarkGray,Color.Tan);
            insertIntoRejectedRequest(label14.Text, label8.Text, label9.Text, label10.Text, label11.Text, label12.Text, label7.Text);
            deleteFromdatabase(label14.Text, Color.Tan);

        }

        private void refreshToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            loadListView();
        }

        private void databaseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void acceptedRequestsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void rejectedRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

    

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Form2 form = new Form2();
            this.Hide();
            form.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loadListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void addItemToList()
        {
            SqlCommand cmd;
            DataTable dtbl;
            SqlDataAdapter sda;
            DataSet dtset;


            listView1.Columns.Add("Requests", 500);
            listView1.Columns.Add("  ", 500);
            listView1.View = View.Details;

            con.Open();
            cmd = new SqlCommand("SELECT * FROM verificationRequests", con);
            sda = new SqlDataAdapter(cmd);
            dtset = new DataSet();
            sda.Fill(dtset, "verification Request List");
            con.Close();
            dtbl = dtset.Tables["verification Request List"];

            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                listView1.Items.Add("@" + dtbl.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add("Has sent a verification request");

            }

            listView1.ForeColor = Color.Blue;
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void listView1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
