using Resume.Application.DTOs.Mapper;
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
    public class ContactMeService : IContactMeService
    {
        private readonly IContactMeRepository _contactMeRepository;

        public ContactMeService(IContactMeRepository contactMeRepository)
        {
            _contactMeRepository = contactMeRepository;
            
        }

        public async Task SubmitNewContactMe(ContactMeDTO contactMeDTO)
        {
               
            await _contactMeRepository.SubmitNewContactMe(DTOMapper.ToContactMe(contactMeDTO));
        }

        public async Task<List<ContactMeAdminDTO>> GetContactMesAdminDTO()
        {
            List<ContactMe> contactMes=await _contactMeRepository.GetContactMesListAsync();
            List<ContactMeAdminDTO> contactMeAdminDTOs = new();

            foreach (ContactMe contactMe in contactMes)
            {
                
                contactMeAdminDTOs.Add(DTOMapper.ToContactMeAdminDTO(contactMe));
            }

            return contactMeAdminDTOs;


        }

        public async Task<ContactMeAdminDTO> GetContactMeAdminDTO(int id)
        {
            return DTOMapper.ToContactMeAdminDTO(await _contactMeRepository.GetContactMeAsync(id));
        }

        public async Task Delete(ContactMeAdminDTO contactMeAdminDTO)
        {
            await _contactMeRepository.Delete(DTOMapper.ToContactMe(contactMeAdminDTO));
        }


    }
}
