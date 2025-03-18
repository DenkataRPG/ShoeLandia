using ShoeLandia.Data.Models;

namespace ShoeLandia.ViewModels.Item
{
    public class ItemFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public ICollection<string> Colors { get; set; }
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public List<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
