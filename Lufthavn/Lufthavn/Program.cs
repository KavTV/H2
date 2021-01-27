using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lufthavn
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LufthavnEntities())
            {

                List<Airline> airlineList = new List<Airline>();
                airlineList.Add(new Airline()
                {
                    ICAO = "UAE",
                    Name = "Emirates"
                });
                airlineList.Add(new Airline()
                {
                    ICAO = "SAS",
                    Name = "Scandinavian Airlines Something"
                });
                airlineList.Add(new Airline()
                {
                    ICAO = "NAX",
                    Name = "Norwegian Air Shuttle"
                });
                context.Airlines.AddRange(airlineList);

                List<Airport> airportList = new List<Airport>();
                airportList.Add(new Airport()
                {
                    IATA = "RNN",
                    Name = "Bornholm lufthavn",
                    City = "Rønne",
                    Country = "Denmark"
                });
                airportList.Add(new Airport()
                {
                    IATA = "BLL",
                    Name = "Billund lufthavn",
                    City = "Billund",
                    Country = "Denmark"
                });
                airportList.Add(new Airport()
                {
                    IATA = "CPH",
                    Name = "Kastrup lufthavn",
                    City = "Kastrup",
                    Country = "Denmark"
                });
                context.Airports.AddRange(airportList);

                List<Airplane> airplaneList = new List<Airplane>();

                airplaneList.Add(new Airplane()
                {
                    No = "SK123",
                    AirlineICAO = "SAS",
                    Type = "A380"
                });
                airplaneList.Add(new Airplane()
                {
                    No = "DY41",
                    AirlineICAO = "NAX",
                    Type = "A321"
                });
                airplaneList.Add(new Airplane()
                {
                    No = "EK369",
                    AirlineICAO = "UAE",
                    Type = "A330"
                });
                airplaneList.Add(new Airplane()
                {
                    No = "DY35",
                    AirlineICAO = "NAX",
                    Type = "A321"
                });
                context.Airplanes.AddRange(airplaneList);

                List<Route> routeList = new List<Route>();
                routeList.Add(new Route()
                {
                    //Could also refer to AirportDeparture and use Airport object
                    Departure = "BLL",
                    Arrival = "CPH",
                    ICAO = "SAS"
                });
                routeList.Add(new Route()
                {
                    Departure = "BLL",
                    Arrival = "RNN",
                    ICAO = "NAX"
                });
                context.Routes.AddRange(routeList);

                List<Flight> flightList = new List<Flight>();
                flightList.Add(new Flight()
                {
                    AirplaneNo = "DY35",
                    Departure = "CPH",
                    Arrival = "BLL",
                    RouteICAO = "SAS",
                    DepartureTime = new DateTime(2021, 01, 27, 12, 0, 0),
                    ArrivalTime = new DateTime(2021, 01, 27, 14, 0, 0)
                });
                flightList.Add(new Flight()
                {
                    AirplaneNo = "SK123",
                    Departure = "CPH",
                    Arrival = "BLL",
                    RouteICAO = "SAS",
                    DepartureTime = new DateTime(2021, 01, 27, 14, 0, 0),
                    ArrivalTime = new DateTime(2021, 01, 27, 16, 0, 0)
                });
                flightList.Add(new Flight()
                {
                    AirplaneNo = "SK123",
                    Departure = "BLL",
                    Arrival = "RNN",
                    RouteICAO = "SAS",
                    DepartureTime = new DateTime(2021, 02, 27, 10, 0, 0),
                    ArrivalTime = new DateTime(2021, 02, 27, 14, 0, 0)
                });
                context.Flights.AddRange(flightList);
                context.SaveChanges();


                foreach (var flight in context.Flights)
                {
                    Console.WriteLine("-----------");
                    Console.WriteLine(flight.Departure);
                    Console.WriteLine(flight.Arrival);
                    Console.WriteLine(flight.DepartureTime);
                    Console.WriteLine(flight.Airplane.Type);
                    Console.WriteLine("----------");
                }

            }
            Console.Read();
        }


    }
}
