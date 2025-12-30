
namespace Week2.Assignment4.Entities
{
    public class Book
    {
        public string Title { get; set; } = "A Great Book";
        public string Author { get; set; } = "John Doe";
        private int _currentPage = 1;

        public void TurnPage()
        {
            _currentPage++;
        }

        public string GetCurrentPageContent()
        {
            return $"Content of page {_currentPage}";
        }
    }

}
