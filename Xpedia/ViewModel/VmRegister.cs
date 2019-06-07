using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Xpedia.ViewModel
{
    public class VmRegister
    {
        [Display(Name = "Adınız")]
        [Required(ErrorMessage = "Adınız boş olmamalıdır !")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Display(Name = "Soyadınız")]
        [Required(ErrorMessage = "Soyadınız boş olmamalıdır !")]
        [StringLength(maximumLength: 25)]
        public string LastName { get; set; }
        [Display(Name = "İstifadəçi adınız")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "İstifadəçi adınız boş olmamalıdır !")]
        [StringLength(maximumLength: 25)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifrəniz boş olmamalıdır", AllowEmptyStrings = false)]
        [Display(Name = "Şifrəniz")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Şifrəniz minimum 8 simvoldan ibarət olmalıdır.")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "İkinci şifrə boş olmamalıdır !")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İkinci şifrə uyğun gəlmir !")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "E-poçtunuz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-poçtunuz boş ola bilməz !")]
        public string Email { get; set; }
        [Display(Name = "Əlaqə nömrəniz")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [Display(Name = "Yadda saxla")]
        public string DriverLicenseID { get; set; }
        [Column(TypeName = "uniqueidentifier")]
        public Guid ActivationCode { get; set; }
        [Column(TypeName = "bit")]
        public bool IsUser { get; set; }
        [Column(TypeName = "bit")]
        public bool IsEmailVerified { get; set; }
        [StringLength(maximumLength: 250)]
        public string Photo { get; set; }
       
        
    }
}