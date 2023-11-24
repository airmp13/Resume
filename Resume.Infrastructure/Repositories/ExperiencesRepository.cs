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

        public async Task Create(Experiences experiences)
        {
            await _context.experiences.AddAsync(experiences);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Experiences experiences)
        {
            _context.experiences.Update(experiences);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Experiences experiences)
        {
            _context.experiences.Remove(experiences);
            await _context.SaveChangesAsync();
        }

        public async Task<Experiences> GetExperiencesAsync(int id)
        {
            return await _context.experiences.FirstOrDefaultAsync(e => e.ID == id);

        }

        public async Task<List<Experiences>> GetExperiencesListAsync()
        {
            return await _context.experiences.ToListAsync();
        }

        
    }
}
