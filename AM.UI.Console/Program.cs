// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // TP2 - Q5:Créer une instance de la classe ServiceFlight
        ServiceFlight sf = new ServiceFlight();

        //TP2-Q5:Affecter listFlights à la propriété Flights de la classe ServiceFlight
        sf.Flights = TestData.listFlights;

        Console.WriteLine("************************************ TESTS AREA  ****************************** ");

        Console.WriteLine("\n\nFlight dates to Madrid");
        foreach (var item in sf.GetFlightDates("Madrid"))
            Console.WriteLine(item);

        Console.WriteLine("\n\nFlight dates Airbus planes");
        sf.ShowFlightDetails(TestData.Airbusplane);

        Console.WriteLine($"\n\nNumber of flights up for the next 7 days: {sf.ProgrammedFlightNumber(new DateTime(2021, 12, 30))}");

        Console.WriteLine($"\n\nEstimated duration to Paris: {sf.DurationAverage("Paris")}");

        Console.WriteLine("\n\nOrdered longest to shortest flights:");
        foreach (var item in sf.OrderedDurationFlights()) 
            Console.WriteLine($"flight: {item}");

        Console.WriteLine("\n\nEldest 3 travellers");
        foreach (var item in sf.SeniorTravellers(TestData.flight1))
            Console.WriteLine($"name: {item.FirstName}\ndate of birth: {item.BirthDate}");

        Console.WriteLine("\n\nFlights grouped by destination:");
        sf.DestinationGroupedFlights();
    }
}