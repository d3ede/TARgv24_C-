/* using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsGradesAnalysis
{
    class Student
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; }

        public double Average => Grades.Count > 0 ? Grades.Average() : 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "������", Grades = new List<int> { 5, 4, 5, 3 } },
                new Student { Name = "�����", Grades = new List<int> { 4, 5, 5, 5, 5 } },
                new Student { Name = "�����", Grades = new List<int> { 3, 4, 4 } }
            };

            Console.WriteLine("������� ������ ���������:\n");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}: {student.Average:F2}");
            }

            var bestStudent = students.OrderByDescending(s => s.Average).First();
            Console.WriteLine($"\n������ ������� ���� �: {bestStudent.Name} ({bestStudent.Average:F2})");
        }
    }
}
