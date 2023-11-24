﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Admin
{
    public class UserLoginDTO
    {
        [Required]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]   
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
