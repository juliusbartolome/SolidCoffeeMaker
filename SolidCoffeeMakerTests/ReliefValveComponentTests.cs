using Moq;
using SolidCoffeeMaker;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class ReliefValveComponentTests: BaseCoffeeMakerComponentTests
    {
        private readonly Mock<IOpenCloseDevice> reliefValveDeviceMock;

        public ReliefValveComponentTests()
        {
            this.reliefValveDeviceMock = new Mock<IOpenCloseDevice>();
            this.sut = new ReliefValveComponent(this.reliefValveDeviceMock.Object);
        }

        [Fact(DisplayName = "Start brewing should close the relief valve once")]
        public void StartBrewing_Should_Close_ReliefValveDevice_Once()
        {
            this.sut.StartBrewing();

            this.reliefValveDeviceMock.Verify(rv => rv.Close(), Times.Once);
        }

        [Fact(DisplayName = "Finish brewing should open the relief valve once")]
        public void FinishBrewing_Should_Open_ReliefValveDevice_Once()
        {
            this.sut.FinishBrewing();

            this.reliefValveDeviceMock.Verify(rv => rv.Open(), Times.Once);
        }

        [Fact(DisplayName = "Interrupt brewing should open the relief valve once")]
        public void InterruptBrewing_Should_Open__ReliefValve_Once()
        {
            this.sut.InterruptBrewing();

            this.reliefValveDeviceMock.Verify(rv => rv.Open(), Times.Once);
        }
    }
}
