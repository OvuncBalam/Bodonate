using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.DAL.Repositories
{
   public class DonaterRepo
    {
        public static List<Donater> GetAllDonaters()
        {
            using (BodonateDbContext db= new BodonateDbContext())
            {
                var Donaters = db.Donaters.ToList();
                return Donaters;

            }

        }
        public static void AddDonater (Donater Donater)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                db.Donaters.Add(Donater);
                db.SaveChanges();

            }

        }
        public static void DeleteDonaterById(int Id)
        {
            using(BodonateDbContext db= new BodonateDbContext())
            {
                var DonaterToBeDeleted = db.Donaters.SingleOrDefault(d => d.Id == Id);
                db.Donaters.Remove(DonaterToBeDeleted);
            }
        }
    }
}
