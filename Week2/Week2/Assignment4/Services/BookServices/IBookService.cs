
using Week2.Assignment4.Entities;

namespace Week2.Assignment4.Services.BookServices
{
    public interface IBookService
    {
        string GetBookLocation(Book book);
        void SaveBook(Book book);
        void TurnPage(Book book);
        string GetCurrentPage(Book book);
    }
}
