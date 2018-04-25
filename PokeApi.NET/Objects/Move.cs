using Newtonsoft.Json;

namespace PokeAPI
{
    public struct ContestComboDetail
    {
        [JsonProperty("use_before")]
        public NamedApiResource<Move>[] UseBefore { get; internal set; }
        [JsonProperty("use_after")]
        public NamedApiResource<Move>[] UseAfter { get; internal set; }
    }

    public struct ContestComboSet
    {
        [JsonProperty("normal")]
        public ContestComboDetail Normal { get; internal set; }
        [JsonProperty("super")]
        public ContestComboDetail Super { get; internal set; }
    }

    public struct MoveMetadata
    {
        [JsonProperty("ailment")]
        public NamedApiResource<MoveAilment> Ailment { get; internal set; }
        [JsonProperty("category")]
        public NamedApiResource<MoveCategory> Category { get; internal set; }

        [JsonProperty("min_hits")]
        public int? MinHits { get; internal set; }
        [JsonProperty("max_hits")]
        public int? MaxHits { get; internal set; }
        [JsonProperty("min_turns")]
        public int? MinTurns { get; internal set; }
        [JsonProperty("max_turns")]
        public int? MaxTurns { get; internal set; }

        [JsonProperty("drain")]
        public int DrainRecoil { get; internal set; }
        [JsonProperty("healing")]
        public int Healing { get; internal set; }

        [JsonProperty("crit_rate")]
        public int CritRate { get; internal set; }
        [JsonProperty("ailment_chance")]
        public float AilmentChance { get; internal set; }
        [JsonProperty("flinch_chance")]
        public float FlinchChance { get; internal set; }
        [JsonProperty("stat_chance")]
        public int StatChance { get; internal set; }
    }

    public struct MoveStatChange
    {
        [JsonProperty("change")]
        public int Change { get; internal set; }

        [JsonProperty("stat")]
        public NamedApiResource<Stat> Stat { get; internal set; }
    }

    public struct PastMoveStatValue
    {
        [JsonProperty("accuracy")]
        public float? Accuracy { get; internal set; }
        [JsonProperty("effect_chance")]
        public float? EffectChance { get; internal set; }

        [JsonProperty("power")]
        public int? Power { get; internal set; }
        [JsonProperty("pp")]
        public int? PP { get; internal set; }

        [JsonProperty("effect_entries")]
        public VerboseEffect[] Effects { get; internal set; }

        [JsonProperty("type")]
        public NamedApiResource<PokemonType> Type { get; internal set; }

        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; internal set; }
    }

    public class Move : NamedApiObject
    {
        [JsonProperty("accuracy")]
        public float? Accuracy { get; internal set; }
        [JsonProperty("effect_chance")]
        public float? EffectChance { get; internal set; }

        [JsonProperty("pp")]
        public int? PP { get; internal set; }
        [JsonProperty("priority")]
        public int Priority { get; internal set; }
        [JsonProperty("power")]
        public int? Power { get; internal set; }

        [JsonProperty("contest_combos")]
        public ContestComboSet? ComboSets { get; internal set; }

        [JsonProperty("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; internal set; }

        [JsonProperty("contest_effect")]
        public ApiResource<ContestEffect> ContestEffect { get; internal set; }

        [JsonProperty("damage_class")]
        public NamedApiResource<MoveDamageClass> DamageClass { get; internal set; }

        [JsonProperty("effect_entries")]
        public VerboseEffect[] Effects { get; internal set; }

        [JsonProperty("effect_changes")]
        public AbilityEffectChange[] EffectChanges { get; internal set; }

        [JsonProperty("generation")]
        public NamedApiResource<Generation> Generation { get; internal set; }

        [JsonProperty("meta")]
        public MoveMetadata? Meta { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("past_values")]
        public PastMoveStatValue[] PastValues { get; internal set; }

        [JsonProperty("stat_changes")]
        public MoveStatChange[] StatChanges { get; internal set; }

        [JsonProperty("target")]
        public NamedApiResource<MoveTarget> Target { get; internal set; }

        [JsonProperty("type")]
        public NamedApiResource<PokemonType> Type { get; internal set; }

        [JsonProperty("super_contest_effect")]
        public ApiResource<SuperContestEffect> SuperContestEffect { get; internal set; }

        [JsonProperty("machines")]
        public MachineVersionDetail[] Machines { get; internal set; }

        [JsonProperty("flavor_text_entries")]
        public VersionGroupFlavorText[] FlavorTextEntries { get; internal set; }
    }

    public class MoveAilment : NamedApiObject
    {
        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class MoveBattleStyle : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class MoveCategory : NamedApiObject
    {
        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }

        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }
    }

    public class MoveDamageClass : NamedApiObject
    {
        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }

        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class MoveLearnMethod : NamedApiObject
    {
        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("version_groups")]
        public NamedApiResource<VersionGroup>[] VersionGroups { get; internal set; }
    }

    public class MoveTarget : NamedApiObject
    {
        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; internal set; }

        [JsonProperty("moves")]
        public NamedApiResource<Move>[] Moves { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }
}
