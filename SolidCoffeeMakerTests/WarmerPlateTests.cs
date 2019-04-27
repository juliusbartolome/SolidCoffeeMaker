using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class WarmerPlateTests
    {
        private readonly Mock<IOnOffDevice> warmerPlateDeviceMock;
        private readonly WarmerPlate sut;

        public WarmerPlateTests()
        {
            this.warmerPlateDeviceMock = new Mock<IOnOffDevice>();
            this.sut = new WarmerPlate(this.warmerPlateDeviceMock.Object);
        }

        [Fact(DisplayName = "When warmer plate status is pot not empty, the warmer should be on.")]
        public void OnNext_WhenPotNotEmpty_ShouldTurnOnWarmerPlate()
        {
            this.sut.OnNext(WarmerPlateStatus.PotNotEmpty);

            this.warmerPlateDeviceMock.Verify(wp => wp.On(), Times.Once);
        }

        [Fact(DisplayName = "When warmer plate status is pot empty, the warmer should be off")]
        public void OnNext_WhenPotEmpty_ShouldTurnOffWarmerPlate()
        {
            this.sut.OnNext(WarmerPlateStatus.PotEmpty);

            this.warmerPlateDeviceMock.Verify(wp => wp.Off(), Times.Once);
        }

        [Fact(DisplayName = "When warmer plate status is pot empty, the warmer should be off")]
        public void OnNext_WhenWarmerEmpty_ShouldTurnOffWarmerPlate()
        {
            this.sut.OnNext(WarmerPlateStatus.WarmerEmpty);

            this.warmerPlateDeviceMock.Verify(wp => wp.Off(), Times.Once);
        }
    }
}
