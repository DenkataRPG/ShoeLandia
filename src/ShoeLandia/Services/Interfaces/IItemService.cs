using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Services.Interfaces
{
    public interface IItemService
    {
        public IEnumerable<SingleItemViewModel> All();
    }
}
