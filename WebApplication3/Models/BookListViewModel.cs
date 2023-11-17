namespace LibraryProject.Models
{
    public class BookListViewModel
    {
        public string? Author { get; set; }
        public string? Name { get; set; }

        public IEnumerable<Book> books { get; set; } = new List<Book>();
    }
}
