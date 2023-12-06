﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities.Account
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام")]
        public string? FName { get; set; }


        [Display(Name = "نام خانوادگی")]
        public string? LName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Email { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Password{ get; set; }



    }
}