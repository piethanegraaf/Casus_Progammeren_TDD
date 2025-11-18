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
    }
}