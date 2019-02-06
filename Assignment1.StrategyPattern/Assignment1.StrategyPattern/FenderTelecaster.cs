using System;

namespace Assignment_1_Strategy_Pattern
{
    class FenderTelecaster : IGuitar
    {
        public string PlayGuitar()
        {
            return $"plays the {this.GetType().Name}";
        }
    }
}
