using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using ShoeLandia.Data.Models;

namespace ShoeLandia.ViewModels.Item
{
    public class ItemFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Colors { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public string Images { get; set; }
        public string OwnerId { get; set; }
        public List<KeyValuePair<string, string>> CategoriesItems { get; set; }
        //public IEnumerable<Category>Categories { get; set; }
    }
}
