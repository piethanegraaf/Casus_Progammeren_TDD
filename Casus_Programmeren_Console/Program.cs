using Casus_Programmeren_Console;

namespace Casus_Programmeren_TDD
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // console input/output voor de beheerder om ruimtes aan te maken
            /*
            Console.WriteLine("Maak een nieuwe ruimte aan:\n");

            Space userSpace = Space.LetUserDefineSpace();

            Console.WriteLine("\nNieuwe ruimte aangemaakt:");
            Console.WriteLine($"Naam: {userSpace.Naam}");
            Console.WriteLine($"Type: {userSpace.Type}");
            Console.WriteLine($"Capaciteit: {userSpace.Capacity}");
            Console.WriteLine($"X: {userSpace.XCoordinate}");
            Console.WriteLine($"Y: {userSpace.YCoordinate}");

            // berekening van de hoeveelheid zuurstof die wordt verberuikt en overblijft in een ruimte
            Space testSpace = new Space("TestRoom", "Lab", 20, 5, 5);

            */
            //costs.Calculate_total_cost();
            Costs costs = new Costs();
            var reservations = new Dictionary<string, (int aantalPersonen, DateTime begintijd, int aantalUren, DayOfWeek dagVanDeWeek, string gebouw)>
            {
                { "Lokaal in Prisma", (10, new DateTime(2023, 1, 1, 23, 0, 0), 4, DayOfWeek.Sunday, "Prisma") }
            };
            float totalCost = costs.Calculate_total_cost(reservations);
            Console.WriteLine("\nDruk op een toets om af te sluiten...");
            Console.ReadKey();
        }
    }
}
