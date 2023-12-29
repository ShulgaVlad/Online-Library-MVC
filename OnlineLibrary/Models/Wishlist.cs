using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.Models
{
    public class Wishlist
    {
        [Key]
        public int id { get; set; }

        public string? ItemName { get; set; }

        public int Price { get; set; }

        [ForeignKey("BookId")]

        public Book Book { get; set; }

        [ForeignKey("ReaderId")]
        public RegisteredReader RegisteredReaders { get; set; }
    }
}