using System;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ISStorageCS
{
    public class DataBase : DbContext
    {
        public static string strExeFilePath = Assembly.GetExecutingAssembly().Location;

        private SqliteConnection connection = new SqliteConnection(@"Data Source=" +
        strExeFilePath.Substring(0,
        strExeFilePath.Length - 15) + @"storage.sqlite");
        // private SqliteConnection connection = new SqliteConnection(@"Data Source=C:\Users\kak7\Documents\GitHub\ISStorageCS\storage.sqlite");

        public DataBase()
        {
            connection.Open();
        }

        public SqliteDataReader GetReader(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;

            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;
            command.ExecuteNonQuery();
        }

        
        
        
        
    }
}
