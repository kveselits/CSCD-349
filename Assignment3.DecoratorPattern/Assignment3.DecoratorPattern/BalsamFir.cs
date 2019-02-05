namespace Assignment3.DecoratorPattern
{
    internal class BalsamFir : Tree
    {
        public BalsamFir()
        {
            Description = "Balsam Fir";
        }

        public override double Cost()
        {
            return 25.0;
        }
    }
}