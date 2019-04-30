using System;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterEmptyState : ICoffeeMaker
    {
        public ICoffeeMaker FinishBrewing() => this;

        public ICoffeeMaker InterruptBrewing() => this;

        public ICoffeeMaker RefillBoilerWater() => new BoilerWaterRefilledState();

        public ICoffeeMaker StartBrewing() => this;

        ICoffeeMaker ICoffeeMaker.EmptyBoilerWater() => this;
    }
}
