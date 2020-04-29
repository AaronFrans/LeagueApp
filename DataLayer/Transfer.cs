

using System;

namespace DataLayer
{
    public class Transfer
    {
        public Transfer(Speler transferredSpeler, double transferPrijs, Team oudTeam, Team nieuwTeam)
        {
            TransferredSpeler = transferredSpeler;
            TransferPrijs = transferPrijs;
            OudTeam = oudTeam;
            NieuwTeam = nieuwTeam;
            if (OudTeam.Spelers.Contains(TransferredSpeler) & !NieuwTeam.Spelers.Contains(TransferredSpeler))
            {
                OudTeam.Spelers.Remove(TransferredSpeler);
                NieuwTeam.Spelers.Add(TransferredSpeler);
            }
            else if(NieuwTeam.Spelers.Contains(TransferredSpeler) & OudTeam.Spelers.Contains(TransferredSpeler))
            {
                OudTeam.Spelers.Remove(TransferredSpeler);
            }
            else if(!NieuwTeam.Spelers.Contains(TransferredSpeler) & !OudTeam.Spelers.Contains(TransferredSpeler))
            {
                NieuwTeam.Spelers.Add(TransferredSpeler);
            }
        }

        public Transfer(double transferPrijs)
        {
            TransferPrijs = transferPrijs;
        }

        public int TransferId { get; set; }
        public Speler TransferredSpeler { get; set; }
        public double TransferPrijs { get; set; }
        public Team OudTeam { get; set; }
        public Team NieuwTeam { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Transfer transfer &&
                   TransferId == transfer.TransferId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(TransferId);
        }
        public override string ToString()
        {
            return $"Speler: {TransferredSpeler.Naam} is van Team: {OudTeam.Naam} naar Team: {NieuwTeam.Naam} getransferd voor een waarde van {TransferPrijs} euro";
        }
    }
}
