namespace SolidCoffeeMaker
{
    public class WarmerPlateComponent: BaseCoffeeMakerComponent
    {
        private readonly IOnOffDevice warmerPlateDevice;

        public WarmerPlateComponent(IOnOffDevice warmerPlateDevice)
        {
            this.warmerPlateDevice = warmerPlateDevice;
        }

        public override void InterruptBrewing() => this.warmerPlateDevice.Off();

        public override void StartBrewing() => this.warmerPlateDevice.On();
    }
}
