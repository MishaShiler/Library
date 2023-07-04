namespace Library.DbModels
{
    public class Fluent_Publisher
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }
        //[MaxLength(100)]
        public string Address { get; set; }
        public List<Fluent_Book> Books  { get; set; }

    }
}
