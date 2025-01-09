using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Services.MateriaServices
{
    public interface IMateriaService : IRepository<Materias>
    {
    }

    public class MateriaService(DatabaseContext context) : Repository<Materias>(context), IMateriaService
    {
    }

}
