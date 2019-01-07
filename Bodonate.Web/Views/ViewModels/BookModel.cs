using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodonate.Web.Views.ViewModels
{
    public class BookModel
    {
        public int id { get; set; }
        public string Name { get; set; }
       // public string Author { get; set; }
        public string Genre { get; set; }
        //   public int GenreBookCount { get; set; }
        public bool Checked { get; set; }
        // public string Message { get; set; }
        //public User User { get; set; }
    }
}