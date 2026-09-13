namespace Accounting.Domain.Entities;

public class Account
{
    public int Id { get; set; }

    public string AccountNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int AccountTypeId { get; set; }

    public AccountType AccountType { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public ICollection<AccountBalance> Balances { get; set; } = new List<AccountBalance>();
}