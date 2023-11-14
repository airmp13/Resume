using Resume.Domain.Entities;
using Resume.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Repositories
{
    public class ContactMeRepository : IContactMeRepository
    {
        private readonly ResumeDbContext _context;

        public ContactMeRepository(ResumeDbContext context)
        {
            _context = context;
            
        }
        public async Task SubmitNewContactMe(ContactMe contactMe)
        {
            _context.contactMe.Add(contactMe);
            _context.SaveChanges();
        }
    }
}
