using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // List<DateTime> ls = new List<DateTime>();
            // for (int j = 0; j < Flights.Count; j++)
            //     if (Flights[j].Destination.Equals(destination))
            //         ls.Add(Flights[j].FlightDate);
            // return ls;


            ////TP2-Q7: Reformuler la requête avec foreach
            //List<DateTime> ls = new List<DateTime>();
            //foreach (Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;


            //TP2-Q9: Reformuler la méthode en utilisant LINQ
            var query = from f in Flights
                        where f.Destination.Equals(destination)
                        select f.FlightDate;
            return query.ToList();
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
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where (f.FlightDate - startDate).TotalDays < 7 && (f.FlightDate - startDate).TotalDays > 0
                        select f;

            return query.Count();

        }

        public double DurationAverage(string destination)
        {
            var query = from f in Flights
                        where (f.Destination.Equals(destination))
                        select f.EstimatedDuration;

            return query.Average();

                    }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            return  from flight in Flights
                    orderby flight.EstimatedDuration descending
                    select flight;
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {

            var query = from p in flight.Passengers.OfType<Traveller>()
                        orderby p.BirthDate
                        select p;

            return query.Take(3);
        }

        public void DestinationGroupedFlights()
        {
            var query = from f in Flights
                        group f by f.Destination;

            foreach (var item in query)
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
                return  (from f in Flights
                        where (f.Destination.Equals(destination))
                        select f.EstimatedDuration).Average();
            };
        }



    }
}
