namespace Assignment3.DecoratorPattern
{
    internal class BallsSilver : TreeDecorator
    {
        private Tree MyTree { get; }

        public BallsSilver(Tree myTree)
        {
            MyTree = myTree;
        }

        public override double Cost()
        {

            return MyTree.Cost() + 3.00;
        }

        public override string GetDescription()
        {
            return MyTree.GetDescription() + ", Balls Silver";
        }
    }
}