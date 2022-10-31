using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public string AirlineLogo { get; set; }

        [ForeignKey("Plane")]
        public int PlaneId { get; set; }

        //prop de navigation
        public virtual List<Passenger> Passengers { get; set; }
        public virtual Plane Plane { get; set; }


        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FlightId: " + FlightId + " FlightDate: " + FlightDate + " Destination: " + Destination;
        }
    }
}
