using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace mysqlDeneme
{
    public partial class Form1 : Form
    {
        string myConnectionString = "server=localhost;database=ctry;uid=yavuz;pwd=123456789;";
        public Form1()
        {
            InitializeComponent();

            this.dataGridView1.AllowUserToAddRows = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.ReadOnly = true;
            ara();

        }
       


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "ctry",
                UserID = "yavuz",
                Password = "123456789",

            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                string user1 = textBox1.Text;
                string user2 = textBox2.Text;
                try
                {
                    conn.Open();
                    //MessageBox.Show("Connection Open!");

                    using (var command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT * FROM user where user1 LIKE @user1 and user2 LIKE @user2 ";

                        command.Parameters.AddWithValue("@user1", user1);
                        command.Parameters.AddWithValue("@user2", user2);

                        using (var reader = command.ExecuteReader())
                        {
                            label1.Text = "2";
                            while (reader.Read())
                            {

                                MessageBox.Show(reader.GetString(1).ToString());

                            }
                            label1.Text = "4";
                        }
                    }






                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            /*
            string user1 = textBox1.Text;
            string user2 = textBox2.Text;

            MessageBox.Show(user2);


            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            try
            {
                cnn.Open();
                // MessageBox.Show("Connection Open!");





                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }
            */
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "ctry",
                UserID = "yavuz",
                Password = "123456789",

            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                string user1 = textBox3.Text;
                string user2 = textBox4.Text;
                string user3 = textBox5.Text;
                try
                {
                    conn.Open();
                    //MessageBox.Show("Connection Open!");

                    using (var command = conn.CreateCommand())
                    {

                        command.CommandText = "INSERT INTO  user(user1 , user2 , user3 ) VALUES (@user1 , @user2 , @user3)";

                        command.Parameters.AddWithValue("@user1", user1);
                        command.Parameters.AddWithValue("@user2", user2);
                        command.Parameters.AddWithValue("@user3", user3);


                        command.ExecuteNonQuery();
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }






                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        public void ara()
        {

            dataGridView1.Rows.Clear();
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "ctry",
                UserID = "yavuz",
                Password = "123456789",

            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                string user1 = textBox1.Text;
                string user2 = textBox2.Text;
                try
                {
                    conn.Open();
                    //MessageBox.Show("Connection Open!");

                    using (var command = conn.CreateCommand())
                    {

                        command.CommandText = "SELECT * FROM user ";



                        using (var reader = command.ExecuteReader())
                        {
                            label1.Text = "2";
                            while (reader.Read())
                            {

                                // MessageBox.Show(reader.GetString(1).ToString());
                                dataGridView1.Rows.Insert(0, reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString());
                            }
                            label1.Text = "4";
                        }
                    }






                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }



            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];

                textBox3.Text = dataGridViewRow.Cells["user1"].Value.ToString();
                textBox4.Text = dataGridViewRow.Cells["user2"].Value.ToString();
                textBox5.Text = dataGridViewRow.Cells["user3"].Value.ToString();

                textBox6.Text = dataGridViewRow.Cells["id"].Value.ToString();



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "ctry",
                UserID = "yavuz",
                Password = "123456789",

            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                string user1 = textBox3.Text;
                string user2 = textBox4.Text;
                string user3 = textBox5.Text;
                string id = textBox6.Text;
                try
                {
                    conn.Open();
                    //MessageBox.Show("Connection Open!");

                    using (var command = conn.CreateCommand())
                    {

                        command.CommandText = "UPDATE user set user1=@user1, user2=@user2 , user3=@user3 WHERE id=@id";

                        command.Parameters.AddWithValue("@user1", user1);
                        command.Parameters.AddWithValue("@user2", user2);
                        command.Parameters.AddWithValue("@user3", user3);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        ara();
                    }






                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "ctry",
                UserID = "yavuz",
                Password = "123456789",

            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                string user1 = textBox3.Text;
                string user2 = textBox4.Text;
                string user3 = textBox5.Text;
                string id = textBox6.Text;
                try
                {
                    conn.Open();
                    //MessageBox.Show("Connection Open!");

                    using (var command = conn.CreateCommand())
                    {

                        command.CommandText = "DELETE FROM user WHERE id=@id";

                     
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        ara();
                    }






                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
    }
}
