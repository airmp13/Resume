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
    public interface IEducationService
    {
        Task Create(EducationsDTO educationsDTO);

        Task Edit(EducationsAdminDTO educationsAdminDTO);

        Task Delete(EducationsAdminDTO educationsAdminDTO);

        Task<List<EducationsAdminDTO>> GetEducationsAdminDTOListAsync();
        Task<EducationsAdminDTO> GetEducationsAdminDTOAsync(int id);
        Task<List<Educations>> GetEducationsListAsync();

        Task<List<EducationsDTO>> GetEducationsDTOListAsync();
    }
}
