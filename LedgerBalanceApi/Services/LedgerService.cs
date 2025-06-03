using LedgerBalanceApi.Models;

namespace LedgerBalanceApi.Services;

public class LedgerService
{
    public LedgerResponseDto CalculateBalance(LedgerRequestDto request)
    {
        if (request.Transactions == null || !request.Transactions.Any())
            throw new ArgumentException("No transactions provided.");

        var parsedTxns = request.Transactions
            .Select(tx =>
            {
                if (!DateTime.TryParse(tx.Date, out var date))
                    throw new ArgumentException($"Invalid date format: {tx.Date}");

                if (tx.Amount < 0)
                    throw new ArgumentException("Amount cannot be negative");

                var isCredit = tx.Type.Equals("Credit", StringComparison.OrdinalIgnoreCase);
                var isDebit = tx.Type.Equals("Debit", StringComparison.OrdinalIgnoreCase);
                if (!isCredit && !isDebit)
                    throw new ArgumentException("Invalid transaction type");

                return new
                {
                    Date = date,
                    Amount = isCredit ? tx.Amount : -tx.Amount
                };
            })
            .ToList();

        var grouped = parsedTxns
            .GroupBy(x => x.Date.Date)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount));

        var start = grouped.Keys.Min();
        var end = grouped.Keys.Max();

        var response = new LedgerResponseDto
        {
            AccountId = request.AccountId,
            StartDate = start,
            EndDate = end,
            OpeningBalance = 0
        };

        decimal currentBalance = 0;
        for (var date = start; date <= end; date = date.AddDays(1))
        {
            if (grouped.TryGetValue(date, out var sum))
            {
                currentBalance += sum;
            }

            response.DailyBalances.Add(new DailyBalance
            {
                Date = date,
                BalanceAtEndOfDay = currentBalance
            });
        }

        response.ClosingBalance = currentBalance;
        return response;
    }
}