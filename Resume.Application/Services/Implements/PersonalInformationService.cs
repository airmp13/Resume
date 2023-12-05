using Microsoft.EntityFrameworkCore;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Mapper;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using Resume.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private IPersonalInformationRepository _personalInformationRepository;

        public PersonalInformationService(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        public async Task EditPersonalInformationAsync(PersonalInformationAdminDTO personalInformationAdminDTO)
        {
            await _personalInformationRepository.EditPersonalInformationAsync(DTOMapper.ToPersonalInformation(personalInformationAdminDTO));
        }

        public async Task<PersonalInformationAdminDTO> GetPersonalInformationAdminDTOAsync()
        {

            return DTOMapper.ToPersonalInformationAdminDTO(await _personalInformationRepository.GetPersonalInformationAsync());
        }

        public async Task<PersonalInformationDTO> GetPersonalInformationDTOAsync()
        {
            return DTOMapper.ToPersonalInformationDTO(await _personalInformationRepository.GetPersonalInformationAsync());
        }
    }
}
