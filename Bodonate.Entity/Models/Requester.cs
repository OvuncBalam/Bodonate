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

        public User UserRequesting { get; set; }
        public int UserId { get; set; }

    }
}
