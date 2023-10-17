using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain
{
    public class Experiences
    {
        public int ID { get; set; }

        public string EntryDateYear { get; set; }
        public string JobTitle { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string position { get; set; }
    }
}
