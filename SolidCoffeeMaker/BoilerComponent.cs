using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public class BoilerComponent : BaseCoffeeMakerComponent, ICoffeeMakerComponent
    {
        private IOnOffDevice boilerDevice;

        public BoilerComponent(IOnOffDevice boilerDevice) => this.boilerDevice = boilerDevice;

        public override void EmptyBoilerWater() => this.boilerDevice.Off();

        public override void StartBrewing() => this.boilerDevice.On();
    }
}
