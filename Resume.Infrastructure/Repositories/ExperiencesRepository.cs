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
    public class ExperiencesRepository : IExperiencesRepository
    {
        private readonly ResumeDbContext _context;

        public ExperiencesRepository(ResumeDbContext context)
        {
            _context = context;
            
        }

        public async Task<List<Experiences>> GetExperiencesListAsync()
        {
            return await _context.experiences.ToListAsync();
        }
    }
}
