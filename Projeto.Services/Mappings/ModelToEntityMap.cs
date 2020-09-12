using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Mappings
{
    public class ModelToEntityMap : Profile
    {
        //ctor
        public ModelToEntityMap()
        {
            CreateMap<FuncionarioCadastroModel, Funcionario>();
            CreateMap<FuncionarioEdicaoModel, Funcionario>();
            CreateMap<CargoCadastroModel, Cargo>();
            CreateMap<CargoEdicaoModel, Cargo>();
            CreateMap<DepartamentoCadastroModel, Departamento>();
            CreateMap<DepartamentoEdicaoModel, Departamento>();
        }
    }
}
