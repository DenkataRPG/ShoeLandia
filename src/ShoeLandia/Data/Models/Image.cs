namespace ShoeLandia.Data.Models
{
    public class Image 
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string RemoteImageUrl { get; set; }
        public  string AddedByUserId { get; set; }
        public  ApplicationUser AddedByUser { get; set; }
    }
}
