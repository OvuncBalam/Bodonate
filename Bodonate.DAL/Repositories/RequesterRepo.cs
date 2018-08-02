using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.DAL.Repositories
{
    class RequesterRepo
    {
        public static List<Requester> GetAllRequesters()
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Requesters = db.Requesters.ToList();
                return Requesters;
            }
            
        }
        public static void AddRequesters(Requester requester)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                db.Requesters.Add(requester);
                db.SaveChanges();
            }

        }
        public static void DeleteRequestersById(int Id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var RequesterTobeDeleted = db.Requesters.SingleOrDefault(r => r.Id == Id);
                db.Requesters.Remove(RequesterTobeDeleted);
            }

        }
        public static void UpdateRequester(int Id,Requester requester)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var RequesterToBeUpdated = db.Requesters.SingleOrDefault(r => r.Id == Id);
                RequesterToBeUpdated.Name = requester.Name;
                RequesterToBeUpdated.UserId = requester.UserId;
                RequesterToBeUpdated.UserRequesting = requester.UserRequesting;
                db.SaveChanges();
            }

        }
    }
}
