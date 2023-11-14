using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.Entities;

namespace Resume.Application.DTOs.Site
{
    public class SinglePageDTO
	{
		public PersonalInformationDTO PersonalInformationDTO { get; set; }
		public AboutMeDTO AboutMeDTO { get; set; }

		public ContactMeDTO ContactMeDTO { get; set; }

		public List<ProjectsDTO> ProjectsDTOList { get; set; }
		public List<ExperiencesDTO> ExperiencesDTOList { get; set; }

		public List<EducationsDTO> EducationsDTOList { get; set; }

		public List<MySkillsDTO> MySkillsDTOGrade0List { get; set; }
		public List<MySkillsDTO> MySkillsDTOGrade1List { get; set; }
		public Dictionary<string,int> AboutmeProject { get; set; }



	}
}
