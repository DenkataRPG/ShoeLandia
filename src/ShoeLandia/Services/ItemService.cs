using ShoeLandia.Data;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;

namespace ShoeLandia.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext dbContext;

        public ItemService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<SingleItemViewModel> All()
        {
            var items = this.dbContext
                .Items
                .Where(item => item.IsDeleted == false)
                .Select(item => new SingleItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Size = item.Size,
                    Colors = item.Colors,
                    CategoryName = item.Category.Name,
                    CategoryId = item.Category.Id,
                    Type = item.Type,
                    Cart = item.Cart,
                    CartId = item.CartId,
                    Images = item.Images,   

                })
                .ToList();
            return items;
        }
    }
}
