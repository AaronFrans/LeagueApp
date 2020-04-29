
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Team
    {
        public Team(int stamnummer, string naam, string bijnaam, string trainer)
        {
            Stamnummer = stamnummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;

            Spelers = new List<Speler>();
        }

        public Team(int stamnummer, string naam, string bijnaam, string trainer, List<Speler> spelers)
        {
            Stamnummer = stamnummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;

            Spelers = spelers;
        }

        [Key]
        public int Stamnummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> Spelers { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Team team &&
                   Stamnummer == team.Stamnummer;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Stamnummer);
        }
        public override string ToString()
        {
            string toReturn = $"Team: {Naam} met bijnaam: {Bijnaam}, Stamnummer: {Stamnummer}, Trainer: {Trainer}, Spelers: \n";
            if (Spelers.Count > 0)
            {
                foreach (var speler in Spelers)
                {
                    toReturn += $"{speler} \n";
                }
            }
            else
            {
                toReturn += "Geen Spelers";
            }

            return toReturn;
        }
    }
}
