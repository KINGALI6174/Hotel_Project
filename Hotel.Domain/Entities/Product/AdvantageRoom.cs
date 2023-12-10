using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Product
{
    public class AdvantageRoom
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(25,ErrorMessage = "تعداد کارکترها نمیتواند بیش تر از{1}باشد")]
        [MinLength(2,ErrorMessage = "تعداد کارکترها نمیتواند کمتر از{1}باشد")]
        public string Name { get; set; }

        public ICollection<AdvantageToRoom> AdvantageToRooms { get; set; }
    }
}
