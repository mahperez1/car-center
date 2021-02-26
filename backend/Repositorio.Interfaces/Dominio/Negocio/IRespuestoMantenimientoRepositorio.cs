using Entidades.Negocio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio.Negocio
{
    public interface IRespuestoMantenimientoRepositorio : ICrearRepositorio<RepuestoMantenimiento, int>, IConsultarTodoRepositorio<RepuestoMantenimiento>, IConsultarxIdRepositorio<RepuestoMantenimiento, int>
    {
    }
}