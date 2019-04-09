using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public class PressureReliefValve: OpenCloseAdapter
    {
        protected override bool IsOpen { get; set; }

        protected override void Close()
        {
        }

        protected override void Open()
        {
        }
    }
}
