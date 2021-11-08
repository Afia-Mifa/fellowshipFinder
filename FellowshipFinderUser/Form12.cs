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

namespace FellowshipFinderUser
{
    public partial class Form12 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");

        public Form12()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

            if (string.IsNullOrEmpty(textBox1.Text))
            {

                errorProvider1.Clear();
                errorProvider2.Clear();

            }
            else
            {
                string query0 = "Select * from fellowshipUsersList where userName='" + Form1.userName + "' and password='" + textBox1.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query0, con);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    errorProvider1.Clear();
                    errorProvider2.SetError(textBox1, "Correct");


                }
                else
                {

                    errorProvider2.Clear();
                    errorProvider1.SetError(textBox1, "Incorrect Password");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider3.Clear();
                errorProvider4.Clear();
            }
            else
            {
                if (!textBox2.Text.Equals(textBox3.Text))
                {
                    errorProvider3.SetError(textBox2, "Password Does not match");
                }
                else
                {
                    errorProvider3.Clear();
                    errorProvider4.SetError(textBox2, "Correct");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider5.Clear();
                errorProvider6.Clear();
            }
            else
            {
                if (textBox3.Text.Length < 8)
                {
                    errorProvider5.SetError(textBox3, "Minimum password length is 8");

                }
                else
                {
                    errorProvider5.Clear();
                    errorProvider6.SetError(textBox3, "Correct");
                }
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                UpdatePassword();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill up all data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePassword()
        {
            string query0 = "Update fellowshipUsersList set password='" + textBox2.Text + "' where userName='" + Form1.userName + "'";
            SqlCommand cmd = new SqlCommand(query0, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password updated successfully", "Pasword update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
            pictureBox3.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox4.Visible = false;

        }
    }
}
