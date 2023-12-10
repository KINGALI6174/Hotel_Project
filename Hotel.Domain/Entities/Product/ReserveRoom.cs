using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class ReserveRoom
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "تاریخ رزرو")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public DateTime ReserveDate { get; set; }
        [Display(Name = "تعداد اتاق")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int Count { get; set;}
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public int price { get; set; }
        [Display(Name = "وضعیت رزرو")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public bool IsReserve { get; set; }

        public int roomId { get; set; }

        [ForeignKey(nameof(roomId))]
        public HotelRoom HotelRoom { get; set; }
    }
}
