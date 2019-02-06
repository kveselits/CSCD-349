using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    class Square : Shape
    {
        public double Side { get; }

        /// <summary>
        /// Accepts one side of square as its only parameter
        /// </summary>
        /// <param name="side">Length of one side of square</param>
        public Square(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Compute area of square:
        /// Area = side squared
        /// </summary>
        /// <returns>Area of a square</returns>
        public double ComputeArea()
        {
            return Math.Pow(Side, 2);
        }
    }
}
