using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    public class Circle : Shape
    {
        protected internal Circle()
        {
        }

        public double Radius { get; set; }

        /// <summary>
        /// Computes the area of a circle:
        /// Area = π * (radius squared)
        /// </summary>
        /// <returns></returns>
        public override double ComputeArea()
        {
            return Math.PI * (Math.Pow(Radius, 2));
        }
    }
}
