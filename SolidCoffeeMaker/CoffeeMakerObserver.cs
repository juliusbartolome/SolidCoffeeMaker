using SolidCoffeeMaker.CoffeeMakerStatus;
using SolidCoffeeMaker.SensorStatus;
using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker
{
    public class CoffeeMakerObserver : IObserver<BoilerSensorStatus>, IObserver<WarmerPlateStatus>, IObserver<BrewButtonStatus>
    {
        private readonly ICoffeeMaker coffeeMakerStatus;
        private readonly IReadOnlyList<ICoffeeMakerComponent> components;

        public CoffeeMakerObserver(IReadOnlyList<ICoffeeMakerComponent> components, ICoffeeMaker coffeeMakerStatus)
        {
            this.coffeeMakerStatus = coffeeMakerStatus;
            this.components = components;
        }

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(BrewButtonStatus value)
        {
            if (value == BrewButtonStatus.IsPushed)
                this.coffeeMakerStatus.StartBrewing(components);
        }

        public void OnNext(WarmerPlateStatus value)
        {
            if (value == WarmerPlateStatus.WarmerEmpty)
                this.coffeeMakerStatus.InterruptBrewing(components);
            else
                this.coffeeMakerStatus.StartBrewing(components);
        }

        public void OnNext(BoilerSensorStatus value)
        {
            if (value == BoilerSensorStatus.BoilerNotEmpty)
                this.coffeeMakerStatus.RefillBoilerWater(components);
            else
                this.coffeeMakerStatus.EmptyBoilerWater(components);
        }
    }
}
