using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodonate.DAL.Repositories;
using Bodonate.Web.Views.ViewModels;

namespace Bodonate.Web.Controllers
{
    public class BodonateController : Controller
    {
        // GET: Books
        public ActionResult Index()   
        {/*
            var books = BooksRepo.GetAllBooks();
            var donators = DonaterRepo.GetAllDonaters();
            var genres = GenreRepo.GetAllGenres();
            //bsy
            var BodobateViewModel = new BodonateViewModel()
            {
                Books = books,
                Donators = donators,
                Genres=genres
            };
            */





            return View();  //BodobateViewModel
        }
    }
}