using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
       
        public string Username { get; set; }

        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string Email { get; set; }

        public List<comments> comments { get; set; }
        public List<Transfer> Transfers { get; set; }
        public List<Requester> RegsForUser { get; set; }
        public List<RequestFor> RequestFors { get; set; }
    }
}
