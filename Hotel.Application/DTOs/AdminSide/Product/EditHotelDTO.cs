using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.DTOs.AdminSide.Product
{
    public class EditHotelDTO
    {
        #region Hotel

        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50, ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2, ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500, ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(20, ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string Description { get; set; }

        [Display(Name = "تعداد اتاق")]
        public int RoomCount { get; set; }

        [Display(Name = "تعداد طبقه")]
        public int StageCount { get; set; }

        [Display(Name = "زمان ورود")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string EntryTime { get; set; }

        [Display(Name = "زمان خروج")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string ExitTime { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }



        #endregion

        #region Hotel Address

        [Display(Name = "آدرس هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500, ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(10, ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string Address { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(35, ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2, ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string City { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(35, ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2, ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string State { get; set; }

        #endregion
    }
}
