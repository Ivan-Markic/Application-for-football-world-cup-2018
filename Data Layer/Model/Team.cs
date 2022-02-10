using Newtonsoft.Json;
using System;

namespace Data_Layer.Model
{
    public class Team : IComparable<Team>
    {
        [JsonProperty("country")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        public int CompareTo(Team other) => Name.CompareTo(other.Name);

        public override string ToString() => $"{Name}({Code})";

        public override bool Equals(object obj) => obj is Team team ? team.Name == Name : false;
    }
}
