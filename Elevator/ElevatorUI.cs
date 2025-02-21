using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevatorSimulation
{
    /// <summary>
    /// Handles all console interactions and user interface for the elevator simulation.
    /// </summary>
    public class ElevatorUI
    {
        private const int MinFloor = 0;
        private const int MaxFloor = 10;
        private readonly ElevatorController controller;
        private readonly List<Elevator> elevators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorUI"/> class.
        /// </summary>
        /// <param name="controller">The elevator controller handling requests.</param>
        /// <param name="elevators">The list of elevators.</param>
        public ElevatorUI(ElevatorController controller, List<Elevator> elevators)
        {
            this.controller = controller;
            this.elevators = elevators;
        }

        /// <summary>
        /// Runs the interactive console interface.
        /// </summary>
        public async Task RunAsync()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Elevator Simulation ===");
                Console.WriteLine("1. Request Elevator");
                Console.WriteLine("2. Show Elevator Statuses");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RequestElevatorAsync();
                        break;
                    case "2":
                        ShowElevatorStatuses();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles requesting an elevator for a specified floor.
        /// </summary>
        private async Task RequestElevatorAsync()
        {
            Console.Write($"Enter the floor number to request an elevator (between {MinFloor} and {MaxFloor}): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int floor))
            {
                if (floor < MinFloor || floor > MaxFloor)
                {
                    Console.WriteLine($"Error: Floor must be between {MinFloor} and {MaxFloor}. Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    controller.AddRequest(floor);
                    Console.WriteLine($"Requesting elevator for floor {floor}...");
                    await controller.ProcessNextRequestAsync();
                    Console.WriteLine("Request processed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while processing the request: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid floor number. Please enter a valid integer.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the current status of all elevators.
        /// </summary>
        private void ShowElevatorStatuses()
        {
            Console.WriteLine("Elevator statuses:");
            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator at floor {elevator.CurrentFloor}, Direction: {elevator.Direction}, Passengers: {elevator.PassengerCount}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
