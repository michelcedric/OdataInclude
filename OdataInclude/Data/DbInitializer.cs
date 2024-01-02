using OdataInclude.Entities;

namespace OdataInclude.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Books.Any())
            {

                var author = Author.Create("Cedric Michel");
                var book = Book.Create("Fake title", author);

                context.Books.Add(book);
                context.SaveChanges();
            }
        }
    }
}
