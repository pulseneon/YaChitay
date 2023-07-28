using YaChitay.Entities.Models;

namespace YaChitay.Entities
{
    public class SelectionBooksCache
    {
        public List<Book> BooksOfDay { get; private set; }

        public void SetBooks(List<Book> books)
        {
            BooksOfDay = books;
        }
    }
}
