namespace Bodonate.Entity.DbContext
{
    using Bodonate.Entity.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BodonateDbContext : DbContext
    {
       
        public BodonateDbContext()
            : base("name=BodonateDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Donater> Donaters { get; set; }
        public virtual DbSet<Requester> Requesters { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

    }

}