﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Entities
{
    public class Projects
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string language { get; set; }

        public string PicPath { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }


    }
}
