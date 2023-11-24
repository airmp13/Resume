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
    public class ExperiencesService : IExperiencesService
    {
        private readonly IExperiencesRepository _experiencesRepository;

        public ExperiencesService(IExperiencesRepository experiencesRepository)
        {
            _experiencesRepository = experiencesRepository;
            
        }

        public async Task Create(ExperiencesDTO experiencesDTO)
        {
            await _experiencesRepository.Create(new Experiences()
            {
                Title = experiencesDTO.Title,
                JobTitle = experiencesDTO.JobTitle,
                EntryDateYear = experiencesDTO.EntryDateYear,
                Description = experiencesDTO.Description,
                Icon = experiencesDTO.Icon,
                position = experiencesDTO.position
            });
        }

        public async Task Edit(ExperiencesAdminDTO experiencesAdminDTO)
        {
            await _experiencesRepository.Edit(new Experiences()
            {
                ID = experiencesAdminDTO.ID,
                Title = experiencesAdminDTO.Title,
                JobTitle = experiencesAdminDTO.JobTitle,
                EntryDateYear = experiencesAdminDTO.EntryDateYear,
                Description = experiencesAdminDTO.Description,
                Icon = experiencesAdminDTO.Icon,
                position = experiencesAdminDTO.position
            });
        }
        public async Task Delete(ExperiencesAdminDTO experiencesAdminDTO)
        {
            await _experiencesRepository.Delete(new Experiences()
            {
                ID = experiencesAdminDTO.ID,
                Title = experiencesAdminDTO.Title,
                JobTitle = experiencesAdminDTO.JobTitle,
                EntryDateYear = experiencesAdminDTO.EntryDateYear,
                Description = experiencesAdminDTO.Description,
                Icon = experiencesAdminDTO.Icon,
                position = experiencesAdminDTO.position
            });
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
                ExperiencesAdminDTO ExperienceAdminDTO = new()
                {
                    ID = experience.ID,
                    Title = experience.Title,
                    JobTitle = experience.JobTitle,
                    EntryDateYear = experience.EntryDateYear,
                    Description = experience.Description,
                    Icon = experience.Icon,
                    position = experience.position
                };
                experiencesAdminDTO.Add(ExperienceAdminDTO);
            }

            return experiencesAdminDTO;
        }

        public async Task<ExperiencesAdminDTO> GetExperiencesAdminDTOAsync(int id)
        {
            Experiences experiences = await _experiencesRepository.GetExperiencesAsync(id);
            return new ExperiencesAdminDTO()
            {
                ID = experiences.ID,
                Title = experiences.Title,
                JobTitle = experiences.JobTitle,
                Description = experiences.Description,
                Icon = experiences.Icon,
                position = experiences.position,
                EntryDateYear = experiences.EntryDateYear
            };

        }


        public async Task<List<ExperiencesDTO>> GetExperiencesDTOListAsync()
        {
            List<Experiences> experiences = await GetExperiencesListAsync();
            List<ExperiencesDTO> experiencesDTO = new();

            foreach (Experiences experience in experiences)
            {
                ExperiencesDTO ExperienceDTO = new()
                {
                    Title = experience.Title,
                    JobTitle = experience.JobTitle,
                    EntryDateYear = experience.EntryDateYear,
                    Description = experience.Description,
                    Icon = experience.Icon,
                    position = experience.position
                };
                experiencesDTO.Add(ExperienceDTO);
            }

            return experiencesDTO;
        }

    }
}
