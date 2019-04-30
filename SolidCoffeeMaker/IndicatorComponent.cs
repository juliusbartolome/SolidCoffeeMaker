namespace SolidCoffeeMaker
{
    public class IndicatorComponent : ICoffeeMakerComponent
    {
        private readonly IOnOffDevice indicatorDevice;

        public IndicatorComponent(IOnOffDevice indicatorDevice)
        {
            this.indicatorDevice = indicatorDevice;
        }

        public void EmptyBoilerWater()
        {
        }

        public void FinishBrewing()
        {
            this.indicatorDevice.On();
        }

        public void InterruptBrewing()
        {
        }

        public void RefillBoilerWater()
        {
        }

        public void StartBrewing()
        {
            this.indicatorDevice.Off();
        }
    }
}
