using System.Text.RegularExpressions;

namespace Casus_Programmeren_Console
{
    public class Costs
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
                        {"Werkruimte in Spectrum", 120},
                        {"Werkruimte in Prisma", 150},
                        {"Publieke ruimte", 250}
                    }

                },
                {
                    "Verwarmingskosten", // deze kosten zijn alleen van toepassing in de morgen
                        new Dictionary<string, float>
                        {
                            {"Uur 1", 5},
                            {"Uur 2", 4},
                            {"Uur 3", 3},
                            {"Uur 4", 2}
                        }
                },
                {
                    "kortingsfactor",
                        new Dictionary<string, float>
                        {
                            {"vrijdag", 0.8f}
                        }
                }
            };
        // methode vraag de gebruiker de benodigde informatie voor één of meerdere reserveringen.
        // de gebruiker kan via single of multiple selecties in de console aangeven welke ruimtes hij wil huren.
        // 1. welke ruimtes (geselecteerde opties uit the keys van Cost_Overview, vaste kosten)
        // 2. aantal personen (wanner relevant), begintijden per gehuurde ruimte
        // 3. aantal uren per ruimte
        // 4. dag van de week per ruimte
        public Dictionary<string, (int aantalPersonen, DateTime begintijd, int aantalUren, DayOfWeek dagVanDeWeek)> Get_user_input_for_reservations()
        {
            var reserveringen = new Dictionary<string, (int, DateTime, int, DayOfWeek)>();

            // implement logic to get user input for reservations
            return reserveringen;
        }

        // methode rekent de totale kosten uit per aanvraag.
        // Als input krijgt het een dictionary met:
        // 1. welke ruimtes (geselecteerde opties uit the keys van Cost_Overview, vaste kosten)
        // 2. aantal personen (wanner relevant), begintijden per gehuurde ruimte
        // 3. aantal uren per ruimte
        // 4. dag van de week per ruimte
        // Cost_Overview wordt gebruikt om de kosten per ruimte te bepalen.

        // methode die bepaald welk lokaal gebruikt moet worden in verbant met de capasiteit. 
        // kiest uit Cost_Overview, vaste kosten, de ruimte die het beste past bij het aantal reserveringen.
        public string Select_Room_Based_On_N_Reservation(string gebouw, int aantalPersonen, string ruimte)
        {
            // implement logic to select room based on capacity
            string geselecteerde_ruimte = "";
            if (ruimte.StartsWith("Lokaal"))
            {
                if (gebouw == "Spectrum")
                {
                    if (aantalPersonen <= 30)
                    {
                        geselecteerde_ruimte = "Lokaal 27 Spectrum";
                    }
                    else
                    {
                        geselecteerde_ruimte = "Lokaal 60 Spectrum";
                    }
                }
                else if (gebouw == "Prisma")
                {
                    if (aantalPersonen <= 30)
                    {
                        geselecteerde_ruimte = "Lokaal 27 Prisma";
                    }
                    else
                    {
                        geselecteerde_ruimte = "Lokaal 60 Prisma";
                    }
                }
            }
            else
            // werkruimte of publieke ruimte
            {
                if (gebouw == "Spectrum")
                {
                    geselecteerde_ruimte = "Werkruimte Spectrum";
                }
                else if (gebouw == "Prisma")
                {
                    geselecteerde_ruimte = "Werkruimte Prisma";
                }
                else
                {
                    geselecteerde_ruimte = "Publieke ruimte";
                }
            }

            return geselecteerde_ruimte;
        }

        private float CalculateHeatingCosts(DateTime begintijd, int aantalUren)
        {
            float heatingCost = 0f;

            DateTime current = begintijd;
            int heatingIndex = 0; // telt alleen de uren mét verwarming

            for (int i = 1; i <= aantalUren; i++)
            {
                // alleen uren die in de ochtend beginnen
                if (current.Hour < 12)
                {
                    heatingIndex++; // 1e verwarmd uur, 2e, 3e...

                    string uurKey = $"Uur {heatingIndex}";
                    if (Cost_Overview["Verwarmingskosten"].TryGetValue(uurKey, out float uurPrijs))
                    {
                        heatingCost += uurPrijs;
                        Console.WriteLine($"Added heating cost for {uurKey} at {current:yyyy-MM-dd HH:mm}: {uurPrijs}");
                    }
                    else
                    {
                        Console.WriteLine($"No heating price defined for {uurKey}");
                    }
                }
                else
                {
                    Console.WriteLine($"No heating cost for hour {i}, time is {current:yyyy-MM-dd HH:mm} (not morning)");
                }

                current = current.AddHours(1);
            }

            Console.WriteLine($"Total heating costs for reservation: {heatingCost}");
            return heatingCost;
        }

        // methode om capaciteit uit room name te halen
        private int GetCapacityFromRoomName(string roomName)
        {
            var match = Regex.Match(roomName, @"\d+");
            if (match.Success)
            {
                return int.Parse(match.Value);
            }
            return 0;
        }

        public float Calculate_total_cost(Dictionary<string, (int aantalPersonen, DateTime begintijd, int aantalUren, DayOfWeek dagVanDeWeek, string gebouw)> reserveringen)
        {
            float totalCost = 0;

            // use Cost_Overview and reserveringen to calculate total cost
            // implement logic to calculate total cost based on input parameters
            // loop through each reservation
            // i added logging for debugging purposes
            foreach (var reservering in reserveringen)
            {
                string ruimte = reservering.Key;
                int aantalPersonen = reservering.Value.aantalPersonen;
                DateTime begintijd = reservering.Value.begintijd;
                int aantalUren = reservering.Value.aantalUren;
                DayOfWeek dagVanDeWeek = reservering.Value.dagVanDeWeek;

                float indiviual_reservation_cost = 0;

                // Add fixed costs if applicable
                // first check what room to select based on number of people
                string geselecteerde_ruimte = Select_Room_Based_On_N_Reservation(reservering.Value.gebouw, aantalPersonen, ruimte);
                Console.WriteLine($"Checking fixed costs for {geselecteerde_ruimte}");
                if (Cost_Overview["Vaste kosten"].ContainsKey(geselecteerde_ruimte))
                {
                    indiviual_reservation_cost += Cost_Overview["Vaste kosten"][geselecteerde_ruimte];
                    Console.WriteLine($"Added fixed cost for {geselecteerde_ruimte}: {Cost_Overview["Vaste kosten"][geselecteerde_ruimte]}");
                    Console.WriteLine($"Total costs: {indiviual_reservation_cost}");
                }
                // Add per person per hour costs if applicable
                Console.WriteLine($"Checking per person per hour costs for {ruimte}");

                // Alleen lokalen hebben "Huur per persoon per uur"
                if (ruimte.StartsWith("Lokaal"))
                {
                    // tarief per persoon per uur hangt af van gebouw
                    float tariefPerPersoonPerUur;

                    if (reservering.Value.gebouw == "Spectrum")
                    {
                        tariefPerPersoonPerUur = Cost_Overview["Huur per persoon per uur"]["Lokaal in Spectrum"];
                    }
                    else // Prisma
                    {
                        tariefPerPersoonPerUur = Cost_Overview["Huur per persoon per uur"]["Lokaal in Prisma"];
                    }

                    // capaciteit uit de gekozen ruimte, bv "Lokaal 27 Spectrum" → 27
                    int capaciteit = GetCapacityFromRoomName(geselecteerde_ruimte);

                    float pphCost = tariefPerPersoonPerUur * capaciteit * aantalUren;
                    indiviual_reservation_cost += pphCost;

                    Console.WriteLine($"Capacity for {geselecteerde_ruimte}: {capaciteit}");
                    Console.WriteLine($"Added per person per hour cost (capacity based) for {ruimte}: {pphCost}");
                    Console.WriteLine($"Total costs: {indiviual_reservation_cost}");
                }

                // Add per day costs if applicable
                Console.WriteLine($"Checking per day costs for {ruimte}");
                if (Cost_Overview["Huur per dag"].ContainsKey(ruimte))
                {
                    indiviual_reservation_cost += Cost_Overview["Huur per dag"][ruimte];
                    Console.WriteLine($"Added per day cost for {ruimte}: {Cost_Overview["Huur per dag"][ruimte]}");
                    Console.WriteLine($"Total costs: {indiviual_reservation_cost}");
                }
                // Add heating costs based on hours
                Console.WriteLine($"Calculating heating costs for {aantalUren} hours starting at {begintijd:HH:mm}");
                float heatingCost = CalculateHeatingCosts(begintijd, aantalUren);
                indiviual_reservation_cost += heatingCost;
                Console.WriteLine($"Total costs after heating: {indiviual_reservation_cost}");

                // Apply discount if it's Friday
                Console.WriteLine($"Checking for discounts on {dagVanDeWeek}");
                Console.WriteLine($"Day of week: {dagVanDeWeek}");
                if (dagVanDeWeek == DayOfWeek.Friday && Cost_Overview["kortingsfactor"].ContainsKey("vrijdag"))
                {
                    indiviual_reservation_cost *= Cost_Overview["kortingsfactor"]["vrijdag"];
                }

                Console.WriteLine($"Final total costs: {indiviual_reservation_cost}");
                Console.WriteLine($"-----------------------------------");

                totalCost += indiviual_reservation_cost;
            }
            Console.WriteLine($"Total cost for all reservations: {totalCost}");
            return totalCost;
        }

    }

}
