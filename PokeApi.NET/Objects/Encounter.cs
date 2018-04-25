using Newtonsoft.Json;

namespace PokeAPI
{
    public class EncounterMethod : NamedApiObject
    {
        [JsonProperty("order")]
        public int Order { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class EncounterCondition : NamedApiObject
    {
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }

        [JsonProperty("values")]
        public NamedApiResource<EncounterConditionValue>[] Values { get; internal set; }
    }

    public class EncounterConditionValue : NamedApiObject
    {
        [JsonProperty("condition")]
        public NamedApiResource<EncounterCondition> Condition { get; internal set; }

        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }
}
