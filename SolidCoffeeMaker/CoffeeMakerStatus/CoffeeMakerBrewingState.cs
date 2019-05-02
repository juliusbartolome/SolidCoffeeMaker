using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class CoffeeMakerBrewingState : BaseCoffeeMakerState, ICoffeeMaker
    {
        public CoffeeMakerBrewingState(IReadOnlyList<ICoffeeMakerComponent> components)
            : base(components) { }

        public override ICoffeeMaker FinishBrewing()
        {
            foreach (var component in this.Components)
                component.FinishBrewing();

            return new BoilerWaterEmptyState(this.Components);
        }

        public override ICoffeeMaker InterruptBrewing()
        {
            foreach (var component in this.Components)
                component.InterruptBrewing();

            return new BoilerWaterRefilledState(this.Components);
        }
    }
}