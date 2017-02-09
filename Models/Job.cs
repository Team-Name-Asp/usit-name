using System;

namespace Models
{
    public class Job
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public int Slots { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Wage { get; set; }

        public string CompanyName { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
