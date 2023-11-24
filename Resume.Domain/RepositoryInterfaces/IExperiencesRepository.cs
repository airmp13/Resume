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
        Task<List<Experiences>> GetExperiencesListAsync();
        Task<Experiences> GetExperiencesAsync(int id);

    }
}
