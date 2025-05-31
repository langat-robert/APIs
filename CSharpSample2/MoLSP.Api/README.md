# MoLSP.Api

A .NET 8 Web API for the Ministry of Labour and Social Protection (MoLSP), providing secure endpoints for authentication and lookup group management.

## Table of Contents
- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Logging](#logging)
- [Contributing](#contributing)
- [License](#license)

---

## Features
- JWT-based authentication
- Lookup group management via SQL Server stored procedures
- Swagger/OpenAPI documentation
- Configurable logging

## Project Structure
```
MoLSP.Api/
├── Controllers/
│   ├── AuthController.cs
│   └── LookupGroupController.cs
├── Models/
│   ├── LoginModel.cs
│   └── LookupGroup.cs
├── Services/
│   └── LookupGroupService.cs
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── MoLSP.Api.csproj
└── ...
```

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (local or remote)
- (Optional) Visual Studio Code with C# extension

### Setup
1. Clone the repository and navigate to the `MoLSP.Api` folder.
2. Restore dependencies:
   ```pwsh
   dotnet restore
   ```
3. Build the project:
   ```pwsh
   dotnet build
   ```
4. Update `appsettings.json` with your SQL Server connection string and JWT settings.
5. Run the API:
   ```pwsh
   dotnet run --project MoLSP.Api.csproj
   ```
6. Open Swagger UI at the URL shown in the console (e.g., http://localhost:5149/swagger).

## Configuration

Edit `appsettings.json` as needed:
```json
{
  "ConnectionStrings": {
    "MoLSPConnection": "Server=localhost;Database=MoLSP;Trusted_Connection=True;..."
  },
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtTokenDontShare",
    "Issuer": "MoLSPAuthIssuer"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
- **MoLSPConnection**: Update for your SQL Server instance.
- **Jwt:Key**: Use a secure, random value in production.
- **Jwt:Issuer**: Set as appropriate for your deployment.

## API Endpoints

### Authentication
- `POST /api/auth/login` — Obtain JWT token
  - Request body: `{ "username": "admin", "password": "password" }`
  - Response: `{ "token": "<jwt-token>" }`

### Lookup Group
- `POST /api/lookupgroup` — Add or edit a lookup group (requires JWT)
  - Request body: `{ "LookupGroupID": 1, "LookupGroupCode": "CODE", "LookupGroupName": "Name", "UserID": 1 }`
  - Response: `"Saved successfully."` or error

### Weather Forecast (Sample)
- `GET /weatherforecast` — Returns sample weather data

## Authentication

This API uses JWT Bearer authentication. To access protected endpoints:
1. Authenticate via `/api/auth/login` to receive a JWT token.
2. Add the token to the `Authorization` header:
   ```
   Authorization: Bearer <your-token>
   ```

## Logging

Logging is configured in `appsettings.json`. Adjust log levels as needed.

## Contributing

1. Fork the repository.
2. Create a feature branch.
3. Commit your changes.
4. Open a pull request.

## License

This project is licensed under the MIT License.

---
**Security Note:**
- Do not share your JWT secret key publicly.
- For production, use secure secrets and update all default credentials.
