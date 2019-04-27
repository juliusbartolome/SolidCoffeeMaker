using System;

namespace SolidCoffeeMaker
{
    public class WarmerPlate : IObserver<WarmerPlateStatus>
    {
        private readonly IOnOffDevice warmerPlateDevice;

        public WarmerPlate(IOnOffDevice warmerPlateDevice)
        {
            this.warmerPlateDevice = warmerPlateDevice;
        }

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(WarmerPlateStatus value)
        {
            if (value == WarmerPlateStatus.PotNotEmpty)
                this.warmerPlateDevice.On();
            else
                this.warmerPlateDevice.Off();
        }
    }
}
