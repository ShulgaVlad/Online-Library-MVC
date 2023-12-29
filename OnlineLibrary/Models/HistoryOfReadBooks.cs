using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace OnlineLibrary.Models
{
    public class HistoryOfReadBooks
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("ReaderId")]
        public RegisteredReader? RegisteredReaders { get; set; }


        [ForeignKey("BookId")]
        public Book? Books { get; set; }

    }

}
