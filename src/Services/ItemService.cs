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
            // var items1 = this.dbContext
            // .Items
            // .Where(item => item.IsDeleted == false).Include(x=>x.Category).ToList();
            // return items1;
            IQueryable<Item> itemsQuery = dbContext
               .Items
               .AsQueryable();



            itemsQuery = queryModel.ItemsSorting switch
            {
                // ItemsSorting.Newest => housesQuery
                //     .OrderByDescending(x => x.CreatedOn),
                // ItemsSorting.Oldest => housesQuery
                //     .OrderBy(x => x.CreatedOn),
                ItemsSorting.PriceAscending => itemsQuery
                    .OrderBy(x => x.Price),
                ItemsSorting.PriceDescending => itemsQuery
                    .OrderByDescending(x => x.Price),
                _ => itemsQuery
                // .ThenByDescending(x => x.CreatedOn)
            };

            IEnumerable<ItemInListViewModel> allItems = await itemsQuery
                .Where(x => x.IsDeleted == false)
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
            int totalItems = itemsQuery.Count();

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
                .FirstAsync(i => i.Id.ToString() == itemId);

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
