using System;

namespace SolidCoffeeMaker
{
    public class CoffeeMaker
    {
        private readonly BoilerHeater boilerHeater;
        private readonly PressureReliefValve pressureReliefValve;

        public bool LightIndicatorIsOn { get; private set; }

        public CoffeeMaker(BoilerHeater boilerHeater, PressureReliefValve pressureReliefValve)
        {
            this.boilerHeater = boilerHeater;
            this.pressureReliefValve = pressureReliefValve;
        }

        public void Brew()
        {
            this.boilerHeater.IsTurnedOn = true;
            this.pressureReliefValve.IsOpen = false;
        }

        private void BoilerSensor_OnWaterEmpty(object sender, EventArgs e)
        {
            this.boilerHeater.IsTurnedOn = false;
            this.pressureReliefValve.IsOpen = true;
            LightIndicatorIsOn = true;
        }
    }
}
