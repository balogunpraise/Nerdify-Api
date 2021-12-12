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

                if (!context.Categories.Any())
                {
                    string categories = File.ReadAllText(@"C:\Users\hp\Desktop\pull api\Nerdify-Api\Nerdify.Data\SeedData\Category.json");
                    var itemCategories = JsonSerializer.Deserialize<List<Category>>(categories);
                    foreach (var item in itemCategories)
                    {
                        await context.Categories.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }



                if (!context.Subjects.Any())
                {
                    var subjects = File.ReadAllText(@"C:\Users\hp\Desktop\test\Nerdify-Api\Nerdify.Data\SeedData\Subject.json");
                    List<Subject> subList = JsonSerializer.Deserialize<List<Subject>>(subjects);
                    foreach(var item in subList)
                    {
                        await context.Subjects.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }



                if (!context.Books.Any())
                {
                    var books = File.ReadAllText(@"C:\Users\hp\Desktop\test\Nerdify-Api\Nerdify.Data\SeedData\Book.json");
                    List<Book> bookProduct = JsonSerializer.Deserialize<List<Book>>(books);
                    foreach (var item in bookProduct)
                    {
                        await context.Books.AddAsync(item);
                    }
                    await context.SaveChangesAsync();

                }

                

            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Seeder>();
                logger.LogError(ex.Message);
            }
        } 
    }
}
