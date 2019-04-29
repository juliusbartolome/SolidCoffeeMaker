using SolidCoffeeMaker.CoffeeMakerStatuses;

namespace SolidCoffeeMaker
{
    public interface ICoffeeMaker
    {
        BoilerSensorStatus GetBoilerSensorStatus();
        WarmerPlateStatus GetWarmerPlateStatus();
        BrewButtonStatus GetBrewButtonStatus();
    }
}
