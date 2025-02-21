using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorSimulation;
using System.Collections.Generic;

namespace ElevatorSimulation.Tests
{
    [TestClass]
    public class ElevatorControllerTests
    {
        [TestMethod]
        public void ProcessNextRequest_DispatchesNearestElevator()
        {
            // Arrange
            // Create two elevators starting at floor 0.
            var elevator1 = new Elevator(5);
            var elevator2 = new Elevator(5);
            var controller = new ElevatorController(new List<Elevator> { elevator1, elevator2 });
            int targetFloor = 4;

            // Act
            controller.AddRequest(targetFloor);
            controller.ProcessNextRequest();

            // Assert
            // With both starting at 0, either elevator could be chosen.
            // Check that at least one elevator reached the target floor.
            bool reached = (elevator1.CurrentFloor == targetFloor) || (elevator2.CurrentFloor == targetFloor);
            Assert.IsTrue(reached, "One of the elevators should have moved to the requested floor.");
        }

        [TestMethod]
        public void FindNearestElevator_ReturnsClosestElevator()
        {
            // Arrange
            // Elevator1 at floor 1, Elevator2 at floor 5.
            var elevator1 = new Elevator(5);
            var elevator2 = new Elevator(5);
            elevator1.MoveTo(1);
            elevator2.MoveTo(5);

            var controller = new ElevatorController(new List<Elevator> { elevator1, elevator2 });
            int requestedFloor = 2;

            // Act
            // Add a request and process it. The nearest (elevator1) should be dispatched.
            controller.AddRequest(requestedFloor);
            controller.ProcessNextRequest();

            // Assert
            Assert.AreEqual(requestedFloor, elevator1.CurrentFloor, "Elevator1 should be dispatched as it is closer.");
        }
    }
}
