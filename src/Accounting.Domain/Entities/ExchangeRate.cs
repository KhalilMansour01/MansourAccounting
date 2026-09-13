namespace Accounting.Domain.Entities;

public class ExchangeRate
{
    public int Id { get; set; }

    public int FromCurrencyId { get; set; }
    public Currency FromCurrency { get; set; } = null!;

    public int ToCurrencyId { get; set; }
    public Currency ToCurrency { get; set; } = null!;

    public decimal Rate { get; set; }

    public DateTime EffectiveFrom { get; set; }

    public bool IsActive { get; set; } = true;
}