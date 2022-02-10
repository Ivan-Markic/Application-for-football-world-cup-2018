using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data_Layer.Model
{
    public class Match
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        public int Attendance { get; set; }

        [JsonProperty("home_team")]
        public Team home_team { get; set; }

        [JsonProperty("away_team")]
        public Team away_team { get; set; }


        [JsonProperty("home_team_events")]
        public List<TeamEvent> homeTeamEvent { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> awayTeamEvent { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics homeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics awayTeamStatistics { get; set; }

    }
}
