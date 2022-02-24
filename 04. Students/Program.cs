using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }
            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:f2}";
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int countOfStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] student = Console.ReadLine().Split(' ');
                Student student1 = new Student { FirstName = student[0], LastName = student[1], Grade = double.Parse(student[2]) };
                students.Add(student1);
            }
            List<Student> orderedStudents = students.OrderBy(student => student.Grade).ToList();
            orderedStudents.Reverse();
            foreach (Student student in orderedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
