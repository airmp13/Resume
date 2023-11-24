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

        public async Task Create(Educations educations)
        {
            await _context.educations.AddAsync(educations);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Educations educations)
        {
            _context.educations.Update(educations);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Educations educations)
        {
            _context.educations.Remove(educations);
            await _context.SaveChangesAsync();
        }

        public async Task<Educations> GetEducationsAsync(int id)
        {
            return await _context.educations.FirstOrDefaultAsync(e => e.ID == id);

        }

        public async Task<List<Educations>> GetEducationsListAsync()
        {
           return await _context.educations.ToListAsync();
        }
    }
}
