using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterEmptyState : ICoffeeMaker
    {
        public ICoffeeMaker FinishBrewing(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        public ICoffeeMaker InterruptBrewing(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        public ICoffeeMaker RefillBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            foreach (var component in components)
                component.RefillBoilerWater();

            return new BoilerWaterRefilledState();
        }

        public ICoffeeMaker StartBrewing(IReadOnlyList<ICoffeeMakerComponent> components) => this;

        ICoffeeMaker ICoffeeMaker.EmptyBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components) => this;
    }
}
