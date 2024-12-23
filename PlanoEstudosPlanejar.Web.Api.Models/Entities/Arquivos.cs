using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Models.Entities
{
    public class Arquivos : Table
    {
        public required string Nome { get; set; }
        public required string Caminho { get; set; }
        public string? Descricao { get; set; }
        public int PlanoEstudoId { get; set; }
        public PlanoEstudo? PlanoEstudo { get; set; }
    }
}
