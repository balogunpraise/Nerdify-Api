using Microsoft.Extensions.Logging;
using Nerdify.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nerdify.Data.SeedData
{
    public class Seeder
    {
        public static async Task DbInitializer(DatabaseContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ItemTypes.Any())
                {
                    var itemTypes = File.ReadAllText("./ItemType.json");
                    var types = JsonSerializer.Deserialize<List<ItemType>>(itemTypes);
                    foreach(var item in types)
                    {
                        context.ItemTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Categories.Any())
                {
                    var categories = File.ReadAllText("./Category.json");
                    var itemCategories = JsonSerializer.Deserialize<List<Category>>(categories);
                    foreach(var item in itemCategories)
                    {
                        context.Categories.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Subjects.Any())
                {
                    var subjects = File.ReadAllText("./Subject.json");
                    var itemSubject = JsonSerializer.Deserialize<List<Subject>>(subjects);
                    foreach(var item in itemSubject)
                    {
                        context.Subjects.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Books.Any())
                {
                    var books = File.ReadAllText("./Book.json");
                    var bookProduct = JsonSerializer.Deserialize<List<Book>>(books);
                    foreach(var item in bookProduct)
                    {
                        context.Books.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Reviews.Any())
                {
                    var reviews = File.ReadAllText("./Review.json");
                    var bookReview = JsonSerializer.Deserialize<List<Review>>(reviews);
                    foreach(var item in bookReview)
                    {
                        context.Reviews.Add(item);
                    }
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
