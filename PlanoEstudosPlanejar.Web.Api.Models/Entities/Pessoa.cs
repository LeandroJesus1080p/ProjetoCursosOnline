using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Models.Entities
{
    public class Pessoa : Table
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public int Idade { get; set; }
    }
}
