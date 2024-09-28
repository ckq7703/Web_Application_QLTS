using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_CaoKienQuoc.Models;

namespace WebApplication_CaoKienQuoc.Controllers
{
    public class BooksController : Controller
    {
        private List<Book> listBooks;

        public BooksController()
        {
            listBooks = new List<Book>();
            listBooks.Add(new Book()
            {
                Id = 1,
                Title = "Sach 1",
                Author = "Tac gia sach 1",
                PublicYear = 2817,
                Price = 40000,
                Cover = "https://th.bing.com/th/id/OIP.JRE8gYBuVHguNRKqnGsHRAAAAA?rs=1&pid=ImgDetMain"
            });
            listBooks.Add(new Book()
            {
                Id = 2,
                Title = "Sach 2",
                Author = "Tac gia sach 2",
                PublicYear = 2817,
                Price = 40000,
                Cover = "https://th.bing.com/th/id/OIP.JRE8gYBuVHguNRKqnGsHRAAAAA?rs=1&pid=ImgDetMain"
            });
            listBooks.Add(new Book()
            {
                Id = 3,
                Title = "Sach 3",
                Author = "Tac gia sach 3",
                PublicYear = 2817,
                Price = 40000,
                Cover = "https://th.bing.com/th/id/OIP.JRE8gYBuVHguNRKqnGsHRAAAAA?rs=1&pid=ImgDetMain"
            });
        }

        // GET: Books
        public ActionResult ListBooks()
        {
            ViewBag.TitlePageName = "Book view page";
            return View(listBooks);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = listBooks.Find(s => s.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = listBooks.Find(s => s.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.Id == book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover = book.Cover;
                    editBook.Price = book.Price;
                    editBook.PublicYear = book.PublicYear;

                    // Return to the list view after successful edit
                    return View("ListBooks", listBooks);
                }
                catch (Exception ex)
                {
                    // Log exception if needed
                    return HttpNotFound();
                }
            }
            else
            {
                // Add model level error message
                ModelState.AddModelError("", "Input Model Not Valid!");

                // Return to the edit view with model errors
                return View(book);
            }
        }

    }
}
