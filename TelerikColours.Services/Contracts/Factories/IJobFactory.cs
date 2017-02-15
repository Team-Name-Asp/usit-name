﻿using System;
using Models;

namespace TelerikColours.Services.Contracts.Factories
{
    public interface IJobFactory
    {
        Job CreateJob(int cityId, string jobTitle, string jobDescription, int slots,
            DateTime startDate, DateTime endDate, decimal wage, string companyName, decimal price);
    }
}
