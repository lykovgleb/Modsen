﻿using System.ComponentModel.DataAnnotations;

namespace Modsen.BL.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
