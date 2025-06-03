namespace LedgerBalanceApi.Models;

public class LedgerRequestDto
{
    public Guid AccountId { get; set; }
    public List<TransactionDto> Transactions { get; set; } = new();
}