using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Entity.Models
{
     public class Transfer
    {
        public int Id { get; set; }
        public int Tracknumber { get; set; }
        public Donater UserDonated { get; set; }
        public Requester UserRequested { get; set; }
        public RequestFor RequestFors { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
