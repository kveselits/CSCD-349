using System;
using System.Collections.Generic;
using course;

namespace CourseIteratorTester
{
    class CourseIteratorTester
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Some Guy", 5), new Student("Einstein", 10), new Student("Trump", 15)
            };
            Course course = new Course(students);

            foreach (Student student in course)
            {
                Console.WriteLine($"Student Name: {student.Name}, Student ID: {student.Id}");
            }
        }
    }
}
