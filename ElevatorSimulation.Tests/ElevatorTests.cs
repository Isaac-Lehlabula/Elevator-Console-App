using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorSimulation;

namespace ElevatorSimulation.Tests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void MoveUp_IncrementsCurrentFloor()
        {
            // Arrange
            var elevator = new Elevator(5);
            int initialFloor = elevator.CurrentFloor;

            // Act
            elevator.MoveUp();

            // Assert
            Assert.AreEqual(initialFloor + 1, elevator.CurrentFloor);
            Assert.AreEqual(ElevatorDirection.Up, elevator.Direction);
        }

        [TestMethod]
        public void MoveDown_DecrementsCurrentFloor()
        {
            // Arrange
            var elevator = new Elevator(5);
            // Move up twice to get to floor 2
            elevator.MoveUp();
            elevator.MoveUp();
            int currentFloor = elevator.CurrentFloor;

            // Act
            elevator.MoveDown();

            // Assert
            Assert.AreEqual(currentFloor - 1, elevator.CurrentFloor);
            Assert.AreEqual(ElevatorDirection.Down, elevator.Direction);
        }

        [TestMethod]
        public void Stop_SetsDirectionToIdle()
        {
            // Arrange
            var elevator = new Elevator(5);
            elevator.MoveUp();

            // Act
            elevator.Stop();

            // Assert
            Assert.AreEqual(ElevatorDirection.Idle, elevator.Direction);
        }

        [TestMethod]
        public void AddPassenger_RespectsCapacity()
        {
            // Arrange
            var elevator = new Elevator(2);

            // Act
            bool firstAdd = elevator.AddPassenger();
            bool secondAdd = elevator.AddPassenger();
            bool thirdAdd = elevator.AddPassenger(); // Should fail since capacity is 2

            // Assert
            Assert.IsTrue(firstAdd);
            Assert.IsTrue(secondAdd);
            Assert.IsFalse(thirdAdd);
            Assert.AreEqual(2, elevator.PassengerCount);
        }

        [TestMethod]
        public void RemovePassenger_DecrementsPassengerCount()
        {
            // Arrange
            var elevator = new Elevator(2);
            elevator.AddPassenger();
            elevator.AddPassenger();

            // Act
            elevator.RemovePassenger();

            // Assert
            Assert.AreEqual(1, elevator.PassengerCount);
        }

        [TestMethod]
        public async Task MoveToAsync_ReachesTargetFloor()
        {
            // Arrange
            var elevator = new Elevator(5);
            int targetFloor = 3;
            
            // Act
            await elevator.MoveToAsync(targetFloor);
            
            // Assert
            Assert.AreEqual(targetFloor, elevator.CurrentFloor);
            Assert.AreEqual(ElevatorDirection.Idle, elevator.Direction);
        }
    }
}
