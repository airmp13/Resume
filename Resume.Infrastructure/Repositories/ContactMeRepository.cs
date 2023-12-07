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
    public class ContactMeRepository : IContactMeRepository
    {
        private readonly ResumeDbContext _context;

        public ContactMeRepository(ResumeDbContext context)
        {
            _context = context;
            
        }
        public async Task SubmitNewContactMe(ContactMe contactMe)
        {
            contactMe.IsRead = false;
            _context.contactMe.Add(contactMe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContactMe>> GetContactMesListAsync()
        {
            return await _context.contactMe.ToListAsync();
        }

        public async Task<ContactMe> GetContactMeAsync(int id)
        {
            ContactMe contactMe = await _context.contactMe.FirstOrDefaultAsync(c => c.ID == id);
            contactMe.IsRead = true;
            _context.Update(contactMe);
            await _context.SaveChangesAsync(true);
            return contactMe;
        }

        public async Task Delete(ContactMe contactMe)
        {
            _context.contactMe.Remove(contactMe);
            await _context.SaveChangesAsync();
        }
    }
}
