using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Books.Models;

namespace E_Books.Controllers
    
{
    
    public class BookController : Controller
    {
        // GET: /Book/BookList
        public ActionResult BookList()
        {
            using (EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
            {
                return View(eBooksDBEntities.Books.ToList());
            }
        }

        // GET: Book/Details/5
        public ActionResult Details(int id = 1)
        {
            using(EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
            {
                return View(eBooksDBEntities.Books.Where(x => x.Id == id).FirstOrDefault());
            }
          
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Books books)
        {
            try
            {
                // TODO: Add insert logic here
                using(EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
                {
                    eBooksDBEntities.Books.Add(books);
                    eBooksDBEntities.SaveChanges();
                }
                return RedirectToAction("BookList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id = 1)
        {
            using (EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
            {
                return View(eBooksDBEntities.Books.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Books books)
        {
            try
            {
                using (EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
                {
                    eBooksDBEntities.Entry(books).State = EntityState.Modified;
                    eBooksDBEntities.SaveChanges();
                }
                return RedirectToAction("BookList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
            {
                return View(eBooksDBEntities.Books.Where(x => x.Id == id).FirstOrDefault());
            }
            
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (EBooksDBEntities eBooksDBEntities = new EBooksDBEntities())
                {
                    Books books = eBooksDBEntities.Books.Where(x => x.Id == id).FirstOrDefault();
                    eBooksDBEntities.Books.Remove(books);
                    eBooksDBEntities.SaveChanges();
                }
                return RedirectToAction("BookList");
            }
            catch
            {
                return View();
            }
        }
    }
}
