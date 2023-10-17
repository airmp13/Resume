using Microsoft.EntityFrameworkCore;
using Resume.Domain;
using Resume.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application
{
	public class AllDTOService : IAllDTOService
	{
		private ResumeDbContext _resumeDbContext;
		public AllDTOService(ResumeDbContext resumeDbContext) {
			_resumeDbContext = resumeDbContext;
		}

		public async Task<AllDTO> GetAllDTOAsync()
		{
			AllDTO? allDTO = new AllDTO();
			Dictionary<string,int> proj=new Dictionary<string,int>();

			allDTO.PersonalInformation = await _resumeDbContext.personalInformation.FirstOrDefaultAsync();
			allDTO.AboutMe = await _resumeDbContext.aboutMe.FirstOrDefaultAsync();
			allDTO.ProjectsList = await _resumeDbContext.projects.ToListAsync();
			allDTO.ExperiencesList = await _resumeDbContext.experiences.ToListAsync();
			allDTO.EducationsList = await _resumeDbContext.educations.ToListAsync();
			allDTO.MySkillsGrade0List = await _resumeDbContext.mySkills.Where(s=> s.grade==0).ToListAsync();
			allDTO.MySkillsGrade1List = await _resumeDbContext.mySkills.Where(s => s.grade == 1).ToListAsync();


			foreach (Projects item in allDTO.ProjectsList)
			{
				int count = 0;
				if (proj.Count==0 || !proj.ContainsKey(item.language))
				{
					foreach (Projects projects in allDTO.ProjectsList)
					{
						if (item.language == projects.language) count++;
					}

					proj.Add(item.language, count);

				}

				

			}

			allDTO.AboutmeProject = proj;
			return allDTO;
			
		}
	
		public async Task<bool> submitContactme(ContactMe contactMe)
		{
			_resumeDbContext.AddAsync(contactMe);
			_resumeDbContext.SaveChanges();
			return true;
		}
	
	
	}
}
