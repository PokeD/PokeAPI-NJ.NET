using Newtonsoft.Json;

namespace PokeAPI
{
    public class Item : NamedApiObject
    {
        [JsonProperty("cost")]
        public int Cost { get; internal set; }

        [JsonProperty("fling_power")]
        public int? FlingPower { get; internal set; }

        [JsonProperty("fling_effect")]
        public NamedApiResource<ItemFlingEffect> FlingEffect { get; internal set; }

        [JsonProperty("attributes")]
        public NamedApiResource<ItemAttribute>[] Attributes { get; internal set; }

        [JsonProperty("category")]
        public NamedApiResource<ItemCategory> Category { get; internal set; }

        [JsonProperty("effect_entries")]
        public VerboseEffect[] Effects { get; internal set; }

        [JsonProperty("flavor_text_entries")]
        public VersionGroupFlavorText[] FlavorTexts { get; internal set; }

        [JsonProperty("game_indices")]
        public GenerationGameIndex[] GameIndices { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("held_by_pokemon")]
        public ItemHeldBy[] HeldBy { get; internal set; }

        [JsonProperty("baby_trigger_for")]
        public ApiResource<EvolutionChain> BabyTriggerFor { get; internal set; }

        [JsonProperty("sprites")]
        public ItemSprites Sprites { get; internal set; }

        [JsonProperty("machines")]
        public MachineVersionDetail[] Machines { get; internal set; }
    }

    public class ItemAttribute : NamedApiObject
    {
        [JsonProperty("items")]
        public NamedApiResource<Item>[] Items { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }
    }

    public class ItemCategory : NamedApiObject
    {
        [JsonProperty("items")]
        public NamedApiResource<Item>[] Items { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("pocket")]
        public NamedApiResource<ItemPocket> Pocket { get; internal set; }
    }

    public class ItemFlingEffect : NamedApiObject
    {
        [JsonProperty("effect_entries")]
        public Effect[] Effects { get; internal set; }

        [JsonProperty("items")]
        public NamedApiResource<Item>[] Items { get; internal set; }
    }

    public class ItemPocket : NamedApiObject
    {
        [JsonProperty("categories")]
        public NamedApiResource<ItemCategory>[] Categories { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class ItemHeldBy
    {
        [JsonProperty("pokemon")]
        public NamedApiResource<Pokemon> Pokemon { get; internal set; }

        [JsonProperty("version_details")]
        public VersionDetails[] VersionDetails { get; internal set; }
    }

    public class VersionDetails
    {
        [JsonProperty("rarity")]
        public int Rarity { get; internal set; }

        [JsonProperty("version")]
        public NamedApiResource<GameVersion> Version { get; internal set; }
    }

    public class ItemSprites
    {
        [JsonProperty("default")]
        public string Default { get; internal set; }
    }

    public class MachineVersionDetail
    {
        [JsonProperty("machine")]
        public ApiResource<Machine> Machine { get; internal set; }

        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }
    }
}
