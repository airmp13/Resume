using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IExperiencesService
    {

        Task Create(ExperiencesDTO experiencesDTO);

        Task Edit(ExperiencesAdminDTO experiencesAdminDTO);

        Task Delete(ExperiencesAdminDTO experiencesAdminDTO);

        Task<List<Experiences>> GetExperiencesListAsync();

        Task<List<ExperiencesDTO>> GetExperiencesDTOListAsync();

        Task<List<ExperiencesAdminDTO>> GetExperiencesAdminDTOListAsync();
        Task<ExperiencesAdminDTO> GetExperiencesAdminDTOAsync(int id);

    }
}
