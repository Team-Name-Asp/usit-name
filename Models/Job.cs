using System;
using System.ComponentModel.DataAnnotations;
using Models.Constants;

namespace Models
{
    public class Job
    {
        public Job()
        {
        }

        public Job(int cityId, string jobTitle, string jobDescription, int slots,
            DateTime startDate, DateTime endDate, decimal wage, string companyName, decimal price)
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
            this.Price = price;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.JobTitleMinLength)]
        [MaxLength(ModelConstants.JobTitleMaxLength)]
        public string JobTitle { get; set; }

        [Required]
        [MinLength(ModelConstants.JobDescriptionMinLength)]
        [MaxLength(ModelConstants.JobDescriptionMaxLength)]
        public string JobDescription { get; set; }

        [Required]
        public int Slots { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Wage { get; set; }

        [Required]
        [MinLength(ModelConstants.CompanyMinLength)]
        [MaxLength(ModelConstants.CompanyMaxLength)]
        public string CompanyName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
