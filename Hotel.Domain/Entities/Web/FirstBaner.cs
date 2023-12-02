using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hotel.Domain.Entities.Web
{
    public class FirstBaner
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید")]
        public string banerTitle { get; set; }
        [Display(Name = "متن دکمه")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید")]
        public string banerBotton { get; set; }
        [Display(Name = "تصویر بنر")]
        public string ImageName { get; set; }

    }
}
