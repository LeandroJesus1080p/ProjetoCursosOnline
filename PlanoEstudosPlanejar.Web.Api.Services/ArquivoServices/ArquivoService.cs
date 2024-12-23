using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.ArquivoServices
{
    public interface IArquivoService : IRepository<Arquivos>
    {
    }

    public class ArquivoService : Repository<Arquivos>, IArquivoService
    {
        public ArquivoService(DatabaseContext context) : base(context)
        {            
        }
    }
}
