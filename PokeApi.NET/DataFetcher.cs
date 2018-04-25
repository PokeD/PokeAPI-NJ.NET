using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PokeAPI
{
    /*
    public interface IDataFetcher
    {
        void SetHttpClient(IHttpClientAdapter client);

        CacheGetter<int, ApiObject> ChacheOf<T>() where T : ApiObject;
        CacheGetter<string, ApiObject> CacheOfByName<T>() where T : NamedApiObject;
        CacheGetter<Uri, ApiObject> CacheOfByUrl<T>() where T : ApiObject;
        CacheGetter<ValueTuple<int, int>, ApiObject> ListCacheOf<T>() where T : ApiObject;

        Task<T> GetJsonOf<T>(int id) where T : ApiObject;
        Task<T> GetJsonOf<T>(string name) where T : NamedApiObject;
        Task<T> GetJsonOf<T>(Uri url) where T : ApiObject;
        Task<T> GetJsonOfAny<T>(Uri url);
        Task<T> GetListJsonOf<T>(int offset, int limit) where T : ApiObject;
        bool ShouldCacheData { get; set; }
        void ClearAll();

        Task<T> GetApiObject<T>(int id) where T : ApiObject;
        Task<T> GetApiObject<T>(Uri url) where T : ApiObject;
        Task<T> GetNamedApiObject<T>(string name) where T : NamedApiObject;
        Task<T> GetNamedApiObject<T>(Uri url) where T : NamedApiObject;
        Task<T> GetAny<T>(Uri url);
        //Task<ResourceList<T, TInner>> GetResourceList<T, TInner>(int limit = 20) where TInner : ApiObject where T : ApiResource<TInner>;
    }
    */

    // TODO:
    //   * docs
    //   * utility stuff from v1?

    /// <summary>
    /// Retrieves JSON data from the http://pokeapi.co/ site.
    /// </summary>
    public static class DataFetcher
    {
        internal static readonly string
            SITE_URL = "https://pokeapi.co",
            BASE_URL = SITE_URL + "/api/v2/",
            SLASH = "/";

        internal static IHttpClientAdapter Client = new HttpClientDefaultAdapter();

        /// <summary>
        /// Sets the <see cref="IHttpClientAdapter" /> the data fetcher uses.
        /// </summary>
        /// <param name="client">The <see cref="IHttpClientAdapter" /> to use.</param>
        public static void SetHttpClient(IHttpClientAdapter client) => Client = client ?? throw new ArgumentNullException(nameof(client));

        #region static Dictionary<Type, string> UrlOfType = new Dictionary<Type, string> { [...] };
        private static readonly Dictionary<Type, string> UrlOfType = new Dictionary<Type, string>
        {
            { typeof(ContestEffect     ), "contest-effect"       },
            { typeof(SuperContestEffect), "super-contest-effect" },
            { typeof(Characteristic    ), "characteristic"       },

            { typeof(Berry        ), "berry"          },
            { typeof(BerryFirmness), "berry-firmness" },
            { typeof(BerryFlavor  ), "berry-flavor"   },

            { typeof(ContestType), "contest-type" },

            { typeof(EncounterMethod        ), "encounter-method"          },
            { typeof(EncounterCondition     ), "encounter-condition"       },
            { typeof(EncounterConditionValue), "encounter-condition-value" },

            { typeof(EvolutionChain  ), "evolution-chain"   },
            { typeof(EvolutionTrigger), "evolution-trigger" },

            { typeof(Generation  ), "generation"    },
            { typeof(Pokedex     ), "pokedex"       },
            { typeof(GameVersion ), "version"       },
            { typeof(VersionGroup), "version-group" },

            { typeof(Item           ), "item"              },
            { typeof(ItemAttribute  ), "item-attribute"    },
            { typeof(ItemCategory   ), "item-category"     },
            { typeof(ItemFlingEffect), "item-fling-effect" },
            { typeof(ItemPocket     ), "item-pocket"       },

            { typeof(Move           ), "move"              },
            { typeof(MoveAilment    ), "move-ailment"      },
            { typeof(MoveBattleStyle), "move-battle-style" },
            { typeof(MoveCategory   ), "move-category"     },
            { typeof(MoveDamageClass), "move-damage-class" },
            { typeof(MoveLearnMethod), "move-learn-method" },
            { typeof(MoveTarget     ), "move-target"       },

            { typeof(Location    ), "location"      },
            { typeof(LocationArea), "location-area" },
            { typeof(PalParkArea ), "pal-park-area" },
            { typeof(Region      ), "region"        },

            { typeof(Ability       ), "ability"         },
            { typeof(EggGroup      ), "egg-group"       },
            { typeof(Gender        ), "gender"          },
            { typeof(GrowthRate    ), "growth-rate"     },
            { typeof(Nature        ), "nature"          },
            { typeof(PokeathlonStat), "pokeathlon-stat" },
            { typeof(Pokemon       ), "pokemon"         },
            { typeof(PokemonColor ), "pokemon-color"   },
            { typeof(PokemonForm   ), "pokemon-form"    },
            { typeof(PokemonHabitat), "pokemon-habitat" },
            { typeof(PokemonShape  ), "pokemon-shape"   },
            { typeof(PokemonSpecies), "pokemon-species" },
            { typeof(Stat          ), "stat"            },
            { typeof(PokemonType   ), "type"            },

            { typeof(Language), "language" },
            { typeof(Machine ), "machine"  }
        };
        #endregion

        private static Dictionary<Type, Dictionary<int, ApiObject>> Cache { get; } = new Dictionary<Type, Dictionary<int, ApiObject>>();
        private static Dictionary<Type, Dictionary<string, NamedApiObject>> CacheString { get; } = new Dictionary<Type, Dictionary<string, NamedApiObject>>();
        private static Dictionary<Type, Dictionary<Uri, ApiObject>> CacheUrl { get; } = new Dictionary<Type, Dictionary<Uri, ApiObject>>();
        private static Dictionary<Type, Dictionary<Uri, object>> CacheMisc { get; } = new Dictionary<Type, Dictionary<Uri, object>>();

        public static bool ShouldCacheData { get; set; }

        public static async Task<T> CacheOf<T>(int id) where T : ApiObject
        {
            var type = typeof(T);

            if(!ShouldCacheData)
                return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(BASE_URL + UrlOfType[type] + SLASH + id));

            if (!Cache.ContainsKey(type))
                Cache.Add(type, new Dictionary<int, ApiObject>());

            var dictionary = Cache[type];
            if (!dictionary.TryGetValue(id, out var apiObject))
            {
                apiObject = JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(BASE_URL + UrlOfType[type] + SLASH + id));
                dictionary.Add(id, apiObject);
            }

            return (T) apiObject;
        }
        public static async Task<T> CacheOfByName<T>(string name) where T : NamedApiObject
        {
            var type = typeof(T);

            if (!ShouldCacheData)
                return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(BASE_URL + UrlOfType[type] + SLASH + name));

            if (!CacheString.ContainsKey(type))
                CacheString.Add(type, new Dictionary<string, NamedApiObject>());

            var dictionary = CacheString[type];
            if (!dictionary.TryGetValue(name, out var apiObject))
            {
                apiObject = JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(BASE_URL + UrlOfType[type] + SLASH + name));
                dictionary.Add(name, apiObject);
            }

            return (T) apiObject;
        }
        public static async Task<T> CacheOfByUrl<T>(Uri url) where T : ApiObject
        {
            if (!ShouldCacheData)
                return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url.AbsoluteUri));

            var type = typeof(T);

            if (!CacheUrl.ContainsKey(type))
                CacheUrl.Add(type, new Dictionary<Uri, ApiObject>());

            var dictionary = CacheUrl[type];
            if (!dictionary.TryGetValue(url, out var apiObject))
            {
                apiObject = JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url.AbsoluteUri));
                dictionary.Add(url, apiObject);
            }

            return (T) apiObject;
        }
        public static async Task<T> CacheOfObject<T>(Uri url)
        {
            if (!ShouldCacheData)
                return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url.AbsoluteUri));

            var type = typeof(T);

            if (!CacheMisc.ContainsKey(type))
                CacheMisc.Add(type, new Dictionary<Uri, object>());

            var dictionary = CacheMisc[type];
            if (!dictionary.TryGetValue(url, out var apiObject))
            {
                apiObject = JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url.AbsoluteUri));
                dictionary.Add(url, apiObject);
            }

            return (T) apiObject;
        }

        public static void ClearAll()
        {
            Cache.Clear();
            CacheString.Clear();
            CacheUrl.Clear();
        }


        public static Task<T> GetJsonOf<T>(int id) where T : ApiObject => CacheOf<T>(id);
        public static Task<T> GetJsonOf<T>(string name) where T : NamedApiObject => CacheOfByName<T>(name);
        public static Task<T> GetJsonOf<T>(Uri url) where T : ApiObject => CacheOfByUrl<T>(url);
        public static Task<T> GetJsonOfAny<T>(Uri url) => CacheOfObject<T>(url);
        public static Task<T> GetJsonOfAny<T>(string obj) => GetJsonOfAny<T>(new Uri(BASE_URL + obj));

        public static Task<T> GetApiObject<T>(int id) where T : ApiObject => GetJsonOf<T>(id);
        public static Task<T> GetApiObject<T>(Uri url) where T : ApiObject => GetJsonOf<T>(url);
        public static Task<T> GetNamedApiObject<T>(string name) where T : NamedApiObject => GetJsonOf<T>(name);
        public static Task<T> GetNamedApiObject<T>(Uri url) where T : NamedApiObject => GetJsonOf<T>(url);
        public static Task<T> GetAny<T>(Uri url) => GetJsonOfAny<T>(url);
    }
}
