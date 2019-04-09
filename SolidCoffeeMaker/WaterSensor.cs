using System;
using System.Collections.Generic;
using System.Text;
using SolidCoffeeMaker.SensorStates;

namespace SolidCoffeeMaker
{
    public class BoilerSensor: ISensor<BoilerSensorStates>
    {
        private BoilerSensorStates boilerState = BoilerSensorStates.BoilerEmpty;

        public BoilerSensorStates GetState()
        {
            return this.boilerState;
        }
    }
}
