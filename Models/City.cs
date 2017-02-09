﻿using System.Collections.Generic;

namespace Models
{
    public class City
    {
        private ICollection<Airport> airports;
        private ICollection<Job> jobs;

        public City()
        {
            this.Jobs = new HashSet<Job>();
            this.airports = new HashSet<Airport>();
        }
        public City(string name, int countryId)
            : base()
        {
         
            this.Name = name;
            this.CountryId = countryId;
        }
    
        public string Name { get; set; }

        public int Id { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }


        public virtual ICollection<Airport> Airports
        {
            get
            {
                return this.airports;
            }

            set
            {
                this.airports = value;
            }
        }

        public virtual ICollection<Job> Jobs
        {
            get
            {
                return this.jobs;
            }

            set
            {
                this.jobs = value;
            }
        }


    }
}
