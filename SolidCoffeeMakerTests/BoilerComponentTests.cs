using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class BoilerComponentTests: BaseCoffeeMakerComponentTests
    {
        private readonly Mock<IOnOffDevice> boilerDevice;

        public BoilerComponentTests()
        {
            this.boilerDevice = new Mock<IOnOffDevice>();
            this.sut = new BoilerComponent(this.boilerDevice.Object);
        }

        [Fact(DisplayName = "Empty Boiler Water should turn off boiler device once")]
        public void EmptyBoilerWater_Should_TurnOff_BoilerDevice_Once()
        {
            this.sut.EmptyBoilerWater();

            this.boilerDevice.Verify(b => b.Off(), Times.Once);
        }

        [Fact(DisplayName = "Finish Brewing should turn off boiler device once")]
        public void FinishBrewing_Should_TurnOff_BoilerDevice_Once()
        {
            this.sut.FinishBrewing();

            this.boilerDevice.Verify(b => b.Off(), Times.Once);
        }

        [Fact(DisplayName = "Interrupt Brewing should turn off boiler device once")]
        public void InterruptBrewing_Should_TurnOff_BoilerDevice_Once()
        {
            this.sut.InterruptBrewing();

            this.boilerDevice.Verify(b => b.Off(), Times.Once);
        }

        [Fact(DisplayName = "Refill Boiler Water should not throw a not implemented exception")]
        public void RefillBoilerWater_ShouldNotThrowNotImplementedException()
        {
            this.sut.RefillBoilerWater();
        }

        [Fact(DisplayName = "Start Brewing should turn on boiler device")]
        public void StartBrewing_ShouldTurnOnBoilerDevice()
        {
            this.sut.StartBrewing();

            this.boilerDevice.Verify(b => b.On(), Times.Once);
        }
    }
}
