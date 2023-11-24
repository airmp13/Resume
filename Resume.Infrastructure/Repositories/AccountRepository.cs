using Microsoft.EntityFrameworkCore;
using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly ResumeDbContext _Context;

        public AccountRepository(ResumeDbContext resumeDbContext)
        {
            _Context = resumeDbContext;
            
        }

        public async Task<User> GetUserAsync()
        {
            return await _Context.users.FirstOrDefaultAsync();
        }

    }
}
