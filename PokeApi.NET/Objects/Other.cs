using Newtonsoft.Json;

namespace PokeAPI
{
    public class Ability : NamedApiObject
    {
        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; internal set; }

        [JsonProperty("generation")]
        public NamedApiResource<Generation> Generation { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("effect_entries")]
        public VerboseEffect[] Effects { get; internal set; }

        [JsonProperty("effect_changes")]
        public AbilityEffectChange[] EffectChanges { get; internal set; }

        [JsonProperty("flavor_text_entries")]
        public VersionGroupFlavorText[] FlavorTexts { get; internal set; }

        [JsonProperty("pokemon")]
        public AbilityPokemon[] Pokemon { get; internal set; }
    }

    public class Characteristic : ApiObject
    {
        [JsonProperty("highest_stat")]
        public NamedApiResource<Stat> HighestStat { get; internal set; }

        [JsonProperty("gene_modulo")]
        public int GeneModulo { get; internal set; }

        [JsonProperty("possible_values")]
        public int[] PossibleValues { get; internal set; }

        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }
    }

    public class EggGroup : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }
    }

    public class Gender : NamedApiObject
    {
        [JsonProperty("pokemon_species_details")]
        public PokemonSpeciesGender[] SpeciesDetails { get; internal set; }

        [JsonProperty("required_for_evolution")]
        public NamedApiResource<PokemonSpecies>[] RequiredForEvolution { get; internal set; }
    }

    public class GrowthRate : NamedApiObject
    {
        /// <summary>
        /// LaTeX-style (maths mode)
        /// </summary>
        [JsonProperty("formula")]
        public string Formula { get; internal set; }

        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }

        [JsonProperty("levels")]
        public GrowthRateExperienceLevel[] Levels { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }
    }

    public class Nature : NamedApiObject
    {
        [JsonProperty("decreased_stat")]
        public NamedApiResource<Stat> DecreasedStat { get; internal set; }
        [JsonProperty("increased_stat")]
        public NamedApiResource<Stat> IncreasedStat { get; internal set; }

        [JsonProperty("hates_flavor")]
        public NamedApiResource<BerryFlavor> HatesFlavor { get; internal set; }
        [JsonProperty("likes_flavor")]
        public NamedApiResource<BerryFlavor> LikesFlavor { get; internal set; }

        [JsonProperty("pokeathlon_stat_changes")]
        public NatureStatChange[] PokeathlonStatChanges { get; internal set; }

        [JsonProperty("move_battle_style_preferences")]
        public MoveBattleStylePreference[] BattleStylePreferences { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class PokeathlonStat : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("affecting_natures")]
        public NaturePokeathlonStatAffectSets AffectingNatures { get; internal set; }
    }

    public class Machine : ApiObject
    {
        [JsonProperty("item")]
        public NamedApiResource<Item> Item { get; internal set; }
        [JsonProperty("move")]
        public NamedApiResource<Move> Move { get; internal set; }
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }
    }
}
