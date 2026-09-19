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
//sing static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace playground
{
    public partial class Form4 : Form
    {
        string connectionString = "data source=DESKTOP-F9NV9JN\\SQLEXPRESS; database=PLAYGROUND; integrated security=SSPI";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM slot_game";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            string id = textBox1.Text;
            string game = comboBox2.Text;
            string slot_time = comboBox1.Text;
            string slot_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(game) || string.IsNullOrEmpty(slot_time))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO slot_game (id, game, slot, date) VALUES (@id, @game, @slot, @date)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@game", game);
                        command.Parameters.AddWithValue("@slot", slot_time);
                        command.Parameters.AddWithValue("@date", slot_date);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully.");
                            LoadData(); 
                        }
                        else
                        {
                            MessageBox.Show("Data insertion failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedId = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString(); // Assuming "id" is the column name

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM slot_game WHERE id = @id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", selectedId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data deleted successfully.");
                                LoadData(); 
                            }
                            else
                            {
                                MessageBox.Show("Data deletion failed.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting data: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Hide();
        }
    }
}
