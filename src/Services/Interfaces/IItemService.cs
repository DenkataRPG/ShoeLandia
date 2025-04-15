using ShoeLandia.Data.Models;
using ShoeLandia.Services.Filter;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Services.Interfaces
{
    public interface IItemService
    {
        public Task<AllItemsFilteredAndPagedServiceModel> All(AllItemsQueryModel queryModel);
        void AddNewItemInDB(ItemFormViewModel item, string userId);
        public ShoeLandia.Data.Models.Item GetById<Item>(string itemId);

        public Task EditItemAsync(ItemFormViewModel model, string itemId,
            List<KeyValuePair<string, string>> categoriesItems, string userId);

        public Task<ItemFormViewModel> GetItemForEditByIdAsync(string itemId,
            List<KeyValuePair<string, string>> categoriesItems, string userId);

        public Task DeleteAsync(string itemId, string userId);
    }
}
