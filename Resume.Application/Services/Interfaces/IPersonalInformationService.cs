using Resume.Application.DTOs.Site;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IPersonalInformationService
    {
        Task<PersonalInformation> GetPersonalInformationAsync();
        Task<PersonalInformationDTO> GetPersonalInformationDTOAsync();

        Task EditPersonalInformationAsync(PersonalInformation personalInformation);
    }
}
