using Data_Layer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Data_Layer.Repo
{
    internal class FileRepo : IRepo
    {


        public List<Country> GetCountries()
        {
            string path = PreferencesRepo.ReadChampionship() ? PreferencesRepo.GetResourceFileDir("men/results.json") : PreferencesRepo.GetResourceFileDir("women/results.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Country>>(json);
            }
        }

        public List<Match> GetMatches()
        {

            string json = String.Empty;

            using (StreamReader r = new StreamReader(PreferencesRepo.ReadChampionship() ? PreferencesRepo.GetResourceFileDir("men/matches.json") : PreferencesRepo.GetResourceFileDir("women/matches.json")))
            {
                json = r.ReadToEnd();
            }
            var matches = JsonConvert.DeserializeObject<List<Match>>(json);

            return matches;
        }

        public List<Player> GetPlayers(List<Match> matches)
        {
            string country = PreferencesRepo.ReadMainCountry();

            matches = matches.FindAll(match => match.homeTeamStatistics.Country == country || match.awayTeamStatistics.Country == country);
            var data = new List<TeamStatistics>();

            foreach (Match match in matches)
            {
                if (match.awayTeamStatistics.Country == country)
                {
                    if (!data.Contains(match.awayTeamStatistics))
                    {
                        data.Add(match.awayTeamStatistics);
                    }
                }
                else if (match.homeTeamStatistics.Country == country)
                {
                    if (!data.Contains(match.homeTeamStatistics))
                    {
                        data.Add(match.homeTeamStatistics);
                    }
                }
            }

            List<Player> players = new List<Player>();



            foreach (TeamStatistics team in data)
            {
                if (team.Country == country)
                {
                    foreach (Player player in team.StartingEleven)
                    {
                        players.Add(player);
                    }

                    foreach (Player player in team.Substitutes)
                    {
                        players.Add(player);
                    }
                    break;
                }
            }

            return players;
        }


        public List<Player> GetPlayers()
        {
            var matches = GetMatches();


            List<Player> players = GetPlayers(matches);

            return players;
        }

        public List<Match> GetSpecificMatches()
        {
            string country = PreferencesRepo.ReadMainCountry();
            List<Match> matches = GetMatches();
            matches = matches.FindAll(match => match.homeTeamStatistics.Country == country || match.awayTeamStatistics.Country == country);
            
            return matches;
        }
    }
}
