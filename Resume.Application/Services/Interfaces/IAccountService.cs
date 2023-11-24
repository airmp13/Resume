using Resume.Application.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserLoginDTO> UserLogin(UserLoginDTO userLogin);
    }
}
