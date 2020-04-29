
using System;

namespace DataLayer
{
    public class Speler
    {
        public Speler(string naam, int rugnummer, int waarde)
        {
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;
        }

        public int SpelerId { get; set; }
        public string Naam { get; set; }
        public int Rugnummer { get; set; }
        public int Waarde { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Speler speler &&
                   Naam == speler.Naam &&
                   Rugnummer == speler.Rugnummer &&
                   Waarde == speler.Waarde;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Naam, Rugnummer, Waarde);
        }
        public override string ToString()
        {
            return $"Naam : {Naam}, ID: {SpelerId}, Rugnummer: {Rugnummer}, met geschatte waarde van {Waarde}";
        }
    }
}
