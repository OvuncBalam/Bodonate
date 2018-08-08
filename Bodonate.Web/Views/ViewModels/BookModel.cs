using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodonate.Web.Views.ViewModels
{
    public class BookModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
    }
}