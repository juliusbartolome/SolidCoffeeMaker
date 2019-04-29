namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterRefilledState : ICoffeeMakerStatus
    {
        public ICoffeeMakerStatus EmptyBoilerWater() => new BoilerWaterEmptyState();

        public ICoffeeMakerStatus FinishBrewing() => this;

        public ICoffeeMakerStatus InterruptBrewing() => this;

        public ICoffeeMakerStatus RefillBoilerWater() => this;

        public ICoffeeMakerStatus StartBrewing() => new CoffeeMakerBrewingState();
    }
}