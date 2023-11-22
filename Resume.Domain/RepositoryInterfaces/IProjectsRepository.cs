using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.RepositoryInterfaces
{
    public interface IProjectsRepository
    {
        Task Create(Projects projects);
        Task<List<Projects>> GetProjectsListAsync();
        Task<Projects> GetProjectsAsync(int id);

        Task Edit(Projects projects);


        Task Delete(Projects projects);
    }
}
