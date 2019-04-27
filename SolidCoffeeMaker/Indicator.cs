using System;

namespace SolidCoffeeMaker
{
    public class Indicator : IObserver<BoilerSensorStatus>, IObserver<BrewButtonStatus>
    {
        private readonly IOnOffDevice indicatorDevice;
        private bool hasWater;
        private bool isBrewing;

        public Indicator(IOnOffDevice indicatorDevice)
        {
            this.indicatorDevice = indicatorDevice;
        }

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(BrewButtonStatus value)
        {
            this.isBrewing = value == BrewButtonStatus.IsPushed && this.hasWater;
            if (this.isBrewing && this.indicatorDevice.IsOn())
                this.indicatorDevice.Off();
        }

        public void OnNext(BoilerSensorStatus value)
        {
            this.hasWater = value == BoilerSensorStatus.BoilerNotEmpty;
            if (!this.hasWater && this.isBrewing)
            {
                this.indicatorDevice.On();
                this.isBrewing = false;
            }
            else
            {
                // Do nothing 
            }
        }
    }
}
