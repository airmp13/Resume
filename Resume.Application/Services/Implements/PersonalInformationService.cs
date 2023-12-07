using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Mapper;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IUploadService _uploadService;

        public PersonalInformationService(IPersonalInformationRepository personalInformationRepository,
            IHostingEnvironment hostingEnvironment,
            IUploadService uploadService)
        {
            _personalInformationRepository = personalInformationRepository;
            _hostingEnvironment = hostingEnvironment;
            _uploadService = uploadService;
        }

        public async Task EditPersonalInformationAsync(PersonalInformationAdminDTO personalInformationAdminDTO)
        {


            if (personalInformationAdminDTO.ProfilePicture != null)
            {
                if (personalInformationAdminDTO.ProfilePicPath != null)
                {
                    string existfile = Path.Combine(_hostingEnvironment.WebRootPath, personalInformationAdminDTO.ProfilePicPath);
                    System.IO.File.Delete(existfile);
                }
                personalInformationAdminDTO.ProfilePicPath = _uploadService.UploadFile(personalInformationAdminDTO.ProfilePicture, "HomeFiles/images");
            }

            await _personalInformationRepository.EditPersonalInformationAsync(DTOMapper.ToPersonalInformation(personalInformationAdminDTO));
        }

        public async Task<PersonalInformationAdminDTO> GetPersonalInformationAdminDTOAsync()
        {

            return DTOMapper.ToPersonalInformationAdminDTO(await _personalInformationRepository.GetPersonalInformationAsync());
        }

        public async Task<PersonalInformationDTO> GetPersonalInformationDTOAsync()
        {
            return DTOMapper.ToPersonalInformationDTO(await _personalInformationRepository.GetPersonalInformationAsync());
        }
    }
}
