using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı boş geçmeyin.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı boş geçmeyin.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage ="Lütfen kullanıcı adını boş geçmeyin.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen resim url alanını boş geçmeyin.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen şifre alanını boş geçmeyin.")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Lütfen şifre kontrol alanını boş geçmeyin.")]
        [Compare("Password",ErrorMessage ="Şifre doğrulamanız uyuşmamaktadır.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Mesaj alanı boş geçilemez")]
        public string Mail { get; set; }

    }
}
