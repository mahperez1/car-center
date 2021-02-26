using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Negocio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio.Negocio
{
    public interface IPersonaRepositorio: ICrearRepositorio<Persona, bool>, IConsultarTodoRepositorio<Persona>, IConsultarxIdRepositorio<Persona, int>
    {
    }
}
