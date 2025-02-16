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
    }
}

