using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public abstract class BaseCoffeeMakerComponentTests
    {
        protected ICoffeeMakerComponent sut;

        [Fact(DisplayName = "Start Brewing should not throw a not implemented exception")]
        public void Startrewing_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.StartBrewing();
        }

        [Fact(DisplayName = "Interrupt Brewing should not throw a not implemented exception")]
        public void InterruptBrewing_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.InterruptBrewing();
        }

        [Fact(DisplayName = "Finish Brewing should not throw a not implemented exception")]
        public void FinishBrewing_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.FinishBrewing();
        }

        [Fact(DisplayName = "Empty Boiler should not throw a not implemented exception")]
        public void EmptyBoilerWater_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.EmptyBoilerWater();
        }

        [Fact(DisplayName = "Refill Boiler Water should not throw a not implemented exception")]
        public void RefillBoilerWater_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.RefillBoilerWater();
        }
    }
}
