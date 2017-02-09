using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using TelerikColours.Services.Contracts;
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

        public FlightService(IRepository<Airport> airportRepository, IUnitOfWork unitOfWork, IRepository<Airline> airlineRepository, IRepository<Flight> flightRepository, IRepository<City> cityRepository)
        {
            if (airportRepository == null)
            {
                throw new NullReferenceException("Repository is null");
            }

            if (airlineRepository == null)
            {
                throw new NullReferenceException("Airline repository is null");
            }

            if (flightRepository == null)
            {
                throw new NullReferenceException("Flight repository is null");
            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("UnitOfWork is null");
            }

            this.airportRepository = airportRepository;
            this.airlineRepository = airlineRepository;
            this.unitOfWork = unitOfWork;
            this.flightRepository = flightRepository;
            this.cityRepository = cityRepository;
        }

        public IEnumerable<Airport> GetAllAirportsInCity(int cityId)
        {
            return this.airportRepository.GetAll(x => x.CityId == cityId, x => x.Name);
        }

        public IEnumerable<Airline> GetAllAirlines()
        {
            return this.airlineRepository.GetAll(null, x => x.Name);
        }

        public IEnumerable<Flight> GetFlights(int currentAirportId, int destinationAirportId)
        {
            var airports = this.airportRepository.GetAll();
            var flights = this.flightRepository.GetAll();

            var dict = new Dictionary<SecondFlightNode, List<MappedFlight>>();
            var nodes = new Dictionary<int, SecondFlightNode>();

            foreach (var item in airports)
            {
                nodes.Add(item.Id, new SecondFlightNode(item.Id));
            }

            foreach (var item in flights)
            {
                var departureAirport = nodes[item.AirportDepartureId];
                var arrivalAirport = nodes[item.AirportArrivalId];
                var current = new MappedFlight(item.Id, departureAirport, arrivalAirport, item.DateOfDeparture, item.DateOfArrival);

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

            var resultFlights = new List<Flight>();

            for (int i = listFLights.Count - 1; i >= 0; i--)
            {
                var currentFlightId = listFLights[i];

                var currentFlight = this.flightRepository.GetById(currentFlightId);

                resultFlights.Add(currentFlight);
            }

            return resultFlights;
        }

    }
}