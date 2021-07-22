using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrchestrationServices.Api.MisDatos.Service.Internal.VehicleDetails
{
    public class Clase
    {
        [JsonProperty("codClase")]
        public long CodClase { get; set; }

        [JsonProperty("txtDesc")]
        public string TxtDesc { get; set; }

        [JsonProperty("codTipoVehMinTrans")]
        public long CodTipoVehMinTrans { get; set; }
    }
}
