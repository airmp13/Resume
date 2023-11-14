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
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ResumeDbContext _context;

        public ProjectsRepository(ResumeDbContext context)
        {
            _context = context;
        }
        public async Task<List<Projects>> GetProjectsListAsync()
        {
            return await _context.projects.ToListAsync();
        }
    }
}
