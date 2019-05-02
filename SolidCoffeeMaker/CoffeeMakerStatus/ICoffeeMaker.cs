using System;
using System.Collections.Generic;

namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public interface ICoffeeMaker
    {
        ICoffeeMaker StartBrewing();
        ICoffeeMaker InterruptBrewing();
        ICoffeeMaker FinishBrewing();
        ICoffeeMaker RefillBoilerWater();
        ICoffeeMaker EmptyBoilerWater();
    }
}
