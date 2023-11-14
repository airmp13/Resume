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
        public async Task<List<Experiences>> GetExperiencesListAsync()
        {
            return await _experiencesRepository.GetExperiencesListAsync();
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
