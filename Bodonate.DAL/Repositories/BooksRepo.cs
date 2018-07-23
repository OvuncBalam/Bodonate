using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.DAL.Repositories
{
    public static class BooksRepo
    {
        

        public static List<Book> GetAllBooks()
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var books = db.Books.ToList();
                return books;
            }
        }

        public static void AddNewBook(Book book)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public static void DeleteBook(int id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var book_To_Delete = db.Books.SingleOrDefault(b => b.Id == id);
                db.Books.Remove(book_To_Delete);
                db.SaveChanges();
            }
        }

        public static void UpdateBook(int id,Book updateBook)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var book_To_Update = db.Books.SingleOrDefault(b => b.Id == id);
                book_To_Update.Name = updateBook.Name;
                book_To_Update.Genre.Id = updateBook.Genre.Id;
                book_To_Update.Author = updateBook.Author;
                db.SaveChanges();



            }
        }

        public static List<Book> GetBooksByGenreId(int id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var books  = db.Books.Where(b => b.Genre.Id == id).ToList();
                return books;

            }
        }
      
    }
}
