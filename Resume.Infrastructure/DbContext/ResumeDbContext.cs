using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Domain.Entities;

namespace Resume.Infrastructure
{
    public class ResumeDbContext : DbContext
    {

        public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
            : base(options)
        {
			
		}

		
		public DbSet<PersonalInformation> personalInformation { get; set; }
        public DbSet<AboutMe> aboutMe { get; set; }

        public DbSet<Projects> projects { get; set; }   

        public DbSet<Experiences> experiences { get; set; }

        public DbSet<Educations> educations { get; set; }

        public DbSet<MySkills> mySkills { get; set; }

        public DbSet<ContactMe> contactMe { get; set; }

    }
}
