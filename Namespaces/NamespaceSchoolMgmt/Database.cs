using System;
using System.Data.Common;
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
                SqliteConnection db = DbConnection();

                var insertCommand = db.CreateCommand();
                insertCommand.CommandText =
                @"
                    INSERT INTO students (lastname, firstname, middlename)
                    VALUES (@lastname, @firstname, @middlename);
                ";

                insertCommand.Parameters.AddWithValue("@lastname", student.GetLastName());
                insertCommand.Parameters.AddWithValue("@firstname", student.GetFirstName());
                insertCommand.Parameters.AddWithValue("@middlename", student.GetMiddleName());

                db.Open();
                insertCommand.ExecuteNonQuery();
                db.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static Student.Student? GetStudent(string lastname, string firstname)
        {
            try
            {
                SqliteConnection db = DbConnection();

                var getCommand = db.CreateCommand();
                getCommand.CommandText =
                @"
                    SELECT * FROM students WHERE lastname=@lastname
                    AND firstname=@firstname;
                ";

                getCommand.Parameters.AddWithValue("@lastname", lastname);
                getCommand.Parameters.AddWithValue("@firstname", firstname);

                db.Open();
                using var result = getCommand.ExecuteReader();
                if (result.Read())
                {
                    return new Student.Student(result.GetInt32(0), result.GetString(1), result.GetString(2));
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void UpdateStudent() { }

        public static void DeleteStudent() { }
    }
}