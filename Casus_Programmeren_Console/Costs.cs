namespace Casus_Programmeren_Console
{
    internal class Costs
    {
        public Dictionary<string, Dictionary<string, float>> Cost_Overview =
            new Dictionary<string, Dictionary<string, float>>
            {
                {
                    "Vaste kosten",
                    new Dictionary<string, float>
                    {
                        {"Lokaal 27 Spectrum", 300},
                        {"Lokaal 60 Spectrum", 500},
                        {"Lokaal 27 Prisma", 275},
                        {"Lokaal 60 Prisma", 475},
                        {"Werkruimte Spectrum", 100},
                        {"Werkruimte Prisma", 90},
                        {"Publieke ruimte", 200}

                    }
                },
                {
                    "Huur per persoon per uur",
                    new Dictionary<string, float>
                    {
                        {"Lokaal in Spectrum", 20},
                        {"Lokaal in Prisma", 17.50f}
                    }
                },
                {
                    "Huur per dag",
                    new Dictionary<string, float>
                    {
                        {"Werkruimte in Spectrum:", 120},
                        {"Werkruimte in Prisma:", 150},
                        {"Publieke ruimte:", 250}
                    }

                },
                {
                    "Verwarmingskosten",
                        new Dictionary<string, float>
                        {
                            {"Uur 1:", 5},
                            {"Uur 2:", 4},
                            {"Uur 3:", 3},
                            {"Uur 4:", 2}
                        }
                },
                {
                    "kortingsfactor",
                        new Dictionary<string, float>
                        {
                            {"vrijdag:", 0.8f}
                        }
                }
            };

        public void Calculate_total_cost_per_hour()
        {
            // ask the user what space they want to rent
            Console.WriteLine("Welke ruimte wilt u huren?");
            foreach (var category in Cost_Overview)
            {
                Console.WriteLine($"\n{category.Key}:");
                foreach (var item in category.Value)
                {
                    Console.WriteLine($"- {item.Key} : €{item.Value}");
                }
            }
        }

    }

}
