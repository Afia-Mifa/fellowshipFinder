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
    public partial class Form1 : Form
    {
        public static string adminId;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HCIEA1E\SQLEXPRESS;Initial Catalog=fellowshipUsers;Integrated Security=True");
            string query = "Select * from fellowshipAdminDetails Where AdminId= '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                try
                {


                    if (con.State == ConnectionState.Closed)
                    {

                        string query1 = "Select AdminId from fellowshipAdminDetails where AdminId= '" + textBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(query1, con);

                        con.Open();

                        adminId = cmd.ExecuteScalar().ToString();

                        con.Close();

                        this.Hide();
                        Form2 form = new Form2();
                        form.Show();



                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


               
            }
            else
            {
                MessageBox.Show("Incorrect Admin Id/Password");

            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {

                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Numeric values Only !");

            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    //errorProvider3.Clear();
                }
            }
            else
            {
                errorProvider1.Clear();
                //errorProvider3.SetError(textBox1, "Numerical values Have Been Entered");


            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Please Give an input!");
            }
            else
            {
                errorProvider2.Clear();
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please Give an input!");
            }
            else
            {
                errorProvider1.Clear();
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
                this.SelectNextControl(textBox1, true, true, true, true);

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrEmpty(textBox2.Text))
            {

                errorProvider2.SetError(textBox2, "Enter Password!");
            }
            else if (!string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider2.Clear();

                if (e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();

                }

            }
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Enter Admin ID", pictureBox3);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Enter Password", pictureBox4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
