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


        public ActionResult Index(UserModel User)

        {
            UserModel user = new UserModel(); // action linki değiştir
            user.Username = User.Username;

            return View(user);
        }



        public ActionResult DonateBook()
        {

            using (BodonateDbContext db = new BodonateDbContext())
            {

            if (Session["UserName"] != null){

             var Username = Session["UserName"].ToString();
             var dbUser = db.Users.SingleOrDefault(x => x.Username == Username);

                var model = new List<BookModel>();
               var Model = new BookListModel();

     
                var genre1 = new BookModel();
                genre1.Name = "hikaye";
                  ModelState.Clear();
                Model.genres.Add(genre1);


                var genre2 = new BookModel();
                genre2.Name = "deneme";
          
                ModelState.Clear();
                Model.genres.Add(genre2);





/*
                var genreList = GenreRepo.GetAllGenres();


                  foreach (var item in genreList)
                      {
                          var add = new BookModel();
                          add.Name = item.Name;
                          add.Checked = item.Checked;
                          Model.genres.Add(add);

                      }

         */        
                return View(Model);
               }


            }
            return RedirectToAction("UserLogin");
        }
        [HttpPost]
        public ActionResult DonateBook(BookListModel donatedBook)
        {


            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Username = Session["UserName"].ToString();
                var dbUser = db.Users.SingleOrDefault(x => x.Username == Username);
                var Reques = new RequestFor();
                Reques.Genres = new List<Genre>();
                Reques.User = new User();
                Reques.User.Id = dbUser.Id;
                Random rastgele = new Random();
                int sayi = rastgele.Next(500);
                Reques.Id = sayi;
                Reques.Message = donatedBook.Message;
                foreach (var item in donatedBook.genres.ToList())
                {

                    if (item.Checked)
                    {
                        var genre = new Genre();

                        genre.Name = item.Name;
                        genre.Checked = item.Checked;
                        genre.RequestFors = new RequestFor();
                        //---------------------------requestera tür isimlerini mesaj olarak ekle 
                        genre.RequestFors.Id = Reques.Id;
                        genre.GenreBookCount = 1;
                        db.Genres.Add(genre);
                        

                    }
                }

             //   db.SaveChanges();

                return RedirectToAction("Index");

          

            }
        }


        public ActionResult Save(BookModel model)
        {
            /*
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
            */
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
                    //Author = book.Author

                };



                return View(model);
            }
        }




        public ActionResult UserLogin(string UserName)
        {
            UserModel user = new UserModel();
            return View(user);
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

                        Session["Username"] = user.Username.ToString();
                        return RedirectToAction("Index", "Bodonate", user);
                    }

                    else
                    {
                        ModelState.AddModelError("", "Lütfen kullanıcı bilgilerinizi kontrol ediniz.");


                    }


                };
                ModelState.AddModelError("", "Lütfen kullanıcı bilgilerinizi kontrol ediniz.");

                return RedirectToAction("UserLogin", "Bodonate", user);

            }
        }




        public ActionResult UserRegister()
        {
            UserModel addUser = new UserModel();

            return View(addUser);
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




        public ActionResult ViewRequests()  //kitap bağışı yapanlar icin
        {

          //  List<BookModel> userList = new List<BookModel>();

           // using (BodonateDbContext db = new BodonateDbContext())
          //  {

            /*if (Session["UserName"] != null)
                {

                    var RequestList = db.Users.ToList();
                    var ViewReqList = new List<RequesterModel>();

                    foreach (var item in RequestList)
                    {
                        var add = new RequesterModel();

                        add.Name = item.Username;

                        add.Message = "";
                        foreach (var genreName in item.genres.ToList())
                        {
                            if (genreName.Checked == true)
                            { add.Message = add.Message + " " + genreName.Name; }


                        }
                        add.Message = add.Message + " " + item.RegsForUser.SingleOrDefault(x => x.Name == Session["UserName"].ToString()).Message;
                        ViewReqList.Add(add);

                    }

                    return View(ViewReqList);

               }

               return RedirectToAction("UserLogin");

*/




        //    }

            var userList = new List<RequestFor>();

           

                        var user1 = new RequestFor();
                        user1.User= new User();
                        user1.User.Username = "övünç";
                        user1.Message = "Bu kitapları bağış olarak almak istiyorum";


                        user1.Genres = new List<Genre>();
                        var genre1 = new Genre();
                        genre1.Name = "ROMAN";
                        user1.Genres.Add(genre1);

                        var genre2 = new Genre();
                        genre2.Name =" "+ "HIKAYE";
                        user1.Genres.Add(genre2);
                        user1.CommentsForUsers = new List<comments>();
                        var comment = new comments();
                        comment.user = new User();
                        comment.user.Name = "ayse";
                        comment.Message = "Merhaba";
                        user1.CommentsForUsers.Add(comment);
                        var comment1 = new comments();
                        comment1.user = new User();
                        comment1.user.Name = "gülenay";
                        comment1.Message = "Merhaba";
                        user1.CommentsForUsers.Add(comment1);

                        userList.Add(user1);


                        var user2 = new RequestFor();
                        user2.User= new User();
                        user2.User.Username = "sevgi";
                        user2.Message = "Bu kitapları bağış olarak almak istiyorum";
                        user2.CommentsForUsers = new List<comments>();

                        var comment2 = new comments();
                        comment2.user = new User();
                        comment2.user.Name = "kevser";
                        comment2.Message = "Merhaba";
                        user2.CommentsForUsers.Add(comment2);
                        var comment3 = new comments();
                        comment3.user = new User();
                        comment3.user.Name = "sevgi";
                        comment3.Message = "Merhaba";
                        user2.CommentsForUsers.Add(comment3);


                        user2.Genres = new List<Genre>();
                        var genre3 = new Genre();
                        genre3.Name = " " + "ROMAN";
                        user2.Genres.Add(genre3);

                        var genre4 = new Genre();
                        genre4.Name = " " + "HIKAYE";
                        user2.Genres.Add(genre4);

                        userList.Add(user2);


                        ModelState.Clear();
                        return View(userList);
          
        }
        [HttpPost]
        public ActionResult ViewRequests(RequestFor message)
        {



            return View();
        }



        public ActionResult Contact()
        {


            return View();
        }



    }




}








