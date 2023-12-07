using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IProjectsService
    {
        Task Create(ProjectsAdminDTO projectsAdminDTO);
        Task<List<Projects>> GetProjectsListAsync();

        Task<Dictionary<string, int>> GetAboutMeProjectsAsync();
        Task<List<ProjectsDTO>> GetProjectsDTOListAsync();

        Task<List<ProjectsAdminDTO>> GetProjectsAdminDTOListAsync();
        Task<ProjectsAdminDTO> GetProjectAdminDTOAsync(int id);

        Task Edit(ProjectsAdminDTO projectsAdminDTO);

        Task Delete(int id);
    }
}
