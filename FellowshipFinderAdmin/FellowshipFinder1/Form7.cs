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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
        string userName, firstName, lastName, email, groupname, catagory, description;


        public Form7()
        {
            InitializeComponent();
            getDataInRejectionTable();
            //toolStripButton1.Enabled = false;
            //toolStripButton2.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            deleteFromdatabase(userName);
            getDataInRejectionTable();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void getDataInRejectionTable()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT *FROM rejectedRequests", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();


                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
    
            insertIntoAcceptedRequest(userName, firstName, lastName, email, groupname, catagory, description);
            deleteFromdatabase(userName);
            getDataInRejectionTable();


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
                    toolStripButton1.Enabled = false;
                    toolStripButton2.Enabled = false;
                }
                else
                {
                    toolStripButton1.Enabled = true;
                    toolStripButton2.Enabled = true;
                }



            }
            catch
            {
                MessageBox.Show("Please Click At The Start Of the Row", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }

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


                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;

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

        public void deleteFromdatabase(string username)
        {
            string query1 = "DELETE rejectedRequests WHERE userName='" + username + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;

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

 

    }
}
