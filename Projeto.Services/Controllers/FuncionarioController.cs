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
    public class FuncionarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model,
            [FromServices] IFuncionarioRepository repository,
            [FromServices] IMapper mapper)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var funcionario = mapper.Map<Funcionario>(model);
                    repository.Inserir(funcionario);

                    return Ok("Funcionário cadastrado com sucesso.");
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
        public IActionResult Put(FuncionarioEdicaoModel model,
            [FromServices] IFuncionarioRepository repository,
            [FromServices] IMapper mapper)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var funcionario = mapper.Map<Funcionario>(model);
                    repository.Atualizar(funcionario);

                    return Ok("Funcionário atualizado com sucesso.");
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
            [FromServices] IFuncionarioRepository repository)
        {
            try
            {
                var funcionario = repository.ObterPorId(id);
                repository.Excluir(funcionario);

                return Ok("Funcionário excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IFuncionarioRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var lista = mapper.Map<List<FuncionarioConsultaModel>>
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
            [FromServices] IFuncionarioRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var model = mapper.Map<FuncionarioConsultaModel>
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
