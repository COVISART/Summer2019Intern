using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mySqlConnection2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private SqlHelper _helper;
        private void Form2_Load(object sender, EventArgs e)
        {
            _helper = new SqlHelper("Server=127.0.0.1;Database=myfirstdb;Uid=root;Pwd=;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _helper.OpenConnection();
            DataSet dataSet =  _helper.GetDataSet("Select * from users");
            _helper.Connection.Close();
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btnVeriEkle_Click(object sender, EventArgs e)
        {
            var param = _helper.Command.Parameters;

            param.Clear();
            param.AddWithValue("@username",txtUsername.Text);
            param.AddWithValue("@password", txtPassword.Text);
            _helper.OpenConnection();
            _helper.ExecuteCommand("insert into users(username,Name) values(@username,@password)");
            _helper.Connection.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _helper.OpenConnection();

            _helper.Command.Parameters.Clear();
            _helper.Command.Parameters.AddWithValue("@name","%"+txtSearch.Text + "%");

            DataSet dataSet = _helper.GetDataSet("Select * from users where username like @name");
            _helper.Connection.Close();
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
