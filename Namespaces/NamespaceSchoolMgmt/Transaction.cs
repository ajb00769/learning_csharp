using System;
using Student;

namespace Transaction
{
    public class Transaction
    {
        private string lastName;
        private string firstName;
        private string? middleName;

        public Student.Student HandleUserInput()
        {
            while (String.IsNullOrEmpty(lastName))
            {
                Console.Write("Enter the student's Last Name: ");
                lastName = Console.ReadLine();
            }

            while (String.IsNullOrEmpty(firstName))
            {
                Console.Write("Enter the student's First Name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Enter the student's Middle Name (Optional): ");
            middleName = Console.ReadLine();

            return new Student.Student(0, lastName, firstName, middleName);
        }
    }
}