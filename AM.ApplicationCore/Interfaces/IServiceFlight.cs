using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        List<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        //IEnumerable<Traveller> SeniorTravellers(Flight flight);
        void DestinationGroupedFlights();


        void add(Flight flight);
        void remove(Flight flight);
        List<Flight> GetAll();
        IList<Flight> GetAll();
    }
}
