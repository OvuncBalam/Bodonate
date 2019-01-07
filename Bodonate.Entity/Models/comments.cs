using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Entity.Models
{
    public class comments
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public User user { get; set; }
        public RequestFor RequestFors { get; set; }
    }
}
