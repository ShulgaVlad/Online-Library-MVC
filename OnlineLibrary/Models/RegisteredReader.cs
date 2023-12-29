using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{ 
    public class RegisteredReader
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string e_mail { get; set; }
        
        [Required]
        public int? phone_number { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string surname { get; set; }

        [Required]
        public string password { get; set; }

        public string? faculty { get; set; }

        public string? specialty { get; set; }
    }
}
