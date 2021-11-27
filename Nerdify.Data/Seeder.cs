using Microsoft.Extensions.Logging;
using Nerdify.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nerdify.Data.SeedData
{
    public class Seeder
    {
        
        public static async Task DbInitializer(DatabaseContext context, ILoggerFactory loggerFactory)
        {
            context.Database.EnsureCreated();
            
            try
            {
                

                


                if (!context.Books.Any())
                {
                    var books = File.ReadAllText(@"C:\Users\hp\Desktop\pull api\Nerdify-Api\Nerdify.Data\SeedData\Book.json");
                    List<Book> bookProduct = JsonSerializer.Deserialize<List<Book>>(books);
                    foreach (var item in bookProduct)
                    {
                        context.Books.Add(item);
                    }

                }


                if (!context.Categories.Any())
                {
                    string categories = File.ReadAllText(@"C:\Users\hp\Desktop\pull api\Nerdify-Api\Nerdify.Data\SeedData\Category.json");
                    var itemCategories = JsonSerializer.Deserialize<List<Category>>(categories);
                    foreach (var item in itemCategories)
                    {
                        context.Categories.Add(item);
                    }

                }

                await context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Seeder>();
                logger.LogError(ex.Message);
            }
        } 
    }
}
