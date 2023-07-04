namespace Library.DbModels
{
    //[Table("Book_Readers")]
    public class Fluent_BookReader
    {
        //[ForeignKey("Book")]
        public int BookId { get; set; }
        public Fluent_Book Book { get; set; }
        //[ForeignKey("Reader")]
        public int ReaderId { get; set; }
        public Fluent_Reader Reader { get; set; }

    }
}
