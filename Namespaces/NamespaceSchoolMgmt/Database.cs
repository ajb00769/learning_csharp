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

        public static bool AddStudent(Student.Student student)
        {
            try
            {
                SqliteConnection Db = DbConnection();
                Db.Open();

                var insertCommand = Db.CreateCommand();
                insertCommand.CommandText =
                @"
                    INSERT INTO students (lastname, firstname, middlename)
                    VALUES (@lastname, @firstname, @middlename);
                ";

                insertCommand.Parameters.AddWithValue("@lastname", student.GetLastName());
                insertCommand.Parameters.AddWithValue("@firstname", student.GetFirstName());
                insertCommand.Parameters.AddWithValue("@middlename", student.GetMiddleName());

                insertCommand.ExecuteNonQuery();
                Db.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void GetStudent() { }

        public static void UpdateStudent() { }

        public static void DeleteStudent() { }
    }
}