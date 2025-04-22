using ShoeLandia.Data.Models;

namespace ShoeLandia.ViewModels.Item
{
    public class ItemInListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Colors { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public string Images { get; set; } // url1|url2|url3

        public string[] GetImages => this.Images.Split("|", StringSplitOptions.RemoveEmptyEntries);
        public List<string> GetColors => this.Colors.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
        
        
    }
}
