using DataLayer;
using LeaqueApp.Func;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;

namespace LeaqueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Teams van File Begin");
            Parser.InitDb(@"C:\Users\aaron\Downloads\foot.csv");
            Console.WriteLine("Teams van File Einde");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Toevoegen Begin");
            //AddTest();
            Console.WriteLine("Toevoegen Einde");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Update Begin");

            Console.WriteLine("Update Einde");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("Select Begin");
            //SelectTest();
            Console.WriteLine("Select Einde");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        static void AddTest()
        {
            Speler speler1 = new Speler("Jeff Bobo", 19, 660000);
            Speler speler2 = new Speler("Rando Nai", 22, 1000000);
            Speler speler3 = new Speler("Aja Che", 10, 55000);
            Speler speler4 = new Speler("Dwight Shrute", 11, 666000);
            Team team1 = new Team(66666, "The OG Team", "Ogs", "That Guy");
            Team team2 = new Team(90000, "The Not OG Team", "NOgs", "That Other Guy");
            team1.Spelers.Add(speler1);
            team1.Spelers.Add(speler2);
            team1.Spelers.Add(speler3);
            team2.Spelers.Add(speler4);
            Transfer t1 = new Transfer(speler4, 600000, team2, team1);
            Transfer t2 = new Transfer(speler2, 900000, team2, team1);
            LeagueBeheer lb = new LeagueBeheer();
            lb.VoegSpelerToe(speler1);
            lb.VoegSpelerToe(speler2);
            lb.VoegSpelerToe(speler3);
            lb.VoegSpelerToe(speler4);
            lb.VoegTeamToe(team1);
            lb.VoegTeamToe(team2);
            lb.VoegTransferToe(t1);
            lb.VoegTransferToe(t2);
        }

        static void SelectTest()
        {
            LeagueBeheer lb = new LeagueBeheer();
            Speler s1 = lb.SelecteerSpeler(50);
            if (s1 != null)
            {
                Console.WriteLine("Speler met id 50 is gevonden");
            }
            else
            {
                Console.WriteLine("Speler met id 50 is niet gevonden");
            }
            Speler s2 = lb.SelecteerSpeler(9);
            if (s2 != null)
            {
                Console.WriteLine("Speler met id 9 is gevonden");
            }
            else
            {
                Console.WriteLine("Speler met id 9 is niet gevonden");
            }
            Speler s3 = lb.SelecteerSpeler(100);
            if (s3 != null)
            {
                Console.WriteLine("Speler met id 100 is gevonden");
            }
            else
            {
                Console.WriteLine("Speler met id 100 is niet gevonden");
            }
            Team tea1 = lb.SelecteerTeam(1);
            if (tea1 != null)
            {
                Console.WriteLine("Team met id 1 is gevonden");
            }
            else
            {
                Console.WriteLine("Team met id 1 is niet gevonden");
            }
            Team tea2 = lb.SelecteerTeam(900000);
            if (tea2 != null)
            {
                Console.WriteLine("Team met id 900000 is gevonden");
            }
            else
            {
                Console.WriteLine("Team met id 900000 is niet gevonden");
            }
            Team tea3 = lb.SelecteerTeam(900000);
            if (tea3 != null)
            {
                Console.WriteLine("Team met id 600000 is gevonden");
            }
            else
            {
                Console.WriteLine("Team met id 600000 is niet gevonden");
            }
            Transfer t1 = lb.SelecteerTransfer(1);
            if (t1 != null)
            {
                Console.WriteLine("Transfer met id 1 is gevonden");
            }
            else
            {
                Console.WriteLine("Transfer met id 1 is niet gevonden");
            }
            Transfer t2 = lb.SelecteerTransfer(99);
            if (t2 != null)
            {
                Console.WriteLine("Transfer met id 99 is gevonden");
            }
            else
            {
                Console.WriteLine("Transfer met id 99 is niet gevonden");
            }
        }
    
        static void UpdateTest()
        {
            LeagueBeheer lb = new LeagueBeheer();
            Team team1 = new Team(66666, "The OG Team", "Ogs", "That Guy's Other Borther");
            Team team2 = new Team(55, "Not Exist", "Fake", "Some Guy");
            lb.UpdateTeam(team1);
            lb.UpdateTeam(team2);
            Speler speler1 = new Speler("Rando Naim", 23, 1000);
            Speler speler2 = new Speler("Aja Ches", 10, 5500000);
            lb.UpdateSpeler(speler2, 2);
            lb.UpdateSpeler(speler1, 5);
        }
    }
}
