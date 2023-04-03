using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PictureUrl { get; set; }
        public IFormFile Picture { get; set; } //resim dosyasını alabilmek için (Sunucuda çalışıyorsan sunucuya göre ayarlaman gerekiyor.)
    }
}
