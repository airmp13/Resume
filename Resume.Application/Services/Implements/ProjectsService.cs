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



    }
}
