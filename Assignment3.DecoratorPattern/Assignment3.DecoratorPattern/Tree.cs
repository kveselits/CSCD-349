namespace Assignment3.DecoratorPattern
{
    internal abstract class Tree
    {
        private string _description = "Unknown Tree";

        public string GetDescription()
        {
            return _description;
        }

        public abstract double Cost();
    }
}