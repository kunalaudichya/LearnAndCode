
using Week2.Assignment4.Entities;
using Week2.Assignment4.Repositories;

namespace Week2.Assignment4.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string GetBookLocation(Book book)
        {
            return "Shelf 3, Room A";
        }

        public void SaveBook(Book book)
        {
            _bookRepository.Save(book);
        }
        public void TurnPage(Book book)
        {
            book.TurnPage();
        }

        public string GetCurrentPage(Book book)
        {
            return book.GetCurrentPageContent();
        }
    }
}
