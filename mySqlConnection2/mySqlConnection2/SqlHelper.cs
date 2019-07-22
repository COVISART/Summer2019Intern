using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mySqlConnection2
{
    class SqlHelper
    {
        public MySqlConnection Connection;
        public MySqlCommand Command;
        public SqlHelper(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            Command = Connection.CreateCommand();
        }
        public void OpenConnection()
        {
            Connection.Open();
        }

        public DataSet GetDataSet(string commandText)
        {
            Command.CommandText = commandText;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Command);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public void ExecuteCommand(string commandText)
        {
            Command.CommandText = commandText;
            Command.ExecuteNonQuery();
        }
    }
}
