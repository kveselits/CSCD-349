using System;

namespace Assignment4.ShapeTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory factory = new ShapeFactory();
            Square mySquare = (Square)factory.CreateShape("Square");
            mySquare.Height = 10;
            Console.WriteLine(mySquare.ComputeArea());
            Circle myCircle = (Circle)factory.CreateShape("Circle");
            myCircle.Radius = 10;
            Console.WriteLine(myCircle.ComputeArea());
            Rectangle myRectangle = (Rectangle)factory.CreateShape("Rectangle");
            myRectangle.Height = 4;
            myRectangle.Width = 6;
            Console.WriteLine(myRectangle.ComputeArea());
            Triangle myTriangle = (Triangle)factory.CreateShape("Triangle");
            myTriangle.Height = 7;
            myTriangle.Width = 12;
            Console.WriteLine(myTriangle.ComputeArea());

            Shape square = new Circle();
        }
    }
}
