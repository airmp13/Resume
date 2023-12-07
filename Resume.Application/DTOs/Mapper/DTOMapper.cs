using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.DTOs.Mapper
{
    public static class DTOMapper
    {

        #region AboutMe Mappings

        public static AboutMeDTO ToAboutMeDTO(AboutMe aboutMe)
        {

            return new AboutMeDTO()
            {
                Description1 = aboutMe.Description1,
                Description2 = aboutMe.Description2,
                subtitle1 = aboutMe.subtitle1,
                Title1 = aboutMe.Title1,
                Title2 = aboutMe.Title2,
                Title1_img = aboutMe.Title1_img,
                Title2_img = aboutMe.Title2_img
            };

        }

        public static AboutMeAdminDTO ToAboutMeAdminDTO(AboutMe aboutMe)
        {
            return new AboutMeAdminDTO()
            {
                ID = aboutMe.ID,
                Description1 = aboutMe.Description1,
                Description2 = aboutMe.Description2,
                subtitle1 = aboutMe.subtitle1,
                Title1 = aboutMe.Title1,
                Title2 = aboutMe.Title2,
                Title1_img = aboutMe.Title1_img,
                Title2_img = aboutMe.Title2_img
            };
        }

        public static AboutMe ToAboutMe(AboutMeAdminDTO aboutMeAdminDTO)
        {
            return new AboutMe()
            {
                ID = aboutMeAdminDTO.ID,
                Description1 = aboutMeAdminDTO.Description1,
                Description2 = aboutMeAdminDTO.Description2,
                subtitle1 = aboutMeAdminDTO.subtitle1,
                Title1 = aboutMeAdminDTO.Title1,
                Title2 = aboutMeAdminDTO.Title2,
                Title1_img = aboutMeAdminDTO.Title1_img,
                Title2_img = aboutMeAdminDTO.Title2_img
            };
        }

        #endregion

        #region ContactMe Mappings

        public static ContactMe ToContactMe(ContactMeDTO contactMeDTO)
        {
            return new ContactMe() 
            {
                Name = contactMeDTO.Name,
                Email = contactMeDTO.Email,
                Message = contactMeDTO.Message,
                PhoneNumber = contactMeDTO.PhoneNumber

            };
        }

        public static ContactMe ToContactMe(ContactMeAdminDTO contactMeAdminDTO)
        {
            return new ContactMe()
            {
                ID = contactMeAdminDTO.ID,
                Email = contactMeAdminDTO.Email,
                Message = contactMeAdminDTO.Message,
                PhoneNumber = contactMeAdminDTO.PhoneNumber,
				IsRead = contactMeAdminDTO.IsRead

			};
        }

        public static ContactMeAdminDTO ToContactMeAdminDTO(ContactMe contactMe)
        {
            return new ContactMeAdminDTO()
            {
                ID = contactMe.ID,
                Email = contactMe.Email,
                Message = contactMe.Message,
                PhoneNumber = contactMe.PhoneNumber,
				IsRead = contactMe.IsRead
			};
        }





        #endregion

        #region Education Mappings

        public static Educations ToEducations(EducationsDTO educationsDTO)
        {
            return new Educations()
            {
                Title = educationsDTO.Title,
                SubTitle = educationsDTO.SubTitle,
                Description = educationsDTO.Description,
                EntryDateYear = educationsDTO.EntryDateYear
            };
        }

        public static Educations ToEducations(EducationsAdminDTO educationsAdminDTO)
        {
            return new Educations()
            {
                ID = educationsAdminDTO.ID,
                Title = educationsAdminDTO.Title,
                SubTitle = educationsAdminDTO.SubTitle,
                Description = educationsAdminDTO.Description,
                EntryDateYear = educationsAdminDTO.EntryDateYear
            };
        }

        public static EducationsDTO ToEducationsDTO(Educations educations)
        {
            return new EducationsDTO()
            {
                Title = educations.Title,
                EntryDateYear = educations.EntryDateYear,
                Description = educations.Description,
                SubTitle = educations.SubTitle
            };
        }

        public static EducationsAdminDTO ToEducationsAdminDTO(Educations educations)
        {
            return new EducationsAdminDTO()
            {
                ID = educations.ID,
                Title = educations.Title,
                SubTitle = educations.SubTitle,
                Description = educations.Description,
                EntryDateYear = educations.EntryDateYear
            };
        }

        #endregion

        #region Experience Mapping

        public static Experiences ToExperiences(ExperiencesDTO experiencesDTO)
        {
            return new Experiences()
            {
                Title = experiencesDTO.Title,
                JobTitle = experiencesDTO.JobTitle,
                EntryDateYear = experiencesDTO.EntryDateYear,
                Description = experiencesDTO.Description,
                Icon = experiencesDTO.Icon,
                position = experiencesDTO.position
            };
        }

        public static Experiences ToExperiences(ExperiencesAdminDTO experiencesAdminDTO)
        {
            return new Experiences()
            {
                ID = experiencesAdminDTO.ID,
                Title = experiencesAdminDTO.Title,
                JobTitle = experiencesAdminDTO.JobTitle,
                EntryDateYear = experiencesAdminDTO.EntryDateYear,
                Description = experiencesAdminDTO.Description,
                Icon = experiencesAdminDTO.Icon,
                position = experiencesAdminDTO.position
            };
        }

        public static ExperiencesDTO ToExperiencesDTO(Experiences experiences)
        {
            return new ExperiencesDTO()
            {
                Title = experiences.Title,
                JobTitle = experiences.JobTitle,
                EntryDateYear = experiences.EntryDateYear,
                Description = experiences.Description,
                Icon = experiences.Icon,
                position = experiences.position
            };
        }

        public static ExperiencesAdminDTO ToExperiencesAdminDTO(Experiences experiences)
        {
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
        #endregion

        #region MySkills Mapping

        public static MySkills ToMySkill(MySkillsDTO mySkillsDTO)
        {

            return new MySkills()
            {
                Name = mySkillsDTO.Name,
                grade = mySkillsDTO.grade,
                Value = mySkillsDTO.Value
            };

        }

        public static MySkills ToMySkill(MySkillsAdminDTO mySkillsAdminDTO)
        {
           return new MySkills()
            {
                ID = mySkillsAdminDTO.ID,
                Name = mySkillsAdminDTO.Name,
                grade = mySkillsAdminDTO.grade,
                Value = mySkillsAdminDTO.Value
            };
        }

        public static MySkillsDTO ToMySkillDTO(MySkills mySkills)
        {
            return new MySkillsDTO()
            {
                Name = mySkills.Name,
                grade = mySkills.grade,
                Value = mySkills.Value
            };
        }

        public static MySkillsAdminDTO ToMySkillsAdminDTO(MySkills mySkills)
        {
            return new MySkillsAdminDTO()
            {
                ID = mySkills.ID,
                Name = mySkills.Name,
                grade = mySkills.grade,
                Value = mySkills.Value
            };
        }

        #endregion

        #region     personalinformation Mapping

        public static PersonalInformation ToPersonalInformation(PersonalInformationDTO personalInformationDTO)
        {

            return new PersonalInformation()
            {
                FName = personalInformationDTO.FName,
                LName = personalInformationDTO.LName,
                Address = personalInformationDTO.Address,
                WebsiteAddress = personalInformationDTO.WebsiteAddress,
                birthdate = personalInformationDTO.birthdate,
                Description = personalInformationDTO.Description,
                DescriptionTitle = personalInformationDTO.DescriptionTitle,
                Email = personalInformationDTO.Email,
                JobTitle = personalInformationDTO.JobTitle,
                Phone = personalInformationDTO.Phone,
                ProfilePicPath = personalInformationDTO.ProfilePicPath

            };

        }

        public static PersonalInformation ToPersonalInformation(PersonalInformationAdminDTO personalInformationAdminDTO)
        {
            return new PersonalInformation()
            {
                ID = personalInformationAdminDTO.ID,
                FName = personalInformationAdminDTO.FName,
                LName = personalInformationAdminDTO.LName,
                Address = personalInformationAdminDTO.Address,
                WebsiteAddress = personalInformationAdminDTO.WebsiteAddress,
                birthdate = personalInformationAdminDTO.birthdate,
                Description = personalInformationAdminDTO.Description,
                DescriptionTitle = personalInformationAdminDTO.DescriptionTitle,
                Email = personalInformationAdminDTO.Email,
                JobTitle = personalInformationAdminDTO.JobTitle,
                Phone = personalInformationAdminDTO.Phone,
                ProfilePicPath = personalInformationAdminDTO.ProfilePicPath

            };
        }

        public static PersonalInformationDTO ToPersonalInformationDTO(PersonalInformation personalInformation)
        {
            return new PersonalInformationDTO()
            {
                FName = personalInformation.FName,
                LName = personalInformation.LName,
                Address = personalInformation.Address,
                WebsiteAddress = personalInformation.WebsiteAddress,
                birthdate = personalInformation.birthdate,
                Description = personalInformation.Description,
                DescriptionTitle = personalInformation.DescriptionTitle,
                Email = personalInformation.Email,
                JobTitle = personalInformation.JobTitle,
                Phone = personalInformation.Phone,
                ProfilePicPath = personalInformation.ProfilePicPath

            };
        }

        public static PersonalInformationAdminDTO ToPersonalInformationAdminDTO(PersonalInformation personalInformation)
        {
            return new PersonalInformationAdminDTO()
            {
                ID = personalInformation.ID,
                FName = personalInformation.FName,
                LName = personalInformation.LName,
                Address = personalInformation.Address,
                WebsiteAddress = personalInformation.WebsiteAddress,
                birthdate = personalInformation.birthdate,
                Description = personalInformation.Description,
                DescriptionTitle = personalInformation.DescriptionTitle,
                Email = personalInformation.Email,
                JobTitle = personalInformation.JobTitle,
                Phone = personalInformation.Phone,
                ProfilePicPath = personalInformation.ProfilePicPath
            };
        }

        #endregion

        #region Projects Mapping

        public static Projects ToProjects(ProjectsDTO projectsDTO)
        {
            return new Projects()
            {
                Name = projectsDTO.Name,
                Description = projectsDTO.Description,
                img = projectsDTO.img,
                language = projectsDTO.language,
                Url = projectsDTO.Url
            };

        }

        public static Projects ToProjects(ProjectsAdminDTO projectsAdminDTO)
        {
            return new Projects()
            {
                ID = projectsAdminDTO.ID,
                Name = projectsAdminDTO.Name,
                Description = projectsAdminDTO.Description,
                Url = projectsAdminDTO.Url,
                img = projectsAdminDTO.img,
                language = projectsAdminDTO.language

            };
        }

        public static ProjectsDTO ToProjectsDTO(Projects projects)
        {
            return new ProjectsDTO()
            {
                Name = projects.Name,
                Description = projects.Description,
                img = projects.img,
                language = projects.language,
                Url = projects.Url
            };
        }

        public static ProjectsAdminDTO ToProjectsAdminDTO(Projects projects)
        {
            return new ProjectsAdminDTO()
            {
                ID = projects.ID,
                Name = projects.Name,
                Description = projects.Description,
                img = projects.img,
                language = projects.language,
                Url = projects.Url
            };
        }
        #endregion
    }
}
