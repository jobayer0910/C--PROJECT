
using System;
using System.Windows.Forms;
//using System.Data.Sql;
#pragma warning disable  
using System.Data.SqlClient;
#pragma warning restore  





namespace playground
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string uId = textBox1.Text;
            string uPass = textBox2.Text;

          
            string connectionString = "data source=DESKTOP-F9NV9JN\\SQLEXPRESS; database=PLAYGROUND; integrated security=SSPI";

          
            string query = "SELECT COUNT(1) FROM ADMIN_LOGIN WHERE ADMIN_ID = @uId AND ADMIN_PASS = @uPass";

            try
            {
               

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                  
                    connection.Open();

                   
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@uId", uId);
                        command.Parameters.AddWithValue("@uPass", uPass);

                      
                        int result = (int)command.ExecuteScalar();

                      
                        if (result == 1)
                        {
                           
                            Form3 form3 = new Form3();
                            form3.Show();
                            this.Hide();
                        }
                        else
                        {
                          
                            MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}