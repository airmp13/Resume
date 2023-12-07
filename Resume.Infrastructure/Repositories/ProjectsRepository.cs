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

        public async Task Create(Projects projects)
        {
            await _context.projects.AddAsync(projects);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Projects>> GetProjectsListAsync()
        {
            return await _context.projects.ToListAsync();
        }

        public async Task<Projects> GetProjectsAsync(int id)
        {
            return await _context.projects.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task Edit(Projects projects)
        {

            _context.projects.Update(projects);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Projects projects)
        {
            _context.projects.Remove(projects);
			await _context.SaveChangesAsync();

		}

        
	}
}
