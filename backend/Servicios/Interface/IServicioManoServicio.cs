using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Parametrica;

namespace Servicios.Interface
{
    public interface IServicioManoServicio
    {
        Task<List<ServicioMano>> consultarTodo();
    }
}
