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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
            
        }
        public async Task<List<Educations>> GetEducationsListAsync()
        {
            return await _educationRepository.GetEducationsListAsync();
        }

        public async Task<List<EducationsDTO>> GetEducationsDTOListAsync()
        {
            List<Educations> educations = await GetEducationsListAsync();
            List<EducationsDTO> educationsDTO = new();

            foreach (Educations education in educations)
            {
                EducationsDTO educationDTO = new()
                {
                    Title = education.Title,
                    EntryDateYear = education.EntryDateYear,
                    Description = education.Description,
                    SubTitle = education.SubTitle
                };
                educationsDTO.Add(educationDTO);
            }

            return educationsDTO;
        }

    }
}
