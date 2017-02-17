using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace TelerikColours.Services.Contracts
{
    public interface IJobService
    {
        IEnumerable<Job> GetAllJobs();

        IQueryable<Job> GetAllJobsFromByTerm(string searchedTerm);
    }
}
