using System;

namespace Assignment4.RefactorToFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(2, 4);
            Console.WriteLine(rect.ComputeArea());
            Shape square = new Square(4);
            Shape tri = new Triangle(4, 3);
            Console.WriteLine(tri.ComputeArea());
            Shape circ = new Circle(5);
            Console.WriteLine(circ.ComputeArea());

            Console.WriteLine(rect);
        }
    }
}
