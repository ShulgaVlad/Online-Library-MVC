using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required]

        public string? book_name { get; set; }
        [Required]

        public string? author { get; set; }
        [Required]

        public string? book_genre { get; set; }
        [Required]

        public string? short_dicription { get; set; }
        [Required]

        public float? rating { get; set; }

        public int? number_of_views { get; set; }

    }
}
