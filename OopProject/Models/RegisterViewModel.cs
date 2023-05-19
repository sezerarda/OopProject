using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace OopProject.Models
{
    public class RegisterViewModel 
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string password { get; set; }


        [Required(ErrorMessage = "Şifreyi Tekrar Giriniz")]
        [Compare("password", ErrorMessage = "Şifre uyumlu değil, Kontrol ediniz")]
        public string passwordConfirm { get; set; }

    }
}
