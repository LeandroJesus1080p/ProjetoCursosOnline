using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.PessoaServices;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoa;
        public PessoaController(IPessoaService pessoa)
        {
            _pessoa = pessoa;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var pessoa = await _pessoa.GetAll();

            return Ok(new
            {
                pessoas = pessoa
            });
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post(Pessoa pessoa)
        {
            await _pessoa.Create(pessoa);

            await _pessoa.IncrementarPessoa(pessoa.Id);
            return Ok(new
            {
                pessoas = pessoa
            });
        }

        [HttpPut]
        public async Task<ActionResult<Pessoa>> Put(int id)
        {
            await _pessoa.IncrementarPessoa(id);
            return Ok(new
            {
                alteração = id
            });
        }
    }
}
