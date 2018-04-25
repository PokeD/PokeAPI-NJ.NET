using System.Linq;

using Newtonsoft.Json;

namespace PokeAPI
{
    public class Pokemon : NamedApiObject
    {
        [JsonProperty("base_experience")]
        public int BaseExperience { get; internal set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; internal set; }

        [JsonProperty("height")]
        public int Height { get; internal set; }
        [JsonProperty("weight")]
        public int Mass { get; internal set; }

        [JsonProperty("order")]
        public int  Order { get; internal set; }

        [JsonProperty("abilities")]
        public PokemonAbility[] Abilities { get; internal set; }

        [JsonProperty("forms")]
        public NamedApiResource<PokemonForm>[] Forms { get; internal set; }

        [JsonProperty("game_indices")]
        public VersionGameIndex[] GameIndices { get; internal set; }

        [JsonProperty("held_items")]
        public PokemonHeldItem[] HeldItems { get; internal set; }

        //?
        [JsonProperty("location_area_encounters"), JsonConverter(typeof(StructResourceFromStringConverter<LocationAreaEncounter[]>))]
        public StructResource<LocationAreaEncounter[]> LocationAreaEncounters { get; internal set; }

        [JsonProperty("moves")]
        public PokemonMove[] Moves { get; internal set; }

        [JsonProperty("species")]
        public NamedApiResource<PokemonSpecies> Species { get; set; }

        [JsonProperty("stats")]
        public PokemonStats[] Stats { get; internal set; }

        [JsonProperty("types")]
        public PokemonTypeMap[] Types { get; internal set; }

        [JsonProperty("sprites")]
        public PokemonSprites Sprites { get; internal set; }
    }

    public class PokemonColor : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }
    }

    public class PokemonForm : NamedApiObject
    {
        [JsonProperty("order")]
        public int Order { get; internal set; }

        [JsonProperty("form_order")]
        public int FormOrder { get; internal set; }

        /// <summary>
        /// NOTE: some props can be null, fall back on male, non-shiny (if all shinies are null) values!
        /// </summary>
        [JsonProperty("sprites")]
        public PokemonSprites Sprites { get; internal set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; internal set; }
        [JsonProperty("is_battle_only")]
        public bool IsBattleOnly { get; internal set; }
        [JsonProperty("is_mega")]
        public bool IsMegaEvolution { get; internal set; }

        [JsonProperty("form_name")]
        public string FormName { get; internal set; }

        [JsonProperty("pokemon")]
        public NamedApiResource<Pokemon> Pokemon { get; internal set; }

        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }
    }

    public class PokemonHabitat : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }
    }

    public class PokemonShape : NamedApiObject
    {
        [JsonProperty("awesome_names")]
        public AwesomeName[] AwesomeNames { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species { get; internal set; }
    }

    public class PokemonSpecies : NamedApiObject
    {
        [JsonProperty("order")]
        public int Order { get; internal set; }

        [JsonProperty("gender_rate"), JsonConverter(typeof(PokemonSpeciesGender.GenderConverter))]
        public float? FemaleToMaleRate { get; internal set; }

        [JsonProperty("capture_rate")]
        public float CaptureRate { get; internal set; }

        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; internal set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; internal set; }

        [JsonProperty("hatch_counter")]
        public int HatchCounter { get; internal set; }

        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; internal set; }

        [JsonProperty("forms_switchable")]
        public bool FormsAreSwitchable { get; internal set; }

        [JsonProperty("growth_rate")]
        public NamedApiResource<GrowthRate> GrowthRate { get; internal set; }

        [JsonProperty("pokedex_numbers")]
        public PokemonSpeciesDexEntry[] PokedexNumbers { get; internal set; }

        [JsonProperty("egg_groups")]
        public NamedApiResource<EggGroup>[] EggGroups { get; internal set; }

        [JsonProperty("color")]
        public NamedApiResource<PokemonColor> Colours { get; internal set; }
        [JsonProperty("shape")]
        public NamedApiResource<PokemonShape> Shape { get; internal set; }

        [JsonProperty("evolves_from_species")]
        public NamedApiResource<PokemonSpecies> EvolvesFromSpecies { get; internal set; }

        [JsonProperty("evolution_chain")]
        public ApiResource<EvolutionChain> EvolutionChain { get; internal set; }
        [JsonProperty("habitat")]
        public NamedApiResource<PokemonHabitat> Habitat { get; internal set; }
        [JsonProperty("generation")]
        public NamedApiResource<Generation> Generation { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pal_park_encounters")]
        public PalParkEncounterArea[] PalParkEncounters { get; internal set; }

        [JsonProperty("form_descriptions")]
        public Description[] Descriptions { get; internal set; }

        [JsonProperty("genera")]
        public Genus[] Genera { get; internal set; }

        [JsonProperty("varieties")]
        public PokemonSpeciesVariety[] Varieties { get; internal set; }

        [JsonProperty("flavor_text_entries")]
        public PokemonSpeciesFlavorText[] FlavorTexts { get; internal set; }
    }

    public class PokemonType : NamedApiObject
    {
        [JsonProperty("damage_relations")]
        public TypeRelations DamageRelations { get; internal set; }

        [JsonProperty("game_indices")]
        public GenerationGameIndex[] GameIndices { get; internal set; }

        [JsonProperty("generation")]
        public NamedApiResource<Generation> Generation { get; internal set; }

        [JsonProperty("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pokemon")]
        public TypePokemon[] Pokemon { get; internal set; }

        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }

        public static double CalculateDamageMultiplier(PokemonType attackingType, PokemonType defendingType)
        {
            var ad = attackingType.DamageRelations;

            if (ad.NoDamageTo.Any(t => t.Name == defendingType.Name))
                return 0d;
            if (ad.HalfDamageTo.Any(t => t.Name == defendingType.Name))
                return 0.5d;
            if (ad.DoubleDamageTo.Any(t => t.Name == defendingType.Name))
                return 2.0d;

            return 1d;
        }

        public static double CalculateDamageMultiplier(PokemonType attackingType, PokemonType defendingA, PokemonType defendingB) 
            => CalculateDamageMultiplier(attackingType, defendingA) * CalculateDamageMultiplier(attackingType, defendingB);
    }

    public class Stat : NamedApiObject
    {
        [JsonProperty("game_index")]
        public int GameIndex { get; internal set; }

        [JsonProperty("is_battle_only")]
        public bool IsBattleOnly { get; internal set; }

        [JsonProperty("affecting_moves")]
        public StatAffectSets<Move> AffectingMoves { get; internal set; }
        [JsonProperty("affecting_natures")]
        public StatAffectNature AffectingNatures { get; internal set; }

        [JsonProperty("characteristics")]
        public ApiResource<Characteristic>[] Characteristics { get; internal set; }

        [JsonProperty("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }
}
