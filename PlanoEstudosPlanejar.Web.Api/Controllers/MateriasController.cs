using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using PlanoEstudosPlanejar.Web.Api.Services.MateriaServices;
using PlanoEstudosPlanejar.Web.Api.Services.Repository;

namespace PlanoEstudosPlanejar.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaService _repository;
        public MateriasController(IMateriaService repository)
        {
            _repository = repository; 
        }

        [HttpGet]
        public async Task<ActionResult<Materias>> Get()
        {
            try
            {
                var verMaterias = await _repository.GetAll();

                return Ok(new
                {
                    materias = verMaterias
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Materias>> GetId(int id)
        {
            try
            {
                var materiaId = await _repository.GetOne(id);

                return Ok(new
                {
                    materia = materiaId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Materias>> Post(Materias materias)
        {
            try
            {
                await _repository.Create(materias);

                return Ok(new
                {
                    materia = materias
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Put(Materias materias)
        {
            try
            {
                await _repository.Update(materias);

                return Ok(new
                {
                    materia = materias
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);

                return Ok(new
                {
                    materia = id
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
