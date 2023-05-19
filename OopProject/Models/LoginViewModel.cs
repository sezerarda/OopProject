using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace OopProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string password { get; set; }
    }
}
