using Resume.Application.DTOs.Admin;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
             _accountRepository = accountRepository;
        }

        public async Task<UserLoginDTO> UserLogin(UserLoginDTO userLogin)
        {
            User user = await _accountRepository.GetUserAsync();
            
            if (user == null)
            {
                return null;
            }

            else if ((userLogin.PhoneNumber == user.PhoneNumber) && (userLogin.Password == user.Password)) 
            {

                

                return new UserLoginDTO()
                {
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password
                };
            }
            else
            return null;

        }

    }
}
