using Newtonsoft.Json;

namespace Data_Layer.Model
{
    public class TeamEvent
    {
        [JsonProperty("type_of_event")]
        public string TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }
    }
}
