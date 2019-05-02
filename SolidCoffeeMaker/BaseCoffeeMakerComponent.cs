using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public abstract class BaseCoffeeMakerComponent : ICoffeeMakerComponent
    {
        public virtual void EmptyBoilerWater() { }

        public virtual void FinishBrewing() { }

        public virtual void InterruptBrewing() { }

        public virtual void RefillBoilerWater() { }

        public virtual void StartBrewing() { }
    }
}
