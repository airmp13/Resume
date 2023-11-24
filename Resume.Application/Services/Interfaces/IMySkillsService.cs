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
    public interface IMySkillsService
    {

        Task Create(MySkillsDTO mySkillsDTO);

        Task Edit(MySkillsAdminDTO mySkillsAdminDTO);

        Task Delete(MySkillsAdminDTO mySkillsAdminDTO);

        Task<List<MySkillsAdminDTO>> GetGradedMySkillsAdminDTOListAsync(int grade);

        Task<MySkillsAdminDTO> GetMySkillsAdminDTOAsync(int id);


        Task<List<MySkills>> GetMySkillsListAsync();

        Task<List<MySkills>> GetGradedMySkillsListAsync(int grade);

        Task<List<MySkillsDTO>> GetGradedMySkillsDTOListAsync(int grade);
    }
}
