using System;
using System.Collections.Generic;
using System.Text;

namespace SolidCoffeeMaker
{
    public interface ICoffeeMaker
    {
        BoilerSensorStatus GetBoilerSensorStatus();
        WarmerPlateStatus GetWarmerPlateStatus();
        BrewButtonStatus GetBrewButtonStatus();
    }
}
