using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Admin

{
    public class AboutMeAdminDTO
    {
        public int ID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title1_PicPath { get; set; }
        public IFormFile Title1_Pic{ get; set; }
        public string Title2_PicPath { get; set; }

        public IFormFile Title2_Pic { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string subtitle1 { get; set; }

        public bool IsRead { get; set; }





    }
}
