using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppNetCore5.Otros;

namespace WebAppNetCore5.Models.PruebaMuchosMuchos
{
    public class RelacionPersona
    {
        //public int PersonaId { get; set; }
        //public Persona Persona { get; set; }

        //public int FamiliarId { get; set; }
        //public Familiar PersonaRelacionada { get; set; }

        //-------------------------------------------------

        public int Id { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int PersonaFamiliarId { get; set; }
        public Persona PersonaFamiliar { get; set; }
        public Parentezco Parentezco { get; set; }
    }
}
