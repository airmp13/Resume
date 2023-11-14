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
        public async Task<AboutMe> GetAboutMesAsync()
        {
            return await _aboutMeRepository.GetAboutMeAsync();
        }

        public async Task<AboutMeDTO> GetAboutMesDTOAsync()
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





    }
}
