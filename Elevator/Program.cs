using System;
using System.Collections.Generic;

namespace ElevatorSimulation
{
    class Program
    {
        /// <summary>
        /// The application entry point.
        /// </summary>
        static async Task Main(string[] args)
        {
            // Initialize elevators (2 elevators with a capacity of 5 each)
            List<Elevator> elevators = new List<Elevator>
            {
                new Elevator(5),
                new Elevator(5)
            };

            // Create the ElevatorController
            ElevatorController controller = new ElevatorController(elevators);

            // Create and run the console UI
            ElevatorUI ui = new ElevatorUI(controller, elevators);
            await ui.RunAsync();
        }
    }
}