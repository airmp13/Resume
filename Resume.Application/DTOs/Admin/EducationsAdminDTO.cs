using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Admin
{
    public class EducationsAdminDTO
    {
        public int ID { get; set; }
        public string EntryDateYear { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
