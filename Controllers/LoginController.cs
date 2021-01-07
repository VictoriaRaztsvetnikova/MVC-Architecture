using E_Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Books.ViewModels;

namespace E_Books.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(E_Books.Models.Users users)
        {
            using(EBooksUserEntities db = new EBooksUserEntities())
            {
                var userDetails = db.Users.Where(x => x.Username == users.Username && x.Password == users.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    users.LoginErrorMessage = "Wrong username or password!";
                    return View("Login", users);
                }
                else
                {
                    Session["Id"] = userDetails.Id;
                    return RedirectToAction("BookList", "Book");
                }
            }
        } 
        public ActionResult Logout()
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("~/Login/Login");
            }
                //int Id = (int)Session["Id"];
                Session.Abandon();
                return RedirectToAction("Login", "Login");
        }
    }
}