using Resume.Application.DTOs.Admin;
using Resume.Application.DTOs.Mapper;
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
            await _mySkillsRepository.Create(DTOMapper.ToMySkill(mySkillsDTO));
        }

        public async Task Edit(MySkillsAdminDTO mySkillsAdminDTO)
        {
            await _mySkillsRepository.Edit(DTOMapper.ToMySkill(mySkillsAdminDTO));
        }
        public async Task Delete(MySkillsAdminDTO mySkillsAdminDTO)
        {
            await _mySkillsRepository.Delete(DTOMapper.ToMySkill(mySkillsAdminDTO));
        }


        public async Task<List<MySkillsAdminDTO>> GetGradedMySkillsAdminDTOListAsync(int grade)
        {
            List<MySkills> mySkills = await GetGradedMySkillsListAsync(grade);
            List<MySkillsAdminDTO> mySkillsAdminDTO = new();

            foreach (MySkills mySkill in mySkills)
            {
                mySkillsAdminDTO.Add(DTOMapper.ToMySkillsAdminDTO(mySkill));
            }

            return mySkillsAdminDTO;
        }

        public async Task<MySkillsAdminDTO> GetMySkillsAdminDTOAsync(int id)
        {

            return DTOMapper.ToMySkillsAdminDTO(await _mySkillsRepository.GetMySkillsAsync(id));

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
                mySkillsDTO.Add(DTOMapper.ToMySkillDTO(mySkill));
            }

            return mySkillsDTO;
        }
    }
}
