﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var books = BooksRepo.GetAllBooks();
            var donators = DonaterRepo.GetAllDonaters();
            var genres = GenreRepo.GetAllGenres();
            var users = UserRepo.GetAllUsers();

            var BodobateViewModel = new BodonateViewModel()
            {
                Books = books,
                Donators = donators,
                Genres = genres,
                Users = users
            };


            return View(BodobateViewModel);
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

    }
}

