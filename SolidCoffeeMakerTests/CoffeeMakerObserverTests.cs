using Moq;
using SolidCoffeeMaker;
using SolidCoffeeMaker.CoffeeMakerStatus;
using SolidCoffeeMaker.SensorStatus;
using System;
using System.Collections.Generic;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class CoffeeMakerObserverTests
    {
        private readonly Mock<ICoffeeMaker> coffeeMakerMock;
        private List<ICoffeeMakerComponent> components;
        private readonly CoffeeMakerObserver sut;

        public CoffeeMakerObserverTests()
        {
            this.coffeeMakerMock = new Mock<ICoffeeMaker>();
            this.components = new List<ICoffeeMakerComponent>();
            this.sut = new CoffeeMakerObserver(this.components, this.coffeeMakerMock.Object);
        }

        [Fact(DisplayName = "OnCompleted should not throw not implemented exception")]
        public void OnCompleted_ShouldNotThrowNotImplementedException()
        {
            this.sut.OnCompleted();
            Assert.True(true);
        }

        [Fact(DisplayName = "OnError should not throw not implemented exception")]
        public void OnError_ShouldNotThrowNotImplementedException()
        {
            try
            {
                var exception = new Exception();
                this.sut.OnError(exception);
            }
            catch (NotImplementedException)
            {
                Assert.True(false, "Returned a NotImplementedException");
            }
        }

        [Fact(DisplayName = "When boiler sensor status is boiler not empty, it should call ICoffeeMaker's RefillBoilerWater once")]
        public void OnNext_With_BoilerSensorStatus_BoilerNotEmpty_ShouldExecute_RefillBoilerWater_Once()
        {
            this.sut.OnNext(BoilerSensorStatus.BoilerNotEmpty);

            this.coffeeMakerMock.Verify(cm => cm.RefillBoilerWater(this.components), Times.Once);
        }

        [Fact(DisplayName = "When boiler sensor status is boiler empty, it should call ICoffeeMaker's EmptyBoilerWater once")]
        public void OnNext_With_BoilerSensorStatus_BoilerEmpty_ShouldExecute_EmptyBoilerWater_Once()
        {
            this.sut.OnNext(BoilerSensorStatus.BoilerEmpty);

            this.coffeeMakerMock.Verify(cm => cm.EmptyBoilerWater(this.components), Times.Once);
        }

        [Fact(DisplayName = "When brew button is pressed, it should call ICoffeeMaker's StartBrewing once")]
        public void OnNext_When_BrewButton_IsPushed_ShoultExecute_StartBrewing_Once()
        {
            this.sut.OnNext(BrewButtonStatus.IsPushed);

            this.coffeeMakerMock.Verify(cm => cm.StartBrewing(this.components), Times.Once);
        }

        [Fact(DisplayName = "When warmer plate status is warmer empty, it should call ICoffeeMaker's InterruptBrewing once")]
        public void OnNext_When_WarmerPlate_WarmerEmpty_ShouldExecute_InterruptBrewing_Once()
        {
            this.sut.OnNext(WarmerPlateStatus.WarmerEmpty);

            this.coffeeMakerMock.Verify(cm => cm.InterruptBrewing(this.components), Times.Once);
        }

        [Fact(DisplayName = "When warmer plate status is pot empty, it should call ICoffeMaker's StartBrewing once")]
        public void OnNext_When_WarmerPlate_PotEmpty_ShouldExecute_StartBrewing_Once()
        {
            this.sut.OnNext(WarmerPlateStatus.PotEmpty);

            this.coffeeMakerMock.Verify(cm => cm.StartBrewing(this.components), Times.Once);
        }

        [Fact(DisplayName = "When warmer plate status is pot not empty, it should call ICoffeMaker's StartBrewing once")]
        public void OnNext_When_WarmerPlate_PotNotEmpty_ShouldExecute_StartBrewing_Once()
        {
            this.sut.OnNext(WarmerPlateStatus.PotNotEmpty);

            this.coffeeMakerMock.Verify(cm => cm.StartBrewing(this.components), Times.Once);
        }
    }
}
