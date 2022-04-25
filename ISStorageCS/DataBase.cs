﻿using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ISStorageCS
{
    public class DataBase : DbContext
    {
        public static string strExeFilePath = Assembly.GetExecutingAssembly().Location;

        // private SqliteConnection connection = new SqliteConnection(@"Data Source=" +
        //                                                            strExeFilePath.Substring(0,
        //                                                                strExeFilePath.Length - 11) + @"\storage.sqlite");
        private SqliteConnection connection = new SqliteConnection(@"Data Source=C:\Users\kaks\RiderProjects\ISStorageCS\storage.sqlite");

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
