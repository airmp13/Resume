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
    public class MySkillsService : IMySkillsService
    {
        private readonly IMySkillsRepository _mySkillsRepository;

        public MySkillsService(IMySkillsRepository mySkillsRepository)
        {
            _mySkillsRepository = mySkillsRepository;
            
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
