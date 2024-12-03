using buoi5_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace buoi5_2.Controllers
{
    public class bookController1 : Controller
    {
        private static List<Book> books = new List<Book>();
        private static int nextId = 1;

        public IActionResult Index()
        { 
           
return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = nextId++;
                books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book updatedBook)
        {
            if (id != updatedBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var book = books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return NotFound();
                }

                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Description = updatedBook.Description;
                book.Price = updatedBook.Price;
                book.Image = updatedBook.Image;

                return RedirectToAction(nameof(Index));
            }
            return View(updatedBook);
        }

        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
