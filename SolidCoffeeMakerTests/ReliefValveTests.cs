using Moq;
using SolidCoffeeMaker;
using System;
using Xunit;

namespace SolidCoffeeMakerTests
{
    public class ReliefValveTests
    {
        private readonly Mock<IOpenCloseDevice> reliefValveDeviceMock;
        private readonly ReliefValve sut;

        public ReliefValveTests()
        {
            this.reliefValveDeviceMock = new Mock<IOpenCloseDevice>();
            this.sut = new ReliefValve(this.reliefValveDeviceMock.Object);
        }

        [Fact(DisplayName = "On Completed should be not throw error.")]
        public void OnCompleted_ShouldNotThrowError()
        {
            this.sut.OnCompleted();
        }

        [Fact(DisplayName = "On Error should not throw not implemented exception.")]
        public void OnError_ShouldNotThrowNotImpletedException()
        {
            try
            {
                var exception = new Exception();
                this.sut.OnError(exception);
                Assert.True(true);
            }
            catch (NotImplementedException)
            {
                Assert.True(false, "NotImplementedException is thrown");
            }
        }

        [Fact(DisplayName = "When warmer plate is empty, relief valve should be open.")]
        public void OnNext_WhenWarmerPlateEmpty_ShouldOpenReliefValve()
        {
            this.sut.OnNext(WarmerPlateStatus.WarmerEmpty);

            this.reliefValveDeviceMock.Verify(rv => rv.Open(), Times.Once);
        }

        [Fact(DisplayName = "When warmer plate state is pot not empty, relief valve should be closed.")]
        public void OnNext_WhenWarmerPlateIsPotNotEmpty_ShouldCloseReliefValve()
        {
            this.sut.OnNext(WarmerPlateStatus.PotNotEmpty);
                
            this.reliefValveDeviceMock.Verify(rv => rv.Close(), Times.Exactly(2));
        }

        [Fact(DisplayName = "When warmer plate state is pot empty, relief valve should be closed.")]
        public void OnNext_WhenWarmerPlateIsPotEmpty_ShouldCloseReliefValve()
        {
            this.sut.OnNext(WarmerPlateStatus.PotEmpty);

            this.reliefValveDeviceMock.Verify(rv => rv.Close(), Times.Exactly(2));
        }
    }
}
