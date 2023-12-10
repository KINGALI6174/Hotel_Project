using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class Hotel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50,ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2,ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
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
        [Display(Name = "تاریخ ثبت")]
        public DateTime DateTime { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public ICollection<HotelGallery> HotelGalleries { get; set; }
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<HotelRule> HotelRules { get; set; }


    }
}
