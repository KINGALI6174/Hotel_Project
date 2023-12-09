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
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string FName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string LName { get; set; }

        [Display(Name = "شماره ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [StringLength(10, ErrorMessage = "شماره ملی نمیتواند بیش از 10 کاراکتر باشد")]
        [MinLength(10,ErrorMessage = "شماره ملی نمی تواند کمتر از 10 رقم باشد")]
        public string NationalCode { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

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
