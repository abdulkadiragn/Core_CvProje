using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adını girmek zorunludur.")]
        public string UserName { get; set; }
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifre zorunlu alan.")]
        public string Password { get; set; }

    }
}
