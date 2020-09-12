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
    public class DepartamentoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(DepartamentoCadastroModel model,
            [FromServices] IDepartamentoRepository repository,
            [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var departamento = mapper.Map<Departamento>(model);
                    repository.Inserir(departamento);

                    return Ok("Departamento cadastrado com sucesso.");
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
        public IActionResult Put(DepartamentoEdicaoModel model,
            [FromServices] IDepartamentoRepository repository,
            [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var departamento = mapper.Map<Departamento>(model);
                    repository.Atualizar(departamento);

                    return Ok("Departamento atualizado com sucesso.");
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
            [FromServices] IDepartamentoRepository repository)
        {
            try
            {
                var departamento = repository.ObterPorId(id);
                repository.Excluir(departamento);

                return Ok("Departamento excluído com sucesso.");

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IDepartamentoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var lista = mapper.Map<List<DepartamentoConsultaModel>>
                    (repository.ObterTodos());

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id,
            [FromServices] IDepartamentoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var model = mapper.Map<DepartamentoConsultaModel>
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
