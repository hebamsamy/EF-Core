using Microsoft.EntityFrameworkCore;

namespace EF_Core_Day1
{
    class Program
    {
        public static void Main()
        {

            using (LibraryContext db = new LibraryContext())
            {
                db.Database.EnsureCreated();


                //db.Categories.Add(new Category
                //{
                //    Name = "novels",

                //    Books = new List<Book>(){
                //        new Book() { Book_Id = 400, Title = "rererer", Price = 200},
                //        new Book() { Book_Id = 500, Title = "rererer", Price = 200},
                //        new Book() { Book_Id = 600, Title = "rererer", Price = 200}
                //    }
                //});

                //db.Categories.AddRange(new Category[] {
                //    new Category(){Name = "one"},
                //    new Category(){Name = "two"},
                //    new Category(){Name = "three"},
                //});


                //db.Books.Add(new Book()
                //{
                //    Book_Id = 700,
                //    Title = "ttttttt",
                //    Price = 200,
                //    Category = db.Categories.Local.Where(i=>i.Name.Contains("one")).FirstOrDefault()
                //});


                //db.SaveChanges();

                foreach (var item in db.Books.Include(b=>b.Category))
                {
                    Console.WriteLine($" {item.CategoryId}  {item.Category.Name} {item.Title}");
                };
                
            }

        } 
    }
}