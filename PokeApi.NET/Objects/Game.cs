using Newtonsoft.Json;

namespace PokeAPI
{
    public struct PokemonEntry
    {
        [JsonProperty("entry_number")]
        public int EntryNumber { get; internal set; }
        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> Species { get; internal set; }
    }

    public class Generation : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("main_region")]
        public NamedApiResource<Region> MainRegion { get; internal set; }

        [JsonProperty("abilities")]
        public NamedApiResource<Ability>[] Abilities { get; internal set; }

        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }

        [JsonProperty("types")]
        public NamedApiResource<PokemonType>[] Types { get; internal set; }

        [JsonProperty("version_groups")]
        public NamedApiResource<VersionGroup>[] VersionGroups { get; internal set; }
    }

    public class Pokedex : NamedApiObject
    {
        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; internal set; }

        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_entries")]
        public PokemonEntry[] Entries { get; internal set; }

        [JsonProperty("region")]
        public NamedApiResource<Region> Region { get; internal set; }

        [JsonProperty("version_groups")]
        public NamedApiResource<VersionGroup>[] VersionGroups { get; internal set; }
    }

    public class GameVersion : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }
    }

    public class VersionGroup : NamedApiObject
    {
        [JsonProperty("order")]
        public int Order { get; internal set; }

        [JsonProperty("generation")]
        public NamedApiResource<Generation> Generation { get; internal set; }

        [JsonProperty("move_learn_methods")]
        public NamedApiResource<MoveLearnMethod>[] MoveLearnMethods { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokedexes")]
        public NamedApiResource<Pokedex>[] Pokedices { get; internal set; }

        [JsonProperty("regions")]
        public NamedApiResource<Region>[] Regions { get; internal set; }

        [JsonProperty("versions")]
        public NamedApiResource<GameVersion>[] Versions { get; internal set; }
    }
}
