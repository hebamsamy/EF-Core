namespace EF_Core_Day1
{
    public class Category
    {
        //Columns
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
