using System;
using System.Collections;
using System.Collections.Generic;

namespace course
{
    public class Course : IEnumerable
    {
        private List<Student> Students { get; }
        public Course(List<Student> students)
        {
            Students = students;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CourseIterator GetEnumerator()
        {
            return new CourseIterator(Students);
        }
    }

    public class CourseIterator : IEnumerator
    {
        private List<Student> Students { get; }

        /// <summary>
        /// Enumerators are positioned before the first element
        /// until the first MoveNext() call.
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=netframework-4.7.2
        /// </summary>
        private int _position = -1;

        public CourseIterator(List<Student> students)
        {
            Students = students;
        }


        public bool MoveNext()
        {
            _position++;
            return (_position < Students.Count);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Student Current
        {
            get
            {
                try
                {
                    return Students[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}