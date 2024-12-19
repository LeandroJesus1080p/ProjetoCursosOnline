using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoEstudosController : ControllerBase
    {
        private readonly IPlanoEstudosRepository _repository;

        public PlanoEstudosController(IPlanoEstudosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var planos = _repository.GetPlanoEstudo();
            return Ok(planos);
        }

        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            var plano = _repository.GetPlanoEstudoById(id);
            return Ok(new
            {
                Plano = plano
            });
        }

        [HttpPost]
        public ActionResult<PlanoEstudo> Post(PlanoEstudo plano)
        {
            _repository.InsertPlanoEstudo(plano);
            return Ok(new
            {
                User = plano
            });
        }

        [HttpPut]
        public ActionResult<PlanoEstudo> Put(PlanoEstudo plano)
        {
            _repository.UpdatePlanoEstudo(plano);

            return Ok(new
            {
                Plano = plano
            });
        }

        [HttpDelete]
        public ActionResult<PlanoEstudo> Delete(int id)
        {
            _repository.DeletePlanoEstudo(id);

            return Ok(new
            {
                Plano = id
            });
        }
    }
}
