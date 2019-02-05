namespace Assignment3.DecoratorPattern
{
    internal class FraserFir : Tree
    {
        public FraserFir()
        {
            Description = "Fraser Fir";
        }

        public override double Cost()
        {
            return 35.0;
        }
    }
}