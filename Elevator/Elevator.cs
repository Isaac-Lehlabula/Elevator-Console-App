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
        // Method to simulate moving to a target floor
        public void MoveTo(int targetFloor)
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

                // Display the current status of the elevator
                Console.WriteLine($"Elevator moving... Floor: {CurrentFloor}, Direction: {Direction}");

                // Pause for 1 second to simulate the elevator traveling between floors
                Thread.Sleep(1000);
            }
            Stop();
            Console.WriteLine($"Elevator reached floor {CurrentFloor}.");
        }
    }
}

