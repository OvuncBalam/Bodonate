using Bodonate.Entity.DbContext;
using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.DAL.Repositories
{
    public static class TransferRepo
    {


        public static List<Transfer> GetAllBooks()
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Transfers = db.Transfers.ToList();
                return Transfers;
            }
        }

        public static void AddNewBook(Transfer transfer )
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                db.Transfers.Add(transfer);
                db.SaveChanges();
            }
        }

        public static void DeleteTransfer(int id)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Transfer_To_Delete = db.Transfers.SingleOrDefault(t => t.Id == id);
                db.Transfers.Remove(Transfer_To_Delete);
                db.SaveChanges();
            }
        }

        public static void UpdateTransfer(int id, Transfer transfer)
        {
            using (BodonateDbContext db = new BodonateDbContext())
            {
                var Transfer_To_Update = db.Transfers.SingleOrDefault(t => t.Id == id);
                Transfer_To_Update.Tracknumber = transfer.Tracknumber;
                Transfer_To_Update.TransferDate = transfer.TransferDate;
                Transfer_To_Update.UserDonated = transfer.UserDonated;
                Transfer_To_Update.UserRequested = transfer.UserRequested;
                db.SaveChanges();



            }
        }
    }
}
