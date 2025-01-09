using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;
using PlanoEstudosPlanejar.Web.Api.Services.UsuarioServices;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService _repository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var usuarios = await _repository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetId(int id)
        {
            var userId = await _repository.GetOne(id);

            return Ok(new
            {
                user = userId
            });
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            await _repository.Create(usuario);
            
            return Ok(new
            {
                User = usuario
            });
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> Put(Usuario usuario)
        {
            try
            {
                await _repository.Update(usuario);
                
                return Ok(new
                {
                    User = usuario
                });
            }
            catch(Exception ex)
            {
                return NotFound($"Algo deu errado {ex}");
            }
 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            return Ok(new
            {
                user = id
            });
        }

    }
}
