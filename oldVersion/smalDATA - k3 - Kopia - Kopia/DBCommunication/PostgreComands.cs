using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using Npgsql;

namespace DBCommunication
{
    public class PostgreComands
    {
        protected NpgsqlConnection connection;
        public string connectionString;

        public PostgreComands(string userId, string password, string host, string port, string database)
        {
            connectionString = $"User ID={userId};Password={password};Host={host};Port={port};Database={database};";
        }

        public void Insert(string nameOfTable, string columnName, string insertValue)
        {
            insertValue = insertValue.Replace(",", "','");
            insertValue = "'" + insertValue + "'";

            var query = String.Format("insert into {0}({1}) values ({2});", nameOfTable, columnName, insertValue);

            using (connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                var liczba = command.ExecuteNonQuery();
            }
        }

        public void Update(string nameOfTable, string updateColumnName, string updateValue, string selectorColumnName, string selectorValue)
        {
            //var a = "UPDATE Customers SET ContactName = 'Alfred Schmidt', City = 'Frankfurt' WHERE CustomerID = 1; ";

            var query = String.Format("UPDATE {0} SET {1} = '{2}' WHERE {3} = '{4}';", nameOfTable, updateColumnName, updateValue, selectorColumnName, selectorValue);
            using (connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                var liczba = command.ExecuteNonQuery();
            }
        }

        public void Delete(string nameOfTable, string columnName, string deleteValue)
        {
            deleteValue = columnName != "id" ? "'" + deleteValue + "'" : deleteValue;
            string query;

            if (deleteValue.Where(m => m == ',').ToList().Count > 0)
            {
                query = String.Format("DELETE FROM {0} WHERE {1} in ({2});", nameOfTable, columnName, deleteValue);
            }
            else
            {
                query = String.Format("DELETE FROM {0} WHERE {1} = {2};", nameOfTable, columnName, deleteValue);
            }

            using (connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                var liczba = command.ExecuteNonQuery();
            }
        }

        public Dictionary<string, List<string>> SelectManyColumns(string nameOfTable, string columnName)        // todo select *
        {
            using (connection = new NpgsqlConnection(connectionString))
            {
                string userComand = $"select {columnName} from {nameOfTable} ";
                NpgsqlCommand npgCommand = new NpgsqlCommand(userComand, connection);
                npgCommand.Connection.Open();

                var columns = columnName != "*" ? columnName.Split(',') : new[] { "*" };

                Dictionary<string,List<string>> dic = new Dictionary<string, List<string>>();
                foreach (var column in columns)
                {
                    var list = new List<string>();
                    using (var reader = npgCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader[column].ToString());
                        }
                        dic.Add(column, list);
                    }
                }
                return dic;
            }
        }


        public List<string> SelectSingleColumn(string nameOfTable, string columnName)
        {
            using (connection = new NpgsqlConnection(connectionString))
            {
                string userComand = $"select {columnName} from {nameOfTable} ";
                NpgsqlCommand npgCommand = new NpgsqlCommand(userComand, connection);
                npgCommand.Connection.Open();

                var list = new List<string>();

                using (var reader = npgCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader[columnName].ToString());
                    }
                    return list;
                }
            }
        }

        public string GetUserIdToStartProcesses()
        {
            using (connection = new NpgsqlConnection(connectionString))
            {
                string userComand = "select facebookid from usersidtable where checked = '0';";
                NpgsqlCommand npgCommand = new NpgsqlCommand(userComand, connection);
                npgCommand.Connection.Open();

                var list = new List<string>();

                using (var reader = npgCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["facebookid"].ToString());
                    }
                    Update("usersidtable", "checked", "1", "facebookid", list.First()); 
                    return list.First();
                }
            }
        }
        public int GetLastID(string tableName)
        {
            using (connection = new NpgsqlConnection(connectionString))
            {
                string userComand = string.Format(" SELECT MAX(Id) FROM {0}; ",tableName);
                NpgsqlCommand npgCommand = new NpgsqlCommand(userComand, connection);
                npgCommand.Connection.Open();

                var list = new List<string>();

                using (var reader = npgCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["max"].ToString());
                    }
                    return Convert.ToInt32(list.First());
                }
            }
        }

        public void UpdateValueWhereIsNull(string nameOfTable, string updateColumnName, string updateValue, string selectorColumnName)
        {
            //var a = "UPDATE Customers SET ContactName = 'Alfred Schmidt', City = 'Frankfurt' WHERE CustomerID = 1; ";

            var query = String.Format("UPDATE {0} SET {1} = '{2}' WHERE {3} is null;", nameOfTable, updateColumnName, updateValue, selectorColumnName);
            using (connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                var liczba = command.ExecuteNonQuery();
            }
        }

    }
}