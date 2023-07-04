

namespace Library.DbModels
{
    public class Fluent_Book
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }
        //[MaxLength(200)]
        public string Description { get; set; }
        //[ForeignKey("BookDetail")]
        
        public int AuthorId { get; set; }
        public Fluent_Author Author { get; set; }
        //[ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public Fluent_Publisher Publisher { get; set; }

        //public List<Reader> Reader { get; set; }
        public List<Fluent_BookReader> BookReaders { get; set; }

        public Fluent_BookDetail BookDetail { get; set; }


    }
}

