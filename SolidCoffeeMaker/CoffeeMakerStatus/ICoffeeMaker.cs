using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public interface ICoffeeMaker
    {
        ICoffeeMaker StartBrewing(IReadOnlyList<ICoffeeMakerComponent> components);
        ICoffeeMaker InterruptBrewing(IReadOnlyList<ICoffeeMakerComponent> components);
        ICoffeeMaker FinishBrewing(IReadOnlyList<ICoffeeMakerComponent> components);
        ICoffeeMaker RefillBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components);
        ICoffeeMaker EmptyBoilerWater(IReadOnlyList<ICoffeeMakerComponent> components);
    }
}
