using ErrorOr;
using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.Application.Items;

public interface IItemRepository
{
  public Task<List<Item>> GetItems();
  public Task<ErrorOr<Item>> CreateItem(ItemDTO item);
  public Task<ErrorOr<Item>> UpdateItem(int id, ItemDTO item);
  public Task<ErrorOr<Item>> DeleteItem(int id);

}
