namespace SolidCoffeeMaker.CoffeeMakerStatus
{
    public class BoilerWaterEmptyState : ICoffeeMakerStatus
    {
        public ICoffeeMakerStatus FinishBrewing() => this;

        public ICoffeeMakerStatus InterruptBrewing() => this;

        public ICoffeeMakerStatus RefillBoilerWater() => new BoilerWaterRefilledState();

        public ICoffeeMakerStatus StartBrewing() => this;

        ICoffeeMakerStatus ICoffeeMakerStatus.EmptyBoilerWater() => this;
    }
}
