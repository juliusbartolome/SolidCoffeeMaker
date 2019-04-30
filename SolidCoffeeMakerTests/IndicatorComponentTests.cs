using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class IndicatorComponentTests
    {
        private readonly Mock<IOnOffDevice> indicatorDeviceMock;
        private readonly IndicatorComponent sut;

        public IndicatorComponentTests()
        {
            this.indicatorDeviceMock = new Mock<IOnOffDevice>();
            this.sut = new IndicatorComponent(this.indicatorDeviceMock.Object);
        }

        [Fact(DisplayName = "Empty Boiler should not throw a not implemented exception")]
        public void EmptyBoilerWater_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.EmptyBoilerWater();
        }

        [Fact(DisplayName = "Finish Brewing should turn indicator device on.")]
        public void FinishBrewing_Should_TurnOn_IndicatorDevice()
        {
            this.sut.FinishBrewing();

            this.indicatorDeviceMock.Verify(i => i.On(), Times.Once);
        }

        [Fact(DisplayName = "Interrupt Brewing should not throw a not implemented exception")]
        public void InterruptBrewing_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.InterruptBrewing();
        }

        [Fact(DisplayName = "Refill Boiler Water should not throw a not implemented exception")]
        public void RefillBoilerWater_ShouldNot_Throw_NotImplementedException()
        {
            this.sut.RefillBoilerWater();
        }

        [Fact(DisplayName = "Start Brewing should turn indicator device off.")]
        public void StartBrewing_Should_TurnOn_IndicatorDevice()
        {
            this.sut.StartBrewing();

            this.indicatorDeviceMock.Verify(i => i.Off(), Times.Once);
        }
    }
}
