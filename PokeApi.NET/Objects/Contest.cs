using Newtonsoft.Json;

namespace PokeAPI
{
    public class ContestType : NamedApiObject
    {
        [JsonProperty("berry_flavor")]
        public NamedApiResource<BerryFlavor> BerryFlavor { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class ContestEffect : ApiObject
    {
        [JsonProperty("appeal")]
        public int Appeal { get; internal set; }

        [JsonProperty("jam")]
        public int Jam { get; internal set; }

        [JsonProperty("effect_entries")]
        public Effect[] Effects { get; internal set; }
        [JsonProperty("flavor_text_entries")]
        public FlavorText[] FlavorTexts { get; internal set; }
    }

    public class SuperContestEffect : ApiObject
    {
        [JsonProperty("appeal")]
        public int Appeal { get; internal set; }

        [JsonProperty("flavor_text_entries")]
        public FlavorText[] FlavorTexts { get; internal set; }

        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }
    }
}
