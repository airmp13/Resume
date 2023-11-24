using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task Create(ProjectsDTO projectsDTO)
        {
            await _projectsRepository.Create(new Projects()
            {
                Name = projectsDTO.Name,
                Description = projectsDTO.Description,
                img = projectsDTO.img,
                language = projectsDTO.language,
                Url = projectsDTO.Url
            });
        }
        public async Task<List<Projects>> GetProjectsListAsync()
        {
            return await _projectsRepository.GetProjectsListAsync();
        }

        public async Task<List<ProjectsDTO>> GetProjectsDTOListAsync()
        {
            List<Projects> projects = await GetProjectsListAsync();
            List<ProjectsDTO> projectsDTO = new();

            foreach (Projects project in projects)
            {
                ProjectsDTO projectDTO = new() 
                { 
                    Name = project.Name,
                    Description = project.Description,
                    img = project.img,
                    language = project.language,
                    Url = project.Url
                };
                projectsDTO.Add(projectDTO);
            }

            return projectsDTO;
        }


        public async Task<Dictionary<string, int>> GetAboutMeProjectsAsync()
        {
            List<Projects> projectsList = await GetProjectsListAsync();
            Dictionary<string, int> proj = new Dictionary<string, int>();

            foreach (Projects item in projectsList)
            {
                int count = 0;
                if (proj.Count == 0 || !proj.ContainsKey(item.language))
                {
                    foreach (Projects projects in projectsList)
                    {
                        if (item.language == projects.language) count++;
                    }

                    proj.Add(item.language, count);

                }



            }

            return proj;


        }


        public async Task<List<ProjectsAdminDTO>> GetProjectsAdminDTOListAsync()
        {
            List<Projects> projects = await GetProjectsListAsync();
            List<ProjectsAdminDTO> projectsAdminDTO = new();

            foreach (Projects project in projects)
            {
                ProjectsAdminDTO projectDTO = new()
                {
                    ID = project.ID,
                    Name = project.Name,
                    Description = project.Description,
                    img = project.img,
                    language = project.language,
                    Url = project.Url
                };
                projectsAdminDTO.Add(projectDTO);
            }

            return projectsAdminDTO;
        }


        public async Task<ProjectsAdminDTO> GetProjectAdminDTOAsync(int id)
        {
            Projects project = await _projectsRepository.GetProjectsAsync(id);

            return new ProjectsAdminDTO()
            {
                ID = project.ID,
                Name = project.Name,
                Description = project.Description,
                img = project.img,
                language = project.language,
                Url = project.Url
            };

        }

        public async Task Edit(ProjectsAdminDTO projectsAdminDTO)
        {
            await _projectsRepository.Edit(new Projects()
            {
                Description = projectsAdminDTO.Description,
                ID = projectsAdminDTO.ID,
                Name = projectsAdminDTO.Name,
                Url = projectsAdminDTO.Url,
                img = projectsAdminDTO.img,
                language=projectsAdminDTO.language
                
            });
        }

        public async Task Delete(int id)
        {
            
            await _projectsRepository.Delete(await _projectsRepository.GetProjectsAsync(id));
        }

    }
}
