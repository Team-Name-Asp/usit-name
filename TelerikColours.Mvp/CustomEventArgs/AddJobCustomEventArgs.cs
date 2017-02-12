﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class AddJobCustomEventArgs
    {
        public int CityId { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public int Slots { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Wage { get; set; }

        public string CompanyName { get; set; }

        public AddJobCustomEventArgs(int cityId, string jobTitle, string jobDescription, int slots,
            DateTime startDate, DateTime endDate, decimal wage, string companyName)
        {
            this.CityId = cityId;
            this.JobTitle = JobTitle;
            this.JobDescription = JobDescription;
            this.Slots = slots;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Wage = wage;
            this.CompanyName = companyName;
        }
    }
}
