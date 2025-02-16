namespace ShoeLandia.Data.Models
{
    public class Item 

    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
        }

        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public virtual Cart Cart { get; set; }
        public string CartId { get; set; }
        public virtual ICollection<Image> Images { get; set; }

    }
}
