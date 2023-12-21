using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class HotelGallery
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string ImageName { get; set; }

        #region Navigation

        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel hotel { get; set; }

        #endregion
    }
}
