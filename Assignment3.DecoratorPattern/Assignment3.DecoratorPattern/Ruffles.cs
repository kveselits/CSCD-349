namespace Assignment3.DecoratorPattern
{
    internal class Ruffles : TreeDecorator
    {
        private Tree MyTree { get; }

        public Ruffles(Tree myTree)
        {
            MyTree = myTree;
        }

        public override double Cost()
        {

            return MyTree.Cost() + 1.00;
        }

        public override string GetDescription()
        {
            return MyTree.GetDescription() + ", Ruffles";
        }
    }
}