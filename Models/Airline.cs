using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Constants;

namespace Models
{
    public class Airline
    {
        private ICollection<City> cities;
        private ICollection<Flight> flights;

        public Airline()
        {
            this.cities = new HashSet<City>();
            this.flights = new HashSet<Flight>();
        }

        public Airline(string name)
            : base()
        {
            this.Name = name;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.AirlineMinLength)]
        [MaxLength(ModelConstants.AirlineMaxLength)]
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

        public virtual ICollection<Flight> Flights
        {
            get
            {
                return this.flights;
            }

            set
            {
                this.flights = value;
            }
        }

    }
}
