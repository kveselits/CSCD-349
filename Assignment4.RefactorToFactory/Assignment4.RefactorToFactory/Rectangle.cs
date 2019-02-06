using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        /// <summary>
        /// Constructor accepts width and height
        /// </summary>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Computes area of rectangle:
        /// Area = length * width
        /// </summary>
        /// <returns>Computed area of rectangle</returns>
        /// 
        internal override double ComputeArea()
        {
            return Width * Height;
        }
    }
}
