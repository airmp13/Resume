using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.RepositoryInterfaces
{
    public interface IEducationRepository
    {
        Task Create(Educations educations);
        Task Edit(Educations educations);
        Task Delete(Educations educations);
        Task<Educations> GetEducationsAsync(int id);
        Task<List<Educations>> GetEducationsListAsync();
    }
}
