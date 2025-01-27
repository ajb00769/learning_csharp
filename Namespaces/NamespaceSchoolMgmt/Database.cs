using System;
using Microsoft.Data.Sqlite;
using Student;

namespace DatabaseHandler
{
    public class DatabaseHandler
    {
        public static SqliteConnection DbConnection()
        {
            return new SqliteConnection("Data Source=localsqlitedb.db");
        }

        public static bool InitDb()
        {
            try
            {
                SqliteConnection Db = DbConnection();
                Db.Open();

                var createTableCommand = Db.CreateCommand();
                createTableCommand.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS students (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        lastname VARCHAR(30) NOT NULL,
                        firstname VARCHAR(30) NOT NULL,
                        middlename VARCHAR(30)
                    );
                ";

                createTableCommand.ExecuteNonQuery();
                Db.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void AddStudent(Student.Student student)
        {
        }

        public static void GetStudent() { }

        public static void UpdateStudent() { }

        public static void DeleteStudent() { }
    }
}