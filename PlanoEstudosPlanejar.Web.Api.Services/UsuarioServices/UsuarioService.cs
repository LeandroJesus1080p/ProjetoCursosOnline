using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.UsuarioServices
{
    public interface IUsuarioService : IRepository<Usuario>
    {
    }

    public class UsuarioService : Repository<Usuario>, IUsuarioService
    {
        public UsuarioService(DatabaseContext context) : base(context)
        {    
        }
    }
}
