namespace ShoeLandia.Data.Models
{
    public class Item

    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        
        }

        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Colors { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public virtual Cart Cart { get; set; }
        public string? CartId { get; set; }
        public string Images  { get; set; } // url1|url2|url3
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }

        public string[] GetImages=> this.Images.Split("|",StringSplitOptions.RemoveEmptyEntries);
        public List <string> GetColors=> this.Colors.Split("|",StringSplitOptions.RemoveEmptyEntries).ToList();

    }
}
