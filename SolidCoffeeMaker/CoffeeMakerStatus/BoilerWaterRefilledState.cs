using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterRefilledState : BaseCoffeeMakerState, ICoffeeMaker
    {
        public BoilerWaterRefilledState(IReadOnlyList<ICoffeeMakerComponent> components)
            : base(components) { }

        public override ICoffeeMaker EmptyBoilerWater()
        {
            foreach (var component in this.Components)
                component.EmptyBoilerWater();

            return new BoilerWaterEmptyState(this.Components);
        }

        public override ICoffeeMaker StartBrewing()
        {
            foreach (var component in this.Components)
                component.StartBrewing();

            return new CoffeeMakerBrewingState(this.Components);
        }
    }
}