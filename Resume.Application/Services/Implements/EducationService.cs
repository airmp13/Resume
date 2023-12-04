using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Mapper;
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
            await _educationRepository.Create(DTOMapper.ToEducations(educationsDTO));
        }

        public async Task Edit(EducationsAdminDTO educationsAdminDTO)
        {
            await _educationRepository.Edit(DTOMapper.ToEducations(educationsAdminDTO));
        }
        public async Task Delete(EducationsAdminDTO educationsAdminDTO)
        {
            await _educationRepository.Delete(DTOMapper.ToEducations(educationsAdminDTO));
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
                educationsDTO.Add(DTOMapper.ToEducationsDTO(education));
            }

            return educationsDTO;
        }


        public async Task<List<EducationsAdminDTO>> GetEducationsAdminDTOListAsync()
        {
            List<Educations> educations = await GetEducationsListAsync();
            List<EducationsAdminDTO> educationsAdminDTOs = new();

            foreach (Educations education in educations)
            {
                educationsAdminDTOs.Add(DTOMapper.ToEducationsAdminDTO(education));
            }

            return educationsAdminDTOs;
        }

        public async Task<EducationsAdminDTO> GetEducationsAdminDTOAsync(int id)
        {
            
            return DTOMapper.ToEducationsAdminDTO(await _educationRepository.GetEducationsAsync(id));

        }

        
    }
}
