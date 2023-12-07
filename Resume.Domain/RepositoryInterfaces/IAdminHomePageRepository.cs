using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.RepositoryInterfaces
{
	public interface IAdminHomePageRepository
	{
		Task<int> GetProjectsCounts();
		Task<int> GetEducationsCount();
		Task<int> GetExperiencesCount();
		Task<int> GetUnredMessagesCount();
 	}
}
