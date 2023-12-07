using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.DTOs.SiteSide.UserRegister
{
    public class UserRegisterDTO
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = " تکرا رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [Compare(nameof(Password),ErrorMessage = "تکرار کلمه عبور همخوانی ندارد")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
