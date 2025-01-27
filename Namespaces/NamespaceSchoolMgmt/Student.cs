using System;

namespace Student
{
    public class Student
    {
        private readonly int StudentId;
        private readonly string LastName;
        private readonly string FirstName;
        private string MiddleName = null!;

        public Student(int studentId, string lastName, string firstName)
        {
            this.StudentId = studentId;
            this.LastName = lastName;
            this.FirstName = firstName;
        }

        public Student(int studentId, string lastName, string firstName, string middleName)
        {
            this.StudentId = studentId;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
        }

        public void UpdateMiddleName(string newMiddleName)
        {
            this.MiddleName = newMiddleName;
        }

        public void PrintStudentData()
        {
            System.Console.WriteLine($"Student ID: {this.StudentId} | {this.LastName}, {this.FirstName}" + (String.IsNullOrEmpty(this.MiddleName) ? "" : $" {this.MiddleName}"));
        }
    }
}