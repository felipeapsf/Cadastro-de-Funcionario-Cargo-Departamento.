using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CargoCadastroModel model,
            [FromServices] ICargoRepository repository,
            [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cargo = mapper.Map<Cargo>(model);
                    repository.Inserir(cargo);

                    return Ok("Cargo cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(CargoEdicaoModel model,
            [FromServices] ICargoRepository repository,
            [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cargo = mapper.Map<Cargo>(model);
                    repository.Atualizar(cargo);

                    return Ok("Cargo atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] ICargoRepository repository)
        {
            try
            {
                var cargo = repository.ObterPorId(id);
                repository.Excluir(cargo);

                return Ok("Cargo excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] ICargoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var lista = mapper.Map<List<CargoConsultaModel>>
                    (repository.ObterTodos());

                return Ok(lista);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id,
            [FromServices] ICargoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var model = mapper.Map<CargoConsultaModel>
                    (repository.ObterPorId(id));

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
