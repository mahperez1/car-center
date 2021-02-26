using System;
using System.Collections.Generic;
using System.Text;
using UoW.Interface;
using System.Threading.Tasks;
using Entidades.Negocio;

namespace Servicios.Interface
{
    public interface IFacturaServicio
    {
        Task<List<Factura>> consultarTodo();
        Task<bool> crear(Factura model);
    }
}
