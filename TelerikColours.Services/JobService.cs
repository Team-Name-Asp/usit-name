using System;
using System.Collections.Generic;
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
    }
}
