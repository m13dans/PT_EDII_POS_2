using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.Application.Transactions;

public class PostTransactionCommand
{
    public required int ItemId { get; set; }
    public required int JumlahItem { get; set; }
}