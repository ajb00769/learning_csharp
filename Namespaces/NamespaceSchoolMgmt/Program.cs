using System;
using Student;
using DatabaseHandler;
using CustomObjectFactory;
using Microsoft.Data.SqlClient;

namespace SchoolMgmt
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Initializing program.");
            Thread.Sleep(1000);
            bool dbInitSuccess = DatabaseHandler.DatabaseHandler.InitDb();
            if (!dbInitSuccess)
            {
                Console.WriteLine("Failure in initializing the database. Exiting program.");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Database initialization success.");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Please type the number of the action you want to perform:\n[1] Add a New Student\n[2] Get an Existing Student\n[3] Update an Existing Student's Data\n[4] Delete a Student");

            char[] validTransactionType = ['1', '2', '3', '4'];
            char selectedTransactionType;

            while (true)
            {
                char keyPressed = Console.ReadKey(true).KeyChar;

                if (validTransactionType.Contains(keyPressed))
                {
                    selectedTransactionType = keyPressed;
                    break;
                }
            }

            CustomObjectFactory.CustomObjectFactory objectFactory = new();

            switch (selectedTransactionType)
            {
                case '1':
                    while (true)
                    {
                        Student.Student studentCreated = objectFactory.CreateStudentObj();
                        bool studentSavedSuccess = DatabaseHandler.DatabaseHandler.AddStudent(studentCreated);
                        if (studentSavedSuccess)
                        {
                            Console.WriteLine("New Student saved successfully.");
                            break;
                        }
                    }
                    break;
                case '2':
                    Student.Student studentToFetch = objectFactory.CreateStudentObj();
                    var studentFetched = DatabaseHandler.DatabaseHandler.GetStudent(studentToFetch.GetLastName(), studentToFetch.GetFirstName());
                    if (studentFetched != null)
                    {
                        Console.WriteLine($"Student Id: {studentFetched.GetStudentId()}\nStudent Name: {studentFetched.GetLastName()}, {studentFetched.GetFirstName()}");
                    }
                    else
                    {
                        Console.WriteLine($"Student \'{studentToFetch.GetLastName()}, {studentToFetch.GetFirstName()}\' not found.");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}