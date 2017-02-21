﻿using Models;
using System.Collections.Generic;
using System.Linq;
using TelerikColours.Services.Models;

namespace TelerikColours.Services.Contracts
{
    public interface IUserService
    {
        bool BuyTicket(string userId, IEnumerable<PresentationFlight> flights);

        void AttachJobToUser(string userId, Job job);

        IEnumerable<Flight> GetFlightHistory(string userId);

        IEnumerable<Flight> GetUpcommingFlights(string userId);

        IEnumerable<Job> GetUpcommingJobs(string userId);

        IEnumerable<Job> GetJobsHistory(string userId);

    }
}