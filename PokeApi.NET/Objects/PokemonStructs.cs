using System;

using Newtonsoft.Json;

namespace PokeAPI
{
    public struct AbilityEffectChange
    {
        [JsonProperty("effect_entries")]
        public VerboseEffect[] Effects { get; internal set; }

        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }
    }

    public struct AbilityPokemon
    {
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; internal set; }
        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("pokemon")]
        public NamedApiResource<Pokemon> Pokemon { get; internal set; }
    }

    public struct MoveVersionGroupDetails
    {
        [JsonProperty("level_learned_at")]
        public int LearnedAt { get; internal set; }

        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }

        [JsonProperty("move_learn_method")]
        public NamedApiResource<MoveLearnMethod> LearnMethod { get; internal set; }
    }

    public struct PokemonMove
    {
        [JsonProperty("move")]
        public NamedApiResource<Move> Move { get; internal set; }

        [JsonProperty("version_group_details")]
        public MoveVersionGroupDetails[] VersionGroupDetails { get; internal set; }
    }

    public struct PokemonStats
    {
        [JsonProperty("base_stat")]
        public int BaseValue { get; internal set; }
        [JsonProperty("effort")]
        public int Effort { get; internal set; }

        [JsonProperty("stat")]
        public NamedApiResource<Stat> Stat { get; internal set; }
    }

    /// <summary>
    /// NOTE: some props can be null, fall back on male, non-shiny (if all shinies are null) values!
    /// </summary>
    public struct PokemonSprites
    {
        //! NOTE: some props can be null, fall back on male, non-shiny (if all shinies are null) values!

        [JsonProperty("back_female")]
        public string BackFemale { get; internal set; }
        [JsonProperty("back_shiny_female")]
        public string BackShinyFemale { get; internal set; }
        [JsonProperty("back_default")]
        public string BackMale { get; internal set; }
        [JsonProperty("front_female")]
        public string FrontFemale { get; internal set; }
        [JsonProperty("front_shiny_female")]
        public string FrontShinyFemale { get; internal set; }
        [JsonProperty("back_shiny")]
        public string BackShinyMale { get; internal set; }
        [JsonProperty("front_default")]
        public string FrontMale { get; internal set; }
        [JsonProperty("front_shiny")]
        public string FrontShinyMale { get; internal set; }
    }

    public struct PokemonHeldItem
    {
        [JsonProperty("item")]
        public NamedApiResource<Item> Item { get; internal set; }
        [JsonProperty("version_details")]
        public VersionDetails[] VersionDetails { get; internal set; }
    }

    public struct PokemonSpeciesVariety
    {
        [JsonProperty("is_default")]
        public bool IsDefault { get; internal set; }

        [JsonProperty("pokemon")]
        public NamedApiResource<Pokemon> Pokemon { get; internal set; }
    }

    public struct PokemonSpeciesGender
    {
        internal class GenderConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => objectType == typeof(int);

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var val = Convert.ToInt32(reader.Value);
                return  val == -1 ? null : (float?) (val * 0.128f);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                => throw new NotImplementedException();
        }

        /// <summary>
        /// The chance of this <see cref="Pokemon" /> being female; or null for genderless.
        /// </summary>
        [JsonProperty("rate"), JsonConverter(typeof(GenderConverter))]
        public float? FemaleToMaleRate { get; internal set; }

        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> Species { get; internal set; }
    }

    public struct PokemonSpeciesFlavorText
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; internal set; }

        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
        [JsonProperty("version")]
        public NamedApiResource<GameVersion> Version { get; internal set; }
    }

    public struct GrowthRateExperienceLevel
    {
        [JsonProperty("level")]
        public int Level { get; internal set; }
        [JsonProperty("experience")]
        public int Experience { get; internal set; }
    }

    public struct NatureStatChange
    {
        [JsonProperty("max_change")]
        public int Change { get; internal set; }

        [JsonProperty("pokeathlon_stat")]
        public NamedApiResource<PokeathlonStat> Stat { get; internal set; }
    }

    public struct MoveBattleStylePreference
    {
        [JsonProperty("low_hp_preference")]
        public float LowHPPreference { get; internal set; }
        [JsonProperty("high_hp_preference")]
        public float HighHPPrefernece { get; internal set; }

        [JsonProperty("move_battle_style")]
        public NamedApiResource<MoveBattleStyle> BattleStyle { get; internal set; }
    }

    public struct NaturePokeathlonStatAffect
    {
        [JsonProperty("max_change")]
        public int MaxChange { get; internal set; }

        [JsonProperty("nature")]
        public NamedApiResource<Nature> Nature { get; internal set; }
    }

    public struct NaturePokeathlonStatAffectSets
    {
        [JsonProperty("increase")]
        public NaturePokeathlonStatAffect[] Increase { get; internal set; }
        [JsonProperty("decrease")]
        public NaturePokeathlonStatAffect[] Decrease { get; internal set; }
    }

    public struct PokemonAbility
    {
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; internal set; }
        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("ability")]
        public NamedApiResource<Ability> Ability { get; internal set; }
    }

    public struct PokemonTypeMap
    {
        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("type")]
        public NamedApiResource<PokemonType> Type { get; internal set; }
    }

    public struct LocationAreaEncounter
    {
        [JsonProperty("location_area")]
        public NamedApiResource<LocationArea> LocationArea { get; internal set; }

        [JsonProperty("version_details")]
        public VersionEncounterDetail[] VersionDetails { get; internal set; }
    }

    public struct AwesomeName
    {
        [JsonProperty("awesome_name")]
        public string Name { get; internal set; }

        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
    }

    public struct Genus
    {
        [JsonProperty("genus")]
        public string Name { get; internal set; }

        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
    }

    public struct PokemonSpeciesDexEntry
    {
        [JsonProperty("entry_number")]
        public int EntryNumber { get; internal set; }

        [JsonProperty("pokedex")]
        public NamedApiResource<Pokedex> Pokedex { get; internal set; }
    }

    public class PalParkEncounterArea
    {
        [JsonProperty("base_score")]
        public int BaseScore { get; internal set; }
        [JsonProperty("rate")]
        public int Rate { get; internal set; }

        [JsonProperty("area")]
        public NamedApiResource<PalParkArea> Area { get; internal set; }
    }

    public struct StatAffect<T> where T : NamedApiObject
    {
        [JsonProperty("change")]
        public int Change { get; internal set; }

        [JsonProperty("move")]
        public NamedApiResource<T> Resource { get; internal set; }
    }

    public struct StatAffectSets<T> where T : NamedApiObject
    {
        [JsonProperty("increase")]
        public StatAffect<T>[] Increase { get; internal set; }
        [JsonProperty("decrease")]
        public StatAffect<T>[] Decrease { get; internal set; }
    }

    public struct StatAffectNature
    {
        [JsonProperty("increase")]
        public NamedApiResource<Nature>[] Increase { get; internal set; }
        [JsonProperty("decrease")]
        public NamedApiResource<Nature>[] Decrease { get; internal set; }
    }

    public struct TypePokemon
    {
        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("pokemon")]
        public NamedApiResource<Pokemon> Pokemon { get; internal set; }
    }

    public struct TypeRelations
    {
        [JsonProperty("no_damage_to")]
        public NamedApiResource<PokemonType>[] NoDamageTo { get; internal set; }
        [JsonProperty("half_damage_to")]
        public NamedApiResource<PokemonType>[] HalfDamageTo { get; internal set; }
        [JsonProperty("double_damage_to")]
        public NamedApiResource<PokemonType>[] DoubleDamageTo { get; internal set; }

        [JsonProperty("no_damage_from")]
        public NamedApiResource<PokemonType>[] NoDamageFrom { get; internal set; }
        [JsonProperty("half_damage_from")]
        public NamedApiResource<PokemonType>[] HalfDamageFrom { get; internal set; }

        [JsonProperty("double_damage_from")]
        public NamedApiResource<PokemonType>[] DoubleDamageFrom { get; internal set; }
    }
}
