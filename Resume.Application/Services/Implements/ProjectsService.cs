using Microsoft.AspNetCore.Hosting;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Mapper;
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
		private readonly IUploadService _uploadService;
		private readonly IHostingEnvironment _hostingEnvironment;

		public ProjectsService(IProjectsRepository projectsRepository,
            IUploadService uploadService,
            IHostingEnvironment hostingEnvironment)
        {
            _projectsRepository = projectsRepository;
			_uploadService = uploadService;
			_hostingEnvironment = hostingEnvironment;
		}

        public async Task Create(ProjectsAdminDTO projectsAdminDTO)
        {
            projectsAdminDTO.PicPath = "null";
            if(projectsAdminDTO.Pic != null)
            {
                projectsAdminDTO.PicPath = _uploadService.UploadFile(projectsAdminDTO.Pic, "HomeFiles/images");
            }

            await _projectsRepository.Create(DTOMapper.ToProjects(projectsAdminDTO));
        }

		public async Task Edit(ProjectsAdminDTO projectsAdminDTO)
		{
            if(projectsAdminDTO.Pic != null)
            {
                if(projectsAdminDTO.PicPath != null)
                {
                    string existfile = Path.Combine(_hostingEnvironment.WebRootPath, projectsAdminDTO.PicPath);
                    System.IO.File.Delete(existfile);
                }
                projectsAdminDTO.PicPath = _uploadService.UploadFile(projectsAdminDTO.Pic, "HomeFiles/images");
            }
			await _projectsRepository.Edit(DTOMapper.ToProjects(projectsAdminDTO));
		}

		public async Task Delete(int id)
		{
            Projects projects = await _projectsRepository.GetProjectsAsync(id);
            string existfile = Path.Combine(_hostingEnvironment.WebRootPath,projects.PicPath);
            System.IO.File.Delete( existfile);  
			await _projectsRepository.Delete(projects);

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
                projectsDTO.Add(DTOMapper.ToProjectsDTO(project));
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
                projectsAdminDTO.Add(DTOMapper.ToProjectsAdminDTO(project));
            }

            return projectsAdminDTO;
        }


        public async Task<ProjectsAdminDTO> GetProjectAdminDTOAsync(int id)
        {


            return DTOMapper.ToProjectsAdminDTO(await _projectsRepository.GetProjectsAsync(id));

        }

        

    }
}
