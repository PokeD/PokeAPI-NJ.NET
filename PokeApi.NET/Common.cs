using Newtonsoft.Json;

namespace PokeAPI
{
    public enum TimeOfDay
    {
        Day,
        Night
    }

    public struct Description
    {
        /// <summary>
        /// The localized description for an <see cref="ApiResource{T}" /> in a specific langauge.
        /// </summary>
        [JsonProperty("description")]
        public string Text { get; internal set; }

        /// <summary>
        /// The language this description is in.
        /// </summary>
        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
    }

    public struct Effect
    {
        /// <summary>
        /// The localized text for an <see cref="ApiResource{T}" /> in a specific language.
        /// </summary>
        [JsonProperty("effect")]
        public string Text { get; internal set; }

        /// <summary>
        /// The language this effect is in.
        /// </summary>
        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
    }

    public struct Encounter
    {
        /// <summary>
        /// The lowest level the pokémon could be encountered at.
        /// </summary>
        [JsonProperty("min_level")]
        public int MinLevel { get; internal set; }

        /// <summary>
        /// The highest level the pokémon could be encountered at.
        /// </summary>
        [JsonProperty("max_level")]
        public int MaxLevel { get; internal set; }

        /// <summary>
        /// A list os condition values that muse be in effect for this encounter to occur.
        /// </summary>
        [JsonProperty("condition_values")]
        public NamedApiResource<EncounterConditionValue>[] ConditionValues { get; internal set; }

        /// <summary>
        /// The chance, ranging from 0 to 1, that this encounter will occur.
        /// </summary>
        [JsonProperty("chance")]
        public float Chance { get; internal set; }

        /// <summary>
        /// The method by which this encounter happens.
        /// </summary>
        [JsonProperty("method")]
        public NamedApiResource<EncounterMethod> Method { get; internal set; }
    }

    public struct FlavorText
    {
        /// <summary>
        /// The localized name for an <see cref="ApiResource{T}" /> in a specific langauge.
        /// </summary>
        [JsonProperty("flavor_text")]
        public string Text { get; internal set; }

        /// <summary>
        /// The language this flavor text is in.
        /// </summary>
        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
    }

    public struct GenerationGameIndex
    {
        /// <summary>
        /// The internal ID of an <see cref="ApiResource{T}" /> within game data.
        /// </summary>
        [JsonProperty("game_index")]
        public int GameIndex { get; internal set; }

        /// <summary>
        /// The generation relevant to this game index.
        /// </summary>
        [JsonProperty("generation")]
        public NamedApiResource<Generation> Generation { get; internal set; }
    }

    public struct ResourceName
    {
        /// <summary>
        /// The localized name for an <see cref="ApiResource{T}" /> in a specific langauge.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }

        /// <summary>
        /// The color associated with this contest's name
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; internal set; }
    }

    public struct VerboseEffect
    {
        /// <summary>
        /// The localized effect text for an <see cref="ApiResource{T}" /> in a specific language.
        /// </summary>
        [JsonProperty("effect")]
        public string Effect { get; internal set; }

        /// <summary>
        /// The localized effect text in brief.
        /// </summary>
        [JsonProperty("short_effect")]
        public string ShortEffect { get; internal set; }

        /// <summary>
        /// The language this effect is in.
        /// </summary>
        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }
    }

    public struct VersionEncounterDetail
    {
        /// <summary>
        /// the game version this encounter happens in.
        /// </summary>
        [JsonProperty("version")]
        public NamedApiResource<GameVersion> Version { get; internal set; }

        /// <summary>
        /// the total chance, ranging from 0 to 1, of all encounter potential.
        /// </summary>
        [JsonProperty("max_chance")]
        public float MaxChance { get; internal set; }

        /// <summary>
        /// A list of special encounters and their specifics.
        /// </summary>
        [JsonProperty("encounter_details")]
        public Encounter[] EncounterDetails { get; internal set; }
    }

    public struct VersionGameIndex
    {
        /// <summary>
        /// The internal ID of an <see cref="ApiResource{T}" /> within game data.
        /// </summary>
        [JsonProperty("game_index")]
        public int GameIndex { get; internal set; }

        /// <summary>
        /// The version relevant to this game index.
        /// </summary>
        [JsonProperty("version")]
        public NamedApiResource<GameVersion> Version { get; internal set; }
    }

    public struct VersionGroupFlavorText
    {
        /// <summary>
        /// The localized name for an <see cref="ApiResource{T}" /> in a specific language.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; internal set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        [JsonProperty("language")]
        public NamedApiResource<Language> Language { get; internal set; }

        /// <summary>
        /// The version group which uses this flavor text.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }

        [JsonProperty("flavor_text")]
        public string FlavorText { get; internal set; }
    }
}
