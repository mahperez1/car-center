using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Repositorio.Interfaces.Acciones;
using Entidades.Negocio;

namespace Repositorio.Interfaces.Dominio.Negocio
{
    public interface IMantenimientoRepositorio: ICrearRepositorio<Mantenimiento, string>, IConsultarTodoRepositorio<Mantenimiento>, IConsultarxIdRepositorio<Mantenimiento, string>, IActualizarRepositorio<Mantenimiento>
    {
    }
}
