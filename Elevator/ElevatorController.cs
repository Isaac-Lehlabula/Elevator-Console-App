namespace ElevatorSimulation
{
    public class ElevatorController
    {
        private List<Elevator> elevators;
        private Queue<int> requestQueue; // Queue to store floor requests

        public ElevatorController(List<Elevator> elevators)
        {
            this.elevators = elevators;
            requestQueue = new Queue<int>();
        }

        // Method to add a floor request to the queue
        public void AddRequest(int floor)
        {
            requestQueue.Enqueue(floor);
        }

        // Method to process the next request from the queue
        public void ProcessNextRequest()
        {
            if (requestQueue.Count == 0)
                return;

            int requestedFloor = requestQueue.Dequeue();
            Elevator bestElevator = FindNearestElevator(requestedFloor);

            if (bestElevator != null)
            {
                Console.WriteLine($"Dispatching elevator from floor {bestElevator.CurrentFloor} to floor {requestedFloor}");
                bestElevator.MoveTo(requestedFloor);
            }
        }

        // Finds the nearest available elevator to the requested floor
        private Elevator FindNearestElevator(int floor)
        {
            return elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).FirstOrDefault();
        }
    }
}
