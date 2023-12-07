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
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly ResumeDbContext _resumeDbContext;

        public PersonalInformationRepository(ResumeDbContext resumeDbContext)
        {
            _resumeDbContext = resumeDbContext;
        }

        public async Task EditPersonalInformationAsync(PersonalInformation personalInformation)
        {
              _resumeDbContext.personalInformation.Update(personalInformation);
             await _resumeDbContext.SaveChangesAsync();
           
        }

        public async Task<PersonalInformation> GetPersonalInformationAsync()
        {


            return await _resumeDbContext.personalInformation.FirstOrDefaultAsync();
        }
    }
}
