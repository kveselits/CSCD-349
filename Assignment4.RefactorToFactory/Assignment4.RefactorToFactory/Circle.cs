using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    class Circle : Shape
    {
        public double Radius { get; }
        /// <summary>
        /// Accepts a single parameter of radius
        /// </summary>
        /// <param name="radius">Radius of a circle</param>
        public Circle(double radius)
        {
            Radius = radius;
        }
        /// <summary>
        /// Computes the area of a circle:
        /// Area = π * (radius squared)
        /// </summary>
        /// <returns></returns>
        internal override double ComputeArea()
        {
            return Math.PI * (Math.Pow(Radius, 2));
        }
    }
}
