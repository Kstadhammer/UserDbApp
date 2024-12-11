# User Database Application

A C# application for managing user data with a clean architecture and persistent storage using JSON.

## Project Structure

- **Business**: Core business logic and services
  - Services: Contains UserService and FileService for data management
  - Interfaces: Defines contracts for services
  - Models: Data models and entities
- **Business.Test**: Unit tests for the business logic
- **UserDataBaseAppMain**: Main desktop application
  - Dialogs: User interface dialogs
  - Views: Application views
- **UserDataBaseApp.Web**: Web interface for the application

## Features

- Create, Read, Update, and Delete user records
- Persistent data storage using JSON files
- Clean separation of concerns with interface-based architecture
- Desktop and web interfaces
- Unit tests for core business logic

## Getting Started

### Prerequisites

- .NET 6.0 or later
- Visual Studio 2022 or compatible IDE

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Kstadhammer/UserDbApp.git
   ```

2. Open the solution in Visual Studio:
   ```
   UserDataBaseAppComplete.sln
   ```

3. Restore NuGet packages
4. Build the solution

### Running the Application

#### Desktop Application
1. Set `UserDataBaseAppMain` as the startup project
2. Press F5 or click "Start Debugging"

#### Web Application
1. Set `UserDataBaseApp.Web` as the startup project
2. Press F5 or click "Start Debugging"
3. Open your browser to the displayed URL (typically `https://localhost:xxxx`)

## Data Storage

User data is stored in JSON format in the following location:
```
Business/Data/[filename].json
```

The application automatically creates the necessary directories and files on first run.

## Testing

The project includes unit tests in the Business.Test project. To run the tests:

1. Open Test Explorer in Visual Studio
2. Click "Run All Tests"

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
