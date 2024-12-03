using buoi5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi5.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await Task.FromResult(_books); // Trả về danh sách sách hiện tại
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(book);
        }

        public async Task CreateBookAsync(Book book)
        {
            book.Id = _books.Count + 1;  // Tạo Id tự động (giả sử chưa có cơ sở dữ liệu)
            _books.Add(book);
            await Task.CompletedTask;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Price = book.Price;
                existingBook.Image = book.Image;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            await Task.CompletedTask;
        }
    }
}
