﻿using Resume.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application
{
    public interface IPersonalInformationService
    {
         Task<PersonalInformation> GetPersonalInformationAsync();
    }
}
