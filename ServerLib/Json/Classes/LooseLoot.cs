﻿using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class LooseLoot
    {
        public class Base
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public SpawnpointCount spawnpointCount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<SpawnpointsForced> spawnpointsForced { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Spawnpoint> spawnpoints { get; set; }

        }
        public class SpawnpointCount
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int mean { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int std { get; set; }

        }
        public class SpawnpointsForced
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string locationId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int probability { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public SpawnpointTemplate template { get; set; }

        }
        public class SpawnpointTemplate
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool IsStatic { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool useGravity { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool randomRotation { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Xyz Position { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Xyz Rotation { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool IsGroupPosition { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<object> GroupPositions { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object Root { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Item.Base> Items { get; set; }

        }
        public class Spawnpoint
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string locationId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int probability { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public SpawnpointTemplate template { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<ItemDistribution> itemDistribution { get; set; }

        }
        public class Xyz
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int x { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int y { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int z { get; set; }

        }
        public class ItemDistribution
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ComposedKey composedKey { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int relativeProbability { get; set; }

        }
        public class ComposedKey

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string key { get; set; }

        }
    }
}
