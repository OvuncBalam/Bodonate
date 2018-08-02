using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodonate.Web.Views.ViewModels
{
    public class BodonateViewModel
    {
        public BodonateViewModel()
        {

        }

        public List<Book> Books { get; set; }
        public List<Donater> Donators { get; set; }
        public List<Genre> Genres { get; set; }
        public List <User> Users { get; set; }
    }
}