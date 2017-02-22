using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Constants;

namespace Models
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        public Country(string name)
            : this()
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.CountryMinLength)]
        [MaxLength(ModelConstants.CountryMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                this.cities = value;
            }
        }        
    }
}
