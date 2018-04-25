using Newtonsoft.Json;

namespace PokeAPI
{
    public struct EncounterVersionDetails
    {
        [JsonProperty("rate")]
        public int Rate { get; internal set; }
        [JsonProperty("version")]
        public NamedApiResource<GameVersion> Version { get; internal set; }
    }

    public struct EncounterMethodRate
    {
        [JsonProperty("encounter_method")]
        public NamedApiResource<EncounterMethod> EncounterMethod { get; internal set; }

        [JsonProperty("version_details")]
        public EncounterVersionDetails[] VersionDetails { get; internal set; }
    }

    public struct PokemonEncounter
    {
        [JsonProperty("pokemon")]
        public NamedApiResource<Pokemon> Pokemon { get; internal set; }

        [JsonProperty("version_details")]
        public VersionEncounterDetail[] VersionDetails { get; internal set; }
    }

    public struct PalParkEncounterSpecies
    {
        [JsonProperty("base_score")]
        public int BaseScore { get; internal set; }
        [JsonProperty("rate")]
        public int Rate { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> Species { get; internal set; }
    }

    public class Location : NamedApiObject
    {
        [JsonProperty("region")]
        public NamedApiResource<Region> Region { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("game_indices")]
        public GenerationGameIndex[] GameIndices { get; internal set; }

        [JsonProperty("areas")]
        public NamedApiResource<LocationArea>[] Areas { get; internal set; }
    }

    public class LocationArea : NamedApiObject
    {
        [JsonProperty("game_index")]
        public int GameIndex { get; internal set; }

        [JsonProperty("encounter_method_rates")]
        public EncounterMethodRate[] EncounterMethodRates { get; internal set; }

        [JsonProperty("location")]
        public NamedApiResource<Region> Region { get; internal set; }

        [JsonProperty("pokemon_encounters")]
        public PokemonEncounter[] Encounters { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class PalParkArea : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_encounters")]
        public PalParkEncounterSpecies[] Encounters { get; internal set; }
    }

    public class Region : NamedApiObject
    {
        [JsonProperty("locations")]
        public NamedApiResource<Location>[] Locations { get; internal set; }
        [JsonProperty("main_generation")]
        public NamedApiResource<Generation> MainGeneration { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokedexes")]
        public NamedApiResource<Pokedex>[] Pokedices { get; internal set; }

        [JsonProperty("version_groups")]
        public NamedApiResource<VersionGroup>[] VersionGroups { get; internal set; }
    }
}
