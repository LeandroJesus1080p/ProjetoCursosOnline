using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivosController : ControllerBase
    {
        private readonly IArquivoRepository _repository;

        public ArquivosController(IArquivoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var procurarArquivos = _repository.GetArquivo();

            return Ok(new
            {
                arquivos = procurarArquivos
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            var procurarId = _repository.GetArquivoById(id);

            return Ok(new
            {
                arquivo = procurarId
            });
        }

        [HttpPost]
        public ActionResult<Arquivos> Post(Arquivos arquivos)
        {
            _repository.InsertArquivo(arquivos);

            return Ok(new
            {
                Post = arquivos
            });
        }

        [HttpPut]
        public async Task<ActionResult<Arquivos>> Put(Arquivos arquivos)
        {
            _repository.UpdateArquivo(arquivos);

            return Ok(new
            {
                Arquivos = arquivos
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _repository.DeleteArquivo(id);

            return Ok(new
            {
                Arquivo = id
            });
        }
    }
}
