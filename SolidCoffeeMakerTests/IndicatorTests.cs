using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class IndicatorTests
    {
        private readonly Mock<IOnOffDevice> indicatorDeviceMock;
        private readonly Indicator sut;

        public IndicatorTests()
        {
            this.indicatorDeviceMock = new Mock<IOnOffDevice>();
            this.sut = new Indicator(this.indicatorDeviceMock.Object);
        }

        [Fact(DisplayName = "When coffee maker is brewing and boiler's water becomes empty, the indicator light should turn on.")]
        public void OnNext_WhenBrewingAndBoilerEmpty_ShouldTurnOnIndicator()
        {
            this.sut.OnNext(BoilerSensorStatus.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonStatus.IsPushed);
            this.sut.OnNext(BoilerSensorStatus.BoilerEmpty);

            this.indicatorDeviceMock.Verify(i => i.On(), Times.Once);
        }

        [Fact(DisplayName = "When indicator is turned on and a new brewing cycle starts, indicator light should turn off.")]
        public void OnNext_WhenIndicatorIsOnAndBrewingCycleStartsAgain_ShouldTurnOffIndicator()
        {
            // First Brewing Cycle
            this.sut.OnNext(BoilerSensorStatus.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonStatus.IsPushed);
            this.sut.OnNext(BoilerSensorStatus.BoilerEmpty);
            this.indicatorDeviceMock.Setup(i => i.IsOn()).Returns(true);
            // Second Brewing Cycle
            this.sut.OnNext(BoilerSensorStatus.BoilerNotEmpty);
            this.sut.OnNext(BrewButtonStatus.IsPushed);

            this.indicatorDeviceMock.Verify(i => i.Off(), Times.Once);
        }
    }
}
