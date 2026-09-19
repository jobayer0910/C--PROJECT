using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#pragma warning disable  // Suppress the obsolete warning for SqlConnection
using System.Data.SqlClient;
#pragma warning restore  // Re-enable the warning



namespace playground
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string uId = txtUsername.Text;
            string uPass = txtPassword.Text;

            
            string connectionString = "Data Source=DESKTOP-F9NV9JN\\SQLEXPRESS;database=PLAYGROUND;integrated security=SSPI";

            
            string query = "SELECT COUNT(1) FROM user_info WHERE Id = @Id AND Password = @Password";

           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                       
                        cmd.Parameters.AddWithValue("@Id", uId);
                        cmd.Parameters.AddWithValue("@Password", uPass);

                        
                        int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                           
                            MessageBox.Show("Login Success");

                          
                            Form9 form9 = new Form9();
                            form9.Show();
                            this.Hide(); 
                        }
                        else
                        {
                           
                            MessageBox.Show("Invalid Username or Password. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
