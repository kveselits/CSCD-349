namespace Assignment3.DecoratorPattern
{
    internal class BallsBlue : TreeDecorator
    {
        private Tree MyTree { get; }

        public BallsBlue(Tree myTree)
        {
            MyTree = myTree;
        }

        public override double Cost()
        {

            return MyTree.Cost() + 2.00;
        }

        public override string GetDescription()
        {
            return MyTree.GetDescription() + ", Balls Blue";
        }
    }
}