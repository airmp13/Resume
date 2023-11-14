using Microsoft.EntityFrameworkCore;
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

        public async Task EditPersonalInformationAsync(PersonalInformation personalInformation)
        {
            _personalInformationRepository.EditPersonalInformationAsync(personalInformation);
        }

        public async Task<PersonalInformation> GetPersonalInformationAsync()
        {

            return await _personalInformationRepository.GetPersonalInformationAsync();
        }

        public async Task<PersonalInformationDTO> GetPersonalInformationDTOAsync()
        {
            PersonalInformation personalInformation = await GetPersonalInformationAsync();
            PersonalInformationDTO personalInformationDTO = new();

            personalInformationDTO.FName = personalInformation.FName;
            personalInformationDTO.LName = personalInformation.LName;
            personalInformationDTO.Address = personalInformation.Address;
            personalInformationDTO.WebsiteAddress = personalInformation.WebsiteAddress;
            personalInformationDTO.birthdate = personalInformation.birthdate;
            personalInformationDTO.Description = personalInformation.Description;
            personalInformationDTO.DescriptionTitle = personalInformation.DescriptionTitle;
            personalInformationDTO.Email = personalInformation.Email;
            personalInformationDTO.JobTitle = personalInformation.JobTitle;
            personalInformationDTO.Phone = personalInformation.Phone;
            personalInformationDTO.Picture = personalInformation.Picture;
            
            
            return personalInformationDTO;
        }
    }
}
