using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class HotelRoom
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "تصویر اتاق")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string ImageName { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100,ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2,ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500, ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2, ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "تعداد")]
        public int UserCount { get; set; }

        [Display(Name = "ظرفیت")]
        public int Capecity { get; set; }

        [Display(Name = "تعدادتخت")]
        public int BedCount { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public ICollection<AdvantageToRoom> AdvantageToRooms { get; set; }

        public ICollection<ReserveRoom> reserveRooms { get; set; }

        #region Navigation

        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hotel { get; set; }

        #endregion



    }
}
