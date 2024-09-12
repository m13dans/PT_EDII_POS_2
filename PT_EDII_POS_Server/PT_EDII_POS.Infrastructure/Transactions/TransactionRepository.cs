using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.API.Features.Reports;
using PT_EDII_POS.Application.Transactions;
using PT_EDII_POS.Domain.Transactions;
using PT_EDII_POS.Infrastructure.DataContext;

namespace PT_EDII_POS.Infrastructure.Transactions;

public class TransactionRepository(AppDbContext dbContext) : ITransactionRepository
{
    public async Task<List<Transaction>> GetTransaction()
    {
        var result = await dbContext.Transactions.ToListAsync();
        return result;
    }
    public async Task<List<Transaction>> GetTransaction(QueryOption query)
    {
        var result = dbContext.Transactions.OrderTransactionBy(query);
        return await result.ToListAsync();
    }

    public async Task<ErrorOr<Transaction>> PostTransaction(PostTransactionCommand command)
    {
        var item = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == command.ItemId);
        if (item is null)
            return Error.NotFound(code: "404", description: "Item tidak ditemukan");

        if (item.StokAwal < command.JumlahItem)
            return Error.Validation(code: "400", description: "Jumlah item yang akan dijual lebih dari stok");

        Transaction transaction = new()
        {
            ItemId = command.ItemId,
            JumlahItem = command.JumlahItem,
            Kategori = item.Kategori,
            Harga = item.Harga,
            TotalHarga = item.Harga * command.JumlahItem,
            TanggalTransaksi = DateOnly.FromDateTime(DateTime.Now)
        };
        await dbContext.Transactions.AddAsync(transaction);

        var stokUpdated = item.StokAwal - command.JumlahItem;
        item.StokAwal = stokUpdated;
        dbContext.Items.Update(item);

        await dbContext.SaveChangesAsync();
        return transaction;
    }


}

public static class ProductListDtoSort
{
    public static IQueryable<Transaction> OrderTransactionBy(
        this IQueryable<Transaction> transactions,
        QueryOption query) =>

        query.OrderOption switch
        {
            OrderOption.TanggalTransaksi => transactions.OrderByDescending(x => x.TanggalTransaksi),
            OrderOption.TotalTransaksi => transactions.OrderByDescending(x => x.TotalHarga),
            _ => transactions.OrderByDescending(x => x.Id)
        };
}
