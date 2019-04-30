using System;

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
