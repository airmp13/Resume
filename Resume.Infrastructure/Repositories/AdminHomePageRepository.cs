using Microsoft.EntityFrameworkCore;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Repositories
{
	public class AdminHomePageRepository : IAdminHomePageRepository
	{
		private readonly ResumeDbContext _resumeDbContext;

		public AdminHomePageRepository(ResumeDbContext resumeDbContext)
        {
			_resumeDbContext = resumeDbContext;
		}
        public async Task<int> GetEducationsCount()
		{
			return await _resumeDbContext.educations.CountAsync();
		}

		public async Task<int> GetExperiencesCount()
		{
			return await _resumeDbContext.experiences.CountAsync();
		}

		public async Task<int> GetUnredMessagesCount()
		{
			return await _resumeDbContext.contactMe.Where(m=> m.IsRead ==false).CountAsync();
		}

		public async Task<int> GetProjectsCounts()
		{
			return await _resumeDbContext.projects.CountAsync();
		}
	}
}
