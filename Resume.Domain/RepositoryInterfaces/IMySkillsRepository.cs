using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.RepositoryInterfaces
{
    public interface IMySkillsRepository
    {
        Task<List<MySkills>> GetMySkillsListAsync();
        Task<List<MySkills>> GetGradedSkillsListAsync(int grade);
    }
}
