# Elevator Simulation

A C# console application that simulates the movement of elevators in a multi-floor building. The goal of this project is to efficiently transport passengers using object-oriented principles, asynchronous programming, and a robust dispatch algorithm.

## Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [Usage](#usage)
- [Testing](#testing)
- [Continuous Integration](#continuous-integration)

## Features

- **Real-Time Elevator Simulation:**  
  Simulates multiple elevators moving between floors with asynchronous operations.

- **Enhanced Dispatch Logic:**  
  Elevators can handle multiple requests along their route by dynamically adding stops.

- **User-Friendly Console Interface:**  
  A menu-driven interface that allows users to request elevators and view current statuses.

- **Robust Error Handling and Input Validation:**  
  Ensures that user inputs are within valid ranges and gracefully handles errors.

- **Unit Tested:**  
  Comprehensive unit tests verify that core functionalities work as expected.

- **Continuous Integration:**  
  GitHub Actions is configured to automatically build and test the project on every push.

## Project Structure

```plaintext
ElevatorSimulation/
├── ElevatorSimulation.sln      # The solution file
├── ElevatorSimulation/         # Main project folder
│   ├── Program.cs              # Application entry point
│   ├── Elevator.cs             # Elevator class and movement logic
│   ├── ElevatorController.cs   # Manages elevator dispatching and request queue
│   ├── ElevatorUI.cs           # Decoupled console interface logic
│   └── ...                     # Other supporting classes
└── ElevatorSimulation.Tests/   # Unit test project
    ├── ElevatorTests.cs        # Tests for Elevator functionality
    ├── ElevatorControllerTests.cs  # Tests for ElevatorController logic
    └── FloorTests.cs           # Tests for Floor functionality (if applicable)
```

## Installation

1. **Clone the Repository:**
   ```
   git clone https://github.com/Isaac-Lehlabula/ElevatorSimulation.git
   cd ElevatorSimulation
Open the Solution: Open the solution file (ElevatorSimulation.sln) in Visual Studio 2022 or later.

Restore NuGet Packages: Visual Studio will automatically restore NuGet packages (e.g., MSTest) when you build the solution.
Alternatively, run:
   ```
  dotnet restore
```
## Usage
1. Build and Run the Application:

In Visual Studio, press F5 to build and run the application.
Or, use the command line:
```
dotnet run --project ElevatorSimulation
```
2. Interact with the Console Interface:

- The console displays a menu with options:
- - Request an Elevator
- - Show Elevator Statuses
- - Exit
- Follow the on-screen prompts to request an elevator by entering a floor number, and view real-time status updates.
## Testing
1. Run Unit Tests:

- Open Test > Test Explorer in Visual Studio and click Run All.
- Or run via command line:
```
dotnet test
```
2. Test Coverage:

- The unit tests cover elevator movement, dispatch logic, route processing, and error handling scenarios.
## Continuous Integration
This project uses GitHub Actions to ensure continuous integration. The workflow is defined in .github/workflows/dotnet.yml and will automatically:

- Restore dependencies
- Build the solution
- Run the unit tests on every push or pull request to the master branch
