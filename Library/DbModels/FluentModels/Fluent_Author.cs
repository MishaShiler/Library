

namespace Library.DbModels
{
    public class Fluent_Author
    {
        //[Key]   
        public int Id { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string FullName { get; set; }
        public List<Fluent_Book> Books { get; set; }

    }
}
