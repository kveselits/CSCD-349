using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    public class Square : Shape
    {
        protected internal Square()
        {
        }

        public double Height { get; set; }

        /// <summary>
        /// Compute area of square:
        /// Area = side squared
        /// </summary>
        /// <returns>Area of a square</returns>
        public override double ComputeArea()
        {
            return Math.Pow(Height, 2);
        }
    }
}
