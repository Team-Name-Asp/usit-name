using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TelerikColours.Services.Contracts;
using TelerikColours.Services.Contracts.Factories;
using TelerikColours.Services.DataStructures;
using TelerikColours.Services.Models;

namespace TelerikColours.Services
{
    public class FlightService : IFlightService
    {
        private IRepository<Airport> airportRepository;

        private IRepository<Airline> airlineRepository;

        private IRepository<Flight> flightRepository;

        private IRepository<City> cityRepository;

        private IUnitOfWork unitOfWork;

        private IMappedClassFactory mappedFlightFactory;

        public FlightService(IRepository<Airport> airportRepository, IUnitOfWork unitOfWork, IRepository<Airline> airlineRepository, IRepository<Flight> flightRepository, IRepository<City> cityRepository, IMappedClassFactory mappedFlightFactory)
        {
            if (airportRepository == null)
            {
                throw new NullReferenceException("AirportRepository");
            }

            if (airlineRepository == null)
            {
                throw new NullReferenceException("AirlineRepository");
            }

            if (flightRepository == null)
            {
                throw new NullReferenceException("FlightRepository");
            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("UnitOfWork");
            }

            if(mappedFlightFactory == null)
            {
                throw new NullReferenceException("MappedFactory");
            }

            this.airportRepository = airportRepository;
            this.airlineRepository = airlineRepository;
            this.unitOfWork = unitOfWork;
            this.flightRepository = flightRepository;
            this.cityRepository = cityRepository;
            this.mappedFlightFactory = mappedFlightFactory;
        }

        public IEnumerable<Airport> GetAllAirportsInCity(int cityId)
        {
            return this.airportRepository.GetAll(x => x.CityId == cityId, x => x.Name);
        }

        public IEnumerable<Airline> GetAllAirlines()
        {
            return this.airlineRepository.GetAll(null, x => x.Name);
        }


        public IEnumerable<PresentationFlight> GetFlights(int currentAirportId, int destinationAirportId, DateTime travelDate, int count)
        {
            var airports = this.airportRepository.GetAll();

            var lowerBoundDate = travelDate.AddDays(-1);
            var upperBOundDate = travelDate.AddDays(1);

            var flights = this.flightRepository.GetAll(x => lowerBoundDate <= x.DateOfDeparture && x.DateOfDeparture <= upperBOundDate && x.AvailableSeats >= count);

            var dict = new Dictionary<SecondFlightNode, List<MappedFlight>>();
            var nodes = new Dictionary<int, SecondFlightNode>();

            foreach (var item in airports)
            {
                nodes.Add(item.Id, this.mappedFlightFactory.CreateSecondFlightNode(item.Id));
            }

            foreach (var item in flights)
            {
                var departureAirport = nodes[item.AirportDepartureId];
                var arrivalAirport = nodes[item.AirportArrivalId];
                var current = this.mappedFlightFactory.CreateMappedFlight(item.Id, departureAirport, arrivalAirport, item.DateOfDeparture, item.DateOfArrival);

                if (!dict.ContainsKey(departureAirport))
                {
                    dict.Add(departureAirport, new List<MappedFlight>());
                }

                dict[departureAirport].Add(current);
            }

            var heap = new PriorityQueue<SecondFlightNode>();

            var currentAirport = nodes[currentAirportId];

            // Source airport set before today
            currentAirport.PreviousFlightTime = new DateTime(1999, 1, 1);

            heap.Enqueue(currentAirport);

            while (heap.Count > 0)
            {
                var current = heap.Dequeue();

                if (!dict.ContainsKey(current))
                {
                    continue;
                }

                foreach (var flight in dict[current])
                {
                    bool isLastFlightBeforeCurrentFlight = current.PreviousFlightTime < flight.DepartureTime;
                    bool isNextAirportLastFlightAfterFlight = nodes[flight.ArrivalAirport.AirportId].PreviousFlightTime > flight.ArrivalTime;
                    if (isLastFlightBeforeCurrentFlight && isNextAirportLastFlightAfterFlight)
                    {
                        nodes[flight.ArrivalAirport.AirportId].PreviousFlightTime = flight.ArrivalTime;
                        nodes[flight.ArrivalAirport.AirportId].ParentAirportId = current.AirportId;
                        nodes[flight.ArrivalAirport.AirportId].ParentFlightId = flight.Id;

                        heap.Enqueue(flight.ArrivalAirport);
                    }
                }
            }

            var lastAirport = nodes[destinationAirportId];
            var trackChilds = new List<int>();
            trackChilds.Add(destinationAirportId);

            var listFLights = new List<int>();
            while (lastAirport.ParentFlightId != -1)
            {
                listFLights.Add(lastAirport.ParentFlightId);
                trackChilds.Add(lastAirport.ParentAirportId);
                lastAirport = nodes[lastAirport.ParentAirportId];
            }

            listFLights.ToArray();

            var resultFlights = new List<PresentationFlight>();

            for (int i = listFLights.Count - 1; i >= 0; i--)
            {
                var currentFlightId = listFLights[i];

                var currentFlight = this.flightRepository.GetById(currentFlightId);

                var newMappedFlight = this.mappedFlightFactory.CreatePresentationFlight(currentFlight.Id, currentFlight.AirportDeparture.City.Name, currentFlight.AirportArrival.City.Name, currentFlight.AirportDeparture.Name, currentFlight.AirportArrival.Name, currentFlight.DateOfDeparture, currentFlight.DateOfArrival, currentFlight.Price, currentFlight.Airline.Name);

                resultFlights.Add(newMappedFlight);
            }

            return resultFlights;
        }

        public IEnumerable<Flight> FilterFlights(string type, string filterExpression)
        {
            IQueryable<Flight> resultQuery = null;
            if(type == "date")
            {
                var queryDate = DateTime.Parse(filterExpression);
                resultQuery = this.flightRepository.All.Where(x => x.DateOfDeparture.DayOfYear == queryDate.DayOfYear);
            }
            else if (type == "airline")
            {
                resultQuery = this.flightRepository.All.Include(x => x.Airline).Where(x => x.Airline.Name == filterExpression);
            }
            else if (type == "airport")
            {
                resultQuery = this.flightRepository.All.Include(x => x.AirportArrival).Include(x => x.AirportDeparture).Where(x => x.AirportDeparture.Name == filterExpression || x.AirportArrival.Name == filterExpression);
            }

            return resultQuery.ToList();
        }

        public Flight GetFlightForUpdate(int id)
        {
            return this.flightRepository.GetById(id);
        }

        public void SaveUpdatedFlight()
        {
            using (this.unitOfWork)
            {
                this.unitOfWork.Commit();
            }
        }
    }
}