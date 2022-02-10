using Data_Layer.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Layer.Repo
{

    internal class APIRepo : IRepo
    {
        private readonly RestClient client;


        public APIRepo()
        {
            if (PreferencesRepo.ReadChampionship())
            {
                client = new RestClient(PreferencesRepo.men);
            }
            else
            {
                client = new RestClient(PreferencesRepo.women);
            }

        }

        public List<Country> GetCountries()
        {
            var request = new RestRequest(@"teams\results", Method.GET);

            Task<IRestResponse<List<Country>>> data = client.ExecuteAsync<List<Country>>(request);


            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(data.Result.Content);

            return countries;
        }

        public List<Match> GetMatches()
        {

            var request = new RestRequest("matches", Method.GET);

            Task<IRestResponse<List<Match>>> response = client.ExecuteAsync<List<Match>>(request);


            List<Match> matches = JsonConvert.DeserializeObject<List<Match>>(response.Result.Content);
            
            return matches;
        }

        public List<Player> GetPlayers()
        {
            var matches = GetSpecificMatches();

            List<Player> players = GetPlayers(matches);

            return players;
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

        public List<Match> GetSpecificMatches()
        {
            string country = PreferencesRepo.ReadMainCountry();
            List<Match> matches = GetMatches();
            matches = matches.FindAll(match => match.homeTeamStatistics.Country == country || match.awayTeamStatistics.Country == country);
            return matches;
        }
    }
}
