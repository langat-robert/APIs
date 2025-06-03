namespace LedgerBalanceApi.Models;

public class DailyBalance
{
    public DateTime Date { get; set; }
    public decimal BalanceAtEndOfDay { get; set; }
}

public class LedgerResponseDto
{
    public Guid AccountId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal OpeningBalance { get; set; } = 0;
    public decimal ClosingBalance { get; set; }
    public List<DailyBalance> DailyBalances { get; set; } = new();
}