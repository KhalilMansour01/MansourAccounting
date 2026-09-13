namespace Accounting.Domain.Entities;

public class Currency
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<AccountBalance> AccountBalances { get; set; } = new List<AccountBalance>();
}