namespace LedgerBalanceApi.Models;

public class TransactionDto
{
    public string Date { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } // "Credit" or "Debit"
}