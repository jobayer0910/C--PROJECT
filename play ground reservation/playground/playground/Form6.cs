using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace playground
{
    public partial class Form6 : Form
    {
        string connectionString = "data source=DESKTOP-F9NV9JN\\SQLEXPRESS; database=PLAYGROUND; integrated security=SSPI";

        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Hide(); 
        }

        private void Form6_Load(object sender, EventArgs e)
        {
          
            LoadData();
        }

        private void LoadData(string searchQuery = "")
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                   
                    string query = string.IsNullOrEmpty(searchQuery) ?
                                   "SELECT Name, Id, Password, Phone_no, Address, Gender, Game, Slot, Date FROM user_info" :
                                   "SELECT Name, Id, Password, Phone_no, Address, Gender, Game, Slot, Date FROM user_info " +
                                   "WHERE Id LIKE @search OR Password LIKE @search OR Phone_no LIKE @search OR Address LIKE @search OR Gender LIKE @search";

                   
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                   
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchQuery + "%");
                    }

                   
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                  
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            string search = textBox1.Text;

           
            LoadData(search);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                DeleteRecord(id);
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void DeleteRecord(string id)
        {
            string query = "DELETE FROM user_info WHERE Id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                           
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given Id.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
