using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppNetCore5.Otros;

namespace WebAppNetCore5.Models.PruebaMuchosMuchos
{
    public class Familiar
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public Parentezco Parentezco { get; set; }
        //public int PersonaId { get; set; }
    }
}
