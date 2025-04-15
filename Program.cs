using ManningBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using var keepAliveConnection = new SqliteConnection(CatalogContext.ConnectionString);
keepAliveConnection.Open();

using var dbContext = new CatalogContext();
dbContext.Database.EnsureCreated();

// dbContext.Add(new Book { Title = ".NET in Action"});
// dbContext.Add(new Book { Title = "API Design Patterns" });
// dbContext.Add(new Book { Title = "Grokking Simplicity" });
// dbContext.Add(new Book { Title = "The Programmer's Brain" });

dbContext.SaveChanges();

foreach (var book in dbContext.Books.OrderByDescending(b => b.Id))
{
    Console.WriteLine($"Book \"{book.Title}\" has id {book.Id}");
}

// var efBook = new Book { Title = "EF Core in Action" };
// efBook.Ratings.Add(new Rating { Comment = "Great!" });
// efBook.Ratings.Add(new Rating { Stars = 4 });
// dbContext.Add(efBook);
// dbContext.SaveChanges();

// var efRatings = (
//     from b in dbContext.Books
//     where b.Title == "EF Core in Action"
//     select b.Ratings
//     ).FirstOrDefault();

// dbContext.Add(new Book { Title = ".NET in Action"});
// dbContext.Add(new Book { Title = "API Design Patterns" });
// dbContext.Add(new Book { Title = "Grokking Simplicity" });
// dbContext.Add(new Book { Title = "The Programmer's Brain" });
// dbContext.SaveChanges();

// Console.WriteLine("--------------------");

// foreach (var book in dbContext.Books.Include(b => b.Ratings))
// {
//     Console.WriteLine($"Book \"{book.Title}\" has id {book.Id}");
//     book.Ratings.ForEach(r => Console.WriteLine($"\t{r.Stars} stars: {r.Comment ?? "-blank-"}"));
// }
