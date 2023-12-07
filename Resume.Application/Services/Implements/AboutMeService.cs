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
    public class AboutMeService : IAboutMeService
    {
        private readonly IAboutMeRepository _aboutMeRepository;
		private readonly IUploadService _uploadService;
		private readonly IHostingEnvironment _hostingEnvironment;

		public AboutMeService(IAboutMeRepository aboutMeRepository,
            IUploadService uploadService,
            IHostingEnvironment hostingEnvironment)
        {
            _aboutMeRepository = aboutMeRepository;
			_uploadService = uploadService;
			_hostingEnvironment = hostingEnvironment;
		}
        public async Task<AboutMe> GetAboutMeAsync()
        {
            return await _aboutMeRepository.GetAboutMeAsync();
        }

        public async Task<AboutMeAdminDTO> GetAboutMeAdminDTOAsync()
        {
            AboutMe aboutMe = await _aboutMeRepository.GetAboutMeAsync();

            return DTOMapper.ToAboutMeAdminDTO(aboutMe);
        }

        public async Task<AboutMeDTO> GetAboutMeDTOAsync()
        {
            AboutMe aboutMe = await _aboutMeRepository.GetAboutMeAsync();
            return DTOMapper.ToAboutMeDTO(aboutMe);
        }

        public async Task EditAboutMeAdminDTOAsync(AboutMeAdminDTO aboutMeAdminDTO)
        {
            
                if(aboutMeAdminDTO.Title1_Pic != null)
                {
                    if (aboutMeAdminDTO.Title1_PicPath != null)
                    {
					string existfile = Path.Combine(_hostingEnvironment.WebRootPath, aboutMeAdminDTO.Title1_PicPath);
					System.IO.File.Delete(existfile);
				    }
                    aboutMeAdminDTO.Title1_PicPath = _uploadService.UploadFile(aboutMeAdminDTO.Title1_Pic, "HomeFiles/images");

                }

				if (aboutMeAdminDTO.Title2_Pic != null )
				{
                    if (aboutMeAdminDTO.Title2_PicPath != null)
                    {
					    string existfile = Path.Combine(_hostingEnvironment.WebRootPath, aboutMeAdminDTO.Title2_PicPath);
					    System.IO.File.Delete(existfile);
				    }

					aboutMeAdminDTO.Title2_PicPath = _uploadService.UploadFile(aboutMeAdminDTO.Title2_Pic, "HomeFiles/images");
				}

            await _aboutMeRepository.EditAboutMeAsync(DTOMapper.ToAboutMe(aboutMeAdminDTO));
        }

        
    }
}
