using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public class IndicatorLight : IOnOffDevice
    {
        public bool IsOn { get; private set; }

        public void Off()
        {
            IsOn = false;
        }

        public void On()
        {
            IsOn = true;
        }
    }
}
