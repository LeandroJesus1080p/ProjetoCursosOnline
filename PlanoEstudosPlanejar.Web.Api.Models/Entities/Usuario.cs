using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Models.Entities
{
    public class Usuario : Table
    {
        public required string Nome { get; set; }
        public required string SobreNome { get; set; }
        public int Idade { get; set; }
        public required string Eamil { get; set; }
        public required string Senha { get; set; }

        public ICollection<PlanoEstudo>? PlanoEstudo { get; set; }
    }
}
