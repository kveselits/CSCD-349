using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    public class Triangle : Shape
    {
        protected internal Triangle()
        {
        }

        public double Width { get; set; }
        public double Height { get; set; }

        /// <summary>
        /// Computes the area of triangle:
        /// Area = half of width * height
        /// </summary>
        /// <returns></returns>
        public override double ComputeArea()
        {
            return (Width * Height) / 2;
        }

    }
}
