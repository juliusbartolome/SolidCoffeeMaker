using SolidCoffeeMaker.CoffeeMakerStatus;
using SolidCoffeeMaker.SensorStatus;
using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker
{
    public class CoffeeMakerObserver : IObserver<BoilerSensorStatus>, IObserver<WarmerPlateStatus>, IObserver<BrewButtonStatus>
    {
        private readonly ICoffeeMaker coffeeMakerStatus;

        public CoffeeMakerObserver(ICoffeeMaker coffeeMakerStatus) => this.coffeeMakerStatus = coffeeMakerStatus;

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(BrewButtonStatus value)
        {
            if (value == BrewButtonStatus.IsPushed)
                this.coffeeMakerStatus.StartBrewing();
        }

        public void OnNext(WarmerPlateStatus value)
        {
            if (value == WarmerPlateStatus.WarmerEmpty)
                this.coffeeMakerStatus.InterruptBrewing();
            else
                this.coffeeMakerStatus.StartBrewing();
        }

        public void OnNext(BoilerSensorStatus value)
        {
            if (value == BoilerSensorStatus.BoilerNotEmpty)
                this.coffeeMakerStatus.RefillBoilerWater();
            else
                this.coffeeMakerStatus.EmptyBoilerWater();
        }
    }
}
