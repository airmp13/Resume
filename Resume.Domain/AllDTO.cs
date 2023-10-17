using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain
{
	public class AllDTO
	{
		public PersonalInformation PersonalInformation { get; set; }
		public AboutMe AboutMe { get; set; }

		public ContactMe ContactMe { get; set; }

		public List<Projects> ProjectsList { get; set; }
		public List<Experiences> ExperiencesList { get; set; }

		public List<Educations> EducationsList { get; set; }

		public List<MySkills> MySkillsGrade0List { get; set; }
		public List<MySkills> MySkillsGrade1List { get; set; }
		public Dictionary<string,int> AboutmeProject { get; set; }



	}
}
