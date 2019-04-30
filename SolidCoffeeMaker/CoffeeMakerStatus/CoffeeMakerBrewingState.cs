using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class CoffeeMakerBrewingState : ICoffeeMaker
    {
        public ICoffeeMaker EmptyBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            foreach (var component in components)
                component.EmptyBoilerWater();

            return new BoilerWaterEmptyState();
        }

        public ICoffeeMaker FinishBrewing(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            foreach (var component in components)
                component.FinishBrewing();

            return new BoilerWaterEmptyState();
        }

        public ICoffeeMaker InterruptBrewing(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            foreach (var component in components)
                component.InterruptBrewing();

            return new BoilerWaterRefilledState();
        }

        public ICoffeeMaker RefillBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        public ICoffeeMaker StartBrewing(IReadOnlyList<ICoffeeMakerComponent> components) => this;
    }
}