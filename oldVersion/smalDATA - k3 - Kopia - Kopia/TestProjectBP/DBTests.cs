using System;
using DBCommunication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace TestProjectBP
{
    [TestClass]
    public class DBTests
    {
        PostgreComands comands = new PostgreComands("postgres", "start12345", "localhost", "5432", "smalDATA");

        [TestMethod]
        public void InsertTest()
        {
            for (int i = 0; i < 10; i++)
            {
                comands.Insert("usersidtable", "facebookid", "testVal");
                comands.Insert("usersidtable", "userid,facebookid,checked", "99,testVal,9");
            }
            
        }
        [TestMethod]
        public void UpdateTest()
        {
            comands.Update("usersidtable", "checked", "9", "id", "1");
        }
        [TestMethod]
        public void DeleteTest()
        {
            comands.Delete("usersidtable", "facebookid", "testVal");
            comands.Delete("usersidtable", "id", "1,2,3");
        }
        [TestMethod]
        public void SelectOneColumnTest()
        {
            var b = comands.SelectSingleColumn("usersidtable", "id");
        }
        [TestMethod]
        public void SelectManyColumnsTest()
        {
            var a = comands.SelectManyColumns("usersidtable", "id,checked");
        }

        [TestMethod]
        public void GetIDTest()
        {
            //comands.UpdateValueWhereIsNull("usersidtable", "checked", "0", "checked");
            var a = comands.GetLastID("usersidtable");
        }

        [TestMethod]
        public void kicha()
        {
            NpgsqlConnection connection;
            string connectionString = "User ID=postgres;Password=start12345;Host=localhost;Port=5432;Database=smalDATA;";
            string nameOfTable = "userlikes";
            string columnName = "userid,reallikename,facebooklikename";
            string val = "";
            string insertValue = "'kasia.cmikiewicz','Są śmiertelnicy i herosi , ale żeby Percy 'ego Jacksona nie znać.','Są-śmiertelnicy-i-herosi-ale-żeby-Percyego-Jacksona-nie-znać-202345619897180'); ";

            for (int i = 0; i < insertValue.Length; i++)
            {
                if (insertValue[i].ToString() == "'" || insertValue[i] == ',')
                {
                    val += " ";
                }
                else
                {
                    val += insertValue[i];
                }
                if (insertValue[i] == '\b')
                {
                    val += "'" + "," + "'";
                }
            }

            val = "'" + val + "'";


                var query = String.Format("insert into {0}({1}) values ({2});", nameOfTable, columnName, val);

            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            connection.Open();
            var liczba = command.ExecuteNonQuery();
        }


    }
}