using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Models.Entities
{
    public class PlanoEstudo : Table
    {
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public DateTime HorasPorDia { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Materias>? Materias { get; set; }
        public ICollection<Arquivos>? Arquivos { get; set; }
    }
}
