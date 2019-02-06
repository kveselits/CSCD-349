using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    class Triangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        /// <summary>
        /// Accepts width and height of triangle
        /// </summary>
        /// <param name="width">Width (or base) of triangle</param>
        /// <param name="height">Height of triangle</param>
        public Triangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Computes the area of triangle:
        /// Area = half of width * height
        /// </summary>
        /// <returns></returns>
        internal override double ComputeArea()
        {
            return (Width * Height) / 2;
        }
    }
}
