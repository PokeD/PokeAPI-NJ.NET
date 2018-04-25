using Newtonsoft.Json;

namespace PokeAPI
{
    public struct EvolutionDetail
    {
        [JsonProperty("item")]
        public NamedApiResource<Item> Item { get; internal set; }

        [JsonProperty("trigger")]
        public NamedApiResource<EvolutionTrigger> Trigger { get; internal set; }

        [JsonProperty("gender")]
        public int? Gender { get; internal set; }

        [JsonProperty("held_item")]
        public NamedApiResource<Item> HeldItem { get; internal set; }

        [JsonProperty("known_move")]
        public NamedApiResource<Move> KnownMove { get; internal set; }

        [JsonProperty("known_move_type")]
        public NamedApiResource<PokemonType> KnownMoveType { get; internal set; }

        [JsonProperty("location")]
        public NamedApiResource<Location> Location { get; internal set; }

        [JsonProperty("min_level")]
        public int? MinLevel { get; internal set; }
        [JsonProperty("min_happiness")]
        public int? MinHappiness { get; internal set; }
        [JsonProperty("min_beauty")]
        public int? MinBeauty { get; internal set; }
        [JsonProperty("min_affection")]
        public int? MinAffection { get; internal set; }
        [JsonProperty("needs_overworld_rain")]
        public bool NeedsOverworldRain { get; internal set; }

        [JsonProperty("party_species")]
        public NamedApiResource<PokemonSpecies> PartySpecies { get; internal set; }

        [JsonProperty("party_type")]
        public NamedApiResource<PokemonType> PartyType { get; internal set; }

        [JsonProperty("relative_physical_stats")]
        public int? RelativePhysicalStats { get; internal set; }

        [JsonProperty("time_of_day")]
        public string TimeOfDay { get; internal set; }

        [JsonProperty("trade_species")]
        public NamedApiResource<PokemonSpecies> TradeSpecies { get; internal set; }

        [JsonProperty("turn_upside_down")]
        public bool TurnUpsideDown { get; internal set; }
    }

    public struct ChainLink
    {
        [JsonProperty("is_baby")]
        public bool IsBaby { get; internal set; }

        [JsonProperty("species")]
        public NamedApiResource<PokemonSpecies> Species { get; internal set; }

        [JsonProperty("evolution_details")]
        public EvolutionDetail[] Details { get; internal set; }

        [JsonProperty("evolves_to")]
        public ChainLink[] EvolvesTo { get; internal set; }
    }

    public class EvolutionChain : ApiObject
    {
        [JsonProperty("baby_trigger_item")]
        public NamedApiResource<Item> BabyTriggerItem { get; internal set; }

        [JsonProperty("chain")]
        public ChainLink Chain { get; internal set; }
    }

    public class EvolutionTrigger : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }
    }
}
