﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Site
{
    public class PersonalInformationDTO
    {
        public string ProfilePicPath { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string JobTitle { get; set; }
        public string DescriptionTitle { get; set; }
        public string Description { get; set; }
        public DateTime birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebsiteAddress { get; set; }



    }
}
