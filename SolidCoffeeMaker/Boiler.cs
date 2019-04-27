using System;

namespace SolidCoffeeMaker
{
    public class Boiler : IObserver<BoilerSensorStatus>, IObserver<BrewButtonStatus>
    {
        private bool hasWater;
        private bool isBrewButtonPushed;
        private readonly IOnOffDevice boiler;

        public Boiler(IOnOffDevice boilerDevice)
        {
            this.boiler = boilerDevice;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(BrewButtonStatus value)
        {
            this.isBrewButtonPushed = value == BrewButtonStatus.IsPushed;
            if (this.isBrewButtonPushed && this.hasWater && !this.boiler.IsOn())
                this.boiler.On();
        }

        public void OnNext(BoilerSensorStatus value)
        {
            this.hasWater = value == BoilerSensorStatus.BoilerNotEmpty;
            if (value == BoilerSensorStatus.BoilerEmpty && this.boiler.IsOn())
                this.boiler.Off();
        }
    }
}
