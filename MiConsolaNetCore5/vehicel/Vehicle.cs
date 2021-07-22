using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrchestrationServices.Api.MisDatos.Service.Internal.VehicleDetails
{
    public class Vehicle
    {
        [JsonProperty("idTipoServicio")]
        public long IdTipoServicio { get; set; }

        [JsonProperty("tipoServicio")]
        public string TipoServicio { get; set; }

        [JsonProperty("idClaseVehiculo")]
        public long IdClaseVehiculo { get; set; }

        [JsonProperty("codClaseSise")]
        public long CodClaseSise { get; set; }

        [JsonProperty("claseVehiculo")]
        public string ClaseVehiculo { get; set; }

        [JsonProperty("idMarca")]
        public long IdMarca { get; set; }

        [JsonProperty("codMarcaSise")]
        public string CodMarcaSise { get; set; }

        [JsonProperty("marca")]
        public string Marca { get; set; }

        [JsonProperty("idLinea")]
        public long IdLinea { get; set; }

        [JsonProperty("codLineaSise")]
        public long CodLineaSise { get; set; }

        [JsonProperty("linea")]
        public string Linea { get; set; }

        [JsonProperty("modelo")]
        public long Modelo { get; set; }

        [JsonProperty("idColor")]
        public long IdColor { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("noSerie")]
        public object NoSerie { get; set; }

        [JsonProperty("noMotor")]
        public string NoMotor { get; set; }

        [JsonProperty("noChasis")]
        public string NoChasis { get; set; }

        [JsonProperty("noVin")]
        public string NoVin { get; set; }

        [JsonProperty("cilindraje")]
        public long Cilindraje { get; set; }

        [JsonProperty("toneladas")]
        public string Toneladas { get; set; }

        [JsonProperty("divipola")]
        public long Divipola { get; set; }

        [JsonProperty("pesoBrutoVehicular")]
        public object PesoBrutoVehicular { get; set; }

        [JsonProperty("ocupantes")]
        public long Ocupantes { get; set; }

        [JsonProperty("idTipoCarroceria")]
        public long IdTipoCarroceria { get; set; }

        [JsonProperty("tipoCarroceria")]
        public string TipoCarroceria { get; set; }

        [JsonProperty("idTipoCombustible")]
        public long IdTipoCombustible { get; set; }

        [JsonProperty("tipoCombustible")]
        public string TipoCombustible { get; set; }

        [JsonProperty("estadoDelVehiculo")]
        public string EstadoDelVehiculo { get; set; }

        [JsonProperty("organismoTransito")]
        public string OrganismoTransito { get; set; }

        [JsonProperty("homologaciones")]
        public List<Homologacione> Homologaciones { get; set; }

        [JsonProperty("propietarios")]
        public List<Propietario> Propietarios { get; set; }
    }
}
