namespace ElevatorSimulation
{
    public class ElevatorController
    {
        private List<Elevator> elevators;
        private Queue<int> requestQueue; // Queue to store floor requests
        private readonly object queueLock = new object(); // Lock object for thread-safety

        public ElevatorController(List<Elevator> elevators)
        {
            this.elevators = elevators;
            requestQueue = new Queue<int>();
        }

        // Method to add a floor request to the queue
        public void AddRequest(int floor)
        {
            lock (queueLock)
            {
                requestQueue.Enqueue(floor);
            }
        }

        // Asynchronous method to process the next request from the queue
        public async Task ProcessNextRequestAsync()
        {
            int requestedFloor;
            lock (queueLock)
            {
                if (requestQueue.Count == 0)
                    return;

                requestedFloor = requestQueue.Dequeue();
            }

            Elevator bestElevator = FindNearestElevator(requestedFloor);
            if (bestElevator != null)
            {
                bestElevator.AddStop(requestedFloor);
                // If the elevator is idle, start processing its route.
                if (bestElevator.Direction == ElevatorDirection.Idle)
                {
                    await bestElevator.ProcessRouteAsync();
                }
                else
                {
                    Console.WriteLine($"Added stop {requestedFloor} to elevator's route.");
                }
            }
        }

        // Finds the nearest available elevator to the requested floor
        private Elevator FindNearestElevator(int floor)
        {
            return elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).FirstOrDefault();
        }
    }
}
