using ShoeLandia.Data.Models;

namespace ShoeLandia.ViewModels.Item
{
    public class SingleItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Colors { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public string[] Images { get; set; }
    }
}
