using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Books.Models;
using E_Books.ViewModels;

namespace E_Books.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            Register register = new Register();
            return View(register);
            
        }

        [HttpPost]

        public ActionResult Register(Users users)
        {
            using (EBooksUserEntities userEntities = new EBooksUserEntities())
            {
                userEntities.Users.Add(users);
                userEntities.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful registration!";
            return RedirectToAction("BookList", "Book");
        }
    }
}