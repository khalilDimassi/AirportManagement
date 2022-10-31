using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        //TP2-Q3: Créer la propriété Flights et l’initialiser à une liste vide
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<Traveller> Travellers { get; set; } = new List<Traveller>();

        //TP2-Q6: Implémenter la méthode GetFlightDates(string destination)
        public List<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> lambdaQuery = Flights.Where(flight => flight.Destination == destination).Select(flight => flight.FlightDate);
            return lambdaQuery.ToList();
        }



        //TP2-Q8: Implémenter la méthode GetFlights(string filterType, string filterValue)
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

        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    return flight.Passengers.OfType<Traveller>().OrderBy(passenger => passenger.BirthDate).Select(passenger => passenger).Take(3);
        //}

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
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;

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
                        where (f.Destination.Equals(destination))
                        select f.EstimatedDuration).Average();

            };
        }



    }
}
