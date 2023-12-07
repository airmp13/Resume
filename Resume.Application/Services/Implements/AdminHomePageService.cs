using Resume.Application.DTOs.Admin;
using Resume.Application.Services.Interfaces;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
	public class AdminHomePageService :IAdminHomePageService
	{
		private readonly IAdminHomePageRepository _adminHomePageRepository;

		public AdminHomePageService(IAdminHomePageRepository adminHomePageRepository)
        {
			_adminHomePageRepository = adminHomePageRepository;
		}

		

		public async Task<AdminHomePageDTO> GetAll()
		{
			AdminHomePageDTO adminHomePageDTO = new();
			
			adminHomePageDTO.ProjectsCount = await _adminHomePageRepository.GetProjectsCounts();
			adminHomePageDTO.UnreadMessagesCount = await _adminHomePageRepository.GetUnredMessagesCount();
			adminHomePageDTO.EducationsCount = await _adminHomePageRepository.GetEducationsCount();
			adminHomePageDTO.ExperiencesCount = await _adminHomePageRepository.GetExperiencesCount();
			return adminHomePageDTO;
		}
		
	}
}
