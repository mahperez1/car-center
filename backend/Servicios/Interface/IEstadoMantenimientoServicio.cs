using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Parametrica;
using UoW.Interface;

namespace Servicios.Interface
{
    public interface IEstadoMantenimientoServicio
    {
        Task<List<EstadoMantenimiento>> ConsultarTodo();
    }
}
