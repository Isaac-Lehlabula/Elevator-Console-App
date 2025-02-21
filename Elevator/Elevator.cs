namespace ElevatorSimulation
{
    public enum ElevatorDirection
    {
        Idle,
        Up,
        Down
    }

    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public ElevatorDirection Direction { get; private set; }
        public int PassengerCount { get; private set; }
        public int Capacity { get; private set; }
        public List<int> Route { get; private set; } = new List<int>();
        public Elevator(int capacity)
        {
            Capacity = capacity;
            CurrentFloor = 0; // Starting at the ground floor
            Direction = ElevatorDirection.Idle;
            PassengerCount = 0;
        }

        public void MoveUp()
        {
            CurrentFloor++;
            Direction = ElevatorDirection.Up;
        }

        public void MoveDown()
        {
            CurrentFloor--;
            Direction = ElevatorDirection.Down;
        }

        public void Stop()
        {
            Direction = ElevatorDirection.Idle;
        }

        public bool AddPassenger()
        {
            if (PassengerCount < Capacity)
            {
                PassengerCount++;
                return true;
            }
            return false; 
        }

        public void RemovePassenger()
        {
            if (PassengerCount > 0)
                PassengerCount--;
        }
        // Adds a stop to the route if not already present.
        public void AddStop(int floor)
        {
            if (!Route.Contains(floor))
            {
                Route.Add(floor);
            }
        }
        // Processes all stops in the route asynchronously.
        public async Task ProcessRouteAsync()
        {
            if (Route.Count == 0)
                return;

            List<int> stops;

            // Decide the order of stops based on the current floor.
            if (CurrentFloor <= Route.Min())
            {
                stops = Route.OrderBy(x => x).ToList();
                Direction = ElevatorDirection.Up;
            }
            else if (CurrentFloor >= Route.Max())
            {
                stops = Route.OrderByDescending(x => x).ToList();
                Direction = ElevatorDirection.Down;
            }
            else
            {
                // If the current floor is in between, choose the direction based on the closest stop.
                int nearest = Route.OrderBy(x => Math.Abs(x - CurrentFloor)).First();
                if (nearest > CurrentFloor)
                {
                    stops = Route.OrderBy(x => x).ToList();
                    Direction = ElevatorDirection.Up;
                }
                else
                {
                    stops = Route.OrderByDescending(x => x).ToList();
                    Direction = ElevatorDirection.Down;
                }
            }

            foreach (int stop in stops)
            {
                while (CurrentFloor != stop)
                {
                    if (CurrentFloor < stop)
                        MoveUp();
                    else if (CurrentFloor > stop)
                        MoveDown();

                    Console.WriteLine($"Elevator moving... Floor: {CurrentFloor}, Direction: {Direction}");
                    await Task.Delay(500); // Simulate travel time (adjust as needed)
                }
                Console.WriteLine($"Elevator reached floor {stop}.");
            }

            Route.Clear();
            Stop();
        }

        // Asynchronous method to simulate moving to a target floor without blocking the thread.
        public async Task MoveToAsync(int targetFloor)
        {
            Console.WriteLine($"Elevator starting from floor {CurrentFloor} to reach floor {targetFloor}.");
            while (CurrentFloor != targetFloor)
            {
                if (CurrentFloor < targetFloor)
                {
                    MoveUp();
                }
                else if (CurrentFloor > targetFloor)
                {
                    MoveDown();
                }

                Console.WriteLine($"Elevator moving... Floor: {CurrentFloor}, Direction: {Direction}");

                // Asynchronously wait for 1 second to simulate travel time.
                await Task.Delay(1000);
            }
            Stop();
            Console.WriteLine($"Elevator reached floor {CurrentFloor}.");
        }
    }
}

