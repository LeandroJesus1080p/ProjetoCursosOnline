using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.PlanoEstudoServices
{
    public interface IPlanoEstudoService : IRepository<PlanoEstudo>
    {
       
    }

    public class PlanoEstudoService : Repository<PlanoEstudo>, IPlanoEstudoService
    {
        public PlanoEstudoService(DatabaseContext context) : base(context)
        {
        }
    }
}
