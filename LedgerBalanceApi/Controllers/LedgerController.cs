using LedgerBalanceApi.Models;
using LedgerBalanceApi.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/ledger/balance", ([FromBody] LedgerRequestDto request) =>
{
    var service = new LedgerService();
    var result = service.CalculateBalance(request);
    return Results.Ok(result);
});

app.Run();