namespace Assignment3.DecoratorPattern
{
    internal class LEDs : TreeDecorator
    {
        private Tree MyTree { get; }

        public LEDs(Tree myTree)
        {
            MyTree = myTree;
        }

        public override double Cost()
        {

            return MyTree.Cost() + 10.00;
        }

        public override string GetDescription()
        {
            return MyTree.GetDescription() + ", LEDs";
        }
    }
}