using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Services.ArquivoServices
{
    public interface IArquivoService : IRepository<Arquivos>
    {
    }

    public class ArquivoService(DatabaseContext context) : Repository<Arquivos>(context), IArquivoService
    {
    }
}
