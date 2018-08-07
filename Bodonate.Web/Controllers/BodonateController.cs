using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bodonate.DAL.Repositories;
using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using Bodonate.Web.Views.ViewModels;

namespace Bodonate.Web.Controllers
{
    public class BodonateController : Controller
    {
        // GET: Books


        public ActionResult Index()

        {
         return View();
        }



        public ActionResult NewBook()
        {
            var model = new BookModel();


            return View(model);
        }

        [HttpPost]
        public ActionResult Save(BookModel model)
        {

            using (BodonateDbContext db = new BodonateDbContext())
            {
                var book = new Book
                {
                    Name = model.Name,
                    Author = model.Author
                };

                if (book.Id == 0)
                {
                    db.Books.Add(book);

                }
                else
                {

                    book.Name = model.Name;
                    book.Author = model.Author;


                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public ActionResult Update(int id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {

                var book = db.Books.SingleOrDefault(b => b.Id == id);
                var model = new BookModel
                {
                    Name = book.Name,
                    Author = book.Author

                };



                return View(model);
            }
        }
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]



        public ActionResult UserLogin(UserModel user)

        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                if (ModelState.IsValid)
                {

                    var userInDb = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                    if (userInDb != null)
                    {
                        return RedirectToAction("Index");
                    }

                        else
                        {
                            ModelState.AddModelError("", "Lütfen kullanıcı bilgilerinizi kontrol ediniz.");
                        }


                    };

                    return View("UserLogin");

                }
            }

        [HttpPost]
        public ActionResult UserRegister(UserModel user)
        {
            var UserRegistered = new User()
            {
                Name = user.Name,
                SurName = user.SurName,
                Transfers = user.Transfers,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email


            };
            UserRepo.AddUser(UserRegistered);

            return RedirectToAction("Index");

        }
    }


   

}





    


