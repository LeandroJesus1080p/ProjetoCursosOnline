using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Services.PlanoEstudoServices
{
    public interface IPlanoEstudoService : IRepository<PlanoEstudo>
    {
    }

    public class PlanoEstudoService(DatabaseContext context) : Repository<PlanoEstudo>(context), IPlanoEstudoService
    {
        public override async Task<IEnumerable<PlanoEstudo>> GetAll()
        {
            return await context.Set<PlanoEstudo>().Include("Materias").Include("Arquivos").ToListAsync();
        }

        public override async Task<PlanoEstudo> GetOne(int id)
        {
            return await context.Set<PlanoEstudo>().Include("Materias").Include("Arquivos").FirstOrDefaultAsync(p => p.Id == id) 
                ?? throw new Exception("Id não encontrado");
        }
            
    }
}
