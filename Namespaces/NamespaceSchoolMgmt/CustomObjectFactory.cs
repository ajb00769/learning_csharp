using System;
using Student;

namespace CustomObjectFactory
{
    public class CustomObjectFactory
    {
        private string? lastName;
        private string? firstName;
        private string? middleName;

        public Student.Student CreateStudentObj()
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

            if (String.IsNullOrEmpty(middleName))
            {
                return new Student.Student(0, lastName, firstName);
            }
            else
            {
                return new Student.Student(0, lastName, firstName, middleName);
            }
        }

        public string? GetLastName()
        {
            return this.lastName;
        }

        public string? GetFirstName()
        {
            return this.firstName;
        }
    }
}