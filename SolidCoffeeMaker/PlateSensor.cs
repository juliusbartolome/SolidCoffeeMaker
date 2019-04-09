using SolidCoffeeMaker.SensorStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public class PlateSensor : ISensor<WarmerPlateSensorStates>
    {
        private WarmerPlateSensorStates plateSensorState = WarmerPlateSensorStates.PotEmpty;

        public WarmerPlateSensorStates GetState()
        {
            return this.plateSensorState;
        }
    }
}
