using System;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class CoffeeMakerBrewingState : ICoffeeMaker
    {
        public ICoffeeMaker EmptyBoilerWater() => new BoilerWaterEmptyState();

        public ICoffeeMaker FinishBrewing() => new BoilerWaterEmptyState();

        public ICoffeeMaker InterruptBrewing() => new BoilerWaterRefilledState();

        public ICoffeeMaker RefillBoilerWater() => this;

        public ICoffeeMaker StartBrewing() => this;
    }
}