using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities.Role;

namespace Hotel.Domain.Entities.Account
{
    public class User
    {
        #region property

        [Key]
        public int ID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string FName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string LName { get; set; }

        [Display(Name = "شماره ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string NationalCode { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string PhoneNumber { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Email { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Password{ get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public bool IsDelete  { get; set;}
        public bool SuperAdmin { get; set;}


        #endregion


        #region Navigation Property

        public ICollection<UserSelectedRole> UserSelectedRoles { get; set;}

        #endregion




    }
}
