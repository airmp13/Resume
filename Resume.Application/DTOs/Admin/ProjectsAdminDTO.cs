﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Admin
{
    public class ProjectsAdminDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string language { get; set; }

        public string img { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }


    }
}