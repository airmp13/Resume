using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Entities
{
    public class Educations
    {
        public int ID { get; set; }

        public string EntryDateYear { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}
