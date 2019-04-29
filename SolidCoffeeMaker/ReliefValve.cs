using System;

namespace SolidCoffeeMaker
{
    public class ReliefValve: IObserver<WarmerPlateStatus>
    {
        private IOpenCloseDevice reliefValveDevice;
        private bool isBrewing;
        private bool hasWater;

        public ReliefValve(IOpenCloseDevice reliefValveDevice)
        {
            this.reliefValveDevice = reliefValveDevice;
        }

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(WarmerPlateStatus value)
        {
            if (value == WarmerPlateStatus.WarmerEmpty)
                this.reliefValveDevice.Open();
            else
                this.reliefValveDevice.Close();
        }
    }
}
