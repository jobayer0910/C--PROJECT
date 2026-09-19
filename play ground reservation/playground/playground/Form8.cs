using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
#pragma warning disable  // Suppress the obsolete warning for SqlConnection
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
#pragma warning restore  // Re-enable the warning


namespace playground
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string connectionString = "data source=DESKTOP-F9NV9JN\\SQLEXPRESS; database=PLAYGROUND; integrated security=SSPI";

           
            string user_name = textBox4.Text;
            string user_id = textBox1.Text;
            string user_pass = textBox2.Text;
            string user_phone = textBox3.Text;
            string user_address = richTextBox1.Text;
            string gender = "";

            
            if (radioButton1.Checked) 
            {
                gender = "Male";
            }
            else if (radioButton2.Checked) 
            {
                gender = "Female";
            }

           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                   
                    string query = "INSERT INTO user_info (Name, Id, Password, Phone_no, Address, Gender) " +
                                   "VALUES (@Name, @Id, @Password, @Phone_no, @Address, @Gender)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@Name", user_name);
                        command.Parameters.AddWithValue("@Id", user_id);
                        command.Parameters.AddWithValue("@Password", user_pass);
                        command.Parameters.AddWithValue("@Phone_no", user_phone);
                        command.Parameters.AddWithValue("@Address", user_address);
                        command.Parameters.AddWithValue("@Gender", gender);

                       
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sign-up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                          
                            Form7 form7 = new Form7();
                            form7.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sign-up failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }



}



