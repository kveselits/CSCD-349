namespace Assignment3.DecoratorPattern
{
    internal abstract class Tree
    {
        protected string Description { get; set; }

        public virtual string GetDescription()
        {
            return Description;
        }

        public abstract double Cost();
    }
}