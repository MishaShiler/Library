namespace Library.DbModels
{
    public class Fluent_BookDetail
    {
        [Key] 
        public int Id { get; set; }
        //[Required]

        public int PagesCount { get; set; }
        //[Required]
        public decimal Price { get; set; }
        public int BookId { get; set; } 
        public Fluent_Book Book { get; set; }
    }
}
