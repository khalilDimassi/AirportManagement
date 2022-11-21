using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Services;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {

        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<Traveller> Travellers { get; set; } = new List<Traveller>();

        public List<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> lambdaQuery = Flights.Where(flight => flight.Destination == destination).Select(flight => flight.FlightDate);
            return lambdaQuery.ToList();
        }


        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            var lambdaQuery = Flights.Where(flight => flight.Plane.Equals(plane)).Select(flight =>  new {flight.FlightDate, flight.Destination});
            foreach (var item in lambdaQuery)
            {
                Console.WriteLine($"\nDate: {item.FlightDate}, Desination: {item.Destination}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var labmdaQuery = Flights.Where(flight => (flight.FlightDate - startDate).TotalDays < 7 && (flight.FlightDate - startDate).TotalDays > 0).Select(flight => flight);
            return labmdaQuery.Count();

        }

        public double DurationAverage(string destination)
        {
            var lambdaQuery = Flights.Where(flight => flight.Destination.Equals(destination)).Select(flight => flight.EstimatedDuration);
            return lambdaQuery.Average();

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {

            return Flights.OrderByDescending(flight => flight.EstimatedDuration).Select(flight => flight);
        }

        public void DestinationGroupedFlights()
        {

            var lambdaQuery = Flights.GroupBy(flight => flight.Destination);

            foreach (var item in lambdaQuery)
            {
                Console.WriteLine($"\nDestination: {item.Key}");
                foreach (var f in item)
                {
                    Console.WriteLine($"Decollage: {f.FlightDate}");
                }
            }
        }

        public Action<Plane> FlightDetailsDel;
        public Func<String, Double>? DurationAverageDel;

        public ServiceFlight()
        {
            FlightDetailsDel = plane =>
            {
                var query = from flight in Flights
                            where flight.Plane.Equals(plane)
                            select new
                            {
                                flight.FlightDate,
                                flight.Destination
                            };

                foreach (var item in query)
                {
                    System.Console.WriteLine($"\nDate: {item.FlightDate}, Desination: {item.Destination}");
                }
            };

            DurationAverageDel = destination =>
            {
                return (from f in Flights
                        where f.Destination.Equals(destination)
                        select f.EstimatedDuration).Average();

            };
        }

        /* *************************************** generic repository ******************************** */

        IGenericRepository<Flight> GenericRepository_;

        public ServiceFlight(IGenericRepository<Flight> genericRepository)
        {
            GenericRepository_ = genericRepository;
        }


        public void add(Flight flight)
        {
            GenericRepository_.InsertEntity(flight);
        }

        public void remove(Flight flight)
        {
            GenericRepository_.DeleteEntity(flight);
        }

        public List<Flight> GetAll()
        {
            return GenericRepository_.GetAll().ToList();
        }


        /* *************************************** unit of work ******************************** */
        public IUnitOfWork _unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Flight f)
        {
            _unitOfWork.Repository<Flight>().InsertEntity(f);
        }

        public void Update(Flight f)
        {
            _unitOfWork.Repository<Flight>().UpdateEntity(f);
        }

        public IList<Flight> getAll()
        {
            return _unitOfWork.Repository<Flight>().GetAll().ToList();
        }


    }
}
