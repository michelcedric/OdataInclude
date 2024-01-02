using System.ComponentModel.DataAnnotations;

namespace OdataInclude.Entities
{
    public class Book
    {      
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Author MainAuthor { get; set; }

        public static Book Create(string title, Author author)
        {
            return new Book { Id = Guid.NewGuid(), Title = title, MainAuthor = author };
        }
    }
}
