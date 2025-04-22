using Microsoft.EntityFrameworkCore;
using ShoeLandia.Data;
using ShoeLandia.Data.Models;
using ShoeLandia.Services.Filter;
using ShoeLandia.Services.Interfaces;
using ShoeLandia.ViewModels.Item;
using ShoeLandia.Views.Item.Enums;

namespace ShoeLandia.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext dbContext;

        public ItemService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AllItemsFilteredAndPagedServiceModel> All(AllItemsQueryModel queryModel)
        {
            IQueryable<Item> itemsQuery = dbContext
                .Items
                .Where(item => item.IsDeleted == false)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string searchTerm = queryModel.SearchString.ToLower();
                itemsQuery = itemsQuery
                    .Where(i => i.Name.ToLower().Contains(searchTerm) ||
                                i.Description.ToLower().Contains(searchTerm));
            }

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                itemsQuery = itemsQuery
                    .Where(i => i.Category.Name == queryModel.Category);
            }

            itemsQuery = queryModel.ItemsSorting switch
            {
                ItemsSorting.PriceAscending => itemsQuery
                    .OrderBy(x => x.Price),
                ItemsSorting.PriceDescending => itemsQuery
                    .OrderByDescending(x => x.Price),
                _ => itemsQuery
                    .OrderBy(x => x.Name)
            };

            int totalItems = await itemsQuery.CountAsync();

            IEnumerable<ItemInListViewModel> allItems = await itemsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ItemsPerPage)
                .Take(queryModel.ItemsPerPage)
                .Select(x => new ItemInListViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Images = x.Images,
                    Size = x.Size,
                    Colors = x.Colors,
                    Type = x.Type,
                    Category = x.Category.Name,
                })
                .ToArrayAsync();

            return new AllItemsFilteredAndPagedServiceModel
            {
                TotalItemsCount = totalItems,
                Items = allItems
            };
        }


        public void AddNewItemInDB(ItemFormViewModel item, string userId)
        {
            Item newItem = new Item();
            newItem.Name = item.Name;
            newItem.Description = item.Description;
            newItem.Images = item.Images;
            newItem.Size = item.Size;
            newItem.Colors = item.Colors;
            newItem.Type = item.Type;
            newItem.CategoryId = item.CategoryId;
            newItem.Price = item.Price;
            newItem.OwnerId = userId;

            this.dbContext.Add(newItem);
            this.dbContext.SaveChanges();
        }

        public ShoeLandia.Data.Models.Item GetById<Item>(string itemId)
        {
            var item = this.dbContext.Items
               .Where(x => x.Id == itemId )
               .Include(x => x.Category)
               .FirstOrDefault();

            return item;
        }

        public async Task EditItemAsync(ItemFormViewModel model, string itemId, List<KeyValuePair<string, string>> categoriesItems, string userId)
        {
            Item item = await dbContext
                .Items
                .Where(i => i.IsDeleted == false && i.OwnerId==userId)
                .FirstAsync(i => i.Id == itemId);

            item.Name = model.Name;
            item.Description = model.Description;
            item.CategoryId = model.CategoryId;
            item.Price = model.Price;
            item.Size = model.Size;
            item.Colors = model.Colors;
            item.Type = model.Type;
            item.Images = model.Images;
            item.OwnerId = model.OwnerId;
            categoriesItems = model.CategoriesItems;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ItemFormViewModel> GetItemForEditByIdAsync(string itemId, List<KeyValuePair<string, string>> categoriesItems, string userId)
        {

            return await dbContext
                .Items
                .Where(i => i.Id == itemId && i.OwnerId == userId)
                .Select(i => new ItemFormViewModel
                {
                    Name = i.Name,
                    Description = i.Description,
                    CategoryId = i.CategoryId,
                    Price = i.Price,
                    Size = i.Size,
                    Colors = i.Colors,
                    Type = i.Type,
                    Images = i.Images,
                    OwnerId = i.OwnerId,
                    CategoriesItems = categoriesItems,
                }).FirstOrDefaultAsync();
        }
        public async Task DeleteAsync(string itemId, string userId)
        {
            var item = this.dbContext.Items.FirstOrDefault(x => x.Id == itemId && x.OwnerId==userId);

            item.IsDeleted = true;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
