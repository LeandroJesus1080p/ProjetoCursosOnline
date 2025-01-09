using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Services.PessoaServices
{
    public interface IPessoaService : IRepository<Pessoa>
    {
        Task IncrementarPessoa(int id);
    }

    public class PessoaService(DatabaseContext context) : Repository<Pessoa>(context), IPessoaService
    {

        public async Task IncrementarPessoa(int id)
        {
            var pessoaId = await GetOne(id);
            var pessoa = await GetAll();

            pessoaId.Idade = pessoa.Count();
            await SaveAsync();
        }
    }
}
