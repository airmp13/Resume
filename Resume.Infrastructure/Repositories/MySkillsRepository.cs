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
    public class MySkillsRepository : IMySkillsRepository
    {
        private readonly ResumeDbContext _context;

        public MySkillsRepository(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task Create(MySkills mySkills)
        {
            await _context.mySkills.AddAsync(mySkills);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(MySkills mySkills)
        {
            _context.mySkills.Update(mySkills);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(MySkills mySkills)
        {
            _context.mySkills.Remove(mySkills);
            await _context.SaveChangesAsync();
        }
        public async Task<MySkills> GetMySkillsAsync(int id)
        {
            return await _context.mySkills.FirstOrDefaultAsync(e => e.ID == id);

        }

        public async Task<List<MySkills>> GetMySkillsListAsync()
        {
            return await _context.mySkills.ToListAsync(); 
        }
        
        public async Task<List<MySkills>> GetGradedSkillsListAsync(int grade)
        {
            return await _context.mySkills.Where(s => s.grade == grade).ToListAsync();
        }

    }
}
