namespace Accounting.Domain.Entities;

public class AccountType
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}