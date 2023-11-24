using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.RepositoryInterfaces
{
    public interface IExperiencesRepository
    {

        Task Create(Experiences experiences);
        Task Edit(Experiences experiences);
        Task Delete(Experiences experiences);
        Task<Experiences> GetExperiencesAsync(int id);
        Task<List<Experiences>> GetExperiencesListAsync();
        

    }
}
