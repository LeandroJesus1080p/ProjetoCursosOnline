using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.ArquivoServices;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivosController : ControllerBase
    {
        private readonly IArquivoService _repository;

        public ArquivosController(IArquivoService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var procurarArquivos = await _repository.GetAll();

                return Ok(new
                {
                    arquivos = procurarArquivos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetId(int id)
        {
            try
            {
                var procurarId = await _repository.GetOne(id);

                return Ok(new
                {
                    arquivo = procurarId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Arquivos>> Post(Arquivos arquivos)
        {
            try
            {
                await _repository.Create(arquivos);

                return Ok(new
                {
                    Post = arquivos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<Arquivos>> Put(Arquivos arquivos)
        {
            try
            {
                await _repository.Update(arquivos);

                return Ok(new
                {
                    Arquivos = arquivos
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);

                return Ok(new
                {
                    Arquivo = id
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
