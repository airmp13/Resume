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
            
            await _aboutMeRepository.EditAboutMeAsync(DTOMapper.ToAboutMe(aboutMeAdminDTO));
        }

        
    }
}
