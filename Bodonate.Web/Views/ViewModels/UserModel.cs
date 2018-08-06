using Bodonate.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bodonate.Web.Views.ViewModels
{
    public class UserModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(20, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        [StringLength(20, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Confirmpassword { get; set; }

        public List<Transfer> Transfers { get; set; }
    }
}