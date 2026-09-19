using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace playground
{
    public partial class Form9 : Form
    {
        string connectionString = "data source=DESKTOP-F9NV9JN\\SQLEXPRESS; database=PLAYGROUND; integrated security=SSPI";

        public Form9()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
           ClearForm(); 
        }

       
        private void ClearForm()
        {
            textBox4.Text = "";
            textBox1.Text = ""; 
            textBox2.Text = ""; 
            textBox3.Text = ""; 
            richTextBox1.Text = ""; 

           
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                  
                    string query = "SELECT TOP 1 Name, Id, Password, Phone_no, Address, Gender FROM user_info ORDER BY Id DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                              
                                textBox4.Text = reader["Name"].ToString();       
                                textBox1.Text = reader["Id"].ToString();       
                                textBox2.Text = reader["Password"].ToString();   
                                textBox3.Text = reader["Phone_no"].ToString();    
                                richTextBox1.Text = reader["Address"].ToString(); 

                                string gender = reader["Gender"].ToString();


                                if (gender == "Male")
                                {
                                    radioButton1.Checked = true;
                                }
                                else if (gender == "Female")
                                {
                                    radioButton2.Checked = true;
                                }

                                MessageBox.Show("Recent registration data loaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No registration data found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text))  
            {
                MessageBox.Show("Please load user data first by clicking 'Show Data'!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            string user_name = textBox4.Text;  
            string user_id = textBox1.Text;    
            string user_pass = textBox2.Text;  
            string user_phone = textBox3.Text; 
            string user_address = richTextBox1.Text;  
            string gender = radioButton1.Checked ? "Male" : radioButton2.Checked ? "Female" : ""; // Gender

            
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                   
                    string query = "UPDATE user_info " +
                                   "SET Name = @Name, Password = @Password, Phone_no = @Phone_no, Address = @Address, Gender = @Gender " +
                                   "WHERE Id = @Id";

                    
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
                            MessageBox.Show("User data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No changes were made or the user does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string game = string.Empty;
            if (radioButton4.Checked) 
            {
                game = "Cricket";
            }
            else if (radioButton5.Checked) 
            {
                game = "Football";
            }

           
            string slot = comboBox1.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

           
            if (string.IsNullOrEmpty(game) || string.IsNullOrEmpty(slot) || string.IsNullOrEmpty(date))
            {
                MessageBox.Show("Please select a game, slot, and date.");
                return;
            }

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM slot_game WHERE game = @game AND slot = @slot AND date = @date";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@game", game);
                        command.Parameters.AddWithValue("@slot", slot);
                        command.Parameters.AddWithValue("@date", date);

                        int count = (int)command.ExecuteScalar();

                       
                        if (count > 0)
                        {
                            MessageBox.Show("Request slot successful.");
                        }
                        else
                        {
                            MessageBox.Show("Slot is not available.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking slot availability: " + ex.Message);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }
    }
}     