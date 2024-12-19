using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var usuarios = _repository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            var userId = _repository.GetUsuarioById(id);

            return Ok(new
            {
                user = userId
            });
        }

        [HttpPost]
        public ActionResult<Usuario> Post(Usuario usuario)
        {
            _repository.InsertUsuario(usuario);
            
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
                _repository.UpdateUsuario(usuario);
                
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
            _repository.DeleteUsuario(id);

            return Ok(new
            {
                user = id
            });
        }

    }
}
