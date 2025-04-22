using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Services.Filter
{
    public class AllItemsFilteredAndPagedServiceModel
    {
       public AllItemsFilteredAndPagedServiceModel()
        {
            Items = new HashSet<ItemInListViewModel>();
        }

        public int TotalItemsCount { get; set; }

        public IEnumerable<ItemInListViewModel> Items { get; set; }
    }
}
