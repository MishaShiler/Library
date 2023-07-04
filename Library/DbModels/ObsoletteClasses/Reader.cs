//using System.ComponentModel.DataAnnotations.Schema;

//namespace Library.DbModels
//{
//    public class Reader
//    {
//        [Key]

//        public int Id { get; set; }
//        [Required]
//        [MaxLength(100)]
//        public string FirstName { get; set; }
//        [Required]
//        [MaxLength(100)]
//        public string LastName { get; set; }
//        [Column("Phone")]
//        [MaxLength(20)]
//        public string PhoneNumber { get ; set; }
//        [NotMapped]
//        public int TempId { get; set; }
//        //List<Book> Book { get; set; }
//        public List<BookReader> BookReaders { get; set; }

//    }
//}
