using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Negocio;
using Entidades.Parametrica;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio.Parametricas
{
    public interface IEstadoMantenimientoRepositorio: IConsultarTodoRepositorio<EstadoMantenimiento>
    {
    }
}
