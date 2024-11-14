# SapiensData.API

Welcome to **SapiensData API**! This RESTful API is designed to support the **SapiensData** project, providing backend services for personal accounting, receipt scanning, analysis, and management. Built with ASP.NET Core, it supports functionalities for CRUD operations, database management, and secure data processing.

## 🚀 Features

- **CRUD Operations** for handling personal and financial data, receipts, and user management.
- **Entity Framework Core** for efficient data access and management.
- **SQL Server** integration for reliable, scalable storage.
- **Swagger UI** for interactive API documentation and testing.
- **Clean and Modular Architecture** optimized for ease of development and scalability.

## 🛠️ Getting Started

Follow these steps to set up and run the project on your local machine for development and testing.

### Prerequisites

Please ensure you have the following installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the .NET Core cross-platform development workload.
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or LocalDB for local development.
- [Git](https://git-scm.com/)

### 🔧 Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://gitlab.com/yourusername/SapiensData.API.git
   cd SapiensData.API
   ```

2. **Open the Project in Visual Studio**:
   - Navigate to the `SapiensData.API` folder and open `SapiensData.API.sln`.

3. **Install NuGet Packages**:
   - Open the **NuGet Package Manager Console** and run:

   ```bash
   Install-Package Microsoft.EntityFrameworkCore.SqlServer
   Install-Package Microsoft.EntityFrameworkCore.Tools
   ```

4. **Configure the Database Connection**:
   - Update the connection string in `appsettings.json` to match your local SQL Server or LocalDB configuration.

5. **Apply Migrations and Update the Database**:
   - Run the following commands in the **NuGet Package Manager Console**:

   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```

6. **Run the Application**:
   - Press `F5` or click the **Run** button in Visual Studio. The API will run on `https://localhost:5001` (or a different port if configured).

### 🧪 Testing

- **Swagger UI** provides an interactive interface to test each API endpoint.
- Use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) for additional testing.

### 🚀 Deployment

To deploy the API to a server or cloud service:

1. Publish the project from Visual Studio.
2. Configure the target environment's connection string in `appsettings.Production.json`.
3. Deploy to your chosen cloud provider or server.

## Commands

```bash
# Update Database Command
## If you're using Entity Framework Core:
EntityFrameworkCore\Update-Database 
## or 
dotnet ef database update
```
