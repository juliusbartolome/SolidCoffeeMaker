using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public abstract class BaseCoffeeMakerState : ICoffeeMaker
    {
        protected IReadOnlyList<ICoffeeMakerComponent> Components { get; }

        public BaseCoffeeMakerState(IReadOnlyList<ICoffeeMakerComponent> components)
        {
            this.Components = components;
        }

        public virtual ICoffeeMaker EmptyBoilerWater() => this;

        public virtual ICoffeeMaker FinishBrewing() => this;

        public virtual ICoffeeMaker InterruptBrewing() => this;

        public virtual ICoffeeMaker RefillBoilerWater() => this;

        public virtual ICoffeeMaker StartBrewing() => this;
    }
}
