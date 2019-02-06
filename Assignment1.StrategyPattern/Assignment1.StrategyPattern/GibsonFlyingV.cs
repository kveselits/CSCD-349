using System;

namespace Assignment_1_Strategy_Pattern
{
    class GibsonFlyingV : IGuitar
    {
        public string PlayGuitar()
        {
            return $"plays the {this.GetType().Name}";
        }
    }
}
