using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Site;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
    public class MySkillsService : IMySkillsService
    {
        private readonly IMySkillsRepository _mySkillsRepository;

        public MySkillsService(IMySkillsRepository mySkillsRepository)
        {
            _mySkillsRepository = mySkillsRepository;
            
        }


        public async Task Create(MySkillsDTO mySkillsDTO)
        {
            await _mySkillsRepository.Create(new MySkills()
            {
                Name = mySkillsDTO.Name,
                grade = mySkillsDTO.grade,
                Value = mySkillsDTO.Value
            });
        }

        public async Task Edit(MySkillsAdminDTO mySkillsAdminDTO)
        {
            await _mySkillsRepository.Edit(new MySkills()
            {
                ID = mySkillsAdminDTO.ID,
                Name = mySkillsAdminDTO.Name,
                grade = mySkillsAdminDTO.grade,
                Value = mySkillsAdminDTO.Value
            });
        }
        public async Task Delete(MySkillsAdminDTO mySkillsAdminDTO)
        {
            await _mySkillsRepository.Delete(new MySkills()
            {
                ID = mySkillsAdminDTO.ID,
                Name = mySkillsAdminDTO.Name,
                grade = mySkillsAdminDTO.grade,
                Value = mySkillsAdminDTO.Value
            });
        }


        public async Task<List<MySkillsAdminDTO>> GetGradedMySkillsAdminDTOListAsync(int grade)
        {
            List<MySkills> mySkills = await GetGradedMySkillsListAsync(grade);
            List<MySkillsAdminDTO> mySkillsAdminDTO = new();

            foreach (MySkills mySkill in mySkills)
            {
                MySkillsAdminDTO mySkillAdminDTO = new()
                {
                    ID=mySkill.ID,
                    Name = mySkill.Name,
                    grade = mySkill.grade,
                    Value = mySkill.Value
                };
                mySkillsAdminDTO.Add(mySkillAdminDTO);
            }

            return mySkillsAdminDTO;
        }

        public async Task<MySkillsAdminDTO> GetMySkillsAdminDTOAsync(int id)
        {
            MySkills mySkills = await _mySkillsRepository.GetMySkillsAsync(id);
            return new MySkillsAdminDTO()
            {
                ID = mySkills.ID,
                Name = mySkills.Name,
                grade = mySkills.grade,
                Value = mySkills.Value
            };

        }


        public async Task<List<MySkills>> GetGradedMySkillsListAsync(int grade)
        {
            return await _mySkillsRepository.GetGradedSkillsListAsync(grade);
        }

        public async Task<List<MySkills>> GetMySkillsListAsync()
        {
            return await _mySkillsRepository.GetMySkillsListAsync();
        }

        public async Task<List<MySkillsDTO>> GetGradedMySkillsDTOListAsync(int grade)
        {
            List<MySkills> mySkills = await GetGradedMySkillsListAsync(grade);
            List<MySkillsDTO> mySkillsDTO = new();

            foreach (MySkills mySkill in mySkills)
            {
                MySkillsDTO mySkillDTO = new()
                {
                    Name = mySkill.Name,
                    grade = grade,
                    Value = mySkill.Value
                };
                mySkillsDTO.Add(mySkillDTO);
            }

            return mySkillsDTO;
        }
    }
}
