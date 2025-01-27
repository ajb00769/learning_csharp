using System;
using Student;
using DatabaseHandler;
using Microsoft.Data.SqlClient;

namespace SchoolMgmt
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Initializing program.");
            Thread.Sleep(2000);
            bool DbInitSuccess = DatabaseHandler.DatabaseHandler.InitDb();
            if (!DbInitSuccess)
            {
                Console.WriteLine("Failure in initializing the database. Exiting program.");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Database initialization success.");
                Thread.Sleep(2000);
            }

            Console.WriteLine("Please type the number of the action you want to perform:\n[1] Add a New Student\n[2] Get an Existing Student\n[3] Update an Existing Student's Data\n[4] Delete a Student");

            char[] ValidTransactionType = ['1', '2', '3', '4'];
            char SelectedTransactionType;

            while (true)
            {
                char KeyPressed = Console.ReadKey(true).KeyChar;

                if (ValidTransactionType.Contains(KeyPressed))
                {
                    SelectedTransactionType = KeyPressed;
                    break;
                }
            }

            Console.WriteLine(SelectedTransactionType);
        }
    }
}