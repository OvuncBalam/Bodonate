using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bodonate.DAL.Repositories
{
   public class GenreRepo
    {
        public static List<Genre> GetAllGenres()
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Genres = db.Genres.ToList();
                return Genres;
            }
        }
        public static void AddGenre(Genre Genre)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                
                db.Genres.Add(Genre);
                db.SaveChanges();
             
            }
        }
        public static void DeleteGenreById(int Id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var GenreToBeDeleted = db.Genres.SingleOrDefault(g => g.Id == Id);
                db.Genres.Remove(GenreToBeDeleted);
                db.SaveChanges();

            }
        }
        public static void UpdateGenre(string userName, Genre Genre)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var GenreToBeUpdated = db.Genres.SingleOrDefault(g => g.User.Username == userName);
                GenreToBeUpdated.Name = Genre.Name;
                GenreToBeUpdated.Id = Genre.Id;
                GenreToBeUpdated.Checked = Genre.Checked;
                GenreToBeUpdated.Message = Genre.Message;
                db.SaveChanges();



            }
        }
    }
}
