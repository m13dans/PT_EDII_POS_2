namespace PT_EDII_POS.Application.Features.Transactions;

public class PostTransactionCommand
{
    public required int ItemId { get; set; }
    public required int JumlahItem { get; set; }
}