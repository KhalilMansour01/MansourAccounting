using Accounting.Domain.Enums;

namespace Accounting.Domain.Entities;

public class VoucherLine
{
    public int Id { get; set; }

    public int VoucherId { get; set; }

    public Voucher Voucher { get; set; } = null!;

    public int AccountId { get; set; }

    public Account Account { get; set; } = null!;

    public int CurrencyId { get; set; }

    public Currency Currency { get; set; } = null!;

    public TransactionSide Side { get; set; }

    public decimal Amount { get; set; }

    // If null, the voucher's AppliedExchangeRate is used.
    public decimal? AppliedExchangeRateOverride { get; set; }

    public string Description { get; set; } = string.Empty;
}