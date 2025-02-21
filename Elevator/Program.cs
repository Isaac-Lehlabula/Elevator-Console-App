using System;
using System.Collections.Generic;

namespace ElevatorSimulation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize a list of elevators (for example: 2 elevators with a capacity of 5 each)
            List<Elevator> elevators = new List<Elevator>
            {
                new Elevator(5),
                new Elevator(5)
            };

            // Create the ElevatorController using the list of elevators
            ElevatorController controller = new ElevatorController(elevators);

            Console.WriteLine("Elevator Simulation Started");
            Console.WriteLine("Enter a floor number to request an elevator, or type 'exit' to quit.");

            while (true)
            {
                Console.Write("Enter floor: ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (int.TryParse(input, out int floor))
                {
                    // Add the floor request to the controller's queue
                    controller.AddRequest(floor);

                    // Process the next request in the queue
                    await controller.ProcessNextRequestAsync();

                    // Display the current status of each elevator
                    Console.WriteLine("Elevator statuses:");
                    foreach (var elevator in elevators)
                    {
                        Console.WriteLine($"Elevator at floor {elevator.CurrentFloor}, Direction: {elevator.Direction}, Passengers: {elevator.PassengerCount}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid floor number.");
                }
            }
        }
    }
}
