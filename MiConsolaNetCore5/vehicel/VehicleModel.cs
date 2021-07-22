using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrchestrationServices.Api.MisDatos.Service.Internal.VehicleDetails
{
    public class VehicleModel
    {
        [JsonProperty("plate")]
        public string Plate { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}
