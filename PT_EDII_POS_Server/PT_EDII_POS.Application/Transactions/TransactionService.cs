using ErrorOr;
using PT_EDII_POS.API.Features.Reports;
using PT_EDII_POS.Application.Items;
using PT_EDII_POS.Domain.Stocks;
using PT_EDII_POS.Domain.Transactions;

namespace PT_EDII_POS.Application.Transactions;

public class TransactionService(ITransactionRepository repository)
{
    public async Task<List<Transaction>> GetTransaction()
    {
        var result = await repository.GetTransaction();
        return result;
    }
    public async Task<List<Transaction>> GetTransaction(QueryOption query)
    {
        var result = await repository.GetTransaction(query);
        return result;
    }
    public async Task<ErrorOr<Transaction>> PostTransaction(PostTransactionCommand command)
    {
        var result = await repository.PostTransaction(command);
        return result;
    }
}
