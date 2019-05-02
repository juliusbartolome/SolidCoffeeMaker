using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterEmptyState : BaseCoffeeMakerState, ICoffeeMaker
    {
        public BoilerWaterEmptyState(IReadOnlyList<ICoffeeMakerComponent> components)
            : base(components) { }

        public override ICoffeeMaker RefillBoilerWater()
        {
            foreach (var component in this.Components)
                component.RefillBoilerWater();

            return new BoilerWaterRefilledState(this.Components);
        }
    }
}
