﻿using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class HideoutSettings
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int generatorSpeedWithoutFuel { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int generatorFuelFlowRate { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int airFilterUnitFlowRate { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int gpuBoostRate { get; set; }
    }
}
