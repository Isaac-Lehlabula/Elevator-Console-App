using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorSimulation;
using System.Collections.Generic;

namespace ElevatorSimulation.Tests
{
    [TestClass]
    public class ElevatorControllerTests
    {
        [TestMethod]
        public async Task ProcessNextRequestAsync_DispatchesNearestElevator()
        {
            // Arrange
            var elevator1 = new Elevator(5);
            var elevator2 = new Elevator(5);
            // Both elevators start at floor 0
            var controller = new ElevatorController(new List<Elevator> { elevator1, elevator2 });
            int targetFloor = 4;

            // Act
            controller.AddRequest(targetFloor);
            await controller.ProcessNextRequestAsync();

            // Assert: Since both start at 0, either elevator could be dispatched.
            bool reached = (elevator1.CurrentFloor == targetFloor) || (elevator2.CurrentFloor == targetFloor);
            Assert.IsTrue(reached, "One of the elevators should have moved to the requested floor.");
        }

        [TestMethod]
        public async Task FindNearestElevator_ReturnsClosestElevator()
        {
            // Arrange
            var elevator1 = new Elevator(5);
            var elevator2 = new Elevator(5);

            // Manually move elevators to simulate different positions.
            await elevator1.MoveToAsync(1);
            await elevator2.MoveToAsync(5);

            var controller = new ElevatorController(new List<Elevator> { elevator1, elevator2 });
            int requestedFloor = 2;

            // Act
            controller.AddRequest(requestedFloor);
            await controller.ProcessNextRequestAsync();

            // Assert: Elevator1 (closer to floor 2) should be dispatched.
            Assert.AreEqual(requestedFloor, elevator1.CurrentFloor, "Elevator1 should be dispatched as it is closer to the requested floor.");
        }
    }
}
