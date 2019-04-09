using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public abstract class OpenCloseAdapter : IOnOffDevice
    {
        public bool IsOn => this.IsOpen;

        public void Off()
        {
            this.Close();
        }

        public void On()
        {
            this.Open();
        }

        protected abstract bool IsOpen { get; set; }
        protected abstract void Close();
        protected abstract void Open();
    }
}
