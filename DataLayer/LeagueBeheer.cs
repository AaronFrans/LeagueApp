using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class LeagueBeheer
    {

        private LeagueContext ctx;

        public LeagueBeheer()
        {
            ctx = new LeagueContext();
        }

        public void VoegSpelerToe(Speler speler)
        {
            ctx.Spelers.Add(speler);
            ctx.SaveChanges();
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Speler: \n{0} is nu in databank\n", speler);
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        public void VoegTeamToe(Team team)
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Team: \n{0} is nu in databank\n", team);
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        public void VoegTransferToe(Transfer transfer)
        {
            ctx.Transfers.Add(transfer);
            ctx.SaveChanges();
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Transfer: \n{0} is nu in databank\n", transfer);
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        public void UpdateSpeler(Speler speler, int spelerId)
        {

            if (ctx.Spelers.Any(s => s.SpelerId == spelerId))
            {
                Speler spelerToUpdate = ctx.Spelers.Single(s => s.SpelerId == spelerId);
                spelerToUpdate.Naam = speler.Naam;
                spelerToUpdate.Rugnummer = speler.Rugnummer;
                spelerToUpdate.Waarde = speler.Waarde;
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Speler: \n{0} is nu geüpdate\n", speler);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Speler: \n{0} is niet gevonden in databank\n", speler);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
        }

        public void UpdateTeam(Team team)
        {
            if (ctx.Teams.Any(s => s.Stamnummer == team.Stamnummer))
            {
                Team teamToUpdate = ctx.Teams.Single(s => s.Stamnummer == team.Stamnummer);
                teamToUpdate.Naam = team.Naam;
                teamToUpdate.Bijnaam = team.Bijnaam;
                teamToUpdate.Trainer = team.Trainer;
                teamToUpdate.Spelers = team.Spelers;
                ctx.SaveChanges();
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Team: \n{0} is nu geüpdate\n", team);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Team: \n{0} is niet gevonden in databank\n", team);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
        }


        public Speler SelecteerSpeler(int id)
        {
            if (ctx.Spelers.Any(s => s.SpelerId == id))
            {
                return ctx.Spelers.Where(s => s.SpelerId == id).First();
            }
            else
            {
                return null;
            }
        }

        public Team SelecteerTeam(int stamnummer)
        {
            if (ctx.Teams.Any(s => s.Stamnummer == stamnummer))
            {
                return ctx.Teams.Where(s => s.Stamnummer == stamnummer).First();
            }
            else
            {
                return null;
            }
        }

        public Transfer SelecteerTransfer(int id)
        {
            if (ctx.Transfers.Any(s => s.TransferId == id))
            {
                return ctx.Transfers.Where(s => s.TransferId == id).First();
            }
            else
            {
                return null;
            }
        }



    }
}
