using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Admin
{
	public class AdminHomePageDTO
	{
        public int ProjectsCount { get; set; }

		public int EducationsCount { get; set; }

		public int ExperiencesCount { get; set; }

		public int UnreadMessagesCount { get; set; }
    }
}
