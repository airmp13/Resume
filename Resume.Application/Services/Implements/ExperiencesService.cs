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
    public class ExperiencesService : IExperiencesService
    {
        private readonly IExperiencesRepository _experiencesRepository;

        public ExperiencesService(IExperiencesRepository experiencesRepository)
        {
            _experiencesRepository = experiencesRepository;
            
        }

        public async Task Create(ExperiencesDTO experiencesDTO)
        {
            await _experiencesRepository.Create(DTOMapper.ToExperiences(experiencesDTO));
        }

        public async Task Edit(ExperiencesAdminDTO experiencesAdminDTO)
        {
            await _experiencesRepository.Edit(DTOMapper.ToExperiences(experiencesAdminDTO));
        }
        public async Task Delete(ExperiencesAdminDTO experiencesAdminDTO)
        {
            await _experiencesRepository.Delete(DTOMapper.ToExperiences(experiencesAdminDTO));
        }



        public async Task<List<Experiences>> GetExperiencesListAsync()
        {
            return await _experiencesRepository.GetExperiencesListAsync();
        }


        public async Task<List<ExperiencesAdminDTO>> GetExperiencesAdminDTOListAsync()
        {
            List<Experiences> experiences = await GetExperiencesListAsync();
            List<ExperiencesAdminDTO> experiencesAdminDTO = new();

            foreach (Experiences experience in experiences)
            {
                
                experiencesAdminDTO.Add(DTOMapper.ToExperiencesAdminDTO(experience));
            }

            return experiencesAdminDTO;
        }

        public async Task<ExperiencesAdminDTO> GetExperiencesAdminDTOAsync(int id)
        {
             
            return DTOMapper.ToExperiencesAdminDTO(await _experiencesRepository.GetExperiencesAsync(id));

        }


        public async Task<List<ExperiencesDTO>> GetExperiencesDTOListAsync()
        {
            List<Experiences> experiences = await GetExperiencesListAsync();
            List<ExperiencesDTO> experiencesDTO = new();

            foreach (Experiences experience in experiences)
            {
                experiencesDTO.Add(DTOMapper.ToExperiencesDTO(experience));
            }

            return experiencesDTO;
        }

    }
}
