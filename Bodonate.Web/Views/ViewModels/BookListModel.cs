using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodonate.Web.Views.ViewModels
{
    public class BookListModel
    {
        public BookListModel()
            {
            genres = new List<BookModel>();

            }
        
         public int id { get; set; }
         public List<BookModel> genres { get; set; }
         public string Message { get; set; }
    }
}