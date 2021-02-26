using Repositorio.Interfaces.Dominio.Negocio;
using Repositorio.Interfaces.Dominio.Parametricas;

namespace UoW.Interface
{
    public interface IUoWRepositorio
    {
        #region "Parametricas"

        IEstadoMantenimientoRepositorio EstadoMantenimientoRepositorio { get; }
        IRepuestoRepositorio RepuestoRepositorio { get; }
        IServicioManoRepositorio ServicioManoRepositorio { get; }
        ITipoDocumentoRepositorio TipoDocumentoRepositorio { get; }

        #endregion "Parametricas"

        #region "Negocio"

        IFacturaRepositorio FacturaRepositorio { get; }
        IMantenimientoRepositorio MantenimientoRepositorio { get; }
        IMecanicoRepositorio MecanicoRepositorio { get; }
        IPersonaRepositorio PersonaRepositorio { get; }
        IRespuestoMantenimientoRepositorio RespuestoMantenimientoRepositorio { get; }

        #endregion "Negocio"


    }
}