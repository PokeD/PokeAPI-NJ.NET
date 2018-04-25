using System;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace PokeAPI
{
    public interface IResource<T>
    {
        Uri Url { get; }

        Task<T> GetObject();
    }

    public class StructResource<T> : IResource<T>
    {
        /// <summary>
        /// The path to the referenced data.
        /// </summary>
        public string Path { get; internal set; }

        public Uri Url
        {
            get
            {
                if (Path.StartsWith("http"))
                    return new Uri(Path, UriKind.Absolute);

                return new Uri(DataFetcher.SITE_URL + Path, UriKind.Absolute);
            }
        }

        public virtual async Task<T> GetObject() => await DataFetcher.GetJsonOfAny<T>(Url);
    }

    internal class StructResourceFromStringConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => new StructResource<T> { Path = Convert.ToString(reader.Value) };
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }

    public class ApiResource<T> : IResource<T> where T : ApiObject
    {
        /// <summary>
        /// The ID of the referenced resource.
        /// </summary>
        [JsonIgnore]
        public int ID
        {   
            get
            {
                if (_id == null)
                    _id = int.TryParse(Url.Segments.Last().Trim('/'), out var id) ? id : -1;
                return _id.Value;
            }
        }
        private int? _id;

        /// <summary>
        /// The URL of the referenced resource.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; internal set; }

        public virtual async Task<T> GetObject() => await DataFetcher.GetApiObject<T>(Url);
    }

    public class NamedApiResource<T> : ApiResource<T> where T : NamedApiObject
    {
        /// <summary>
        /// The name of the referenced resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }
    }

    internal class ApiResourceFromStringConverter<T> : JsonConverter where T : ApiObject
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => new ApiResource<T> { Url = new Uri(Convert.ToString(reader.Value), UriKind.Absolute) };
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
