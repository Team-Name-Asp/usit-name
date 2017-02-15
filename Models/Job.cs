﻿using System;

namespace Models
{
    public class Job
    {
        public Job()
        {
        }

        public Job(int cityId, string jobTitle, string jobDescription, int slots,
            DateTime startDate, DateTime endDate, decimal wage, string companyName)
            : base()
        {
            this.CityId = cityId;
            this.JobTitle = jobTitle;
            this.JobDescription = jobDescription;
            this.Slots = slots;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Wage = wage;
            this.CompanyName = companyName;
        }

        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public int Slots { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Wage { get; set; }

        public string CompanyName { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
