using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public interface IOnOffDevice
    {
        bool IsOn { get; }
        void Off();
        void On();
    }
}
