using System;

namespace TelerikColours.Mvp.CustomEventArgs
{
    public class AddJobCustomEventArgs : EventArgs
    {
        public AddJobCustomEventArgs(int cityId, string jobTitle, string jobDescription, int slots,
         DateTime startDate, DateTime endDate, decimal wage, string companyName, decimal price, string imagePath)
        {
            this.CityId = cityId;
            this.JobTitle = jobTitle;
            this.JobDescription = jobDescription;
            this.Slots = slots;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Wage = wage;
            this.CompanyName = companyName;
            this.Price = price;
            this.ImagePath = imagePath;
        }

        public int CityId { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public int Slots { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Wage { get; set; }

        public string CompanyName { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }
    }
}
