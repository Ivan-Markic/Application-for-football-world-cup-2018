using Data_Layer.Model;
using System.Collections.Generic;

namespace Data_Layer.Repo
{
    public interface IRepo
    {
        List<Country> GetCountries();
        List<Player> GetPlayers(List<Match> matches);
        List<Player> GetPlayers();
        List<Match> GetMatches();
        List<Match> GetSpecificMatches();
    }
}
