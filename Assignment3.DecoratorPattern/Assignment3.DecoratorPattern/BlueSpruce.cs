namespace Assignment3.DecoratorPattern
{
    internal class BlueSpruce : Tree
    {
        public BlueSpruce()
        {
            Description = "Colorado Blue Spruce";
        }

        public override double Cost()
        {
            return 50.0;
        }
    }
}