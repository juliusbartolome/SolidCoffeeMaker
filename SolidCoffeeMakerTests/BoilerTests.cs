using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class BoilerTests
    {
        private readonly Mock<IOnOffDevice> boilerDeviceMock;
        private readonly Boiler sut;

        public BoilerTests()
        {
            this.boilerDeviceMock = new Mock<IOnOffDevice>();
            this.sut = new Boiler(this.boilerDeviceMock.Object);
        }

        [Fact(DisplayName = "When boiler has water and brew button is pushed while boiler is off, should turn on the boiler plate.")]
        public void OnNext_WhenBoilerNotEmptyAndIsBrewButtonPushed_ShouldTurnOnBoiler()
        {
            this.boilerDeviceMock.Setup(b => b.IsOn()).Returns(false);

            this.sut.OnNext(BoilerSensorStatus.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonStatus.IsPushed);

            this.boilerDeviceMock.Verify(b => b.On(), Times.Once);
        }

        [Fact(DisplayName = "When boiler has water and brew button is pushed while boiler is on should not turn on the boiler plate again.")]
        public void OnNext_WhenBoilerPlateNotEmptyAndIsBrewButtonPushed_WhileBoilerIsOn_ShouldNotTurnOnBoiler()
        {
            this.boilerDeviceMock.Setup(b => b.IsOn()).Returns(true);

            this.sut.OnNext(BoilerSensorStatus.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonStatus.IsPushed);

            this.boilerDeviceMock.Verify(b => b.On(), Times.Never);
        }

        [Fact(DisplayName = "When boiler has no water and the boiler is on, the boiler should turn off.")]
        public void OnNext_WhenBoilerEmptyAndBoilerIsOn_ShouldTurnOffBoiler()
        {
            this.boilerDeviceMock.Setup(b => b.IsOn()).Returns(true);

            this.sut.OnNext(BoilerSensorStatus.BoilerEmpty);

            this.boilerDeviceMock.Verify(b => b.Off(), Times.Once);
        }

        [Fact(DisplayName = "When boiler has no water and the brew button is pushed while boiler is off, should do nothing.")]
        public void OnNext_WhenBoilerEmptyAndBoilerIsOff_ShouldDoNothing()
        {
            this.boilerDeviceMock.Setup(b => b.IsOn()).Returns(false);

            this.sut.OnNext(BoilerSensorStatus.BoilerEmpty);
            this.sut.OnNext(BrewButtonStatus.IsPushed);

            this.boilerDeviceMock.Verify(b => b.Off(), Times.Never);
            Assert.False(this.boilerDeviceMock.Object.IsOn());
        }
    }
}
