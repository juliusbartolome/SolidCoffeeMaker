namespace SolidCoffeeMaker
{
    public class ReliefValveComponent: BaseCoffeeMakerComponent
    {
        private readonly IOpenCloseDevice reliefValveDevice;

        public ReliefValveComponent(IOpenCloseDevice reliefValveDevice)
        {
            this.reliefValveDevice = reliefValveDevice;
        }

        public override void FinishBrewing() => this.reliefValveDevice.Open();

        public override void InterruptBrewing() => this.reliefValveDevice.Open();

        public override void StartBrewing() => this.reliefValveDevice.Close();
    }
}
