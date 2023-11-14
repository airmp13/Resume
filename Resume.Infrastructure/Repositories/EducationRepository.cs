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
    public class EducationRepository : IEducationRepository
    {
        private readonly ResumeDbContext _context;

        public EducationRepository(ResumeDbContext context)
        {
            _context = context;
        }
        public async Task<List<Educations>> GetEducationsListAsync()
        {
           return await _context.educations.ToListAsync();
        }
    }
}
