using System.ComponentModel.DataAnnotations;

namespace ShoeLandia.ViewModels.Review
{
    public class ReviewViewModel
    {
        [Required(ErrorMessage = "Името е задължително")]
        public string CustomerName { get; set; }

        [Range(1, 5, ErrorMessage = "Рейтингът трябва да е между 1 и 5")]
        public int Rating { get; set; }

        [StringLength(500, ErrorMessage = "Коментарът е прекалено дълъг")]
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public string AuthorId { get; set; }
    }
}
