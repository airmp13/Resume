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
            ContactMe contactMe = new() 
            { 
                Name = contactMeDTO.Name,
                Email = contactMeDTO.Email,
                Message = contactMeDTO.Message,
                PhoneNumber = contactMeDTO.PhoneNumber
            };   
            await _contactMeRepository.SubmitNewContactMe(contactMe);
        }

        public async Task<List<ContactMeAdminDTO>> GetContactMesAdminDTO()
        {
            List<ContactMe> contactMes=await _contactMeRepository.GetContactMesListAsync();
            List<ContactMeAdminDTO> contactMeAdminDTOs = new();

            foreach (ContactMe contactMe in contactMes)
            {
                ContactMeAdminDTO contactMeAdminDTO = new()
                {
                    ID = contactMe.ID, 
                    Email = contactMe.Email,
                    Message= contactMe.Message,
                    PhoneNumber = contactMe.PhoneNumber
                };
                contactMeAdminDTOs.Add(contactMeAdminDTO);
            }

            return contactMeAdminDTOs;


        }

        public async Task<ContactMeAdminDTO> GetContactMeAdminDTO(int id)
        {
            ContactMe contactMe = await _contactMeRepository.GetContactMeAsync(id);
            return new ContactMeAdminDTO() { 
                    ID = contactMe.ID,
                    Email = contactMe.Email,
                    Message = contactMe.Message,
                    PhoneNumber = contactMe.PhoneNumber
                };
        }

        public async Task Delete(ContactMeAdminDTO contactMeAdminDTO)
        {
            await _contactMeRepository.Delete(new ContactMe()
            {
                ID = contactMeAdminDTO.ID,
                Email = contactMeAdminDTO.Email,
                Message = contactMeAdminDTO.Message,
                PhoneNumber = contactMeAdminDTO.PhoneNumber
            });
        }


    }
}
