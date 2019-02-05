using System;

namespace Assignment3.DecoratorPattern
{
    /// <summary>
    /// Referenced: https://www.dofactory.com/net/singleton-design-pattern
    /// </summary>
    class Star : TreeDecorator
    {
        private Tree MyTree { get; }
        private static Star _instance;

        protected Star(Tree myTree)
        {
            MyTree = myTree;
        }

        public static Tree Instance(Tree myTree)
        {
            if (_instance == null)
            {
                _instance = new Star(myTree);
            }
            else if (_instance != null)
            {
                Console.WriteLine("Tree already has a star!");
                return myTree;
            }

            return _instance;
        }

        public override string GetDescription()
        {
            return MyTree.GetDescription() + ", Star";
        }

        public override double Cost()
        {
            return MyTree.Cost() + 4.00;
        }
    }
}
