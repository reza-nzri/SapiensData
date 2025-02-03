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
- [.NET SDK version 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or LocalDB for local development.
- [Git](https://git-scm.com/)
- For your own .ENV:
  - Sapiens API key to connect to and authorize the SapiensDataAPI subproject (identical to your `SAPIENS_API_KEY` variable from `Analytics/.env.dev`)
  - A Google Drive folder path

### 🔧 Setup Instructions

1. **Open the Project in Visual Studio**:
   - Navigate to the `SapiensDataAPI` folder and open `SapiensData.API.sln`.

2. **Set Up Environment Variables**:

Be ensure that you'r in the `./SapiensDataAPI/SapiensDataAPI` path.

```bash
cp .env.example .env
```

🛠️ **Edit `.env.dev` and set required values.**

1. **Install / Update the Database**:
   - Run the following commands in the **NuGet Package Manager Console**:

   ```bash
   Update-Database
   ```

   ```bash
   # Update Database Command
   ## If you're using Entity Framework Core:
   EntityFrameworkCore\Update-Database 
   ## or 
   dotnet ef database update
   dotnet ef database update --project SapiensDataAPI
   ```

2. **Run the Application**:
   - Press `F5` or click the **Run** button in Visual Studio. The API will run on `https://localhost:5001` (or a different port if configured).

### 🧪 Testing

- **Swagger UI** provides an interactive interface to test each API endpoint.
- Use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) for additional testing.
