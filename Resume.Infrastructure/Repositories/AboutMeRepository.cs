using Microsoft.EntityFrameworkCore;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Repositories
{
    public class AboutMeRepository : IAboutMeRepository
    {
        private readonly ResumeDbContext _resumeDbContext;

        public AboutMeRepository(ResumeDbContext resumeDbContext)
        {
            _resumeDbContext = resumeDbContext;
        }

        public async Task EditAboutMeAsync(AboutMe aboutMe)
        {
            _resumeDbContext.aboutMe.Update(aboutMe);
            await _resumeDbContext.SaveChangesAsync();

        }

        public async Task<AboutMe> GetAboutMeAsync()
        {

            return await _resumeDbContext.aboutMe.FirstOrDefaultAsync();
        }

        
    }
}
