using Moq;
using SolidCoffeeMaker;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class WarmerPlateComponentTests: BaseCoffeeMakerComponentTests
    {
        private readonly Mock<IOnOffDevice> warmerPlateDevice;

        public WarmerPlateComponentTests()
        {
            this.warmerPlateDevice = new Mock<IOnOffDevice>();
            this.sut = new WarmerPlateComponent(this.warmerPlateDevice.Object);
        }

        [Fact(DisplayName = "Interrupt brewing should turn off warmer plate device once")]
        public void InterruptBrewing_Should_TurnOff_WarmerPlateDevice_Once()
        {
            this.sut.InterruptBrewing();

            this.warmerPlateDevice.Verify(wp => wp.Off(), Times.Once);
        }

        [Fact(DisplayName = "Start brewing should turn on warmer plate device once")]
        public void StartBrewing_Should_TurnOn_WarmerPlateDevice_Once()
        {
            this.sut.StartBrewing();

            this.warmerPlateDevice.Verify(wp => wp.On(), Times.Once);
        }


    }
}
