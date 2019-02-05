using System;

namespace Assignment3.DecoratorPattern
{
    class TreeTester
    {
        static void Main(string[] args)
        {
            Tree mytree = new BlueSpruce();
            mytree = new Star(mytree);
            mytree = new Ruffles(mytree);
            mytree = new Star(mytree); //this is problematic and should not be permitted
            mytree = new Ruffles(mytree);
            printtree(mytree);
        }
    }
}
