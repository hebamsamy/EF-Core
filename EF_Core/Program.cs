// Day one 
// ORM 
// install 2 Packages 
// Database First vs Code First
// to map Class to table Strcture "DataAnnotations"

// Day Two
// to map Class to table Strcture "Fluent API"
// Migrations Commands MUST Install (2 Packages TOOLS, Desgin)
// Add-Migration init 
// Add-Migration update......
// Remove-Migration // remove last migartion (BUT NOT implemented Migratios)
// Update-database  // implement All Migration To Database
// update-database productvendorrelation //Undo Till productvendorrelation
// get-migration // list all migration with status 

//Day Three
// Models Configration
// Data Seeding

// Execution 
//Eager
//Implicit
//Lazy

using Microsoft.EntityFrameworkCore;

namespace EF_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {

            EShopContext context = new EShopContext();


            //Eager Loading

            var data = context.Categories.ToList();
            //var data = context.Categories
            //    //.Include(c => c.Products)
            //    //.ThenInclude(p => p.Attachments)
            //    .ToList();
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Name} ");
                foreach (var prd in item.Products)
                {
                    Console.WriteLine($"{prd.Attachments.Count}");
                }
            }
        }
    }
}