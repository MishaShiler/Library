using Library.DbModels;

namespace Library.Dtos
{
    public class BookAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int PagesCount { get; set; }
        public decimal Price { get; set; }
    }
}
