using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace mySqlConnection2
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        MySqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection("Server=127.0.0.1;Database=myfirstdb;Uid=root;Pwd=;");
        }

        private void btnVeriGetir_Click(object sender, EventArgs e)
        {

            try
            {
                connection.Open();

                cmd.CommandText = "INSERT INTO `users`( `Name`, `Username`) " +
                                  "VALUES (@Name,@Username);";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", txtUsername.Text);
                cmd.Parameters.Add("@Username", MySqlDbType.VarChar).Value = txtPassword.Text;

                cmd.ExecuteScalar();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                cmd.CommandText = "select * from users";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];

                DataTable tblUser = dataSet.Tables[0];
                DataRowCollection rows = tblUser.Rows;

                List<UserObject> lstUserObjects = new List<UserObject>();

                foreach (DataRow col in rows)
                {
                    UserObject obj = new UserObject()
                    {
                        Name = col["Name"].ToString(),
                        Ref = Convert.ToInt32(col["Ref"]),
                        UserName = col["Username"].ToString()
                    };

                    lstUserObjects.Add(obj);
                }


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
