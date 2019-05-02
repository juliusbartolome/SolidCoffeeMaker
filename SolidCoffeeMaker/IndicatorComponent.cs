namespace SolidCoffeeMaker
{
    public class IndicatorComponent : BaseCoffeeMakerComponent
    {
        private readonly IOnOffDevice indicatorDevice;

        public IndicatorComponent(IOnOffDevice indicatorDevice) => this.indicatorDevice = indicatorDevice;

        public override void FinishBrewing() => this.indicatorDevice.On();

        public override void StartBrewing() => this.indicatorDevice.Off();
    }
}
