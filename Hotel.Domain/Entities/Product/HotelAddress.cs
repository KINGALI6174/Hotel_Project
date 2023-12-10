using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class HotelAddress
    {
        [Display(Name = "آدرس هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(500,ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(10,ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
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
        public string Stage { get; set; }


        #region Navigation
        [Key]
        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hetel { get; set; }

        #endregion
    }
}
