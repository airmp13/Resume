﻿using Resume.Application.DTOs.Site;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IContactMeService
    {
        Task SubmitNewContactMe(ContactMeDTO contactMeDTO);
        Task<List<ContactMeAdminDTO>> GetContactMesAdminDTO();
        Task<ContactMeAdminDTO> GetContactMeAdminDTO(int id);

        Task Delete(ContactMeAdminDTO contactMeAdminDTO);
    }
}
