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
    }
}
