namespace Assignment3.DecoratorPattern
{
    internal class Lights : TreeDecorator
    {
        private Tree MyTree { get; }

        public Lights(Tree myTree)
        {
            MyTree = myTree;
        }

        public override double Cost()
        {

            return MyTree.Cost() + 5.00;
        }

        public override string GetDescription()
        {
            return MyTree.GetDescription() + ", Lights";
        }
    }
}