﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.RefactorToFactory
{
    /// <summary>
    /// Rectangle Shape class
    /// </summary>
    class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        /// <summary>
        /// Constructor accepts width and height
        /// </summary>
        /// <param name="width">The width of the rectangle</param>
        /// <param name="height">The height of the rectangle</param>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Computes area of rectangle:
        /// Area = length * width
        /// </summary>
        /// <returns>Computed value of rectangle</returns>
        /// 
        public double ComputeArea()
        {
            return Width * Height;
        }
    }
}
