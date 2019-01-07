using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Entity.Models
{
   public  class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public int GenreBookCount { get; set; }
        [DefaultValue(false)]
        public bool Checked { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public RequestFor RequestFors { get; set; }
        public List<Book> Books { get; set; }
    }
}
