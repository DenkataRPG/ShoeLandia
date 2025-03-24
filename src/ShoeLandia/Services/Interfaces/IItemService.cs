using ShoeLandia.Data.Models;
using ShoeLandia.Services.Filter;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Services.Interfaces
{
    public interface IItemService
    {
        public Task<AllItemsFilteredAndPagedServiceModel> All(AllItemsQueryModel queryModel);
        void AddNewItemInDB(ItemFormViewModel item);
        public ShoeLandia.Data.Models.Item GetById<Item>(string itemId);
    }
}
