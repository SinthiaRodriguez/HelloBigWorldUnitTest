using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrchestrationServices.Api.MisDatos.Service.Internal.VehicleDetails
{
    public class Homologacione
    {
        [JsonProperty("clase")]
        public Clase Clase { get; set; }

        [JsonProperty("codMarcaSise")]
        public string CodMarcaSise { get; set; }

        [JsonProperty("codLineaSise")]
        public long CodLineaSise { get; set; }

        [JsonProperty("codDestinoSise")]
        public long CodDestinoSise { get; set; }
    }
}
