using Microsoft.EntityFrameworkCore;
using Resume.Domain;
using Resume.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private  ResumeDbContext _context;

        public PersonalInformationService(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalInformation> GetPersonalInformationAsync()
        {
            
            return await _context.personalInformation.FirstOrDefaultAsync();
        }
    }
}
