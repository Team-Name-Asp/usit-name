using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Models;
using Repositories.Contracts;
using TelerikColours.Services.Contracts;

namespace TelerikColours.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> jobRepository;

        public JobService(IRepository<Job> jobRepository)
        {
            if (jobRepository == null)
            {
                throw new NullReferenceException("JobRepository");
            }

            this.jobRepository = jobRepository;
        }
        public IEnumerable<Job> GetAllJobs()
        {
            return this.jobRepository.GetAll();
        }

        public IQueryable<Job> GetAllJobsFromByTerm(string searchedTerm)
        {
            return this.jobRepository.All.Where(j => j.JobTitle.Contains(searchedTerm) || j.JobDescription.Contains(searchedTerm) || j.CompanyName.Contains(searchedTerm)).Include(j => j.City).OrderBy(j => j.JobTitle);
        }

        public Job GetJobById(int id)
        {
            return this.jobRepository.GetById(id);
        }
    }
}
