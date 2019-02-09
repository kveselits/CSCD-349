using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    public abstract class Shape : IComparable
    {
        /// <summary>
        /// Name of shape
        /// </summary>
        /// <returns>Name of a given shape</returns>
        public string GetName()
        {
            return GetType().Name;
        }

        /// <summary>
        /// Computes area of a given shape
        /// </summary>
        /// <returns>Area of a given shape</returns>
        public abstract double ComputeArea();

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Shape otherShape)
            {
                if (GetName().CompareTo(otherShape.GetName()) == 0)
                {
                    return ComputeArea().CompareTo(otherShape.ComputeArea());
                }

                return GetName().CompareTo(otherShape.GetName());
            }
            throw new ArgumentException("Object is not a Shape");
        }
    }
}
