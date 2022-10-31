using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        Console.WriteLine("Hello, World!");

        ServiceFlight sf = new()
        {
            Flights = TestData.listFlights
        };

        Console.WriteLine("\n\n\n\n************************************ TESTS AREA  ******************************");

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

        //Console.WriteLine("\n\nEldest 3 travellers");
        //foreach (var item in sf.SeniorTravellers(TestData.flight1))
        //{
        //    item.UpperFullName();
        //    Console.WriteLine($"name: {item.FullName.FirstName} {item.FullName.LastName};  date of birth: {item.BirthDate}");
        //}

        Console.WriteLine("\n\nFlights grouped by destination:");
        sf.DestinationGroupedFlights();

        sf.FlightDetailsDel(TestData.BoingPlane);

        Console.WriteLine($"\n\nDuration average to Paris: {sf.DurationAverageDel("Madrid")}");



        /*              CONTEXT TESTING              */
        Console.WriteLine("\n\n\n\n************************************ CONTEXT TESTING  ******************************");
        AMContext Context = new();

        //Context.Flights.Add(TestData.flight2);
        //Context.SaveChanges();

        Console.WriteLine($"\nPlane capacity of 2nd flight: {Context.Flights.First().Plane.Capacity}");

    }
}