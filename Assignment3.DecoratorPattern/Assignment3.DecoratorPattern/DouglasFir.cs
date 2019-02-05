namespace Assignment3.DecoratorPattern
{
    internal class DouglasFir : Tree
    {
        public DouglasFir()
        {
            Description = "Douglas Fir";
        }

        public override double Cost()
        {
            return 30.0;
        }
    }
}