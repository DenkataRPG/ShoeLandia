using ShoeLandia.Data.Models;

namespace ShoeLandia.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
        public IEnumerable<Category> GetAllCategories();
        public Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
