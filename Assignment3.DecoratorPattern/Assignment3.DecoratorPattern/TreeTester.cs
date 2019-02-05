using System;

namespace Assignment3.DecoratorPattern
{
    class TreeTester
    {
        static void Main(string[] args)
        {
            Tree myTree = new BlueSpruce();
            Tree myTree2 = new DouglasFir();
            Tree myTree3 = new FraserFir();
            Tree myTree4 = new BalsamFir();

            Decorate(myTree);
            Decorate(myTree2);
            Decorate(myTree3);
            Decorate(myTree4);

        }
        /// <summary>
        /// Realize I'm probably violating DRY here.
        /// Probably a better way to test all the different combinations.
        /// </summary>
        private static void Decorate(Tree myTree)
        {
            PrintTree(myTree);
            myTree = Star.Instance(myTree);
            PrintTree(myTree);
            myTree = new Ruffles(myTree);
            PrintTree(myTree);
            myTree = Star.Instance(myTree);
            PrintTree(myTree);
            myTree = new Ruffles(myTree);
            PrintTree(myTree);
            myTree = new BallsBlue(myTree);
            PrintTree(myTree);
            myTree = new BallsRed(myTree);
            PrintTree(myTree);
            myTree = new BallsSilver(myTree);
            PrintTree(myTree);
            myTree = new LEDs(myTree);
            PrintTree(myTree);
            myTree = new Lights(myTree);
            PrintTree(myTree);
            myTree = new Ribbons(myTree);
            PrintTree(myTree);
            Console.WriteLine(Environment.NewLine);
        }

        private static void PrintTree(Tree myTree)
        {
            Console.WriteLine($"{myTree.GetDescription()}, Cost: ${myTree.Cost()}");
        }
    }
}
