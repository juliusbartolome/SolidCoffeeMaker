using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public class BoilerHeater
    {
        public BoilerHeater(BoilerSensor boilerSensor)
        {
            BoilerSensor = boilerSensor;
        }

        public BoilerSensor BoilerSensor { get; private set; }
        public bool IsTurnedOn { get; set; }
    }
}
