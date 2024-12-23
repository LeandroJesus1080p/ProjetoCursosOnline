using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.MateriaServices
{
    public interface IMateriaService : IRepository<Materias>
    {
    }

    public class MateriaService : Repository<Materias>, IMateriaService
    {
        public MateriaService(DatabaseContext context) : base(context)
        {   
        }
    }

}
