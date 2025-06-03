# Ledger Balance API

A minimal ASP.NET Core 6 API to compute account ledger balances based on daily transactions.

## Project Overview
This API calculates daily and closing balances for an account based on a list of credit and debit transactions. It is designed for simplicity and can be used as a backend service for financial applications or as a coding reference for ledger calculations.

## Features
- Accepts a list of transactions (credit/debit) with dates and amounts
- Validates transaction data (date format, amount, type)
- Calculates daily balances and closing balance
- Returns a summary including daily balances for the requested period

## API Endpoint
### POST `/api/ledger/balance`

**Request Body Example:**
```json
{
  "accountId": "12345",
  "transactions": [
    { "date": "2025-06-01", "type": "Credit", "amount": 100 },
    { "date": "2025-06-02", "type": "Debit", "amount": 50 }
  ]
}
```

**Response Example:**
```json
{
  "accountId": "12345",
  "startDate": "2025-06-01T00:00:00",
  "endDate": "2025-06-02T00:00:00",
  "openingBalance": 0,
  "closingBalance": 50,
  "dailyBalances": [
    { "date": "2025-06-01T00:00:00", "balanceAtEndOfDay": 100 },
    { "date": "2025-06-02T00:00:00", "balanceAtEndOfDay": 50 }
  ]
}
```

## Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022 or VS Code (optional)

## How to Run

1. Clone the repository or download the source code.
2. Open the solution in Visual Studio, or use the command line:
   ```sh
   dotnet run
   ```
3. The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.
4. Test the API using Postman, CURL, or any HTTP client.

## Testing
- Test manually using the `/api/ledger/balance` endpoint.
- Unit tests can be added using xUnit or your preferred testing framework.

## Project Structure
- `Controllers/` - API controllers
- `Models/` - Data transfer objects (DTOs)
- `Services/` - Business logic (ledger calculation)
- `Program.cs` - Application entry point

## Future Improvements
- Add automated unit and integration tests
- Support for initial opening balance
- Add authentication/authorization
- Docker support for containerized deployment
- API documentation with Swagger