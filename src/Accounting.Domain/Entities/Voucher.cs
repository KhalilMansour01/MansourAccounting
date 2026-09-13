namespace Accounting.Domain.Entities;

public class Voucher
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; } = string.Empty;

    // Default rate captured when the voucher is created.
    public decimal AppliedExchangeRate { get; set; }

    public ICollection<VoucherLine> Lines { get; set; } = new List<VoucherLine>();
}