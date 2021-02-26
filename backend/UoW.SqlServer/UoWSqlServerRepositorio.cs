using Repositorio.Interfaces.Dominio.Negocio;
using Repositorio.Interfaces.Dominio.Parametricas;
using Repositorio.SqlServer.Dominio.Negocio;
using Repositorio.SqlServer.Dominio.Parametrica;
using UoW.Interface;
using System.Data.SqlClient;

namespace UoW.SqlServer
{
    public class UoWSqlServerRepositorio : IUoWRepositorio
    {
        #region "negocio"

        public IFacturaRepositorio FacturaRepositorio { get; }
        public IMantenimientoRepositorio MantenimientoRepositorio { get; }
        public IMecanicoRepositorio MecanicoRepositorio { get; }
        public IPersonaRepositorio PersonaRepositorio { get; }
        public IRespuestoMantenimientoRepositorio RespuestoMantenimientoRepositorio { get; }

        #endregion "negocio"

        #region "parametrica"

        public IEstadoMantenimientoRepositorio EstadoMantenimientoRepositorio { get; }
        public IRepuestoRepositorio RepuestoRepositorio { get; }
        public IServicioManoRepositorio ServicioManoRepositorio { get; }
        public ITipoDocumentoRepositorio TipoDocumentoRepositorio { get; }

        #endregion "Negocio"


        public UoWSqlServerRepositorio(SqlConnection contexto, SqlTransaction transaccion)
        {
            FacturaRepositorio = new FacturaRepositorio(contexto, transaccion);
            MantenimientoRepositorio = new MantenimientoRepositorio(contexto, transaccion);
            MecanicoRepositorio = new MecanicoRepositorio(contexto, transaccion);
            PersonaRepositorio = new PersonaRepositorio(contexto, transaccion);
            RespuestoMantenimientoRepositorio = new RepuestoMantenimientoRepositorio(contexto, transaccion);

            EstadoMantenimientoRepositorio = new EstadoMantenimienoRepositorio(contexto, transaccion);
            RepuestoRepositorio = new RepuestoRepositorio(contexto, transaccion);
            ServicioManoRepositorio = new ServicioManoRepositorio(contexto, transaccion);
            TipoDocumentoRepositorio = new TipoDocumentoRepositorio(contexto, transaccion);

        }
    }
}