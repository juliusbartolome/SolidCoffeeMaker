namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public interface ICoffeeMakerStatus
    {
        ICoffeeMakerStatus StartBrewing();
        ICoffeeMakerStatus InterruptBrewing();
        ICoffeeMakerStatus FinishBrewing();
        ICoffeeMakerStatus RefillBoilerWater();
        ICoffeeMakerStatus EmptyBoilerWater();
    }
}
