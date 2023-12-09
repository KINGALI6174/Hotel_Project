using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.DTOs.SiteSide.UserLogin
{
    public class UserLoginDTO
    {
        [Display(Name = "شماره ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [StringLength(10, ErrorMessage = "شماره ملی نمیتواند بیش از 10 کاراکتر باشد")]
        [MinLength(10, ErrorMessage = "شماره ملی نمی تواند کمتر از 10 رقم باشد")]
        public string NationalCode { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
