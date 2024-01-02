namespace OdataInclude.Entities
{

    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static Author Create(string name)
        {
            return new Author { Id = Guid.NewGuid(), Name = name };
        }
    }
}
