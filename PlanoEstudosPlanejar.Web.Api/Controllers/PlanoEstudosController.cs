using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.PlanoEstudoServices;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoEstudosController : ControllerBase
    {
        private readonly IPlanoEstudoService _repository;

        public PlanoEstudosController(IPlanoEstudoService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var planos = await _repository.GetAll();
            return Ok(planos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetId(int id)
        {
            var plano = await _repository.GetOne(id);
            return Ok(new
            {
                Plano = plano
            });
        }

        [HttpPost]
        public async Task<ActionResult<PlanoEstudo>> Post(PlanoEstudo plano)
        {
            await _repository.Create(plano);
            return Ok(new
            {
                User = plano
            });
        }

        [HttpPut]
        public async Task<ActionResult<PlanoEstudo>> Put(PlanoEstudo plano)
        {
            await _repository.Update(plano);

            return Ok(new
            {
                Plano = plano
            });
        }

        [HttpDelete]
        public async Task<ActionResult<PlanoEstudo>> Delete(int id)
        {
            await _repository.Delete(id);

            return Ok(new
            {
                Plano = id
            });
        }
    }
}
