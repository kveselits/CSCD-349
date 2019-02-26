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

            Console.WriteLine(Environment.NewLine);

            //Test using the methods returned in the CourseIterator object:
            CourseIterator iterator = new CourseIterator(students);

            while (iterator.MoveNext())
            {
                Student student = iterator.Current;
                Console.WriteLine($"Manually iterated student Name: {student.Name}, Manually iterated student ID: {student.Id}");
            }

            Console.WriteLine(Environment.NewLine);

            //Repeating while loop to test reset method. Nothing should print because iterator should still be positioned at end of list:
            while (iterator.MoveNext())
            {
                Student student = iterator.Current;
                Console.WriteLine($"Manually iterated student Name: {student.Name}, Manually iterated student ID: {student.Id}");
            }

            iterator.Reset();

            while (iterator.MoveNext())
            {
                Student student = iterator.Current;
                Console.WriteLine($"Manually iterated after reset: {student.Name}, Manually iterated after reset: {student.Id}");
            }
        }
    }
}
