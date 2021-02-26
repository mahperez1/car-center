using System;
using System.Collections.Generic;
using System.Text;
using Repositorio.Interfaces.Acciones;
using Entidades.Negocio;
using System.Threading.Tasks;

namespace Repositorio.Interfaces.Dominio.Negocio
{
    public interface IFacturaRepositorio : ICrearRepositorio<Factura, int>, IConsultarTodoRepositorio<Factura>, IConsultarxIdRepositorio<Factura, int>, IActualizarRepositorio<Factura>
    {
    }
}
