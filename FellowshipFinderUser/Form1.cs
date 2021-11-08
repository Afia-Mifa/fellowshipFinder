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
    public partial class Form1 : Form
    {
        public static string userName;

        public Form1()
        {
            InitializeComponent();
       
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private bool isvalid()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                return false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        private void logIn()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query = "Select * from fellowshipUsersList Where userName= '" + textBox1.Text + "' and password= '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if (dtbl.Rows.Count == 1)
            {


                try
                {


                    if (con.State == ConnectionState.Closed)
                    {

                        string query1 = "Select userName from fellowshipUsersList where userName= '" + textBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(query1, con);

                        con.Open();

                        userName = cmd.ExecuteScalar().ToString();

                        con.Close();

                        this.Hide();
                        Form2 form = new Form2();
                        form.Show();



                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else
            {
                MessageBox.Show("Incorrect User Id/Password", "Login Unsuccessful ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                logIn();
            }
            else
            {
                MessageBox.Show("Please give an input","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (Form8 subForm = new Form8())
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
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
                button1.PerformClick();

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Program?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Username");
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(textBox2, "Password");
        }
    }
}
