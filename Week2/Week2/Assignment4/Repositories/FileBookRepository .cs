using System;
using System.IO;
using Week2.Assignment4.Entities;

namespace Week2.Assignment4.Repositories
{
    public class FileBookRepository : IBookRepository
    {
        public void Save(Book book)
        {
            string folder = "Documents";
            string filename = Path.Combine(folder, $"{book.Title} - {book.Author}.txt");

            Directory.CreateDirectory(folder);
            File.WriteAllText(filename, $"Title: {book.Title}\nAuthor: {book.Author}");

            Console.WriteLine($"[Repository] Book saved to {filename}");
        }

    }
}
