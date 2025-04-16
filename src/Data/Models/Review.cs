namespace ShoeLandia.Data.Models
{
    public class Review
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();

        }
        public string Id  { get; set; }
        public string CustomerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted  { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
    }
}