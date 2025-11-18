using Casus_Progammeren_TDD;

namespace Casus_Programmeren_TDD
{
    internal class Program
    {
        // console input/output voor de beheerder om ruimtes aan te maken
        static void Main(string[] args)
        {
            Console.WriteLine("Maak een nieuwe ruimte aan:\n");

            Space userSpace = Space.LetUserDefineSpace();

            Console.WriteLine("\nNieuwe ruimte aangemaakt:");
            Console.WriteLine($"Naam: {userSpace.Naam}");
            Console.WriteLine($"Type: {userSpace.Type}");
            Console.WriteLine($"Capaciteit: {userSpace.Capacity}");
            Console.WriteLine($"X: {userSpace.XCoordinate}");
            Console.WriteLine($"Y: {userSpace.YCoordinate}");

            Console.WriteLine("\nDruk op een toets om af te sluiten...");
            Console.ReadKey();
        }
    }
}
