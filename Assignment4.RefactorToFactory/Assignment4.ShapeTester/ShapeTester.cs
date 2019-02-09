using System;
using System.Collections.Generic;
using Assignment4.RefactorToFactory;

namespace Assignment4.ShapeTester
{
    /// <summary>
    /// I realize the need for typecasting violates some OO principles. Ran out of time.
    /// I would have liked it so that "Shape newShape = factory.CreateShape("Circle")" worked.
    /// </summary>
    class ShapeTester
    {
        static void Main(string[] args)
        {

            /* Not allowed:
            Shape square = new Square();
            Shape circle = new Circle();
            Shape rectangle = new Rectangle();
            Shape triangle = new Triangle();*/

            List<Shape> shapeList = new List<Shape>();

            ShapeFactory factory = new ShapeFactory();

            Square mySquare2 = (Square)factory.CreateShape("Square");
            mySquare2.Height = 15;
            shapeList.Add(mySquare2);

            Square mySquare = (Square)factory.CreateShape("Square");
            mySquare.Height = 10;
            shapeList.Add(mySquare);

            Circle myCircle2 = (Circle)factory.CreateShape("Circle");
            myCircle2.Radius = 20;
            shapeList.Add(myCircle2);

            Circle myCircle = (Circle)factory.CreateShape("Circle");
            myCircle.Radius = 10;
            shapeList.Add(myCircle);

            Rectangle myRectangle2 = (Rectangle)factory.CreateShape("Rectangle");
            myRectangle2.Height = 40;
            myRectangle2.Width = 60;
            shapeList.Add(myRectangle2);

            Rectangle myRectangle = (Rectangle)factory.CreateShape("Rectangle");
            myRectangle.Height = 4;
            myRectangle.Width = 6;
            shapeList.Add(myRectangle);

            Triangle myTriangle2 = (Triangle)factory.CreateShape("Triangle");
            myTriangle2.Height = 100;
            myTriangle2.Width = 500;
            shapeList.Add(myTriangle2);

            Triangle myTriangle = (Triangle)factory.CreateShape("Triangle");
            myTriangle.Height = 7;
            myTriangle.Width = 12;
            shapeList.Add(myTriangle);

            Console.WriteLine($"Before sorting:");
            PrintShapes(shapeList);

            Console.WriteLine(Environment.NewLine);

            shapeList.Sort();

            Console.WriteLine($"After sorting:");
            PrintShapes(shapeList);

        }

        private static void PrintShapes(List<Shape> shapeList)
        {
            foreach (var shape in shapeList)
            {
                Console.WriteLine($"{shape.GetName()}: {shape.ComputeArea()}");
            }
        }
    }
}
