using Newtonsoft.Json;

namespace PokeAPI
{
    public abstract class ApiObject
    {
        /// <summary>
        /// The identifier for this <see cref="ApiObject" />.
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; internal set; }
    }

    public abstract class NamedApiObject : ApiObject
    {
        /// <summary>
        /// The name for this <see cref="NamedApiObject" />.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}
