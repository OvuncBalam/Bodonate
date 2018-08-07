using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.DAL.Repositories
{
    public class UserRepo
    {
        public static List<User> GetAllUsers()
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Users = db.Users.ToList();
                return Users;

            }
        }
        public static void AddUser(User User)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                
                db.Users.Add(User);
                db.SaveChanges();
             
            }
        }
        public static void DeleteUserById(int Id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {

                var UserToBeDeleted = db.Users.SingleOrDefault(u => u.Id == Id);
                db.SaveChanges();

            }
        }
        public static void UpdateUser(int Id,User User)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {

                var UserToBeUpdated = db.Users.SingleOrDefault(u => u.Id == Id);
                UserToBeUpdated.Name = User.Name;
                UserToBeUpdated.SurName = User.SurName;
                UserToBeUpdated.Password = User.Password;
                UserToBeUpdated.Username = User.Username;
                UserToBeUpdated.Transfers = User.Transfers;
                UserToBeUpdated.Confirmpassword = User.Email;
                db.SaveChanges();

            }
        }
    }
}