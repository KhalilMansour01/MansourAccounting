namespace Accounting.Domain.Entities;

public class AccountBalance
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public Account Account { get; set; } = null!;

    public int CurrencyId { get; set; }

    public Currency Currency { get; set; } = null!;

    public decimal Balance { get; set; }
}