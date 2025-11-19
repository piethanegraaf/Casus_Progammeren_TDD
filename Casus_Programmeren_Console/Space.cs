namespace Casus_Progammeren_TDD
{
    public class Space
    {
        public string Naam { get; }
        public string Type { get; }
        public float Capacity { get; }
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public Space(string naam, string type, float capacity, int x_coordinate, int y_coordinate)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("ongeldige waarde voor inhoud ruimte");
            }
            Naam = naam;
            Type = type;
            Capacity = capacity;
            XCoordinate = x_coordinate;
            YCoordinate = y_coordinate;
        }
        // method to let administrators define a space via console input
        public static Space LetAdministratorDefineSpace()
        {

            Console.WriteLine("Voer de naam van de ruimte in:");
            string naam = Console.ReadLine();

            Console.WriteLine("Voer het type van de ruimte in:");
            string type = Console.ReadLine();

            Console.WriteLine("Voer de capaciteit van de ruimte in:");
            float capacity = float.Parse(Console.ReadLine());
            if (capacity <= 0)
            {
                throw new ArgumentException("ongeldige waarde voor inhoud ruimte");
            }

            Console.WriteLine("Voer de X-coördinaat van de ruimte in:");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Voer de Y-coördinaat van de ruimte in:");
            int y = int.Parse(Console.ReadLine());

            return new Space(naam, type, capacity, x, y);
        }

        // method to calculate oxygen consumption and remaining oxygen in the space after consumption
        // Gemiddelde zuurstofconsumptie per persoon is 30 liter zuurstof per uur.
        // De lucht bestaat voor ongeveer 21% uit zuurstof.
        // O = 30 × n × t waarbij: O = totaal zuurstofverbruik in liters, n = aantal personen, t = tijd in uren
        // Beschikbare zuurstof = V × 0,21 × 1000 waarbij:
        // V = volume van de ruimte in kubieke meters(m³)
        // 0,21 = fractie zuurstof in de lucht
        // 1000 = omzetting van m³ naar liters
        // De tijd T(in uren) dat de zuurstof in een ruimte van volume V voldoende is voor n personen kan worden berekend met:
        // T = (V × 0,21 × 1000) / 30 × n
        public (float oxygenConsumed, float oxygenRemaining, float time) CalculateOxygenUsage(int numberOfPeople, float timeInHours)
        {
            if (numberOfPeople < 0)
            {
                throw new ArgumentException("ongeldige waarde voor aantal personen");
            }

            if (Capacity <= 0)
            {
                throw new ArgumentException("ongeldige waarde voor inhoud ruimte");
            }
            // Calculate total oxygen consumption
            float oxygenConsumed = 30 * numberOfPeople * timeInHours;
            // Calculate available oxygen in the space
            float availableOxygen = Capacity * 0.21f * 1000; // Convert m³ to liters
            // Calculate remaining oxygen after consumption
            float oxygenRemaining = availableOxygen - oxygenConsumed;
            // Calculate the time in hours that the oxygen will last
            float timeOxygenLasts = availableOxygen / (30 * numberOfPeople);
            return (oxygenConsumed, oxygenRemaining, timeOxygenLasts);
        }

    }
}