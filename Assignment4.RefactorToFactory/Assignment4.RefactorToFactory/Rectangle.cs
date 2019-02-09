using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    public class Rectangle : Shape
    {
        protected internal Rectangle()
        {
        }

        public double Width { get; set; }
        public double Height { get; set; }

        /// <summary>
        /// Computes area of rectangle:
        /// Area = length * width
        /// </summary>
        /// <returns>Computed area of rectangle</returns>
        /// 
        public override double ComputeArea()
        {
            return Width * Height;
        }
    }
}
