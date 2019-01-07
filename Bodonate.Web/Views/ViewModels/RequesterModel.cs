using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodonate.Web.Views.ViewModels
{
    public class RequesterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserModel UserRequesting { get; set; }
        public int UserId { get; set; }
        public string Message;
    }
}