using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Negocio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio.Negocio
{
    public interface IMecanicoRepositorio: ICrearRepositorio<Mecanico, string>, IConsultarTodoRepositorio<Mecanico>, IConsultarxIdRepositorio<Mecanico,int>
    {
    }
}
