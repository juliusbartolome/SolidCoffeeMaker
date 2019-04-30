using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public class BoilerComponent : ICoffeeMakerComponent
    {
        private IOnOffDevice boilerDevice;

        public BoilerComponent(IOnOffDevice boilerDevice)
        {
            this.boilerDevice = boilerDevice;
        }

        public void EmptyBoilerWater() => this.boilerDevice.Off();

        public void FinishBrewing() { }

        public void InterruptBrewing() { }

        public void RefillBoilerWater() { }

        public void StartBrewing() => this.boilerDevice.On();
    }
}
