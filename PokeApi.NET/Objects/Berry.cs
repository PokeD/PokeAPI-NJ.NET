﻿using System;

using Newtonsoft.Json;

namespace PokeAPI
{
    public struct BerryFlavorMap
    {
        /// <summary>
        /// The power of the referenced flavor for this berry.
        /// </summary>
        [JsonProperty("potency")]
        public int Potency { get; internal set; }

        /// <summary>
        /// The referenced berry flavor.
        /// </summary>
        [JsonProperty("flavor")]
        public NamedApiResource<BerryFlavor> Flavor { get; internal set; }
    }

    public struct FlavorBerryMap
    {
        /// <summary>
        /// The power of the flavor for the referenced flavor.
        /// </summary>
        [JsonProperty("potency")]
        public int Potency { get; internal set; }

        /// <summary>
        /// The referenced berry.
        /// </summary>
        [JsonProperty("berry")]
        public NamedApiResource<Berry> Berry { get; internal set; }
    }

    public class Berry : NamedApiObject
    {
        private class BerryGrowthTimeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => objectType == typeof(int);
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                => new TimeSpan(Convert.ToInt32(reader.Value), 0, 0);
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
                => throw new NotImplementedException();
        }

        /// <summary>
        /// Time it takes the tree to grow one stage. Berry trees go through four of these growth stages before they can be picked.
        /// </summary>
        [JsonProperty("growth_time"), JsonConverter(typeof(BerryGrowthTimeConverter))]
        public TimeSpan GrowthTime { get; internal set; }

        /// <summary>
        /// The maximum number of these berries that can grow on one tree in Generation IV.
        /// </summary>
        [JsonProperty("max_harvest")]
        public int MaxHarvest { get; internal set; }

        /// <summary>
        /// The power of the move "Natural Gift" when used with this Berry.
        /// </summary>
        [JsonProperty("natural_gift_power")]
        public int NaturalGiftPower { get; internal set; }

        /// <summary>
        /// The size of this Berry, in millimeters.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; internal set; }

        /// <summary>
        /// The smoothness of this Berry, used in making Pokéblocks or Poffins.
        /// </summary>
        [JsonProperty("smoothness")]
        public int Smoothness { get; internal set; }

        /// <summary>
        /// The speed at which this Berry dries out the soil as it grows. A higher rate means the soil dries more quickly.
        /// </summary>
        [JsonProperty("soil_dryness")]
        public int SoilDryness { get; internal set; }

        /// <summary>
        /// The firmness of this berry, used in making Pokéblocks or Poffins.
        /// </summary>
        [JsonProperty("firmness")]
        public NamedApiResource<BerryFirmness> Firmness { get; internal set; }

        /// <summary>
        /// A list of references to each flavor a berry can have and the potency of each of those flavors in regard to this berry.
        /// </summary>
        [JsonProperty("flavors")]
        public BerryFlavorMap[] Flavors { get; internal set; }

        /// <summary>
        ///  	Berries are actually items. This is a reference to the item specific data for this berry.
        /// </summary>
        [JsonProperty("item")]
        public NamedApiResource<Item> Item { get; internal set; }

        /// <summary>
        /// The Type the move "Natural Gift" has when used with this Berry.
        /// </summary>
        [JsonProperty("natural_gift_type")]
        public NamedApiResource<PokemonType> NaturalGiftType { get; internal set; }
    }

    public class BerryFirmness : NamedApiObject
    {
        /// <summary>
        /// A list of the berries with this firmness.
        /// </summary>
        [JsonProperty("berries")]
        public NamedApiResource<Berry>[] Berries { get; internal set; }

        /// <summary>
        /// The name of this berry firmness listed in different languages.
        /// </summary>
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }

    public class BerryFlavor : NamedApiObject
    {
        /// <summary>
        /// A list of the berries with this flavor.
        /// </summary>
        [JsonProperty("berries")]
        public FlavorBerryMap[] Berries { get; internal set; }

        /// <summary>
        /// The contest type that correlates with this berry flavor.
        /// </summary>
        [JsonProperty("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; internal set; }

        /// <summary>
        /// The name of this berry flavor listed in different languages.
        /// </summary>
        [JsonProperty("names")]
        public ResourceName[] Names { get; internal set; }
    }
}
