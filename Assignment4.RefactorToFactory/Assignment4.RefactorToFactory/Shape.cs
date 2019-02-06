using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    abstract class Shape
    {
        /// <summary>
        /// Name of shape
        /// </summary>
        /// <returns>Name of a given shape</returns>
        public override string ToString()
        {
            return GetType().Name;
        }

        /// <summary>
        /// Computes area of a given shape
        /// </summary>
        /// <returns>Area of a given shape</returns>
        internal abstract double ComputeArea();
    }
}
