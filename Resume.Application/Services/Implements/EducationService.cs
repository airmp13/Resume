using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using Resume.Infrastructure.Repositories;
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

        public async Task Create(EducationsDTO educationsDTO)
        {
            await _educationRepository.Create(new Educations()
            {
                Title = educationsDTO.Title,
                SubTitle = educationsDTO.SubTitle,
                Description = educationsDTO.Description,
                EntryDateYear = educationsDTO.EntryDateYear
            });
        }

        public async Task Edit(EducationsAdminDTO educationsAdminDTO)
        {
            await _educationRepository.Edit(new Educations()
            {
                ID = educationsAdminDTO.ID,
                Title = educationsAdminDTO.Title,
                SubTitle = educationsAdminDTO.SubTitle,
                Description = educationsAdminDTO.Description,
                EntryDateYear = educationsAdminDTO.EntryDateYear
            });
        }
        public async Task Delete(EducationsAdminDTO educationsAdminDTO)
        {
            await _educationRepository.Delete(new Educations()
            {
                ID = educationsAdminDTO.ID,
                Title = educationsAdminDTO.Title,
                SubTitle = educationsAdminDTO.SubTitle,
                Description = educationsAdminDTO.Description,
                EntryDateYear = educationsAdminDTO.EntryDateYear
            });
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


        public async Task<List<EducationsAdminDTO>> GetEducationsAdminDTOListAsync()
        {
            List<Educations> educations = await GetEducationsListAsync();
            List<EducationsAdminDTO> educationsAdminDTOs = new();

            foreach (Educations education in educations)
            {
                EducationsAdminDTO educationAdminDTO = new()
                {
                    ID = education.ID,
                    Title = education.Title,
                    SubTitle = education.SubTitle,
                    Description = education.Description,
                    EntryDateYear = education.EntryDateYear
                };
                educationsAdminDTOs.Add(educationAdminDTO);
            }

            return educationsAdminDTOs;
        }

        public async Task<EducationsAdminDTO> GetEducationsAdminDTOAsync(int id)
        {
            Educations educations = await _educationRepository.GetEducationsAsync(id);
            return new EducationsAdminDTO()
            {
                ID = educations.ID,
                Title = educations.Title,
                SubTitle = educations.SubTitle,
                Description = educations.Description,
                EntryDateYear = educations.EntryDateYear
            };

        }

        
    }
}
