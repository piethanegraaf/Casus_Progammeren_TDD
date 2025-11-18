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
            Naam = naam;
            Type = type;
            Capacity = capacity;
            XCoordinate = x_coordinate;
            YCoordinate = y_coordinate;
        }
        // method to let user define a space via console input
        public static Space LetUserDefineSpace()
        {
            Console.WriteLine("Voer de naam van de ruimte in:");
            string naam = Console.ReadLine();

            Console.WriteLine("Voer het type van de ruimte in:");
            string type = Console.ReadLine();

            Console.WriteLine("Voer de capaciteit van de ruimte in:");
            float capacity = float.Parse(Console.ReadLine());

            Console.WriteLine("Voer de X-coördinaat van de ruimte in:");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Voer de Y-coördinaat van de ruimte in:");
            int y = int.Parse(Console.ReadLine());

            return new Space(naam, type, capacity, x, y);
        }

        // method to calculate oxygon comsumption and remaining oxygen in the space after consumption
        // Benadering voor Zuurstofgebruik
        // Gemiddelde zuurstofconsumptie per persoon is 30 liter zuurstof per uur.
        // Zuurstofinhoud in de lucht: De lucht bestaat voor ongeveer 21% uit zuurstof.
        //  O = 30 × n × t waarbij: O = totaal zuurstofverbruik in liters, n = aantal personen, t = tijd in uren
        //  Beschikbare zuurstof = V × 0,21 × 1000 waarbij:
        //  V = volume van de ruimte in kubieke meters(m³)
        //  0,21 = fractie zuurstof in de lucht
        //  1000 = omzetting van m³ naar liters
        //  • De tijd T(in uren) dat de zuurstof in een ruimte van volume V voldoende is voor n personen kan worden berekend met:
        //  T = (V × 0,21 × 1000) / 30 × n
        public (float oxygenConsumed, float oxygenRemaining) CalculateOxygenUsage(int numberOfPeople, float timeInHours)
        {
            // Calculate total oxygen consumption
            float oxygenConsumed = 30 * numberOfPeople * timeInHours;
            // Calculate available oxygen in the space
            float availableOxygen = Capacity * 0.21f * 1000; // Convert m³ to liters
            // Calculate remaining oxygen
            float oxygenRemaining = availableOxygen - oxygenConsumed;
            return (oxygenConsumed, oxygenRemaining);
        }

    }
}