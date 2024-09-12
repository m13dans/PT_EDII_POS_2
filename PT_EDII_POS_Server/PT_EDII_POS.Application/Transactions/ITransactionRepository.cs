using ErrorOr;
using PT_EDII_POS.API.Features.Reports;
using PT_EDII_POS.Domain.Transactions;

namespace PT_EDII_POS.Application.Transactions;

public interface ITransactionRepository
{
    public Task<List<Transaction>> GetTransaction();
    public Task<List<Transaction>> GetTransaction(QueryOption query);
    public Task<ErrorOr<Transaction>> PostTransaction(PostTransactionCommand command);
}
