using SolidCoffeeMaker.CoffeeMakerStatus;

namespace SolidCoffeeMaker
{
    public interface ICoffeeMakerComponent
    {
        void StartBrewing();
        void InterruptBrewing();
        void FinishBrewing();
        void RefillBoilerWater();
        void EmptyBoilerWater();
    }
}