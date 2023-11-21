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
    public class AboutMeService : IAboutMeService
    {
        private readonly IAboutMeRepository _aboutMeRepository;

        public AboutMeService(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
            
        }
        public async Task<AboutMe> GetAboutMeAsync()
        {
            return await _aboutMeRepository.GetAboutMeAsync();
        }

        public async Task<AboutMeAdminDTO> GetAboutMeAdminDTOAsync()
        {
            AboutMe about = await _aboutMeRepository.GetAboutMeAsync();

            return new AboutMeAdminDTO()
            {
                ID = about.ID,
                Description1 = about.Description1,
                Description2 = about.Description2,
                subtitle1 = about.subtitle1,
                Title1 = about.Title1,
                Title2 = about.Title2,
                Title1_img = about.Title1_img,
                Title2_img = about.Title2_img
            };
        }

        public async Task<AboutMeDTO> GetAboutMeDTOAsync()
        {
            AboutMe a = await _aboutMeRepository.GetAboutMeAsync();
            return new AboutMeDTO() 
            {
                Description1 = a.Description1,
                Description2 = a.Description2,
                subtitle1 = a.subtitle1,
                Title1= a.Title1,
                Title2= a.Title2,
                Title1_img = a.Title1_img,
                Title2_img = a.Title2_img
            };
        }

        public async Task EditAboutMeAdminDTOAsync(AboutMeAdminDTO aboutMeAdminDTO)
        {
            AboutMe aboutMe = new()
            {
                ID = aboutMeAdminDTO.ID,
                Description1 = aboutMeAdminDTO.Description1,
                Description2 = aboutMeAdminDTO.Description2,
                subtitle1 = aboutMeAdminDTO.subtitle1,
                Title1 = aboutMeAdminDTO.Title1,
                Title2 = aboutMeAdminDTO.Title2,
                Title1_img = aboutMeAdminDTO.Title1_img,
                Title2_img = aboutMeAdminDTO.Title2_img
            };
            await _aboutMeRepository.EditAboutMeAsync(aboutMe);
        }

        
    }
}
