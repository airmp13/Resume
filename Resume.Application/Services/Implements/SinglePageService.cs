using Microsoft.EntityFrameworkCore;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using Resume.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
    public class SinglePageService : ISinglePageService
    {
        private readonly IPersonalInformationService _personalInformationService;
        private readonly IAboutMeService _aboutMeService;
        private readonly IEducationService _educationService;
        private readonly IExperiencesService _experiencesService;
        private readonly IMySkillsService _mySkillsService;
        private readonly IProjectsService _projectsService;
        private readonly IContactMeService _contactMeService;

        public SinglePageService(IPersonalInformationService personalInformationService,
                                  IAboutMeService aboutMeService,
                                  IEducationService educationService,
                                  IExperiencesService experiencesService,
                                  IMySkillsService mySkillsService,
                                  IProjectsService projectsService,
                                  IContactMeService contactMeService)
        {
            _personalInformationService = personalInformationService;
            _aboutMeService = aboutMeService;
            _educationService = educationService;
            _experiencesService = experiencesService;
            _mySkillsService = mySkillsService;
            _projectsService = projectsService;
            _contactMeService = contactMeService;
        }

        public async Task<SinglePageDTO> GetSinglePageDTOAsync()
        {
            SinglePageDTO? singlePageDTO = new SinglePageDTO();


            singlePageDTO.PersonalInformationDTO = await _personalInformationService.GetPersonalInformationDTOAsync();
            singlePageDTO.AboutMeDTO = await _aboutMeService.GetAboutMesDTOAsync();
            singlePageDTO.AboutmeProject = await _projectsService.GetAboutMeProjectsAsync();
            singlePageDTO.ProjectsDTOList = await _projectsService.GetProjectsDTOListAsync();
            singlePageDTO.ExperiencesDTOList = await _experiencesService.GetExperiencesDTOListAsync();
            singlePageDTO.EducationsDTOList = await _educationService.GetEducationsDTOListAsync();
            singlePageDTO.MySkillsDTOGrade0List = await _mySkillsService.GetGradedMySkillsDTOListAsync(0);
            singlePageDTO.MySkillsDTOGrade1List = await _mySkillsService.GetGradedMySkillsDTOListAsync(1);

            return singlePageDTO;

        }

        public async Task submitContactme(ContactMeDTO contactMeDTO)
        {
                await _contactMeService.SubmitNewContactMe(contactMeDTO);
               
        }


    }
}
