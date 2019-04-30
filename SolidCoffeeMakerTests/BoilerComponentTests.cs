using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class BoilerComponentTests
    {
        private readonly Mock<IOnOffDevice> boilerDevice;
        private readonly BoilerComponent sut;

        public BoilerComponentTests()
        {
            this.boilerDevice = new Mock<IOnOffDevice>();
            this.sut = new BoilerComponent(this.boilerDevice.Object);
        }

        [Fact(DisplayName = "Empty Boiler Water should turn off boiler device")]
        public void EmptyBoilerWater_ShouldNotThrowNotImplementedException()
        {
            this.sut.EmptyBoilerWater();

            this.boilerDevice.Verify(b => b.Off(), Times.Once);
        }

        [Fact(DisplayName = "Finish Brewing should not throw a not implemented exception")]
        public void FinishBrewing_ShouldNotThrowNotImplementedException()
        {
            this.sut.FinishBrewing();
        }

        [Fact(DisplayName = "Interrupt Brewing should not throw a not implemented exception")]
        public void InterruptBrewing_ShouldNotThrowNotImplementedException()
        {
            this.sut.InterruptBrewing();
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
