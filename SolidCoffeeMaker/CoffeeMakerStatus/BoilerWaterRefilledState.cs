using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterRefilledState : ICoffeeMaker
    {
        public ICoffeeMaker EmptyBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            foreach (var component in components)
                component.EmptyBoilerWater();

            return new BoilerWaterEmptyState();
        }

        public ICoffeeMaker FinishBrewing(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        public ICoffeeMaker InterruptBrewing(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        public ICoffeeMaker RefillBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        public ICoffeeMaker StartBrewing(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            foreach (var component in components)
                component.StartBrewing();

            return new CoffeeMakerBrewingState();
        }
    }
}