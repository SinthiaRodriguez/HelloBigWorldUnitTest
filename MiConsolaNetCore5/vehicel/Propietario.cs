using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrchestrationServices.Api.MisDatos.Service.Internal.VehicleDetails
{
    public class Propietario
    {
        [JsonProperty("tipoDocumento")]
        public string TipoDocumento { get; set; }

        [JsonProperty("noDocumento")]
        public long NoDocumento { get; set; }

        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido1")]
        public string Apellido1 { get; set; }

        [JsonProperty("apellido2")]
        public string Apellido2 { get; set; }

        [JsonProperty("direcciones")]
        public List<string> Direcciones { get; set; }

        [JsonProperty("celular")]
        public long Celular { get; set; }
    }
}
