using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Entity.Models
{
    public class Requester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }

        public User User { get; set; }
        public List<Genre> Genres { get; set; }
        public List<comments> CommentsForUsers { get; set; }
    }
}
