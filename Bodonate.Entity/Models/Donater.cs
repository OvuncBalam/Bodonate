using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Entity.Models
{
   public class Donater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User UserDonating { get; set; }
        public int UserId { get; set; }
        public string Message;
    }
}
