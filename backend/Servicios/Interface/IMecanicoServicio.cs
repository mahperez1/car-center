using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entidades.Negocio;

namespace Servicios.Interface
{
    public interface IMecanicoServicio
    {
        Task<List<Mecanico>> consultarTodo();
        Task<bool> crear(Mecanico model);
    }
}
