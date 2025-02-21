using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorSimulation;

namespace ElevatorSimulation.Tests
{
    [TestClass]
    public class FloorTests
    {
        [TestMethod]
        public void Floor_InitializesWithZeroWaitingPassengers()
        {
            // Arrange
            int floorNumber = 3;

            // Act
            var floor = new Floor(floorNumber);

            // Assert
            Assert.AreEqual(floorNumber, floor.FloorNumber);
            Assert.AreEqual(0, floor.WaitingPassengers);
        }
    }
}
