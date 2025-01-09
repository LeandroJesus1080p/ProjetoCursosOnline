using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Services.UsuarioServices
{
    public interface IUsuarioService : IRepository<Usuario>
    {
    }

    public class UsuarioService(DatabaseContext context) : Repository<Usuario>(context), IUsuarioService
    {
      
        public override async Task<IEnumerable<Usuario>> GetAll()
        {
            return await context.Set<Usuario>().Include("PlanoEstudos").ToListAsync();
        }

        public override async Task<Usuario> GetOne(int id)
        {
            return await context.Set<Usuario>().Include("PlanoEstudos").FirstOrDefaultAsync(p => p.Id == id) 
                ?? throw new Exception("Id não encontrado");
        }
    }
}
