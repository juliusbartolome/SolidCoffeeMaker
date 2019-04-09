using SolidCoffeeMaker.SensorStates;

namespace SolidCoffeeMaker
{
    public interface ISensor<TState>
    {
        TState GetState();
    }
}