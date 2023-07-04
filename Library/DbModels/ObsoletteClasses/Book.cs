

//namespace Library.DbModels
//{
//    public class Book
//    {
//        [Key]
//        public int Id { get; set; }
//        [Required]
//        [MaxLength(50)]
//        public string Name { get; set; }
//        [MaxLength(200)]
//        public string Description { get; set; }
//        [ForeignKey("BookDetail")]
//        public int BookDetail_Id { get; set; }
//        public BookDetail BookDetail { get; set; }
//        [ForeignKey("Author")]
//        public int AuthorId { get; set; }
//        public Author Author { get; set; }
//        [ForeignKey("Publisher")]
//        public int PublisherId { get; set; }
//        public Publisher Publisher { get; set; }

//        //public List<Reader> Reader { get; set; }
//        public List<BookReader> BookReaders { get; set; }

//    }
//}

