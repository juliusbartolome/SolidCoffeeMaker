using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class BoilerSensorObserverTests
    {
        private readonly Mock<IOnOffDevice> mockBoiler;
        private readonly BoilerObserver sut;

        public BoilerSensorObserverTests()
        {
            this.mockBoiler = new Mock<IOnOffDevice>();
            this.sut = new BoilerObserver(this.mockBoiler.Object);
        }

        [Fact(DisplayName = "When boiler has water and brew button is pushed while boiler is off, should turn on the boiler plate.")]
        public void OnNext_WhenBoilerNotEmptyAndIsBrewButtonPushed_ShouldTurnOnBoiler()
        {
            this.mockBoiler.Setup(b => b.IsOn()).Returns(false);

            this.sut.OnNext(BoilerSensorState.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonState.IsPushed);

            this.mockBoiler.Verify(b => b.TurnOn(), Times.Once);
        }

        [Fact(DisplayName = "When boiler has water and brew button is pushed while boiler is on should not turn on the boiler plate again.")]
        public void OnNext_WhenBoilerPlateNotEmptyAndIsBrewButtonPushed_WhileBoilerIsOn_ShouldNotTurnOnBoiler()
        {
            this.mockBoiler.Setup(b => b.IsOn()).Returns(true);

            this.sut.OnNext(BoilerSensorState.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonState.IsPushed);

            this.mockBoiler.Verify(b => b.TurnOn(), Times.Never);
        }

        [Fact(DisplayName = "When boiler has no water and the boiler is on, the boiler should turn off.")]
        public void OnNext_WhenBoilerEmptyAndBoilerIsOn_ShouldTurnOffBoiler()
        {
            this.mockBoiler.Setup(b => b.IsOn()).Returns(true);

            this.sut.OnNext(BoilerSensorState.BoilerEmpty);

            this.mockBoiler.Verify(b => b.TurnOff(), Times.Once);
        }

        [Fact(DisplayName = "When boiler has no water and the brew button is pushed while boiler is off, should do nothing.")]
        public void OnNext_WhenBoilerEmptyAndBoilerIsOff_ShouldDoNothing()
        {
            this.mockBoiler.Setup(b => b.IsOn()).Returns(false);

            this.sut.OnNext(BoilerSensorState.BoilerEmpty);
            this.sut.OnNext(BrewButtonState.IsPushed);

            this.mockBoiler.Verify(b => b.TurnOff(), Times.Never);
            Assert.False(this.mockBoiler.Object.IsOn());
        }
    }
}
