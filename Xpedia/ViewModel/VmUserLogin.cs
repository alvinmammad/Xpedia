using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xpedia.ViewModel
{
    public class VmUserLogin
    {
        [Display(Name = "İstifadəçi adınız")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "İstifadəçi adınız boş olmamalıdır !")]
        [StringLength(maximumLength: 25)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifrəniz boş olmamalıdır", AllowEmptyStrings = false)]
        [Display(Name = "Şifrəniz")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Şifrəniz minimum 8 simvoldan ibarət olmalıdır.")]
        public string Password { get; set; }
        [Display(Name = "E-poçtunuz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-poçtunuz boş ola bilməz !")]
        public string Email { get; set; }
        [Display(Name = "Yadda saxla")]
        public bool RememberMe { get; set; }
    }
}