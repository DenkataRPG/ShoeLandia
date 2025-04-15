using Microsoft.EntityFrameworkCore;
using ShoeLandia.Data;
using ShoeLandia.Data.Models;
using ShoeLandia.Services.Interfaces;

namespace ShoeLandia.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return GetAllCategories()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Id)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return dbContext.Categories.ToList();
        }
        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }
    }
}
