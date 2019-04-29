namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class CoffeeMakerBrewingState : ICoffeeMakerStatus
    {
        public ICoffeeMakerStatus EmptyBoilerWater() => new BoilerWaterEmptyState();

        public ICoffeeMakerStatus FinishBrewing() => new BoilerWaterEmptyState();

        public ICoffeeMakerStatus InterruptBrewing() => new BoilerWaterRefilledState();

        public ICoffeeMakerStatus RefillBoilerWater() => this;

        public ICoffeeMakerStatus StartBrewing() => this;
    }
}