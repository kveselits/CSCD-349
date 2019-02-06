using System;

namespace Assignment_1_Strategy_Pattern
{
    class GibsonSG : IGuitar
    {
        public string PlayGuitar()
        {
            return $"plays the {this.GetType().Name}";
        }
    }
}
