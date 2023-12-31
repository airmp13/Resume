﻿using Resume.Application.DTOs.Site;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ISinglePageService
    {
        public Task<SinglePageDTO> GetSinglePageDTOAsync();
        public Task submitContactme(ContactMeDTO contactMeDTO);
    }
}
