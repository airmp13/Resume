using Resume.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application
{
	public interface IAllDTOService
	{
		public Task<AllDTO> GetAllDTOAsync();
		public Task<bool> submitContactme(ContactMe contactMe);
	}
}
