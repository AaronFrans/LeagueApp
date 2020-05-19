using Microsoft.EntityFrameworkCore;
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
                ctx.SaveChanges();
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Speler met id {1}: \n{0} is nu geüpdate\n", speler, spelerId);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Speler met id {1}: \n{0} is niet gevonden in databank\n", speler, spelerId);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
        }

        public void UpdateTeam(Team team)
        {
            if (ctx.Teams.Any(s => s.Stamnummer == team.Stamnummer))
            {
                Team teamToUpdate = ctx.Teams.Include(t => t.Spelers).Single(s => s.Stamnummer == team.Stamnummer);
                teamToUpdate.Naam = team.Naam;
                teamToUpdate.Bijnaam = team.Bijnaam;
                teamToUpdate.Trainer = team.Trainer;
                for (int i = 0; i < teamToUpdate.Spelers.Count; i++)
                {
                    if (!team.Spelers.Contains(teamToUpdate.Spelers[i]))
                    {
                        teamToUpdate.Spelers.Remove(teamToUpdate.Spelers[i]);
                        i--;
                    }
                }
                foreach(var speler in team.Spelers)
                {
                    if (!teamToUpdate.Spelers.Contains(speler))
                    {
                        if(ctx.Spelers.Any(s=> s.Equals(speler)))
                        {
                            Speler toAdd = ctx.Spelers.Single(s => s.Equals(speler));
                            teamToUpdate.Spelers.Add(speler);
                        }
                        else
                        {
                            teamToUpdate.Spelers.Add(speler); 
                        }
                    }
                }
                ctx.SaveChanges();
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Team met Stamnummer{1}: \n{0} is nu geüpdate\n", team, team.Stamnummer);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("Team met Stamnummer{1}: \n{0} is niet gevonden in databank\n", team, team.Stamnummer);
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
                Team test = ctx.Teams.Include(team => team.Spelers).Single(s => s.Stamnummer == stamnummer);
                foreach (var speler in test.Spelers)
                {
                    Console.WriteLine(speler);
                }
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
                return ctx.Transfers.Where(s => s.TransferId == id).Include(t=>t.TransferredSpeler).Include(t=>t.OudTeam).Include(t=> t.NieuwTeam).First();
            }
            else
            {
                return null;
            }
        }



    }
}
