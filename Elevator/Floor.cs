﻿namespace ElevatorSimulation
{
    public class Floor
    {
        public int FloorNumber { get; }
        public int WaitingPassengers { get; set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            WaitingPassengers = 0;
        }
    }
}

