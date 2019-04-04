using System;
using System.Collections.Generic;
using System.Text;
using SolidCoffeeMaker.SensorStates;

namespace SolidCoffeeMaker
{
    public class BoilerSensor
    {
        public event EventHandler OnWaterRefill;
        public event EventHandler OnWaterEmpty;
    }
}
