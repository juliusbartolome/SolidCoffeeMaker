using System;

namespace SolidCoffeeMaker
{
    public class BoilerObserver : IObserver<BoilerSensorState>, IObserver<BrewButtonState>
    {
        private bool hasWater;
        private bool isBrewButtonPushed;
        private readonly IOnOffDevice boiler;

        public BoilerObserver(IOnOffDevice boiler)
        {
            this.boiler = boiler;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(BrewButtonState value)
        {
            this.isBrewButtonPushed = value == BrewButtonState.IsPushed;
            if (this.isBrewButtonPushed && this.hasWater && !this.boiler.IsOn())
                this.boiler.TurnOn();
        }

        public void OnNext(BoilerSensorState value)
        {
            this.hasWater = value == BoilerSensorState.BoilerNotEmpty;
            if (value == BoilerSensorState.BoilerEmpty && this.boiler.IsOn())
                this.boiler.TurnOff();
        }
    }
}
