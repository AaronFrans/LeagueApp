using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeaqueApp.Func
{
    class Parser
    {
        public static void InitDb(string path)
        {
            Dictionary<int, List<Speler>> SpelerDict = new Dictionary<int, List<Speler>>();
            List<Team> TeamList = new List<Team>();

            using (StreamReader r = new StreamReader(path))
            {
                string line;            string spelerNaam;
                int spelerNummer;       string teamNaam;
                int spelerWaarde;       int teamStamnr;
                string teamTrainer;     string teamBijnaam;
                r.ReadLine();
                while ((line = r.ReadLine()) != null)
                {
                    string[] ss = line.Split(',');
                    spelerNaam = ss[0];
                    spelerNummer = int.Parse(ss[1]);
                    ss[3] = ss[3].Replace(" ", "");
                    spelerWaarde = int.Parse(ss[3]);
                    teamNaam = ss[2];
                    teamBijnaam = ss[6];
                    teamTrainer = ss[5];
                    teamStamnr = int.Parse(ss[4]);
                    Speler toAddSpeler = new Speler(spelerNaam, spelerNummer, spelerWaarde);
                    if (SpelerDict.ContainsKey(teamStamnr))
                    {
                        if (!SpelerDict[teamStamnr].Contains(toAddSpeler))
                        {
                            SpelerDict[teamStamnr].Add(toAddSpeler);
                        }

                    }
                    else
                    {
                        SpelerDict.Add(teamStamnr, new List<Speler>() { toAddSpeler });
                    }

                    Team toAddTeam = new Team(teamStamnr, teamNaam, teamBijnaam, teamTrainer);
                    if (!TeamList.Contains(toAddTeam))
                    {
                        TeamList.Add(toAddTeam);
                    }
                }

                foreach (var pair in SpelerDict)
                {
                    TeamList.Where(s => s.Stamnummer == pair.Key).First().Spelers = pair.Value;
                }
            }

            LeagueBeheer lb = new LeagueBeheer();
            foreach (var team in TeamList)
            {
                lb.VoegTeamToe(team);
            }
        }
    }
}
