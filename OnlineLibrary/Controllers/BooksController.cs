using OnlineLibrary.Data;
using OnlineLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Models;
using Microsoft.EntityFrameworkCore.Query;
using static System.Reflection.Metadata.BlobBuilder;

namespace OnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        private OnlineLibraryDbContext dtbs;

        private int storedBookId = 0;

        // Змініть це поле на об'єкт, що ініціалізується при кожному запиті
        public HistoryOfReadBooks historyOfReadBooks => new HistoryOfReadBooks();

        public BooksController(OnlineLibraryDbContext dtbs)
        {
            this.dtbs = dtbs;
        }

        public IActionResult Books()
        {
            var books = dtbs.Books.ToList();
            return View(books);
        }

        public IActionResult SortByName()
        {
            var books = dtbs.Books.OrderBy(b => b.book_name).ToList();
            return View(books);
        }

        public IActionResult AdminBooks()
        {
            var books = dtbs.Books.ToList();
            return View(books);
        }
        public ActionResult AddedToRead(int bookId, int readerId)
        {
            RegisteredReader regreader = new RegisteredReader();
            regreader = dtbs.RegisteredReaders.Find(readerId);
            Book readedbook = new Book();
            readedbook = dtbs.Books.Find(bookId);
            if (ModelState.IsValid)
            {
                HistoryOfReadBooks hisofread = new HistoryOfReadBooks()
                {
                    Books = readedbook,
                    RegisteredReaders = regreader,
                };
                dtbs.HistoryOfReadBooks.Add(hisofread);
                dtbs.SaveChanges();
            }
            return RedirectToAction("Books", "Books");
        }

        public IActionResult AddingNewBook()
        {
            return View();
        }
        
        public IActionResult EditBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddedBook(Book addedbook)
        {
            if (ModelState.IsValid)
            {
                bool bookExist = dtbs.Books.Any(p => p.book_name == addedbook.book_name);

                if (!bookExist)
                {
                    addedbook.number_of_views = 1;
                    dtbs.Books.Add(addedbook);
                    dtbs.SaveChanges();
                }
            }

            return RedirectToAction("AdminBooks", "Books");
        }

        [HttpPost]
        public ActionResult GetBookId(int bookId)
        {
            this.storedBookId = bookId;
            TempData["BookId"] = storedBookId;
            return RedirectToAction("EditBook");
        }

        [HttpPost]
        public ActionResult BookDelete(int bookId)
        {
            Book deletedBook = new Book();
            deletedBook = dtbs.Books.Find(bookId);
            dtbs.Books.Remove(deletedBook);
            dtbs.SaveChanges();
            return RedirectToAction("AdminBooks");
        }

        [HttpPost]
        public IActionResult EditBook(int id, string newBookName, string newAuthor, string newGenre, string newDiscription, float newRating)
        {
            Book editedBook = new Book();
            if (ModelState.IsValid)
            {
                editedBook = dtbs.Books.Find(id);
                editedBook.book_name = newBookName;
                editedBook.author = newAuthor;
                editedBook.book_genre = newGenre;
                editedBook.short_dicription = newDiscription;
                editedBook.rating = newRating;
                editedBook.number_of_views = 1;
                dtbs.Books.Update(editedBook);
                dtbs.SaveChanges();
                return RedirectToAction("AdminBooks", "Books");
            }
            return View();
        }
    }
}
