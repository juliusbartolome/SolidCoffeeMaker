using System;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterRefilledState : ICoffeeMaker
    {
        public ICoffeeMaker EmptyBoilerWater() => new BoilerWaterEmptyState();

        public ICoffeeMaker FinishBrewing() => this;

        public ICoffeeMaker InterruptBrewing() => this;

        public ICoffeeMaker RefillBoilerWater() => this;

        public ICoffeeMaker StartBrewing() => new CoffeeMakerBrewingState();
    }
}