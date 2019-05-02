using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class IndicatorComponentTests: BaseCoffeeMakerComponentTests
    {
        private readonly Mock<IOnOffDevice> indicatorDeviceMock;

        public IndicatorComponentTests()
        {
            this.indicatorDeviceMock = new Mock<IOnOffDevice>();
            this.sut = new IndicatorComponent(this.indicatorDeviceMock.Object);
        }

        [Fact(DisplayName = "Finish Brewing should turn indicator device on.")]
        public void FinishBrewing_Should_TurnOn_IndicatorDevice()
        {
            this.sut.FinishBrewing();

            this.indicatorDeviceMock.Verify(i => i.On(), Times.Once);
        }

        [Fact(DisplayName = "Start Brewing should turn indicator device off.")]
        public void StartBrewing_Should_TurnOn_IndicatorDevice()
        {
            this.sut.StartBrewing();

            this.indicatorDeviceMock.Verify(i => i.Off(), Times.Once);
        }
    }
}
